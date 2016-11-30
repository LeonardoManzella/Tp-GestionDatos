﻿PRINT 'CREANDO FUNCIONES Y PROCEDURES PARA NEGOCIO...'
GO

------------------OBTENER_TODOS_LOS_ROLES------------------
--Proposito: obtiene los roles actuales del sistema
--
--Ingreso: con ID 0 devuelve todos los roles
--
--Egreso: una tabla con la descripcion y el id de los roles
------------------OBTENER_TODOS_LOS_ROLES------------------
CREATE FUNCTION KFC.fun_obtener_roles_usuario(@usuario_id INT)
returns TABLE AS
RETURN
SELECT DISTINCT rol.rol_id
        , rol.descripcion
FROM
          KFC.roles_usuarios AS rol_us
          INNER JOIN
                    KFC.roles AS rol
          ON
                    rol_us.rol_id = rol.rol_id
WHERE
          (
                    @usuario_id     = 0
                    OR rol_us.us_id = @usuario_id
          )
          AND rol.habilitado = 1
;
GO

CREATE FUNCTION KFC.fun_obtener_funcionalidades_usuario(@usuario_id INT, @rol_descripcion VARCHAR(60) )
returns TABLE AS
RETURN
SELECT DISTINCT	 f.descripcion AS fun_descripcion
				, f.func_id
				, r.rol_id
				, r.descripcion AS rol_descripcion 
FROM
          KFC.roles_usuarios AS ru
          INNER JOIN KFC.roles AS r
          ON
                    ru.rol_id = r.rol_id
		  INNER JOIN KFC.funcionalidades_roles fr
		  ON	fr.rol_id = r.rol_id
		  INNER JOIN KFC.funcionalidades f
		  ON	f.func_id = fr.func_id
WHERE
         ru.us_id = @usuario_id
		 AND UPPER(r.descripcion) = UPPER(@rol_descripcion)
;
GO


------------------VALIDAR_USUARIO------------------
--Proposito: verificar el correcto logueo en el sistema
--
--Ingreso: usuario y contraseña
--
--Egreso: el identificador del usuario. Devuelve -1 si no existe el usuario
------------------VALIDAR_USUARIO------------------
CREATE FUNCTION KFC.fun_validar_usuario(@usuario VARCHAR(30),
@contrasenia                                 VARCHAR(30)
, @rol_desc	VARCHAR(50)
)
returns INT AS
BEGIN
          DECLARE @id INT;
          SELECT
                    @id = ISNULL(us.us_id,-1)
          FROM
                    KFC.usuarios us
					INNER JOIN KFC.roles_usuarios ru
					ON	ru.us_id = us.us_id
					INNER JOIN KFC.roles r
					ON ru.rol_id = r.rol_id
          WHERE
                    us.nick           = @usuario
                    AND us.pass       = HASHBYTES('SHA2_256', @contrasenia)
                    AND us.habilitado = 1
					AND UPPER(r.descripcion) = UPPER(@rol_desc)
          ;
          
          RETURN @id;
END;
GO


------------------DESHABILITAR_USUARIO------------------
--Proposito: deshabilita un usuario
--
--Ingreso: el nick del usuario
--
--Egreso: -
------------------DESHABILITAR_USUARIO------------------
CREATE PROCEDURE kfc.pro_deshabilitar_usuario
          @usu_nick VARCHAR(30)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		UPDATE kfc.usuarios SET habilitado = 0 WHERE nick = @usu_nick;
                    
		COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO


------------------HABILITAR_ROL------------------
--Proposito: Habilitar un rol, para que sea útil en el sistema
--
--Ingreso: el identificador del rol
--
--Egreso: -
------------------HABILITAR_ROL------------------
CREATE PROCEDURE kfc.pro_habilitar_rol
          @rol_id INT
AS
BEGIN
	BEGIN TRY
			BEGIN TRANSACTION
			UPDATE kfc.roles SET habilitado = 1 WHERE rol_id = @rol_id;
                    
			COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO

------------------DESHABILITAR_ROL------------------
--Proposito: Deshabilitar un rol, para que sea inútil en el sistema
--
--Ingreso: el identificador del rol
--
--Egreso: -
------------------DESHABILITAR_ROL------------------
CREATE PROCEDURE kfc.pro_deshabilitar_rol
          @rol_id INT
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION
        UPDATE kfc.roles SET habilitado = 0 WHERE rol_id = @rol_id;
                    
        COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO

------------------AUMENTAR_INTENTOS------------------
--Proposito: Actualizar la cantidad de errores al loguear con un usuario
--
--Ingreso: el nick del usuario
--
--Egreso: -
------------------AUMENTAR_INTENTOS------------------
CREATE PROCEDURE kfc.pro_aumentar_intentos
          @usu_nick VARCHAR(30)
AS
BEGIN
	DECLARE @string VARCHAR(60);

	--Solo veo de aumentar intentos si existe el usuario, sino no puedo hacer nada
	IF NOT EXISTS( SELECT * FROM KFC.usuarios u WHERE u.nick = @usu_nick)
	BEGIN
		SET @string = 'No existe el Usuario: ' + @usu_nick;
		RAISERROR(@string, 16, 1);
		RETURN;
	END

	--Veo si el Usuario NO esta Habilitado para dar error. No tiene sentido aumentar intentos usuario inhabilitado
	IF NOT EXISTS( SELECT * FROM KFC.usuarios u WHERE u.nick = @usu_nick AND u.habilitado = 1 )
	BEGIN
		SET @string = 'El Usuario ' + @usu_nick + ' esta Deshabilitado';
		RAISERROR(@string, 16, 1);
		RETURN;
	END

	BEGIN TRY
		BEGIN TRANSACTION
		UPDATE kfc.usuarios SET intentos = intentos +1 WHERE nick = @usu_nick;

		--Al 3er Intento Mal lo Deshabilito al Usuario
		IF (	(	SELECT TOP 1 u.intentos 
					FROM KFC.usuarios u 
					WHERE UPPER(u.nick) = UPPER(@usu_nick)
				) = 3)
		BEGIN
			EXECUTE KFC.pro_deshabilitar_usuario @usu_nick;
		END
                    
		COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO


------------------REINICIAR_INTENTOS------------------
--Proposito: Reiniciar la cantidad de errores al loguear con un usuario
--
--Ingreso: el nick del usuario
--
--Egreso: -
------------------REINICIAR_INTENTOS------------------
CREATE PROCEDURE kfc.pro_reiniciar_intentos
          @usu_nick VARCHAR(30)
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION
        UPDATE kfc.usuarios SET intentos = 0 WHERE nick = @usu_nick;
                    
        COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO

------------------OBTENER_TODAS_LAS_FUNCIONALIDADES------------------
--Proposito: Saber que funciones hay en el sistema
--
--Ingreso: -
--
--Egreso: una tabla con todas las funcionalidades del sistema
------------------OBTENER_TODAS_LAS_FUNCIONALIDADES------------------
CREATE FUNCTION kfc.fun_obtener_todas_las_funcionalidades()
returns TABLE AS
RETURN
SELECT fun.func_id, fun.descripcion FROM kfc.funcionalidades fun;
GO

------------------VERIFICAR_FUNCION_ROL------------------
--Proposito: Revisa que un rol tenga determinada funcionalidad
--
--Ingreso: -
--
--Egreso: 1 = la tiene, 0 = no la tiene
------------------VERIFICAR_FUNCION_ROL------------------
CREATE PROCEDURE kfc.pro_verificar_funcion_rol( @id_func INT,
@id_rol                                              INT)
AS
          BEGIN
                    SELECT
                              1
                    FROM
                              kfc.funcionalidades_roles fr
                    WHERE
                              fr.func_id    = @id_func
                              AND fr.rol_id = @id_rol
                    ;
                    
                    DECLARE @encontrado BIT
                    IF @@rowcount = 0
						BEGIN
								  SET @encontrado = 0
						END
                    ELSE
						BEGIN
								  SET @encontrado = 1
						END
                    RETURN (@encontrado)
          END;
