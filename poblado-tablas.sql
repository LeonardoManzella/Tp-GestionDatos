-- Insercion Usuarios y Roles del Enunciado
DECLARE @true BIT
SET @true = 1


INSERT INTO KFC.roles(descripcion, habilitado) VALUES ('afiliado', @true)
INSERT INTO KFC.roles(descripcion, habilitado) VALUES ('profesional', @true)
INSERT INTO KFC.roles(descripcion, habilitado) VALUES ('administrativo', @true)

INSERT INTO KFC.usuarios(nick,pass,habilitado) VALUES ('admin', 'w23e', @true)


--Para Planes
SET IDENTITY_INSERT KFC.planes ON
INSERT INTO KFC.planes (plan_id, descripcion, cuota, precio_bono_consulta, precio_bono_farmacia)
SELECT DISTINCT
       Plan_Med_Codigo
      ,Plan_Med_Descripcion
	  , 0		--FIXME De donde Saco datos para Calcular la "Cuota" de cada plan?
      ,Plan_Med_Precio_Bono_Consulta
      ,Plan_Med_Precio_Bono_Farmacia
  FROM GD2C2016.gd_esquema.Maestra
  ORDER BY Plan_Med_Codigo
SET IDENTITY_INSERT KFC.planes OFF


--Para Afiliados
INSERT INTO KFC.afiliados (tipo_doc,numero_doc,nombre, apellido, direccion, telefono, mail, fecha_nacimiento, plan_id, habilitado)
SELECT DISTINCT
	'DNI'
	, Paciente_Dni
	, Paciente_Nombre
	, Paciente_Apellido
	, Paciente_Direccion
	, Paciente_Telefono
	, Paciente_Mail
	, Paciente_Fecha_Nac
	, Plan_Med_Codigo
	, @true
FROM GD2C2016.gd_esquema.Maestra
ORDER BY Paciente_Dni
 



--Para Profesionales
INSERT INTO KFC.profesionales
SELECT DISTINCT
	Medico_Dni
	, Medico_Nombre
	, Medico_Apellido
	, Medico_Direccion
	, Medico_Telefono
	, Medico_Mail
	, Medico_Fecha_Nac
FROM GD2C2016.gd_esquema.Maestra
WHERE Medico_Dni IS NOT NULL
ORDER BY Medico_Dni
 



--Para Tipos Especialidades
INSERT INTO KFC.tipos_especialidades
SELECT DISTINCT
	Tipo_Especialidad_Codigo
	, Tipo_Especialidad_Descripcion
FROM GD2C2016.gd_esquema.Maestra
WHERE Tipo_Especialidad_Codigo IS NOT NULL
ORDER BY Tipo_Especialidad_Codigo
 


--Para Especialidades
INSERT INTO KFC.especialidades
SELECT DISTINCT
	Especialidad_Codigo
	, Especialidad_Descripcion
	, Tipo_Especialidad_Codigo
FROM GD2C2016.gd_esquema.Maestra
WHERE Especialidad_Codigo IS NOT NULL
ORDER BY Especialidad_Codigo
 



--Para Especialidad Profesional
--El ID necesito obtenerlo de la nueva tabla, no puedo obtenerlo de la vieja porque el ID se genera en la nueva tabla.
INSERT INTO KFC.especialidades_profesional
SELECT DISTINCT
	m.Especialidad_Codigo
	, p.prof_id
FROM GD2C2016.gd_esquema.Maestra m, GD2C2016.KFC.profesionales p
WHERE m.Especialidad_Codigo IS NOT NULL 
	AND m.Medico_Nombre = p.nombre
	AND m.Medico_Apellido = p.apellido
ORDER BY m.Especialidad_Codigo
 


--Para la Agenda
-- Link CONVERT: https://msdn.microsoft.com/en-us/library/ms187928.aspx
INSERT INTO KFC.agenda
SELECT DISTINCT 
		m.Especialidad_Codigo
        , p.prof_id
        , DATEPART(WEEKDAY, m.Turno_Fecha)                AS dia_semana
        , MIN( CONVERT(VARCHAR(20), m.Turno_Fecha,112) ) AS fecha_desde		--Convierto Fecha a Formato Varchar YYYY/MM/DD
        , MAX( CONVERT(VARCHAR(20), m.Turno_Fecha,112) ) AS fecha_hasta
        , MIN( CONVERT(VARCHAR(20), m.Turno_Fecha,108) ) AS hora_desde		--Convierto Fecha a Formato Varchar HH:MM:SS
        , MAX( CONVERT(VARCHAR(20), m.Turno_Fecha,108) ) AS hora_hasta
FROM
          GD2C2016.gd_esquema.Maestra m
        , GD2C2016.KFC.profesionales  p
WHERE
          m.Especialidad_Codigo IS NOT NULL
          AND m.Turno_Fecha     IS NOT NULL
          AND m.Medico_Nombre     = p.nombre
          AND m.Medico_Apellido           = p.apellido
GROUP BY
			Especialidad_Codigo
          , p.prof_id
			,m.Turno_Fecha 
 



--Para Tipos Cancelaciones
--TODO Insertar los 2 tipos
INSERT INTO KFC.tipos_cancelaciones	Values('Por Usuario')
INSERT INTO KFC.tipos_cancelaciones	Values('Por Medico')


--Para Turnos
--El ID necesito obtenerlo de la nueva tabla, no puedo obtenerlo de la vieja porque el ID se genera en la nueva tabla.
INSERT INTO KFC.turnos
SELECT DISTINCT
	m.Turno_Numero
	, m.Turno_Fecha
	, CONVERT(VARCHAR(20), m.Turno_Fecha,108)  AS hora
	, a.afil_id
	, p.prof_id
FROM GD2C2016.gd_esquema.Maestra  m, GD2C2016.KFC.afiliados  a, GD2C2016.KFC.profesionales  p
WHERE	m.Turno_Numero IS NOT NULL
		AND m.Paciente_Nombre = a.nombre
		AND m.Paciente_Apellido = a.apellido
		AND m.Medico_Nombre     = p.nombre
        AND m.Medico_Apellido   = p.apellido
ORDER BY m.Turno_Numero
 




--Para Bonos
--El ID necesito obtenerlo de la nueva tabla, no puedo obtenerlo de la vieja porque el ID se genera en la nueva tabla.
INSERT INTO KFC.bonos
SELECT DISTINCT
	m.Bono_Consulta_Numero
	, a.afil_id
	, m.Plan_Med_Codigo
	, m.Compra_Bono_Fecha
	, m.Bono_Consulta_Fecha_Impresion
FROM GD2C2016.gd_esquema.Maestra  m, GD2C2016.KFC.afiliados  a
WHERE	m.Compra_Bono_Fecha IS NOT NULL
		AND m.Bono_Consulta_Numero IS NOT NULL
		AND m.Paciente_Nombre = a.nombre
		AND m.Paciente_Apellido = a.apellido 
ORDER BY m.Bono_Consulta_Numero
 





--Para Atenciones
INSERT INTO KFC.atenciones
SELECT DISTINCT
	Turno_Numero
	, Bono_Consulta_Fecha_Impresion			--Considero la Fecha de Impresion del Bono como la de la Atencion
	, Consulta_Sintomas
	, Consulta_Enfermedades
	, Bono_Consulta_Numero
FROM GD2C2016.gd_esquema.Maestra
WHERE Turno_Numero IS NOT NULL
AND Bono_Consulta_Numero IS NOT NULL
ORDER BY Turno_Numero
 
