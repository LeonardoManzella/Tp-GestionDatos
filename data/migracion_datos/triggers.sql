PRINT 'CREANDO TRIGGERS...'
GO

-- Se chequea la integridad de los datos a insertar en la tabla FUNCIONALIDADES_ROLES
CREATE TRIGGER KFC.rol_nueva_funcionalidad
ON KFC.funcionalidades_roles
INSTEAD OF INSERT AS
	IF NOT EXISTS (SELECT * FROM KFC.roles WHERE rol_id = (SELECT rol_id FROM inserted))
	BEGIN
		RAISERROR ('No existe el rol a insertar en la tabla de relacion', 16, 1);
		RETURN
	END

	IF NOT EXISTS (SELECT * FROM KFC.funcionalidades WHERE func_id = (SELECT func_id FROM inserted))
		BEGIN
			RAISERROR ('No existe la funcionalidad a asociar en la tabla de relacion', 16, 1);
		RETURN
	END

	INSERT INTO KFC.funcionalidades_roles(rol_id, func_id)
	SELECT rol_id, func_id
	FROM inserted;

GO
---------------------------------------------------------------------------

-- Se chequea la integridad de los datos para habilitar/deshabilitar un rol --
CREATE TRIGGER KFC.existe_rol_habilitar_deshabilitar
ON KFC.roles
INSTEAD OF UPDATE AS
	IF NOT EXISTS (SELECT * FROM KFC.roles r, inserted i WHERE r.rol_id = i.rol_id )
	BEGIN
		RAISERROR ('No existe el rol a habilitar/deshabilitar', 16, 1);
		RETURN
	END

	UPDATE KFC.roles SET habilitado = i.habilitado
	FROM	KFC.roles r
		INNER JOIN	inserted i
		ON	r.rol_id = i.rol_id
GO
---------------------------------------------------------------------------

/*
-- Todavía no funciona - aclarar el tema del ID de los afiliados --
CREATE TRIGGER KFC.existe_afiliado_principal
ON KFC.afiliados
INSTEAD OF INSERT AS

DECLARE @afil_id int;
DECLARE @afil_id_base int;
SELECT @afil_id = afil_id FROM inserted;

IF @afil_id NOT LIKE '%01'
BEGIN
	SELECT @afil_id_base = @afil_id/100;
	IF EXISTS (SELECT * FROM KFC.afiliados WHERE afil_id = (@afil_id_base*100+1)
				AND personas_a_car IS NOT NULL)
		BEGIN TRANSACTION
			INSERT INTO KFC.afiliados
			SELECT * FROM inserted;
		COMMIT;
END
ELSE
BEGIN
	RAISERROR ('No existe el afiliado principal', 16, 1);
	RETURN
END;
GO
---------------------------------------------------------------------------
*/

-- Trigger para chequear el insert en la agenda --
CREATE TRIGGER KFC.nueva_agenda_profesional
ON KFC.agenda
INSTEAD OF INSERT AS
IF NOT EXISTS (SELECT * FROM KFC.profesionales 
	WHERE prof_id = (SELECT prof_id FROM inserted))
	BEGIN
		RAISERROR ('No existe el profesional indicado', 16, 1);
		RETURN
	END;
IF NOT EXISTS (SELECT * FROM KFC.especialidades 
	WHERE espe_id = (SELECT espe_id FROM inserted))
	BEGIN
		RAISERROR ('No existe la especialidad indicada', 16, 1);
		RETURN
	END;
IF NOT EXISTS (SELECT * FROM KFC.especialidades_profesional 
	WHERE espe_id = (SELECT espe_id FROM inserted) AND prof_id = (SELECT prof_id FROM inserted))
	BEGIN
		RAISERROR ('El profesional no tiene la especialidad indicada', 16, 1);
		RETURN
	END;
IF ((SELECT fecha_desde from inserted) > (SELECT fecha_hasta from inserted))
	BEGIN
		RAISERROR ('La fecha de inicio no puede ser mayor a la del final', 16, 1);
		RETURN
	END;