GO


------------------OBTENER_PLANES_AFILIADO------------------
--Proposito: Saber que planes posee un afiliado
--
--Ingreso: identificador del afiliado
--
--Egreso: una tabla con todos los planes que actualmente posee el afiliado,
--			el nombre del afiliado y del titular del beneficio
------------------OBTENER_PLANES_AFILIADO------------------
CREATE FUNCTION kfc.fun_obtener_planes_afiliado( @afiliado_id INT)
returns TABLE
RETURN
(
          SELECT
                    afi.afil_id
                  , concat(afi.apellido,', ', afi.nombre) AS paciente
                  , concat(tit.apellido,', ', tit.nombre) AS titular
                  , pl.plan_id
                  , pl.descripcion
          FROM
                    kfc.afiliados afi
                    INNER JOIN
                              kfc.afiliados tit
                    ON
                              ROUND(afi.afil_id / 100, 0, 1)* 100 + 1 = tit.afil_id			-- Lo que hace es considerar unicamente los Afiliados Originales (no conyuge ni hijos). Para hacerlo redondea el numero de afiliado para "truncarle" los ultimos 2 digitos, luego lo multiplica por cien para restablecer el numero original con 00 ultimos 2 digitos (numero familiar), por eso le suma 1
                    INNER JOIN
                              kfc.planes pl
                    ON
                              pl.plan_id = tit.plan_id
          WHERE
                    afi.habilitado  = 1
                    AND afi.afil_id = @afiliado_id);
GO

-------------------------------------

--------------------------------------
CREATE FUNCTION kfc.fun_obtener_todos_los_planes()
returns TABLE
RETURN
( SELECT pl.plan_id, pl.descripcion FROM kfc.planes pl);
GO

--Obtiene los datos no importa si es profesional o afiliado
CREATE FUNCTION kfc.fun_obtener_datos_usuario(@usuario_id INT)
returns @retorno TABLE( nombre VARCHAR, apellido VARCHAR ) AS
BEGIN

	INSERT INTO	@retorno VALUES ( '', '' )
	
	/* LEO: tengo que arreglarlo esto. no se porque devuelve vacio
	--Veo si hay Algun Profesional, sino voy a buscar Afiliados
	IF EXISTS	( SELECT * FROM KFC.profesionales p WHERE p.us_id = 121 )
	BEGIN
		INSERT INTO	@retorno
		SELECT TOP 1 p.nombre, p.apellido--, p.prof_id 
		FROM KFC.profesionales p 
		WHERE p.us_id = 121
	END

	--Ahora voy a ver Afiliados
	ELSE 
	BEGIN
		IF	EXISTS	( SELECT * FROM KFC.afiliados a WHERE a.us_id = 121 )
		BEGIN
			INSERT INTO	@retorno
			SELECT TOP 1 a.nombre, a.apellido--, a.afil_id 
			FROM KFC.afiliados a 
			WHERE a.us_id = 121
		END
	

		--Si no es ninguno, lleno con Vacio
		ELSE
		BEGIN
			INSERT INTO	@retorno
			VALUES ( '', '' )
		END
	END
	*/
	
		
	RETURN; 
END
GO


------------------------------------------

------------------------------------------
create procedure kfc.get_afiliado @id_afiliado int
as
select * from kfc.afiliados a
where a.afil_id = @id_afiliado;
go


------------------OBTENER_ESPECIALIDADES------------------
--Proposito: Saber que especialidades posee un profesional
--
--Ingreso: un identificador de profesional
--
--Egreso: una tabla con todas las especialidades que posee el profesional
------------------OBTENER_ESPECIALIDADES------------------
CREATE FUNCTION kfc.fun_obtener_especialidades_prof(@id_profesional INT)
returns TABLE
RETURN
SELECT
          esp.espe_id
        , esp.descripcion
FROM
          kfc.especialidades_profesional ep
          INNER JOIN
                    kfc.especialidades esp
          ON
                    ep.espe_id= esp.espe_id
WHERE
          (
                    @id_profesional = 0
                    OR ep.prof_id   = @id_profesional
          )
;

GO


CREATE FUNCTION kfc.fun_obtener_especialidades()
returns TABLE
RETURN
SELECT
          esp.espe_id
        , esp.descripcion
FROM
          kfc.especialidades esp
;

GO

------------------OBTENER_PROFESIONALES_POR_ESPECIALIDAD------------------
--Proposito: Saber que profesionales poseen una especialidad
--
--Ingreso: una descripcion de especialidad
--
--Egreso: una tabla con todas los profesionales que poseen esa especialidad
------------------OBTENER_PROFESIONALES_POR_ESPECIALIDAD------------------
CREATE FUNCTION kfc.fun_obtener_profesionales_por_especialidad (@desc_esp VARCHAR(50) )
returns TABLE
RETURN
SELECT
          prof.prof_id
        , concat(prof.apellido,',',prof.nombre) AS profesional
FROM
		kfc.especialidades_profesional ep
		INNER JOIN
				kfc.profesionales prof
		ON
				ep.prof_id= prof.prof_id
		INNER JOIN	KFC.especialidades es
		ON	es.espe_id = ep.espe_id
WHERE es.descripcion = @desc_esp
;
GO


------------------ELIMINAR_ROL_USUARIO------------------
--Proposito: Quitar rol inhabilitados a los usuarios
--
--Ingreso: un identificador de rol inhabilitado
--
--Egreso: -
------------------ELIMINAR_ROL_USUARIO------------------
CREATE PROCEDURE kfc.pro_eliminar_rol_usuario
          @rol_id INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			DELETE
			FROM
						kfc.roles_usuarios
			WHERE
						rol_id    = @rol_id
						--Estado este Deshabilitado
						AND 0 = 
								(
								SELECT TOP 1	r.habilitado
								FROM	KFC.roles r
								WHERE	r.rol_id = @rol_id
								)
			;
		COMMIT
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO


CREATE PROCEDURE kfc.pro_setear_rol_estado_habilitacion
          @rol_id INT,
		  @estado INT
AS
BEGIN
	BEGIN TRY
			IF (@estado!=0 AND @estado!=1)
				RAISERROR('Estado Invalido para Setear Estado Habilitacion Rol',16,1);

			BEGIN TRANSACTION
			UPDATE kfc.roles SET habilitado = @estado WHERE rol_id = @rol_id;
            --Si yo Queria Deshabilitar, quito Rol a los Usuarios (lo pide el enunciado)
			IF (@estado=0)
				EXECUTE kfc.pro_eliminar_rol_usuario @rol_id;
			       
			COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO

CREATE FUNCTION KFC.fun_obtener_id_especialidad(@desc_esp VARCHAR(50) )
RETURNS INT AS
BEGIN
	DECLARE @id INT;
	SET @id = 0;

	SELECT TOP 1	@id = espe_id
	FROM	KFC.especialidades
	WHERE	UPPER(descripcion) = UPPER(@desc_esp)

	return	@id
END;
GO


CREATE FUNCTION KFC.fun_obtener_id_profesional(@nombre VARCHAR(60), @apellido VARCHAR(60)  )
RETURNS INT AS
BEGIN
	DECLARE @id INT;
	SET @id = 0;

	SELECT TOP 1	@id = prof_id
	FROM	KFC.profesionales
	WHERE	UPPER(nombre) = UPPER(@nombre)
	AND		UPPER(apellido) = UPPER(@apellido)

	return	@id
