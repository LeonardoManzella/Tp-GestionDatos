-- Borrado de Funciones Viejas
DROP PROCEDURE KFC.deshabilitar_rol_usuarios;
GO
DROP FUNCTION KFC.obtener_turnos_profesional;
GO
DROP PROCEDURE KFC.asignar_turno;
GO



CREATE FUNCTION KFC.Obtener_Roles_Usuario(@usuario_id INT)
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
          ) -- =0 devuelve todos los roles
          AND rol.habilitado = 1
;

GO

-- Devuelve el ID del Usuario en caso de Verificacion Correcta, o -1 en caso de Error
CREATE FUNCTION KFC.Validar_Usuario(@usuario VARCHAR(30),
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
                    AND us.pass       = @contrasenia
                    AND us.habilitado = 1
          ;
          
          RETURN @id;
END;
GO
CREATE PROCEDURE kfc.deshabilitar_usuario
          @usu_nick VARCHAR(30)
AS
          BEGIN
                    BEGIN TRANSACTION
                    UPDATE kfc.usuarios SET habilitado = 0 WHERE nick = @usu_nick;
                    
                    COMMIT;
          END;
GO
CREATE PROCEDURE kfc.habilitar_rol
          @rol_id INT
AS
          BEGIN
                    BEGIN TRANSACTION
                    UPDATE kfc.roles SET habilitado = 1 WHERE rol_id = @rol_id;
                    
                    COMMIT;
          END;
GO
CREATE PROCEDURE kfc.deshabilitar_rol
          @rol_id INT
AS
          BEGIN
                    BEGIN TRANSACTION
                    UPDATE kfc.roles SET habilitado = 0 WHERE rol_id = @rol_id;
                    
                    COMMIT;
          END;
GO
CREATE PROCEDURE kfc.aumentar_intentos
          @usu_nick VARCHAR(30)
AS
          BEGIN
                    BEGIN TRANSACTION
                    UPDATE kfc.usuarios SET intentos = intentos +1 WHERE nick = @usu_nick;
                    
                    COMMIT;
          END;
GO
CREATE PROCEDURE kfc.reiniciar_intentos
          @usu_nick VARCHAR(30)
AS
          BEGIN
                    BEGIN TRANSACTION
                    UPDATE kfc.usuarios SET intentos = 0 WHERE nick = @usu_nick;
                    
                    COMMIT;
          END;
GO
CREATE FUNCTION kfc.obtener_funcion_rol( @id_rol INT)
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
CREATE FUNCTION kfc.obtener_todas_las_funcionalidades()
returns TABLE AS
RETURN
SELECT fun.func_id, fun.descripcion FROM kfc.funcionalidades fun;

GO

--Devuelve True (1) o False (0) en tipo BIT
CREATE PROCEDURE kfc.verificar_funcion_rol( @id_func INT,
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
CREATE FUNCTION kfc.obtener_planes_afiliado( @afiliado_id INT)
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
CREATE FUNCTION kfc.obtener_todos_los_planes()
returns TABLE
RETURN
( SELECT pl.plan_id, pl.descripcion FROM kfc.planes pl);
GO
CREATE FUNCTION kfc.obtener_especialidades(@id_profesional INT)
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
CREATE FUNCTION kfc.obtener_profesionales_por_especialidad (@id_esp INT)
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
CREATE PROCEDURE kfc.eliminar_rol_usuario
          @rol_id INT
          ,
          @usu_id INT
AS
          BEGIN
                    DELETE
                    FROM
                              kfc.roles_usuarios
                    WHERE
                              rol_id    = @rol_id
                              AND us_id = @usu_id
                    ;
          
          END;
GO
CREATE FUNCTION kfc.obtener_turnos_del_dia (@especialidad INT,
@profesional                                              INT)
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
                    AND CONVERT (DATE,t.fecha_hora) = CONVERT (DATE,GETDATE()));
GO
CREATE FUNCTION obtener_bonos_afiliado(@afiliado_id INT)
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

	
--**********************************AGREGADO POR GONZALO**********************************
--Funcionalidad REGISTRO DE RESULTADO DE ATENCION MEDICA. Devuelve el 'Id Afilidado' (con el Id despues consulto turnos en otra función).
CREATE FUNCTION KFC.Retornar_Id_Afildo(@nombre VARCHAR(255),
@apellido                                      VARCHAR(255))
returns INT AS
BEGIN
          DECLARE @Afil_id INT;
          SELECT
                    @Afil_id = ISNULL(Afil_id,0)
          FROM
                    KFC.afiliados Afi
          WHERE
                    Afi.nombre         = UPPER(@nombre)
                    AND Afi.apellido   = UPPER(@apellido)
                    AND Afi.habilitado = 1
          ;
          
          RETURN @Afil_id;
END;
GO

--Funcionalidad REGISTRO DE RESULTADO DE ATENCION MEDICA. Devuelve los 'Turnos' del afiliado con un profesional.	
CREATE FUNCTION KFC.Devolver_Turnos_Prof_Afildo(@Afil_id INT,@Prof_id INT)
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
CREATE PROCEDURE KFC.Grabar_Resultado_Atencion
          @turno_id INT
          ,
          @sintomas VARCHAR(255)
          ,
          @diagnostico VARCHAR(255)
		  ,
		  @hora_llegada DATETIME
AS
          BEGIN
                    BEGIN TRANSACTION
                    UPDATE
                              kfc.atenciones
                    SET       sintomas    = @sintomas
                            , diagnostico = @diagnostico
							, hora_llegada = @hora_llegada
                    WHERE
                              turno_id = @turno_id
                    COMMIT;
          END;
GO
--**********************************AGREGADO POR GONZALO**********************************


------------------DESHABILITAR_ROL_USUARIOS------------------
--Proposito: Dado el ID de un rol, quitarselo a los usuarios que lo contengan y luego deshabilitarlo
--
--Ingreso: id de rol a deshabilitar
------------------DESHABILITAR_ROL_USUARIOS------------------
CREATE PROCEDURE KFC.deshabilitar_rol_usuarios
          @id_rol INT
AS
    BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				DELETE 
				FROM KFC.roles_usuarios
				WHERE rol_id = @id_rol
                
				 EXECUTE deshabilitar_rol @id_rol
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
--Egreso:	Una Tabla de unica columna Horarios disponibles (multiples filas cada una con un horario disponible)
------------------OBTENER_TURNOS_PROFESIONAL------------------
CREATE FUNCTION KFC.obtener_turnos_profesional( @prof_id INT, @fecha DATE)
returns @retorno TABLE (horario_disponible TIME) AS
--Uso la Variable "@retorno" tipo Tabla para generar los Horarios Disponibles en base al Rango de Horarios Posibles
BEGIN
	DECLARE @hora_desde TIME
	DECLARE	@hora_hasta	TIME
	
	--Me traigo el Rango de Horarios Posibles
	SELECT @hora_desde = hora_desde, @hora_hasta = hora_hasta
	FROM	KFC.agenda
	WHERE	DATEPART(WEEKDAY, @fecha) = dia
	--Convierto para que solo compare por Año-Mes-Dia
	AND		CONVERT(DATE,fecha_desde) >= @fecha
	

	--Inserto Horarios Disponibles, cada 30 minutos (Uso el While para Crear un FOR)
	WHILE ( DATEDIFF(MINUTE, @hora_desde, @hora_hasta) != 0 )
	BEGIN
		--PRINT DATEDIFF(MINUTE, @hora_desde, @hora_hasta)
		INSERT INTO @retorno VALUES (@hora_desde)
		SET @hora_desde = DATEADD(MINUTE, 30, @hora_desde)
	END

	
	--Quito Horarios ya Tomados por Turnos y Retorno
	DELETE
	FROM	@retorno
	-- Debo convertirlos sino no me deja comparar con el IN
	WHERE	CONVERT(varchar,horario_disponible, 108)  IN	(
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
CREATE PROCEDURE KFC.asignar_turno
          @fecha DATETIME
		, @hora	   TIME(0)	--Hora del Turno
		, @afil_id    INT
		, @espe_id    INT
		, @prof_id    INT
AS
    BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO KFC.turnos(fecha_hora,hora,afil_id,espe_id,prof_id) VALUES (@fecha, @hora, @afil_id, @espe_id, @prof_id)
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