IF ((SELECT hora_desde from inserted) > (SELECT hora_hasta from inserted))
	BEGIN
		RAISERROR ('La hora de inicio no puede ser mayor a la del final', 16, 1);
		RETURN
	END;

	INSERT INTO KFC.agenda(espe_id, prof_id, dia, fecha_desde, fecha_hasta, hora_desde, hora_hasta)
	VALUES(
	 (SELECT espe_id FROM inserted), 
	 (SELECT prof_id FROM inserted), 
	 (SELECT dia FROM inserted), 
	 (SELECT fecha_desde FROM inserted), 
	 (SELECT fecha_hasta FROM inserted), 
	 (SELECT hora_desde FROM inserted), 
	 (SELECT hora_hasta FROM inserted)
	 );
GO
---------------------------------------------------------------------------

-- Trigger para chequear la informacion del bono --
CREATE TRIGGER KFC.nuevo_bono
ON KFC.bonos
INSTEAD OF INSERT AS
IF NOT EXISTS (SELECT * FROM KFC.afiliados a INNER JOIN inserted i ON a.afil_id = i.afil_id )
BEGIN
	RAISERROR ('No existe el afiliado que intenta comprar el bono', 16, 1);
	RETURN
END;
IF NOT EXISTS (SELECT * FROM KFC.planes p INNER JOIN inserted i ON p.plan_id = i.plan_id)
BEGIN
	RAISERROR ('No existe el plan para el cual se compra el bono', 16, 1);
	RETURN
END;

INSERT INTO KFC.bonos(afil_id, plan_id, consumido, fecha_compra, fecha_impresion)
	VALUES(
	 (SELECT afil_id FROM inserted),
	 (SELECT plan_id FROM inserted), 
	 (SELECT consumido FROM inserted), 
	 (SELECT fecha_compra FROM inserted), 
	 (SELECT fecha_impresion FROM inserted)
	 );
GO

/* TRIGGER NO NECESARIO
---------------------------------------------------------------------------
-- Trigger para chequear la fecha de la impresion del bono --
CREATE TRIGGER KFC.impresion_bono
ON KFC.bonos
INSTEAD OF UPDATE AS

IF UPDATE(fecha_impresion)
BEGIN
	IF((SELECT fecha_impresion FROM inserted) < (SELECT fecha_compra FROM inserted))
	BEGIN
		RAISERROR ('La fecha de impresión no puede ser anterior a la fecha de la compra del bono', 16, 1);
		RETURN
	END;
END

ARREGLAR
GO
*/
---------------------------------------------------------------------------

-- Trigger para chequear la informacion del turno --
CREATE TRIGGER KFC.nuevo_turno
ON KFC.turnos
INSTEAD OF INSERT AS
IF NOT EXISTS (SELECT * FROM KFC.afiliados WHERE afil_id = (SELECT afil_id FROM inserted))
BEGIN
	RAISERROR ('No existe el afiliado que intenta solicitar el turno', 16, 1);
	RETURN
END;
IF NOT EXISTS (SELECT * FROM KFC.profesionales 
	WHERE prof_id = (SELECT prof_id FROM inserted))
	BEGIN
		RAISERROR ('No existe el profesional indicado', 16, 1);
		RETURN
	END;
IF NOT EXISTS (SELECT * FROM KFC.especialidades 
	WHERE espe_id = (SELECT espe_id FROM inserted))
	BEGIN
		RAISERROR ('No existe la especialidad indicada', 16, 1);
		RETURN
	END;
IF NOT EXISTS (SELECT * FROM KFC.especialidades_profesional 
	WHERE espe_id = (SELECT espe_id FROM inserted) AND prof_id = (SELECT prof_id FROM inserted))
	BEGIN
		RAISERROR ('El profesional no tiene la especialidad indicada', 16, 1);
		RETURN
	END;

INSERT INTO KFC.turnos(afil_id, espe_id, prof_id, fecha_hora, hora)
	VALUES(
	 (SELECT afil_id FROM inserted), 
	 (SELECT espe_id FROM inserted), 
	 (SELECT prof_id FROM inserted),
	 (SELECT fecha_hora FROM inserted), 
	 (SELECT hora FROM inserted)
	 );
GO
---------------------------------------------------------------------------


PRINT 'TRIGGERS CREADOS'
PRINT '------------------'
PRINT 'Fin Script'