END;
GO

CREATE FUNCTION KFC.fun_obtener_id_profesional_x_user_id(@us_id INT)
RETURNS INT AS
BEGIN
	DECLARE @id INT;
	SET @id = 0;

	SELECT TOP 1	@id = prof_id
	FROM	KFC.profesionales
	WHERE	us_id = @us_id

	return	@id
END;
GO

------------------OBTENER_TURNOS_DEL_DIA------------------
--Proposito: Obtener los turnos "ocupados" de un dia
--
--Ingreso: un identificador de profesional, otro de especialidad y un día
--
--Egreso: una tabla con la fecha, hora, paciente, doctor y especialidad
------------------OBTENER_TURNOS_DEL_DIA------------------
CREATE FUNCTION KFC.fun_obtener_turnos_del_dia (@especialidad INT,
												@profesional  INT,
												@fecha		   DATE)
returns TABLE
RETURN
(
          SELECT
                    CONVERT (DATE,t.fecha_hora)        AS fecha
                  , CONVERT (TIME,t.hora)              AS hora
                  , CONCAT(a.apellido, ', ', a.nombre) AS paciente
                  , CONCAT(a.apellido, ', ', a.nombre) AS doctor
                  , esp.descripcion                    AS especialidad
          FROM
                    KFC.turnos t
                    INNER JOIN
                              kfc.afiliados a
                    ON
                              t.afil_id = a.afil_id
                    INNER JOIN
                              kfc.profesionales pr
                    ON
                              pr.prof_id = t.prof_id
                    INNER JOIN
                              kfc.especialidades esp
                    ON
                              esp.espe_id = t.espe_id
			WHERE	t.prof_id = @especialidad
			AND		t.espe_id  = @profesional
			AND		CONVERT (DATE, t.fecha_hora) = @fecha
)
GO



------------------OBTENER_BONOS_AFILIADO------------------
--Proposito: Obtener los turnos "ocupados" de un dia
--
--Ingreso: un identificador de profesional, otro de especialidad y un día
--
--Egreso: una tabla con la fecha, hora, paciente, doctor y especialidad
------------------OBTENER_BONOS_AFILIADO------------------
CREATE FUNCTION KFC.fun_obtener_bonos_afiliado(@afiliado_id INT)
returns TABLE
RETURN
(
          SELECT
                    b.bono_id
                  , b.plan_id
          FROM
                    kfc.bonos b
          WHERE
                    b.afil_id       = @afiliado_id
                    AND b.consumido = 0
);
GO


--Funcionalidad REGISTRO DE RESULTADO DE ATENCION MEDICA. Devuelve el 'Id Afilidado' (con el Id despues consulto turnos en otra función).
CREATE FUNCTION KFC.fun_retornar_id_afildo_por_id(@nombre VARCHAR(255), @apellido VARCHAR(255), @us_id INT)
returns INT AS
BEGIN
          DECLARE @Afil_id INT;
          SELECT TOP 1
                    @Afil_id = ISNULL(Afil_id,0)
          FROM
                    KFC.afiliados Afi
          WHERE
                    Afi.nombre         = UPPER(@nombre)
                    AND Afi.apellido   = UPPER(@apellido)
					AND Afi.us_id 	   = @us_id
                    AND Afi.habilitado = 1
          ;
          
          RETURN @Afil_id;
END;
GO


CREATE FUNCTION KFC.fun_retornar_id_afildo_por_doc(@nombre VARCHAR(255), @apellido VARCHAR(255), @documento NUMERIC(18,0))
returns INT AS
BEGIN
          DECLARE @Afil_id INT;
          SELECT TOP 1
                    @Afil_id = ISNULL(Afil_id,0)
          FROM
                    KFC.afiliados Afi
          WHERE
                    Afi.nombre         = UPPER(@nombre)
                    AND Afi.apellido   = UPPER(@apellido)
					AND Afi.numero_doc = @documento
                    AND Afi.habilitado = 1
          ;
          
          RETURN @Afil_id;
END;
GO

--Funcionalidad REGISTRO DE RESULTADO DE ATENCION MEDICA. Devuelve el 'Id Afilidado' (con el Id despues consulto turnos en otra función).
CREATE FUNCTION KFC.fun_retornar_id_afildo(@nombre VARCHAR(255), @apellido VARCHAR(255), @dni INT)
returns INT AS
BEGIN
          DECLARE @Afil_id INT;
          SELECT TOP 1
                    @Afil_id = ISNULL(Afil_id,0)
          FROM
                    KFC.afiliados Afi
          WHERE
                    Afi.nombre         = UPPER(@nombre)
                    AND Afi.apellido   = UPPER(@apellido)
					--AND Afi.us_id 	   = @us_id
                    AND Afi.habilitado = 1
          ;
          
          RETURN @Afil_id;
END;
GO

--Funcionalidad REGISTRO DE RESULTADO DE ATENCION MEDICA. Devuelve los 'Turnos' del afiliado con un profesional.	
CREATE FUNCTION KFC.fun_devolver_turnos_prof_afildo(@Afil_id INT,@Prof_id INT)
returns TABLE AS
RETURN
(
          SELECT
                    turno_id
                  , fecha_hora
                  , hora
          FROM
                    KFC.turnos
          WHERE
                    afil_id     = @Afil_id
                    AND prof_id = @Prof_id 
);
GO

--Funcionalidad REGISTRO DE RESULTADO DE ATENCION MEDICA. Graba los 'Sintomas/Diagnostico' de la atención.	
CREATE PROCEDURE KFC.pro_grabar_resultado_atencion
          @turno_id INT
          ,
          @sintomas VARCHAR(255)
          ,
          @diagnostico VARCHAR(255)
		  ,
		  @hora_llegada DATETIME
AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION
        UPDATE
                    kfc.atenciones
        SET       sintomas    = @sintomas
                , diagnostico = @diagnostico
				, hora_llegada = @hora_llegada
        WHERE
                    turno_id = @turno_id
        COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO


--Funcionalidad COMPRAR BONOS. Devuelve precio del 'bono consulta' (del mismo plan que tiene el afiliado).
CREATE FUNCTION KFC.fun_devolver_precio_bono(@afiliado_id INT)
returns INT AS
BEGIN
          DECLARE @precio INT;
          SET @precio = 0;
          SELECT
                    @precio = p.precio_bono_consulta
          FROM
                    KFC.afiliados a
                    INNER JOIN
                              KFC.planes p
                    ON
                              a.plan_id = p.plan_id
          WHERE
                    a.afil_id = @afiliado_id
          RETURN @precio;
END;
GO

--Funcionalidad COMPRAR BONOS. Crea 'Bono' comprado por el afiliado (bono del mismo plan que tiene el afiliado).
CREATE PROCEDURE KFC.pro_comprar_bono(@afiliado_id INT, @fecha_formato_string VARCHAR(30) )
AS
BEGIN
	DECLARE @PlanUsuario INT;
	DECLARE @fecha DATETIME;
		
	SET @fecha = CONVERT(DATETIME, @fecha_formato_string, 102);

	SELECT @PlanUsuario = Plan_id
	FROM   KFC.Afiliados
	WHERE  afil_id = @afiliado_id;

	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO KFC.bonos(plan_id,afil_id,fecha_compra) VALUES (@PlanUsuario,@afiliado_id, @fecha);
		COMMIT;
	END TRY
	BEGIN CATCH
                IF @@trancount > 0
                ROLLBACK TRANSACTION;

				PRINT 'Bono No Ingresado. Fecha ' + CONVERT(varchar,@fecha,102)
                ;THROW
    END CATCH
END;
GO

