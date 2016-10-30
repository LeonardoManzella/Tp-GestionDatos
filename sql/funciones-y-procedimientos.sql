---Merge contra lo de Raul. Es de Raul. Estaba trabajando "temporalmente" en esto. NOTA: Hay repetidos que hay que borrar y cosas de Mas
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
-------------------------------------------------------
-------------------------------------------------------
*/
