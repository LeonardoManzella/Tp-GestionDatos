--------------------------------------- Inicio Dropeos---------------------------------------------
IF OBJECT_ID('KFC.pro_top_5_cancelaciones_especialidad') IS NOT NULL
DROP PROCEDURE KFC.pro_top_5_cancelaciones_especialidad ;
GO
-----------------
IF OBJECT_ID('KFC.pro_top_5_profesional_popular') IS NOT NULL
DROP PROCEDURE KFC.pro_top_5_profesional_popular ;
GO
----------------
IF OBJECT_ID('KFC.pro_top_5_compradores_bonos') IS NOT NULL
DROP PROCEDURE KFC.pro_top_5_compradores_bonos ;
GO
----------------
IF OBJECT_ID('KFC.pro_top_5_espec_Atenciones') IS NOT NULL
DROP PROCEDURE KFC.pro_top_5_espec_Atenciones;
GO
---------------
IF OBJECT_ID('KFC.pro_top_5_prof_menos_trabajo') IS NOT NULL
DROP PROCEDURE KFC.pro_top_5_prof_menos_trabajo;
GO

---------------------
----COMBOS
---------------------
IF OBJECT_ID('KFC.get_cmb_especialidades') IS NOT NULL
DROP PROCEDURE KFC.get_cmb_especialidades;
GO
------------------------
---Funciones
------------------------
IF OBJECT_ID('KFC.obtener_titular') IS NOT NULL
DROP FUNCTION KFC.obtener_titular;
GO

-----------------------------------------Fin Dropeos---------------------------------------------
-------------------------------------- Inicio Procedures----------------------------------------

CREATE PROCEDURE KFC.pro_top_5_cancelaciones_especialidad
          @año INT, @plazo_init INT, @plazo_fin INT, @cancelador INT
AS
BEGIN
          SELECT DISTINCT TOP 5 ESP.ESPE_ID id
                  , esp.descripcion
                  , ISNULL(COUNT(*),0) cancelaciones
          FROM
                    kfc.turnos tu
                    INNER JOIN
                              (
                                        SELECT
                                                  *
                                        FROM
                                                  kfc.cancelaciones c
                                        WHERE
                                                  (
                                                            @año                             = 0
                                                            OR DATEPART(YEAR,c.fecha_cancel) = @año
                                                  )
                                                  AND
                                                  (
                                                            @plazo_init                        = 0
                                                            OR DATEPART(MONTH,c.fecha_cancel) >= @plazo_init
                                                  )
                                                  AND
                                                  (
                                                            @plazo_fin                         = 0
                                                            OR DATEPART(MONTH,c.fecha_cancel) <= @plazo_fin
                                                  )
                                                  AND
                                                  (
                                                            @cancelador         =0
                                                            OR c.tipo_cancel_id = @cancelador
                                                  ) ) ca
                    ON
                              tu.turno_id = ca.turno_id
                    INNER JOIN
                              kfc.especialidades esp
                    ON
                              esp.espe_id = tu.espe_id
          GROUP BY
                    esp.espe_id
                  , esp.descripcion
          ORDER BY
                    ISNULL(COUNT(*),0) DESC
          ;

END;
GO

------------------------------------------------------------
------------------------------------------------------------
CREATE PROCEDURE KFC.pro_top_5_profesional_popular
          @año INT, @plazo_init INT, @plazo_fin INT, @plan_id INT AS
BEGIN
          SELECT DISTINCT TOP 5--   PRO.PROF_ID,
                               concat(pro.apellido,', ', pro.nombre) profesional
                    --, esp.espe_id                           especialidad
                  , esp.descripcion
                  , ISNULL(COUNT(*),0) turnos
          FROM
                    (
                              SELECT
                                        *
                              FROM
                                        kfc.turnos t
                              WHERE
                                        (
                                                  @año                           =0
                                                  OR DATEPART(YEAR,t.fecha_hora) = @año
                                        )
                                        AND
                                        (
                                                  @plazo_init                      = 0
                                                  OR DATEPART(MONTH,t.fecha_hora) >= @plazo_init
                                        )
                                        AND
                                        (
                                                  @plazo_fin                       =0
                                                  OR DATEPART(MONTH,t.fecha_hora) <= @plazo_fin
                                        ) )tu
                    INNER JOIN
                              kfc.especialidades esp
                    ON
                              esp.espe_id = tu.espe_id
                    INNER JOIN
                              kfc.profesionales pro
                    ON
                              pro.prof_id = tu.prof_id
                    INNER JOIN
                              (
                                        SELECT
                                                  *
                                        FROM
                                                  kfc.afiliados a
                                        WHERE
                                                  (
                                                            @plan_id    = 0
                                                            OR @plan_id = a.plan_id
                                                  ) )afi
                    ON
                              afi.afil_id = tu.afil_id
          GROUP BY
                    pro.prof_id
                  , concat(pro.apellido,', ', pro.nombre)
                  , esp.espe_id
                  , esp.descripcion
          ORDER BY
                    ISNULL(COUNT(*),0) DESC
          ;

END;
GO
-------------------------------------------------------
-------------------------------------------------------

CREATE PROCEDURE KFC.pro_top_5_compradores_bonos
          @año INT, @plazo_init INT, @plazo_fin INT AS