/*
--Funcionalidad COMPRAR BONOS. Devuelve 'Id Afilaido' y su 'Nombre' para el caso de que administrativo realiza la compra de bonos en nombre de un afiliado.
CREATE function KFC.fun_devolver_afiliado_y_su_nombre(@Usuario_id INT)
returns table AS
return ( 
Select afil_id, nombre, apellido
from KFC.afiliados
where us_id = @Usuario_id );
go
*/

--Funcionalidad ABM AFILIADOS. Devuelve los 'Afiliado' completo con todos los datos.	
CREATE FUNCTION KFC.fun_devolver_afiliado(@mail VARCHAR(255))
returns TABLE AS
RETURN
(
          SELECT
			afil_id,
			nombre,
			apellido,
			tipo_doc,
			numero_doc,
			direccion,
			telefono,
			mail,
			sexo,
			fecha_nacimiento,
			estado_id,
			habilitado,
			personas_a_car,
			plan_id,
			us_id
          
		  FROM
                    KFC.afiliados
          WHERE
                    mail = @mail
);

GO

--Funcionalidad ABM AFILIADOS. modifica 'Afiliado' completo con todos los datos.	
CREATE PROCEDURE KFC.pro_modificar_afiliado(	@afiliado_id INT,
											@nombre                                              VARCHAR(255),
											@apellido                                            VARCHAR(255),
											@tipo_doc                                            VARCHAR(255),
											@numero_doc                                          NUMERIC(18,0),
											@direccion                                           VARCHAR(255),
											@telefono                                            NUMERIC(18,0),
											@mail                                                VARCHAR(255),
											@sexo                                                CHAR(1),
											@fecha_nacimiento                                    DATETIME,
											@estado_id                                           INT,
											@habilitado                                          BIT,
											@personas_a_car                                      INT,
											@plan_id                                             INT,
											@us_id                                               INT
										)
AS
BEGIN
	BEGIN TRY		 
		BEGIN TRANSACTION
		UPDATE
          kfc.afiliados
		SET       nombre           = @nombre
				, apellido         = @apellido
				, tipo_doc         = @tipo_doc
				, numero_doc       = @numero_doc
				, direccion        = @direccion
				, telefono         = @telefono
				, mail             = @mail
				, sexo             = @sexo
				, fecha_nacimiento = @fecha_nacimiento
				, estado_id        = @estado_id
				, habilitado       = @habilitado
				, personas_a_car   = @personas_a_car
				, plan_id          = @plan_id
				, us_id            = @us_id
		WHERE
				  afil_id = @afiliado_id

		if @@ROWCOUNT = 0
			BEGIN
				ROLLBACK TRANSACTION;
				RAISERROR ('Afiliado inexistente',16,1);
				RETURN;
			END;

		COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			;THROW
	END CATCH
END;
GO

--Funcionalidad ABM ROLES. Crea 'Rol'
CREATE PROCEDURE KFC.pro_crear_rol(@descripcion VARCHAR(255), @id int OUTPUT)
AS
    BEGIN

		DECLARE @Habilitado BIT;
		
		SET @Habilitado = 1;

		BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO KFC.roles(descripcion, habilitado) VALUES (@descripcion, @Habilitado)
			COMMIT;

			SELECT TOP 1 @id = rol_id
			FROM	KFC.roles 
			WHERE	descripcion = @descripcion
		END TRY
		BEGIN CATCH
                    IF @@trancount > 0
                    ROLLBACK TRANSACTION;

					PRINT 'Rol No Ingresado'
                    ;THROW
        END CATCH
    END;
GO

--Funcionalidad ABM ROLES. Retorna todos los 'Roles', para luego elegir uno e ir asignandole funcionalidades
CREATE FUNCTION kfc.fun_obtener_todas_los_roles()
returns TABLE AS
RETURN
SELECT r.rol_id, r.descripcion, r.habilitado
FROM kfc.roles r;

GO

CREATE FUNCTION KFC.fun_retornar_id_funcionalidad(@func_desc VARCHAR(60))
returns INT AS
BEGIN
			DECLARE @func_id INT;
			SET @func_id = 0;

			SELECT	@func_id = f.func_id
			FROM	KFC.funcionalidades f
			WHERE	UPPER(f.descripcion) = UPPER(@func_desc)

			/*
			IF (@func_id <= 0)
				BEGIN
				DECLARE @string VARCHAR(100);
				SET @string = 'No existe una Funcionalidad con el nombre' + @func_desc
				RAISERROR(@string,16,1);
				END
			*/
          
          RETURN @func_id;
END;
GO

CREATE FUNCTION KFC.fun_retornar_id_rol(@rol_nombre VARCHAR(60))
returns INT AS
BEGIN
			DECLARE @rol_id INT;
			SET @rol_id = -1;

			SELECT	@rol_id = r.rol_id
			FROM	KFC.roles r
			WHERE	UPPER(r.descripcion) = UPPER(@rol_nombre)

			/*
			IF (@@rol_id <= 0)
				BEGIN
				DECLARE @string VARCHAR(100);
				SET @string = 'No existe un Rol con el nombre' + @@rol_nombre
				RAISERROR(@string,16,1);
				END
			*/
          
          RETURN @rol_id;
END;
GO


------------------OBTENER_FUNCION_ROL------------------
--Proposito: Saber que funciones puede realizar un determinado rol
--
--Ingreso: el identificador del rol
--
--Egreso: una tabla con las funciones de ese rol
------------------OBTENER_FUNCION_ROL------------------
CREATE FUNCTION kfc.fun_obtener_funcion_rol( @id_rol INT)
returns TABLE AS
RETURN
SELECT
          fr.func_id
        , fun.descripcion
FROM
          kfc.funcionalidades_roles fr
          INNER JOIN
                    kfc.funcionalidades fun
          ON
                    fr.func_id = fun.func_id
WHERE
          fr.rol_id = @id_rol
;
GO

CREATE FUNCTION kfc.fun_obtener_habilitacion_rol( @id_rol INT)
returns BIT AS
BEGIN
			DECLARE @rol_habilit BIT;
			SET @rol_habilit = 0;

			SELECT	@rol_habilit = r.habilitado
			FROM	KFC.roles r
			WHERE	r.rol_id = @id_rol
          
          RETURN @rol_habilit;
END;
GO


--Funcionalidad ABM ROLES. Asigna una 'Funcionalidad' a un rol
CREATE PROCEDURE KFC.pro_crear_funcionalidad_de_rol(@func_desc VARCHAR(60) , @rol_id INT)
AS
BEGIN

	DECLARE @func_id INT;
	SELECT @func_id = KFC.fun_retornar_id_funcionalidad(@func_desc);

	SELECT * FROM KFC.funcionalidades_roles
	where rol_id = @rol_id
	and func_id = @func_id;

	IF (@@rowcount = 0)
	BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO KFC.funcionalidades_roles(func_id,rol_id) VALUES (@func_id, @rol_id)
			COMMIT;
	END TRY
	BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;

			PRINT 'Funcionalidad_Rol No Ingresada';
			;THROW
	END CATCH
END;
GO

--Funcionalidad ABM ROLES. Quita una 'Funcionalidad' a un rol
CREATE PROCEDURE KFC.pro_quitar_funcionalidad_de_rol(@func_desc VARCHAR(60), @rol_id INT)
AS
BEGIN

	DECLARE @func_id INT;
	SELECT @func_id = KFC.fun_retornar_id_funcionalidad(@func_desc);

	SELECT	@func_id = f.func_id
	FROM	KFC.funcionalidades f
	WHERE	f.descripcion = @func_desc

	SELECT * FROM KFC.funcionalidades_roles
	where rol_id = @rol_id
	and func_id = @func_id;

	IF @@rowcount != 0
		BEGIN TRY	
				BEGIN TRANSACTION
					DELETE
					FROM KFC.funcionalidades_roles
					WHERE func_id = @func_id and rol_id = @rol_id;
				COMMIT;
		END TRY
		BEGIN CATCH
				IF @@trancount > 0
				ROLLBACK TRANSACTION;
				;THROW
		END CATCH
	ELSE
		RAISERROR('No existe Funcionalidad_Rol',16,1);
