PRINT 'Borrando Triggers...'

IF OBJECT_ID('KFC.existe_afiliado_principal') IS NOT NULL
DROP TRIGGER KFC.existe_afiliado_principal;
GO

IF OBJECT_ID('KFC.rol_nueva_funcionalidad') IS NOT NULL
DROP TRIGGER KFC.rol_nueva_funcionalidad;
GO

IF OBJECT_ID('KFC.existe_rol_habilitar_deshabilitar') IS NOT NULL
DROP TRIGGER KFC.existe_rol_habilitar_deshabilitar;
GO

IF OBJECT_ID('KFC.nueva_agenda_profesional') IS NOT NULL
DROP TRIGGER KFC.nueva_agenda_profesional;
GO

IF OBJECT_ID('KFC.impresion_bono') IS NOT NULL
DROP TRIGGER KFC.impresion_bono;
GO

IF OBJECT_ID('KFC.nuevo_turno') IS NOT NULL
DROP TRIGGER KFC.nuevo_turno;
GO

IF OBJECT_ID('KFC.nuevo_bono') IS NOT NULL
DROP TRIGGER KFC.nuevo_bono;
GO

PRINT 'Triggers Borrados'