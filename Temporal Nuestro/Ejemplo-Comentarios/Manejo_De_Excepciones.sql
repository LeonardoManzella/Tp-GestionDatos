--Borramos el Procedimiento de prueba
DROP PROCEDURE [dbo].[sp_prueba_error];
GO


--Procedimiento de prueba
CREATE PROCEDURE sp_prueba_error
AS
BEGIN
        BEGIN TRY
                    BEGIN TRANSACTION
                    PRINT 'Codigo Nuestro que genera un Error en algun lado'
                    RAISERROR('BOOOOOOOOOOOOOOM',16,1)
                    COMMIT TRANSACTION
        END TRY
        BEGIN CATCH
                    PRINT 'Catcheamos Excepciones'
                    IF @@trancount > 0
                    ROLLBACK TRANSACTION;		-- Importante el PUNTO Y COMA

                    --Importantisimo el proximo PUNTO Y COMA, por favor no se lo olviden
					-- Si no lo ponen, lo toma como argumento para "ROLLBACK TRANSACTION" y no se ejecutara el THROW, entonces no sirvio de nada
                    ;THROW
        END CATCH
END;
GO


--Ejecutamos el Procedimiento de prueba
EXEC sp_prueba_error