END;
GO

--Funcionalidad ABM ROLES. Baja lógica de un 'Rol' y quita rol a usuarios que lo tengan.
CREATE PROCEDURE KFC.pro_baja_logica_rol(@rol_id INT)
AS
    BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				UPDATE kfc.roles SET habilitado = 0 WHERE rol_id = @rol_id;
				if @@ROWCOUNT = 0
					BEGIN
						PRINT 'No se pudo dar de baja rol';
						RETURN;
					END;
				else
					DELETE
					FROM KFC.roles_usuarios
					WHERE rol_id = @rol_id;
			COMMIT;
		END TRY
		BEGIN CATCH
                    IF @@trancount > 0
                    ROLLBACK TRANSACTION;
                    ;THROW
        END CATCH
    END;

GO
	


------------------DESHABILITAR_ROL_USUARIOS------------------
--Proposito: Dado el ID de un rol, quitarselo a los usuarios que lo contengan y luego deshabilitarlo
--
--Ingreso: id de rol a deshabilitar
------------------DESHABILITAR_ROL_USUARIOS------------------
CREATE PROCEDURE KFC.pro_deshabilitar_rol_usuarios
          @id_rol INT
AS
    BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				DELETE 
				FROM KFC.roles_usuarios
				WHERE rol_id = @id_rol
                
				 EXECUTE pro_deshabilitar_rol @id_rol
			COMMIT;
		END TRY
		BEGIN CATCH
                    IF @@trancount > 0
                    ROLLBACK TRANSACTION;
                    ;THROW
        END CATCH
    END;
GO

------------------OBTENER_TURNOS_PROFESIONAL------------------
--Proposito: Consultar los horarios disponibles para un profesional en un determinado dia (horarios dentro de rango definido para ese dia y que no estan ocupados)
--
--Ingreso: id del profesional a consultar horarios y la fecha (formato Año-Mes-Dia) del dia donde quiere ver que horarios hay disponibles 
--Egreso:	Una Tabla de unica columna Horarios disponibles (formato Varchar) (multiples filas cada una con un horario disponible). Necesito que sera Varchar para evitar problemas de conversion contra la aplicacion
------------------OBTENER_TURNOS_PROFESIONAL------------------
--CREATE FUNCTION KFC.fun_obtener_turnos_profesional( @prof_nombre VARCHAR(60), @prof_apellido VARCHAR(60), @fecha_text VARCHAR(60) )

CREATE FUNCTION KFC.fun_obtener_turnos_profesional( @prof_nombre VARCHAR(60), @prof_apellido VARCHAR(60), @fecha DATE )
returns @retorno TABLE (horario_disponible VARCHAR(60)) AS
--Uso la Variable "@retorno" tipo Tabla para generar los Horarios Disponibles en base al Rango de Horarios Posibles
BEGIN
	DECLARE @hora_desde TIME
	DECLARE	@hora_hasta	TIME
	--DECLARE	@fecha DATE
	--SET @fecha = CONVERT(DATE,@fecha_text,102)
	
	--Me traigo el Rango de Horarios Posibles
	SELECT @hora_desde = hora_desde, @hora_hasta = hora_hasta
	FROM	KFC.agenda
	WHERE	DATEPART(WEEKDAY, @fecha) = dia
	--Convierto para que solo compare por Año-Mes-Dia
	AND		CONVERT(DATE,fecha_desde) <= @fecha
	AND		CONVERT(DATE,fecha_hasta) >= @fecha
	AND		prof_id = kfc.fun_obtener_id_profesional(@prof_nombre, @prof_apellido)
	

	--Inserto Horarios Disponibles, cada 30 minutos (Uso el While para Crear un FOR)
	WHILE ( DATEDIFF(MINUTE, @hora_desde, @hora_hasta) != 0 )
	BEGIN
		--PRINT DATEDIFF(MINUTE, @hora_desde, @hora_hasta)
		INSERT INTO @retorno VALUES ( CONVERT(varchar,@hora_desde, 108) )
		SET @hora_desde = DATEADD(MINUTE, 30, @hora_desde)
	END

	
	--Quito Horarios ya Tomados por Turnos y Retorno
	DELETE
	FROM	@retorno
	-- Debo convertirlos sino no me deja comparar con el IN
	WHERE	horario_disponible  IN	(
															SELECT	CONVERT(varchar,hora, 108) AS hora_ocupada
															FROM	KFC.turnos
															-- Debo convertirlos para solo comparar la fecha, no la hora incluida
															WHERE	CONVERT(DATE,fecha_hora) = CONVERT(DATE,@fecha)
															)
	RETURN	
END;
GO


------------------ASIGNAR_TURNO------------------
--Proposito: Asigna un Turno al Usuario y Profesional para una especialidad
--
--Ingreso: Datos necesarios para Crear un Nuevo Turno
------------------ASIGNAR_TURNO------------------
CREATE PROCEDURE KFC.pro_asignar_turno
          @fecha DATETIME
		, @hora	   VARCHAR(60)	--Hora del Turno, en Formato Varchar Para evitar problemas
		, @afil_id    INT
		, @espe_desc  VARCHAR(60)
		, @prof_nombre VARCHAR(60) 
		, @prof_apellido VARCHAR(60)
AS
    BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				DECLARE @horaConvertida TIME(0);
				DECLARE @espe_id INT;
				DECLARE @prof_id INT;

				SET @horaConvertida = CONVERT(TIME(0),@hora, 108);

				SET @espe_id = KFC.fun_obtener_id_especialidad(@espe_desc);
				SET @prof_id = KFC.fun_obtener_id_profesional(@prof_nombre, @prof_apellido)


				INSERT INTO KFC.turnos(fecha_hora,hora,afil_id,espe_id,prof_id) VALUES (@fecha, @horaConvertida, @afil_id, @espe_id, @prof_id)
			COMMIT;
		END TRY
		BEGIN CATCH
                    IF @@trancount > 0
                    ROLLBACK TRANSACTION;

					PRINT 'Turno No Ingresado. Fecha ' + CONVERT(varchar,@fecha,102)
                    ;THROW
        END CATCH
    END;
GO

------------------CANCELAR_TURNO------------------
--Proposito: Cancelar el turno de un afiliado
--
--Ingreso: datos necesarios para cancelar un turno
------------------CANCELAR_TURNO------------------
CREATE PROCEDURE KFC.pro_cancelar_turno
          @fecha DATETIME
		, @hora	   VARCHAR(60)
		, @espe_desc  VARCHAR(60)
		, @prof_nombre VARCHAR(60) 
		, @prof_apellido VARCHAR(60)
		, @tipo VARCHAR(15)
		, @motivo VARCHAR(255)
		, @fecha_formato_string VARCHAR(30)