BEGIN
          SELECT DISTINCT TOP 5 CONCAT(afi.apellido,', ', afi.nombre) titular
                  , ISNULL(afi.personas_a_car,0)                      grupo_familiar
                  , ISNULL(COUNT(*),0)                                bonos
          FROM-- Todos los afiliados con bonos
                    kfc.afiliados afi
                    INNER JOIN
                              (
                                        SELECT
                                                  *
                                        FROM
                                                  kfc.bonos bo
                                        WHERE
                                                  (
                                                            @año                              =0
                                                            OR DATEPART(YEAR,bo.fecha_compra) = @año
                                                  )
                                                  AND
                                                  (
                                                            @plazo_init                         =0
                                                            OR DATEPART(MONTH,bo.fecha_compra) >= @plazo_init
                                                  )
                                                  AND
                                                  (
                                                            @plazo_init                         =0
                                                            OR DATEPART(MONTH,bo.fecha_compra) <= @plazo_fin
                                                  ) ) b --Bonos del Período elegido
                    ON
                              afi.afil_id = b.afil_id
          GROUP BY--Afiliado
                    b.afil_id
                  , ISNULL(afi.personas_a_car,0)
                  , afi.apellido
                  , afi.nombre
          ORDER BY
                    ISNULL(COUNT(*),0) DESC
          ;

END;
GO
----------------------------------------------------------------------------
----------------------------------------------------------------------------

CREATE PROCEDURE KFC.pro_top_5_espec_Atenciones
          @año INT, @plazo_init INT, @plazo_fin INT
AS
BEGIN
          SELECT DISTINCT TOP 5 esp.espe_id especialidad_id
                  , esp.descripcion
                  , ISNULL(COUNT(*),0) cantidad_bonos
          FROM
                    (
                              SELECT
                                        *
                              FROM
                                        kfc.turnos t
                              WHERE
                                        (
                                                  @año                           = 0
                                                  OR DATEPART(YEAR,t.fecha_hora) = @año
                                        )
                                        AND
                                        (
                                                  @plazo_init                      = 0
                                                  OR DATEPART(MONTH,t.fecha_hora) >= @plazo_init
                                        )
                                        AND
                                        (
                                                  @plazo_fin                       = 0
                                                  OR DATEPART(MONTH,t.fecha_hora) <= @plazo_fin
                                        ) ) tu
                    INNER JOIN
                              kfc.atenciones at
                    ON
                              tu.turno_id = at.turno_id
                    INNER JOIN
                              kfc.especialidades esp
                    ON
                              esp.espe_id = tu.espe_id
          GROUP BY
                    esp.espe_id
                  , esp.descripcion
          ORDER BY
                    ISNULL(COUNT(*),0) DESC
          ;

END;
GO
---------------------------------------------------------------------

CREATE PROCEDURE KFC.pro_top_5_prof_menos_trabajo
          @año INT, @plazo_init INT, @plazo_fin INT, @plan_id INT, @esp_id INT
AS
BEGIN
          SELECT DISTINCT TOP 5 CONCAT(pro.apellido,', ', pro.nombre) profesional
                  , esp.descripcion                                   especialidad
                  , pl.descripcion                                    nombre_plan
                  , ISNULL(COUNT(*),0)/4                              hs_trabajadas
                    --SUM(tu.duracion)
          FROM
                    (
                              SELECT
                                        *
                              FROM
                                        kfc.bonos bo
                              WHERE
                                        @plan_id = 0
                                        OR bo.plan_id  = @plan_id ) b
                    INNER JOIN
                              kfc.atenciones at
                    ON
                              b.bono_id = at.bono_id
                    INNER JOIN
                              (
                                        SELECT
                                                  *
                                        FROM
                                                  kfc.turnos t
                                        WHERE
                                                  (
                                                            @año                           =0
                                                            OR DATEPART(YEAR,t.fecha_hora) = @año
                                                  )
                                                  AND
                                                  (
                                                            @plazo_init                      = 0
                                                            OR DATEPART(MONTH,t.fecha_hora) >= @plazo_init
                                                  )
                                                  AND
                                                  (
                                                            @plazo_fin                       =0
                                                            OR DATEPART(MONTH,t.fecha_hora) <= @plazo_fin
                                                  )
                                                  AND
                                                  (
                                                            @esp_id    = 0
                                                            OR @esp_id = t.espe_id
                                                  ) )tu
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
          GROUP BY
                    pro.prof_id
                  , pro.nombre
                  , pro.apellido
                  , b.plan_id
                  , esp.descripcion
                  , pl.descripcion
          ORDER BY
                    ISNULL(COUNT(*),0)/4 ASC
          ;

END;
GO

---------------------------------------------------------
----------------COMBOS
--------------------------------------------------------

CREATE PROCEDURE KFC.get_cmb_especialidades
AS
SELECT e.espe_id id,  e.descripcion
FROM KFC.especialidades e;
GO
---------------------------FIN PROCEDURES------------------------

------------------FUNCTIONS-------------------
CREATE FUNCTION kfc.obtener_titular (@afil_id INT)
RETURNS INT
AS
BEGIN
	DECLARE @id INT;
	SELECT @id = floor(@afil_id/100)*100 + 1;
	RETURN @id;
END;
---------------------------FIN FUNCTIONS------------------------