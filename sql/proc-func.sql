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
CREATE function KFC.Retornar_Id_Afildo(@nombre varchar(255), @apellido varchar(255))
returns int AS
Begin
declare @Afil_id int;
select @Afil_id = isnull(Afil_id,0) from KFC.afiliados Afi
Where Afi.nombre = UPPER(@nombre)            
and Afi.apellido = UPPER(@apellido)        
and Afi.habilitado = 1;
return @Afil_id;
End;

go

CREATE function KFC.Devolver_Turnos_Prof_Afildo(@Afil_id int, @Prof_id int)
returns table AS
return ( 
Select turno_id, fecha_hora, hora
from KFC.turnos 
Where afil_id = @Afil_id
and prof_id =  @Prof_id
);

go

create procedure KFC.Grabar_Resultado_Atencion @turno_id int, @sintomas varchar(255), @diagnostico varchar(255)
as
begin
	begin transaction
		update kfc.atenciones
			set  sintomas = @sintomas, diagnostico = @diagnostico
			where  turno_id = @turno_id
	commit;
end;
	
GO
--**********************************AGREGADO POR GONZALO**********************************