AS
    BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				DECLARE @horaConvertida TIME(0);
				DECLARE @espe_id INT;
				DECLARE @prof_id INT;
				DECLARE @turno_id INT;
				DECLARE @fecha_actual DATETIME;
				SET @fecha_actual = CONVERT(DATETIME, @fecha_formato_string, 102);

				SET @horaConvertida = CONVERT(TIME(0),@hora, 108);
				SET @espe_id = KFC.fun_obtener_id_especialidad(@espe_desc);
				SET @prof_id = KFC.fun_obtener_id_profesional(@prof_nombre, @prof_apellido)
				SET @turno_id = (SELECT turno_id FROM KFC.turnos WHERE espe_id = @espe_id AND prof_id = @prof_id AND fecha_hora = @fecha + CAST(@horaConvertida as DATETIME))

				INSERT INTO KFC.cancelaciones
				SELECT @turno_id, @motivo, @fecha_actual, CASE WHEN @tipo = 'USUARIO' THEN 1 ELSE 2 END

			COMMIT;
		END TRY
		BEGIN CATCH
                    IF @@trancount > 0
                    ROLLBACK TRANSACTION;

					PRINT 'Turno no cancelado. Fecha ' + CONVERT(varchar,@fecha,102)
                    ;THROW
        END CATCH
    END;
GO

------------------OBTENER TURNOS CANCELABLES------------------
--Proposito: Busca los turnos de un afiliado que todavía pueden ser canceladas
--
--Ingreso: El ID del afiliado
------------------OBTENER TURNOS CANCELABLES------------------
CREATE FUNCTION kfc.fun_obtener_turnos_cancelables( @afil_id INT, @fecha_formato_string VARCHAR(30))
RETURNS TABLE AS
RETURN
SELECT
	CONCAT(P.apellido,', ', P.nombre) profesional,
	CONCAT(DAY(T.fecha_hora), '/', MONTH(T.fecha_hora), '/', YEAR(T.fecha_hora)) fecha,
	T.hora hora,
	E.descripcion
FROM
	KFC.turnos T
FULL OUTER JOIN 
	KFC.cancelaciones C
	ON C.turno_id = T.turno_id
INNER JOIN
	KFC.profesionales P
	ON P.prof_id = T.prof_id
INNER JOIN
	KFC.especialidades E
	ON E.espe_id = T.espe_id
WHERE T.afil_id = @afil_id
AND (T.turno_id IS NULL OR C.turno_id IS NULL)
AND DATEDIFF(day, CONVERT(DATETIME, @fecha_formato_string, 102), t.fecha_hora) >= 1;
GO

PRINT 'CREADAS FUNCIONES Y PROCEDURES DE NEGOCIO'
PRINT 'CREANDO FUNCIONES Y PROCEDURES PARA ESTADISTICAS...'
GO


/* RAUL TENES QUE ARREGLAR ESTO PARA QUE ANDE
------------------OBTENER_TITULAR------------------
--Proposito: Ser más descriptivo al momento de obtener el identificador titular de 
--			un grupo familiar de afiliados.
--Ingreso: el identificador del afiliado
--
--Egreso: el identificador del titular del beneficio
------------------OBTENER_TITULAR------------------
CREATE FUNCTION kfc.fun_obtener_titular(@afiliado_id INT)
returns INT AS
BEGIN
          DECLARE @id_titular INT;
          SELECT
                    @id_titular = FLOOR(@afiliado_id / 100)* 100 + 1
          ;
          
          RETURN @id_titular;
END;
GO

CREATE FUNCTION KFC.fun_top_5_cancelaciones_especialidad (@año DATETIME)
returns TABLE AS
RETURN
(
          SELECT TOP 5 ESP.ESPE_ID
                    id
                  , esp.descripcion
          FROM
                    kfc.turnos tu
                    INNER JOIN
                              kfc.cancelaciones ca
                    ON
                              tu.turno_id = ca.turno_id
                    INNER JOIN
                              kfc.especialidades esp
                    ON
                              esp.espe_id = tu.espe_id
          WHERE
                    DATEPART(YEAR,ca.fecha_cancel) = DATEPART(YEAR,@año)
          GROUP BY
                    esp.espe_id
                  , esp.descripcion
          ORDER BY
                    COUNT(*) DESC);
GO
CREATE FUNCTION KFC.fun_top_5_profesional_popular ( @plan_id INT ,
@año                                                     DATETIME)
returns TABLE AS
RETURN
(
          SELECT TOP 5 PRO.PROF_ID
                  , concat(pro.apellido,', ', pro.nombre) profesional
                  , esp.espe_id                           id
                  , esp.descripcion
          FROM
                    kfc.turnos tu
                    INNER JOIN
                              kfc.especialidades esp
                    ON
                              esp.espe_id = tu.espe_id
                    INNER JOIN
                              kfc.profesionales pro
                    ON
                              pro.prof_id = tu.prof_id
                    INNER JOIN
                              kfc.afiliados afi
                    ON
                              afi.afil_id = tu.afil_id
          WHERE
                    DATEPART(YEAR,tu.fecha_hora) = DATEPART(YEAR,@año)
                    AND @plan_id                 = afi.plan_id
          GROUP BY
                    pro.prof_id
                  , esp.espe_id
                  , esp.descripcion
          ORDER BY
                    COUNT(*) DESC);
GO
CREATE FUNCTION KFC.fun_top_5_compradores_bonos ( @afil_id INT ,
@año                                                   DATETIME)
returns TABLE AS
RETURN
(
          SELECT TOP 5 CONCAT
                    (afi.apellido,', ', afi.nombre) titular
                  , ISNULL(afi.personas_a_car,0)    grupo_familiar
          FROM
                    kfc.afiliados afi
                    INNER JOIN
                              kfc.bonos b
                    ON
                              kfc.obtener_titular(@afil_id) = kfc.obtener_titular(b.afil_id)
          WHERE
                    DATEPART(YEAR,b.fecha_compra) = DATEPART(YEAR,@año)
                    AND afi.afil_id               = kfc.obtener_titular(@afil_id)
          GROUP BY
                    kfc.obtener_titular(b.afil_id)
          ORDER BY
                    COUNT(*) DESC);
GO
CREATE FUNCTION KFC.fun_top_5_especialidad_Atenciones (@año DATETIME)
returns TABLE AS
RETURN
(
          SELECT TOP 5 ESP.ESPE_ID
                    id
                  , esp.descripcion
          FROM
                    kfc.turnos tu
                    INNER JOIN
                              kfc.atenciones at
                    ON
                              tu.turno_id = at.turno_id
                    INNER JOIN
                              kfc.especialidades esp
                    ON
                              esp.espe_id = tu.espe_id
          WHERE
                    DATEPART(YEAR,tu.fecha_hora) = DATEPART(YEAR,@año)
          GROUP BY
                    esp.espe_id
                  , esp.descripcion
          ORDER BY
                    COUNT(*) DESC);
GO
CREATE FUNCTION KFC.fun_top_5_profesional_menos_tiempo_trabajado (@año DATETIME)
returns TABLE AS
RETURN
(
          SELECT TOP 5 CONCAT
                    (pro.apellido,', ', pro.nombre) profesional
                  , esp.descripcion                 especialidad
                  , pl.descripcion                  nombre_plan
          FROM
                    kfc.bonos b
                    INNER JOIN
                              kfc.atenciones at
                    ON
                              b.bono_id = at.bono_id
                    INNER JOIN
                              kfc.turnos tu
                    ON
                              tu.turno_id = at.turno_id
                    INNER JOIN
                              kfc.especialidades esp
                    ON
                              esp.espe_id = tu.espe_id
                    INNER JOIN
                              kfc.profesionales pro
                    ON
                              pro.prof_id = tu.prof_id
                    INNER JOIN
                              kfc.planes pl
                    ON
                              b.plan_id = pl.plan_id
          WHERE
                    DATEPART(YEAR,tu.fecha_hora) = DATEPART(YEAR,@año)
          GROUP BY
                    pro.prof_id
                  , esp.descripcion
                  , pl.descripcion
          ORDER BY
                    COUNT(*) ASC);
GO
*/


PRINT 'CREADAS FUNCIONES Y PROCEDURES PARA ESTADISTICAS'
GO












