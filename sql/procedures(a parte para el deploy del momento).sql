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
