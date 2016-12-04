IF OBJECT_ID('KFC.modifica_afiliado') IS NOT NULL
DROP PROCEDURE KFC.modifica_afiliado;
GO
IF OBJECT_ID('KFC.get_cmb_estado_civil') IS NOT NULL
DROP PROCEDURE KFC.get_cmb_estado_civil;
GO
IF OBJECT_ID('KFC.get_afiliado') IS NOT NULL
DROP PROCEDURE KFC.get_afiliado;
GO
IF OBJECT_ID('KFC.alta_afiliado') IS NOT NULL
DROP PROCEDURE KFC.alta_afiliado;
GO

IF OBJECT_ID('KFC.get_cmb_planes_sociales') IS NOT NULL
DROP PROCEDURE KFC.get_cmb_planes_sociales;
GO

IF OBJECT_ID('KFC.registrar_llegada') IS NOT NULL
DROP PROCEDURE KFC.registrar_llegada;
GO

IF OBJECT_ID('KFC.get_bonos_afiliado') IS NOT NULL
DROP PROCEDURE KFC.get_bonos_afiliado;
GO

IF OBJECT_ID('KFC.get_turno_hoy') IS NOT NULL
DROP PROCEDURE KFC.get_turno_hoy;
GO

IF OBJECT_ID('KFC.get_cmb_prof_x_esp') IS NOT NULL
DROP PROCEDURE KFC.get_cmb_prof_x_esp;
GO

IF OBJECT_ID('KFC.get_especialidades') IS NOT NULL
DROP FUNCTION KFC.get_especialidades;
GO

PRINT 'Creando Funciones y Procedures Deploy...'
GO

CREATE FUNCTION kfc.get_especialidades(@id_profesional INT)
returns TABLE
RETURN
SELECT
          esp.espe_id as id
        , esp.descripcion as descripcion 
		FROM
          kfc.especialidades esp
          
;
GO

CREATE PROCEDURE kfc.get_cmb_prof_x_esp (@id_esp INT)
as
SELECT
          prof.prof_id as id
        , concat(prof.apellido,', ',prof.nombre) AS descripcion
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

CREATE PROCEDURE kfc.get_turno_hoy (@afiliado_id INT,
@especialidad INT,
@profesional  INT,
@fecha		  DateTime)
AS
          SELECT	t.turno_id						   AS id
                  , CONCAT(a.apellido, ', ', a.nombre, ': ', esp.descripcion ) AS descripcion
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
					AND
                    (
                              @afiliado_id = 0
                              OR t.afil_id  = @afiliado_id
                    )
                    AND (
		  DATEPART(YEAR, t.fecha_hora) = DATEPART(Year, @fecha) 
	           AND DATEPART(DAYOFYEAR, t.fecha_hora) =DATEPART(DAYOFYEAR, @fecha)
	           AND t.fecha_hora >= @fecha 
						   );
GO

CREATE PROCEDURE kfc.get_bonos_afiliado(@afiliado_id INT, @plan_id INT)
as
	SELECT
                    b.bono_id as id
                  , CONVERT(varchar(10), b.bono_id) as descripcion
          FROM
                    kfc.bonos b
          WHERE
                    b.afil_id       = @afiliado_id
					AND	b.plan_id = @plan_id
                    AND b.consumido = 0;
GO

CREATE Procedure KFC.get_cmb_planes_sociales
as
SELECT pl.plan_id id, pl.descripcion FROM kfc.planes pl;
go

CREATE procedure KFC.registrar_llegada (@id_afiliado int, @id_turno int, @id_bono int, @fecha time)
as
begin
begin try
begin transaction

insert into kfc.atenciones(turno_id, hora_llegada, bono_id)
values
(@id_turno, @fecha, @id_bono);

update kfc.bonos
set consumido = 1
where bono_id = @id_bono;

commit;
end try
begin catch
ROLLBACK TRANSACTION;
PRINT 'LLegada Turno No Ingresada. Fecha ' + CONVERT(varchar,@fecha,102)
;THROW
end catch
END;
GO

CREATE PROCEDURE KFC.alta_afiliado( @nombre VARCHAR(255),
									@apellido                                   VARCHAR(255),
									@tipo_doc                                   VARCHAR(25),
									@nro_doc                                    NUMERIC(18,0),
									@direccion                                  VARCHAR(255),
									@telefono                                   NUMERIC(18,0),
									@mail                                       VARCHAR(255),
									@sexo                                       CHAR(1),
									@fecha_nac                                  DATETIME,
									@estado                                     INT,
									@plan                                       INT,
									@usuario                                    INT,
									@afil_id									NUMERIC(18,0) OUTPUT )
AS
BEGIN
        SET @afil_id = -1;
        BEGIN TRY
                    BEGIN TRANSACTION
                    INSERT INTO kfc.afiliados
                            (
                                        nombre
                                    , apellido
                                    , tipo_doc
                                    , numero_doc
                                    , direccion
                                    , telefono
                                    , mail
                                    , sexo
                                    , fecha_nacimiento
                                    , estado_id
                                    , plan_id
                                    , us_id
                                    , habilitado
                            )
                            VALUES
                            (
                                        @nombre
                                    , @apellido
                                    , @tipo_doc
                                    , @nro_doc
                                    , @direccion
                                    , @telefono
                                    , @mail
                                    , @sexo
                                    , @fecha_nac
                                    , @estado
                                    , @plan
                                    , @usuario
                                    , 1
                            )
                    ;
                              
                    SELECT @afil_id = @@IDENTITY;
                              
                    COMMIT;
                    RETURN
        END TRY
        BEGIN CATCH
                    IF @@trancount > 0
                    ROLLBACK TRANSACTION;
                    PRINT 'Afiliado No Ingresado.';
                    THROW
        END CATCH
END;
GO

create procedure KFC.get_afiliado @id_afiliado int
as
select * from kfc.afiliados a
where a.afil_id = @id_afiliado;
GO

create procedure KFC.get_cmb_estado_civil
as
SELECT DISTINCT c.estado_id
		, c.descripcion 
FROM
	kfc.estado_civil c;
GO

create procedure KFC.modifica_afiliado( 
								 @afiliado int,
								 @nombre varchar(255),
								 @apellido varchar(255),
								 @tipo_doc varchar(25),
								 @direccion varchar(255),
								 @telefono numeric(18,0),
								 @mail  varchar(255),
								 @sexo char(1),
								 @fecha_nac datetime,
								 @estado int,
								 @plan int,
								 @usuario int
								 )
as
Begin
		BEGIN TRY
			BEGIN TRANSACTION
			Update kfc.afiliados
			set nombre = @nombre,
				apellido = @apellido,
				tipo_doc = @tipo_doc,
				direccion = @direccion,
				telefono = @telefono,
				mail = @mail,
				sexo = @sexo,
				fecha_nacimiento = @fecha_nac,
				estado_id = @estado,
				plan_id = @plan,
				us_id = @usuario
				where afil_id = @afiliado;

			Commit;
			End try
			BEGIN CATCH
			IF @@trancount > 0
			ROLLBACK TRANSACTION;
			THROW
			END CATCH
end;


PRINT 'Creadas Funciones y Procedures Deploy'
GO