/*
---Merge contra lo de Raul. Es de Raul. Estaba trabajando "temporalmente" en esto. NOTA: Hay repetidos que hay que borrar y cosas de Mas. 
---------------------------------------------------------------
---------------------------------------------------------------

	------------------OBTENER_TODOS_LOS_ROLES------------------
--Proposito: obtiene los roles actuales del sistema
--
--Ingreso: -
--
--Egreso: una tabla con la descripcion y el id de los roles
------------------OBTENER_TODOS_LOS_ROLES------------------
CREATE FUNCTION KFC.fun_obtener_todos_los_roles()
returns TABLE AS
RETURN
SELECT
          rol.rol_id
        , rol.descripcion
FROM
          KFC.roles AS rol
WHERE
          rol.habilitado = 1
;
GO
------------------VALIDAR_USUARIO------------------
--Proposito: verificar el correcto logueo en el sistema
--
--Ingreso: usuario y contraseña
--
--Egreso: el identificador del usuario
------------------VALIDAR_USUARIO------------------
CREATE FUNCTION KFC.fun_validar_usuario(@usuario VARCHAR(30),
@contrasenia                                 VARCHAR(30))
returns INT AS
BEGIN
          DECLARE @id INT;
          SELECT
                    @id = ISNULL(us_id,-1)
          FROM
                    KFC.usuarios us
          WHERE
                    us.nick           = @usuario
                    AND us.pass       = HASHBYTES('SHA', @contrasenia)
                    AND us.habilitado = 1
          ;
          
          RETURN @id;
END;
GO
------------------DESHABILITAR_USUARIO------------------
--Proposito: deshabilita un usuario
--
--Ingreso: el nick del usuario
--
--Egreso: -
------------------DESHABILITAR_USUARIO------------------
CREATE PROCEDURE kfc.pro_deshabilitar_usuario
          @usu_nick VARCHAR(30)
AS
          BEGIN
                    BEGIN TRANSACTION
                    UPDATE kfc.usuarios SET habilitado = 0 WHERE nick = @usu_nick;
                    
                    COMMIT;
          END;
GO

------------------HABILITAR_ROL------------------
--Proposito: Habilitar un rol, para que sea útil en el sistema
--
--Ingreso: el identificador del rol
--
--Egreso: -
------------------HABILITAR_ROL------------------
CREATE PROCEDURE KFC.pro_habilitar_rol
          @rol_id INT
AS
          BEGIN
                    BEGIN TRANSACTION
                    UPDATE kfc.roles SET habilitado = 1 WHERE rol_id = @rol_id;
                    
                    COMMIT;
          END;
GO
------------------DESHABILITAR_ROL------------------
--Proposito: Deshabilitar un rol, para que sea inútil en el sistema
--
--Ingreso: el identificador del rol
--
--Egreso: -
------------------DESHABILITAR_ROL------------------
CREATE PROCEDURE kfc.pro_deshabilitar_rol
          @rol_id INT
AS
          BEGIN
                    BEGIN TRANSACTION
                    UPDATE kfc.roles SET habilitado = 0 WHERE rol_id = @rol_id;
                    
                    COMMIT;
          END;
GO
------------------AUMENTAR_INTENTOS------------------
--Proposito: Actualizar la cantidad de errores al loguear con un usuario
--
--Ingreso: el nick del usuario
--
--Egreso: -
------------------AUMENTAR_INTENTOS------------------
CREATE PROCEDURE kfc.pro_aumentar_intentos
          @usu_nick VARCHAR(30)
AS
          BEGIN
                    BEGIN TRANSACTION
                    UPDATE kfc.usuarios SET intentos = intentos +1 WHERE nick = @usu_nick;
                    
                    COMMIT;
          END;
GO
------------------REINICIAR_INTENTOS------------------
--Proposito: Reiniciar la cantidad de errores al loguear con un usuario
--
--Ingreso: el nick del usuario
--
--Egreso: -
------------------REINICIAR_INTENTOS------------------
CREATE PROCEDURE kfc.pro_reiniciar_intentos
          @usu_nick VARCHAR(30)
AS
          BEGIN
                    BEGIN TRANSACTION
                    UPDATE kfc.usuarios SET intentos = 0 WHERE nick = @usu_nick;
                    
                    COMMIT;
          END;
GO
------------------OBTENER_FUNCION_ROL------------------
--Proposito: Saber que funciones puede realizar un determinado rol
--
--Ingreso: el identificador del rol
--
--Egreso: una tabla con las funciones de ese rol
------------------OBTENER_FUNCION_ROL------------------
CREATE FUNCTION KFC.fun_obtener_funcion_rol( @id_rol INT)
returns TABLE AS
RETURN
SELECT
          fr.func_id
        , fun.descripcion
FROM
          kfc.funcionalidades_roles fr
          INNER JOIN
                    kfc.funcionalidades fun
          ON
                    fr.func_id = fun.func_id
WHERE
          fr.rol_id = @id_rol
;
GO
------------------OBTENER_TODAS_LAS_FUNCIONALIDADES------------------
--Proposito: Saber que funciones hay en el sistema
--
--Ingreso: -
--
--Egreso: una tabla con todas las funcionalidades del sistema
------------------OBTENER_TODAS_LAS_FUNCIONALIDADES------------------
CREATE FUNCTION kfc.fun_obtener_todas_las_funcionalidades()
returns TABLE AS
RETURN
SELECT fun.func_id, fun.descripcion FROM kfc.funcionalidades fun;
GO
------------------VERIFICAR_FUNCION_ROL------------------
--Proposito: Revisa que un rol tenga determinada funcionalidad
--
--Ingreso: -
--
--Egreso: 1 = la tiene, 0 = no la tiene
------------------VERIFICAR_FUNCION_ROL------------------
CREATE PROCEDURE kfc.pro_verificar_funcion_rol( @id_func INT,
@id_rol                                              INT
)
AS
          BEGIN
		 
                    SELECT
                              'a'
                    FROM
                              kfc.funcionalidades_roles fr
                    WHERE
                              fr.func_id    = @id_func
                              AND fr.rol_id = @id_rol
                    ;
                    
                    DECLARE @encontrado BIT
                    IF @@rowcount = 0
                    BEGIN
                              SET @encontrado = 0
                    END
                    ELSE
                    BEGIN
                              SET @encontrado = 1
                    END
                    RETURN (@encontrado)
          END;
GO
------------------OBTENER_PLANES_AFILIADO------------------
--Proposito: Saber que planes posee un afiliado
--
--Ingreso: identificador del afiliado
--
--Egreso: una tabla con todos los planes que actualmente posee el afiliado,
--			el nombre del afiliado y del titular del beneficio
------------------OBTENER_PLANES_AFILIADO------------------
CREATE FUNCTION kfc.fun_obtener_planes_afiliado( @afiliado_id INT)
returns TABLE
RETURN
(
          SELECT
                    afi.afil_id
                  , concat(afi.apellido,', ', afi.nombre) AS paciente
                  , concat(tit.apellido,', ', tit.nombre) AS titular
                  , pl.plan_id
                  , pl.descripcion
          FROM
                    kfc.afiliados afi
                    INNER JOIN
                              kfc.afiliados tit
                    ON
                              kfc.obtener_titular(afi.afil_id) = tit.afil_id
                    INNER JOIN
                              kfc.planes pl
                    ON
                              pl.plan_id = tit.plan_id
          WHERE
                    afi.habilitado  = 1
                    AND afi.afil_id = @afiliado_id);
GO
------------------OBTENER_TODOS_LOS_PLANES------------------
--Proposito: Saber que planes existen actualmente en nuestro sistema
--
--Ingreso: -
--
--Egreso: una tabla con todos los planes que actualmente existen en nuestro sistema
------------------OBTENER_TODOS_LOS_PLANES------------------
CREATE FUNCTION kfc.fun_obtener_todos_los_planes()
returns TABLE
RETURN
( SELECT pl.plan_id, pl.descripcion FROM kfc.planes pl);
GO
------------------OBTENER_ESPECIALIDADES------------------
--Proposito: Saber que especialidades posee un profesional
--
--Ingreso: un identificador de profesional
--
--Egreso: una tabla con todas las especialidades que posee el profesional
------------------OBTENER_ESPECIALIDADES------------------
CREATE FUNCTION kfc.fun_obtener_especialidades(@id_profesional INT)
returns TABLE
RETURN
SELECT
          esp.espe_id
        , esp.descripcion
FROM
          kfc.especialidades_profesional ep
          INNER JOIN
                    kfc.especialidades esp
          ON
                    ep.espe_id= esp.espe_id
WHERE
          (
                    @id_profesional = 0
                    OR ep.prof_id   = @id_profesional
          )
;
GO
------------------OBTENER_PROFESIONALES_POR_ESPECIALIDAD------------------
--Proposito: Saber que profesionales poseen una especialidad
--
--Ingreso: un identificador de especialidad
--
--Egreso: una tabla con todas los profesionales que poseen esa especialidad
------------------OBTENER_PROFESIONALES_POR_ESPECIALIDAD------------------
CREATE FUNCTION kfc.fun_obtener_profesionales_por_especialidad (@id_esp INT)
returns TABLE
RETURN
SELECT
          prof.prof_id
        , concat(prof.apellido,', ',prof.nombre) AS profesional
FROM
          kfc.especialidades_profesional ep
          INNER JOIN
                    kfc.profesionales prof
          ON
                    ep.prof_id= prof.prof_id
WHERE
          (
                    @id_esp       = 0
                    OR ep.espe_id = @id_esp
          )
;
GO
------------------ELIMINAR_ROL_USUARIO------------------
--Proposito: Quitarle un rol a un determinado usuario
--
--Ingreso: un identificador de usuario
--
--Egreso: -
------------------ELIMINAR_ROL_USUARIO------------------
CREATE PROCEDURE kfc.pro_eliminar_rol_usuario
          @rol_id INT
          ,
          @usu_id INT
AS
          BEGIN
		  begin transaction
                    DELETE
                    FROM
                              kfc.roles_usuarios
                    WHERE
                              rol_id    = @rol_id
                              AND us_id = @usu_id
                    ;
          commit;
          END;
GO
------------------OBTENER_TURNOS_DEL_DIA------------------
--Proposito: Obtener los turnos "ocupados" de un dia
--
--Ingreso: un identificador de profesional, otro de especialidad y un día
--
--Egreso: una tabla con la fecha, hora, paciente, doctor y especialidad
------------------OBTENER_TURNOS_DEL_DIA------------------
CREATE FUNCTION kfc.fun_obtener_turnos_del_dia (@especialidad INT,
@profesional                                              INT,
@sysdate                                                  DATETIME)
returns TABLE
RETURN
(
          SELECT
                    CONVERT (DATE,t.fecha_hora)        AS fecha
                  , CONVERT (TIME,t.hora)              AS hora
                  , CONCAT(a.apellido, ', ', a.nombre) AS paciente
                  , CONCAT(a.apellido, ', ', a.nombre) AS doctor
                  , esp.descripcion                    AS especialidad
          FROM
                    KFC.turnos t
                    INNER JOIN
                              kfc.afiliados a
                    ON
                              t.afil_id = a.afil_id
                    INNER JOIN
                              kfc.profesionales pr
                    ON
                              pr.prof_id = t.prof_id
                    INNER JOIN
                              kfc.especialidades esp
                    ON
                              esp.espe_id = t.espe_id
          WHERE
                    (
                              @profesional = 0
                              OR t.prof_id = @profesional
                    )
                    AND
                    (
                              @especialidad = 0
                              OR t.espe_id  = @especialidad
                    )
                    AND CONVERT(DATE,t.fecha_hora) = CONVERT(DATE, @sysdate)--(date,GETDATE()));
		);
GO
------------------OBTENER_BONOS_AFILIADO------------------
--Proposito: Obtener los turnos "ocupados" de un dia
--
--Ingreso: un identificador de profesional, otro de especialidad y un día
--
--Egreso: una tabla con la fecha, hora, paciente, doctor y especialidad
------------------OBTENER_BONOS_AFILIADO------------------
CREATE FUNCTION fun_obtener_bonos_afiliado(@afiliado_id INT)
returns TABLE
RETURN
(
          SELECT
                    b.bono_id
                  , b.plan_id
          FROM
                    kfc.bonos b
          WHERE
                    b.afil_id       = @afiliado_id
                    AND b.consumido = 0
          ;
GO
CREATE PROCEDURE kfc.pro_crear_agenda_profesional
          @espe_id INT
          ,
          @prof_id INT
          ,
          @dia INT
          ,
          @fecha_desde DATETIME
          ,
          @fecha_hasta DATETIME
          ,
          @hora_desde TIME
          ,
          @hora_hasta TIME
AS
          BEGIN
                    BEGIN TRANSACTION
                    INSERT INTO KFC.agenda
                              (
                                        espe_id
                                      , prof_id
                                      , dia
                                      , fecha_desde
                                      , fecha_hasta
                                      , hora_desde
                                      , hora_hasta
                              )
                              VALUES
                              (
                                        @espe_id
                                      , @prof_id
                                      , @dia
                                      , @fecha_desde
                                      , @fecha_hasta
                                      , @hora_desde
                                      , @hora_hasta
                              )
                    ;
                    
                    COMMIT;
          END;
GO
CREATE PROCEDURE kfc.pro_baja_afiliado
          @afiliado_id INT
          ,
          @sysdate DATETIME
AS
          BEGIN
                    BEGIN TRANSACTION
                    UPDATE kfc.afiliados SET habilitado = 0, fecha_baja = @sysdate;
                    
                    COMMIT;
          END;
GO
CREATE PROCEDURE kfc.pro_liberar_turnos
          @afiliado_id INT
          ,
          @sysdate DATETIME
AS
          BEGIN
                    BEGIN TRANSACTION
                    DELETE
                              kfc.turnos
                    WHERE
                              afil_id                            = @afiliado_id
                              AND DATEPART(YEAR,fecha_hora)     >= DATEPART(YEAR,@sysdate)
                              AND DATEPART(DAYOFYEAR,fecha_hora) > DATEPART(DAYOFYEAR, @sysdate)
                    COMMIT;
          END;
GO
CREATE PROCEDURE kfc.pro_registrar_llegada_atencion
          @turno_id INT
          ,
          @bono_id INT
          ,
          @sysdate DATETIME
AS
          BEGIN
                    BEGIN TRY
                              BEGIN TRANSACTION
                              INSERT INTO kfc.atenciones
                                        (
                                                  turno_id
                                                , hora_llegada
                                                , bono_id
                                        )
                                        VALUES
                                        (
                                                  @turno_id
                                                , @sysdate
                                                , @bono_id
                                        )
                              ;
                              
                              UPDATE
                                        kfc.bonos
                              SET       consumido = 1
                              WHERE
                                        bono_id = @bono_id
                              ;
                              
                              COMMIT;
                              IF (@@ROWCOUNT = 0)
                              RAISERROR('',16,1);
                    END TRY
                    BEGIN CATCH
                              PRINT('Catcheamos Excepciones');
                              IF @@trancount > 0
                              ROLLBACK TRANSACTION;
                              THROW;
                    END CATCH;
          END;
GO
-------------------------------------------------------
-------------------------------------------------------
*/