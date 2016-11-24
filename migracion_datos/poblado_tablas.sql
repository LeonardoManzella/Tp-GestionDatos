PRINT 'POBLANDO TABLAS...'

DECLARE @true BIT
SET @true = 1

-- Insercion Estados Civiles del Enunciado
PRINT '- Llenando Tabla estado_civil...'
INSERT INTO KFC.estado_civil(descripcion) VALUES ('SOLTERO/A')
INSERT INTO KFC.estado_civil(descripcion) VALUES ('CASADO/A')
INSERT INTO KFC.estado_civil(descripcion) VALUES ('VIUDO/A')
INSERT INTO KFC.estado_civil(descripcion) VALUES ('CONCUBINATO')
INSERT INTO KFC.estado_civil(descripcion) VALUES ('DIVORCIADO/A')
INSERT INTO KFC.estado_civil(descripcion) VALUES ('MIGRADO')			--Para los Datos de la Tabla Maestra

-- Insercion Funcionalidades
PRINT '- Llenando Tabla funcionalidades...'
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('ALTA_AFILIADO')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('MODIFICAR_AFILIADO')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('BAJA_AFILIADO')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('PEDIR_TURNO')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('CANCELAR_TURNO')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('COMPRAR_BONO')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('CREAR_AGENDA')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('CANCELAR_TURNOS_AGENDA')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('REGISTRAR_LLEGADA')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('REGISTRAR_DIAGNOSTICO')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('CREAR_ROL')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('MODIFICAR_ROL')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('COMPRA_BONO_ADMINISTRADOR')
INSERT INTO KFC.funcionalidades(descripcion) VALUES ('ESTADISTICAS')

-- Insercion Roles del Enunciado
PRINT '- Llenando Tabla roles...'
INSERT INTO KFC.roles(descripcion, habilitado) VALUES ('AFILIADO', @true)
INSERT INTO KFC.roles(descripcion, habilitado) VALUES ('PROFESIONAL', @true)
INSERT INTO KFC.roles(descripcion, habilitado) VALUES ('ADMINISTRATIVO', @true)

-- Insercion Funcionalidades por Roles
PRINT '- Llenando Tabla funcionalidades_roles...'
INSERT INTO KFC.funcionalidades_roles(rol_id, func_id)
SELECT	r.rol_id, f.func_id
FROM	KFC.roles R,
		KFC.funcionalidades F
WHERE	R.descripcion = 'AFILIADO'
--Uso un OR para no crear multiples Insert
AND		(
		F.descripcion    = 'PEDIR_TURNO'
		OR F.descripcion = 'COMPRAR_BONO'
		OR F.descripcion = 'CANCELAR_TURNO'
		)

INSERT INTO KFC.funcionalidades_roles(rol_id, func_id)
SELECT	r.rol_id, f.func_id
FROM	KFC.roles R,
		KFC.funcionalidades F
WHERE	R.descripcion = 'PROFESIONAL'
--Uso un OR para no crear multiples Insert
AND		(
		F.descripcion	 = 'CREAR_AGENDA'
		OR F.descripcion = 'CANCELAR_TURNOS_AGENDA'
		OR F.descripcion = 'REGISTRAR_LLEGADA'
		OR F.descripcion = 'REGISTRAR_DIAGNOSTICO'
		)

INSERT INTO KFC.funcionalidades_roles(rol_id, func_id)
SELECT	r.rol_id, f.func_id
FROM	KFC.roles R,
		KFC.funcionalidades F
WHERE	R.descripcion = 'ADMINISTRATIVO'
--Uso un OR para no crear multiples Insert
AND		(
		F.descripcion	 = 'ALTA_AFILIADO'
		OR F.descripcion = 'MODIFICAR_AFILIADO'
		OR F.descripcion = 'BAJA_AFILIADO'
		OR F.descripcion = 'CREAR_ROL'
		OR F.descripcion = 'MODIFICAR_ROL'
		OR F.descripcion = 'COMPRA_BONO_ADMINISTRADOR'
		OR F.descripcion = 'ESTADISTICAS'
		)



-- Insercion Usuarios del Enunciado
PRINT '- Llenando Tabla usuarios...'
INSERT INTO KFC.usuarios(nick,pass,habilitado) VALUES ('ADMIN', HASHBYTES('SHA2_256','W23E'), @true)

--Agrego Usuarios para Afiliados, pedido por el Enunciado
INSERT INTO KFC.usuarios
          (
			  nick 
			, pass 
			, habilitado
          )
SELECT DISTINCT  UPPER(Paciente_Mail)
        ,  HASHBYTES('SHA2_256',UPPER(Paciente_Mail)) AS pass
        , @true AS habilitado
FROM
          GD2C2016.gd_esquema.Maestra
WHERE
          Paciente_Mail IS NOT NULL


--Agrego Usuarios para Profesionales, pedido por el Enunciado
INSERT INTO KFC.usuarios
          (
			  nick 
			, pass 
			, habilitado
          )
SELECT DISTINCT  UPPER(Medico_Mail)
        ,  HASHBYTES('SHA2_256',UPPER(Medico_Mail)) AS pass
        , @true AS habilitado
FROM
          GD2C2016.gd_esquema.Maestra
WHERE
          Medico_Mail IS NOT NULL


-- Insercion Roles por Usuario
PRINT '- Llenando Tabla roles_usuarios...'
INSERT INTO KFC.roles_usuarios
          (
			  us_id
			, rol_id
          )
SELECT
          u.us_id
        , r.rol_id
FROM
          KFC.usuarios u
        , KFC.roles    r
WHERE
        UPPER(r.descripcion) =   UPPER('ADMINISTRATIVO')
        AND   UPPER(u.nick)    =   UPPER('ADMIN')


-- Insercion Roles para Afiliados
INSERT INTO KFC.roles_usuarios
          (
			  us_id
			, rol_id
          )
SELECT DISTINCT
          u.us_id
        , r.rol_id
FROM
          KFC.usuarios u
        , KFC.roles    r
WHERE
          UPPER(r.descripcion) = UPPER('AFILIADO')
		  -- Selecciono Solo los Afiliados
          AND u.nick IN (
							SELECT DISTINCT Paciente_Mail
							FROM
										GD2C2016.gd_esquema.Maestra
							WHERE
										Paciente_Mail IS NOT NULL
						)
ORDER BY  u.us_id


-- Insercion Roles para Profesionales
INSERT INTO KFC.roles_usuarios
          (
			  us_id
			, rol_id
          )
SELECT DISTINCT 
		  u.us_id
        , r.rol_id
FROM
          KFC.usuarios u
        , KFC.roles    r
WHERE
          UPPER(r.descripcion) = UPPER('PROFESIONAL')
		  -- Selecciono Solo los Profesionales
          AND u.nick IN (
							SELECT DISTINCT Medico_Mail
							FROM
										GD2C2016.gd_esquema.Maestra
							WHERE
										Medico_Mail IS NOT NULL
						)
ORDER BY
          u.us_id



--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Planes
-- El IDENTITY_INSERT me permite introducir manualmente claves donde seria autoincrementable
-- Link IDENTITY_INSERT: https://www.mssqltips.com/sqlservertutorial/2521/insert-into-sql-server-table-with-identity-column/
PRINT '- Llenando Tabla planes...'
SET IDENTITY_INSERT KFC.planes ON
INSERT INTO KFC.planes
          (
                    plan_id
                  , descripcion
                  , precio_bono_consulta
                  , precio_bono_farmacia
          )
SELECT DISTINCT Plan_Med_Codigo
        ,  UPPER(Plan_Med_Descripcion)
        , Plan_Med_Precio_Bono_Consulta
        , Plan_Med_Precio_Bono_Farmacia
FROM
          GD2C2016.gd_esquema.Maestra
ORDER BY
          Plan_Med_Codigo
SET IDENTITY_INSERT KFC.planes OFF


--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Afiliados
PRINT '- Llenando Tabla afiliados...'
INSERT INTO KFC.afiliados
          (
                    tipo_doc
                  , numero_doc
                  , nombre
                  , apellido
				  , sexo
                  , direccion
                  , telefono
                  , mail
                  , fecha_nacimiento
                  , plan_id
				  , us_id
				  , estado_id
                  , habilitado
          )
SELECT DISTINCT 'DNI' AS Tipo_Doc
        , m.Paciente_Dni
        ,  UPPER(m.Paciente_Nombre)
        ,  UPPER(m.Paciente_Apellido)
		, 'P'								-- P de Pendiente
        ,  UPPER(m.Paciente_Direccion)
        , m.Paciente_Telefono
        ,  UPPER(m.Paciente_Mail)
        , m.Paciente_Fecha_Nac
        , m.Plan_Med_Codigo
		, u.us_id
		, e.estado_id
        , @true AS habilitado
FROM
          GD2C2016.gd_esquema.Maestra m
		  , KFC.usuarios u
		  , KFC.estado_civil e
WHERE
			Paciente_Dni IS NOT NULL
			AND m.Paciente_Mail = u.nick
			AND e.descripcion = 'MIGRADO'
ORDER BY
          u.us_id



--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Profesionales
PRINT '- Llenando Tabla profesionales...'
INSERT INTO KFC.profesionales
          (
                    tipo_doc
                  , numero_doc
                  , nombre
                  , apellido
                  , direccion
                  , telefono
                  , mail
                  , fecha_nacimiento
				  , us_id
                  , habilitado
          )
SELECT DISTINCT 'DNI' AS Tipo_Doc
        , m.Medico_Dni
        ,  UPPER(m.Medico_Nombre)
        ,  UPPER(m.Medico_Apellido)
        ,  UPPER(m.Medico_Direccion)
        , m.Medico_Telefono
        ,  UPPER(m.Medico_Mail)
        , m.Medico_Fecha_Nac
		, u.us_id
        , @true AS habilitado
FROM
          GD2C2016.gd_esquema.Maestra m
		  , KFC.usuarios u
WHERE
          Medico_Dni IS NOT NULL
		  AND m.Medico_Mail = u.nick
ORDER BY
          u.us_id
 



--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Tipos Especialidades
PRINT '- Llenando Tabla tipos_especialidades...'
SET IDENTITY_INSERT KFC.tipos_especialidades ON
INSERT INTO KFC.tipos_especialidades
          (
			tipo_esp_id
			, descripcion
          )
SELECT DISTINCT Tipo_Especialidad_Codigo
        ,  UPPER(Tipo_Especialidad_Descripcion)
FROM
          GD2C2016.gd_esquema.Maestra
WHERE
          Tipo_Especialidad_Codigo IS NOT NULL
ORDER BY
          Tipo_Especialidad_Codigo
SET IDENTITY_INSERT KFC.tipos_especialidades OFF



--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Especialidades
PRINT '- Llenando Tabla especialidades...'
SET IDENTITY_INSERT KFC.especialidades ON
INSERT INTO KFC.especialidades
          (
		      espe_id
			, descripcion
			, tipo_esp_id
          )
SELECT DISTINCT Especialidad_Codigo
        ,  UPPER(Especialidad_Descripcion)
        , Tipo_Especialidad_Codigo
FROM
          GD2C2016.gd_esquema.Maestra
WHERE
          Especialidad_Codigo IS NOT NULL
ORDER BY
          Especialidad_Codigo
SET IDENTITY_INSERT KFC.especialidades OFF
 



--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Especialidad Profesional
--El ID de profesional necesito obtenerlo de la nueva tabla, no puedo obtenerlo de la vieja porque el ID se genera en la nueva tabla.De ahi que halla tantas condiciones de JOIN en el WHERE, estoy haciendolo a mano
PRINT '- Llenando Tabla especialidades_profesional...'
INSERT INTO KFC.especialidades_profesional
          (
		     espe_id
		   , prof_id
          )
SELECT DISTINCT 
		  m.Especialidad_Codigo
        , p.prof_id
FROM
          GD2C2016.gd_esquema.Maestra m
        , KFC.profesionales           p
WHERE
          m.Especialidad_Codigo IS NOT NULL
          AND m.Medico_Nombre             = p.nombre
          AND m.Medico_Apellido           = p.apellido
          AND m.Medico_Dni                = p.numero_doc
ORDER BY
          m.Especialidad_Codigo
 



------------------------------------------------------------------
--Tomo Datos de Tabla Maestra y los Inserto en Tabla  la Agenda
--
--El ID de Profesional necesito obtenerlo de la nueva tabla, no puedo obtenerlo de la vieja porque el ID se genera en la nueva tabla.De ahi que halla tantas condiciones de JOIN en el WHERE, estoy haciendolo a mano
--Este codigo es complicado, pero basicamente lo que hago es calcular los rangos de horarios usando funciones de sumarizacion
--No se preocupen tanto por las conversiones y calculos, las hace y funciona bien. Lo comprobe manualmente.
--Link CONVERT: https://msdn.microsoft.com/en-us/library/ms187928.aspx
------------------------------------------------------------------
PRINT '- Llenando Tabla agenda...'
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
SELECT DISTINCT 
		  m.Especialidad_Codigo
        , p.prof_id
        , DATEPART(WEEKDAY, m.Turno_Fecha)       AS dia_semana
        , MIN( m.Turno_Fecha )                   AS fecha_desde
        , MAX( m.Turno_Fecha )                   AS fecha_hasta
        , MIN( CONVERT(TIME(0), m.Turno_Fecha) ) AS hora_desde
        , MAX( CONVERT(TIME(0), m.Turno_Fecha) ) AS hora_hasta
FROM
          GD2C2016.gd_esquema.Maestra m
        , KFC.profesionales           p
WHERE
          m.Especialidad_Codigo IS NOT NULL
          AND m.Turno_Fecha     IS NOT NULL
          AND m.Medico_Nombre             = p.nombre
          AND m.Medico_Apellido           = p.apellido
          AND m.Medico_Dni                = p.numero_doc
GROUP BY
          Especialidad_Codigo
        , p.prof_id
        , DATEPART(WEEKDAY, m.Turno_Fecha)

--Dato Extra Nuestro para Pruebas
PRINT '- Llenando Tabla agenda...'
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
SELECT DISTINCT 
		  e.espe_id
        , p.prof_id
        , DATEPART(WEEKDAY,  CONVERT( DATETIME, '2016.01.01', 102) )       AS dia_semana
        , CONVERT( DATETIME, '2016.01.01', 102)                   AS fecha_desde
        , CONVERT( DATETIME, '2016.01.30', 102)                   AS fecha_hasta
        , CONVERT(TIME(0), '10:00:00', 108) AS hora_desde
        , CONVERT(TIME(0), '12:00:00', 108) AS hora_hasta
FROM
          KFC.especialidades	e
        , KFC.profesionales     p
WHERE
          UPPER('ALERGOLOGÍA')	= UPPER(e.descripcion)
          AND	UPPER('LARA')		=  UPPER(p.nombre)
          AND	UPPER('GIMÉNEZ')		=  UPPER(p.apellido)



--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Tipos Cancelaciones
PRINT '- Llenando Tabla tipos_cancelaciones...'
INSERT INTO KFC.tipos_cancelaciones	Values('Por Usuario')
INSERT INTO KFC.tipos_cancelaciones	Values('Por Medico')


--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Turnos
--El ID de profesional, especialidad y afiliado necesito obtenerlo de la nueva tabla, no puedo obtenerlo de la vieja porque el ID se genera en la nueva tabla. De ahi que halla tantas condiciones de JOIN en el WHERE, estoy haciendolo a mano
PRINT '- Llenando Tabla turnos...'
SET IDENTITY_INSERT KFC.turnos ON
INSERT INTO KFC.turnos
          (
			    turno_id
			  , fecha_hora
			  , hora
			  , afil_id
			  , espe_id
			  , prof_id
          )
SELECT DISTINCT m.Turno_Numero
        , m.Turno_Fecha
        , CONVERT(TIME(0), m.Turno_Fecha) AS hora		--Covierto Formato Datos
        , a.afil_id
        , m.Especialidad_Codigo
        , p.prof_id
FROM
          GD2C2016.gd_esquema.Maestra m
        , KFC.afiliados               a
        , KFC.profesionales           p
WHERE
          m.Turno_Numero IS NOT NULL
          AND m.Paciente_Nombre    = a.nombre
          AND m.Paciente_Apellido  = a.apellido
          AND m.Paciente_Dni       = a.numero_doc
          AND m.Medico_Nombre      = p.nombre
          AND m.Medico_Apellido    = p.apellido
          AND m.Medico_Dni         = p.numero_doc
ORDER BY
          m.Turno_Numero
SET IDENTITY_INSERT KFC.turnos OFF
 




--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Bonos
--El ID  de plan y afiliado necesito obtenerlo de la nueva tabla, no puedo obtenerlo de la vieja porque el ID se genera en la nueva tabla.--El ID necesito obtenerlo de la nueva tabla, no puedo obtenerlo de la vieja porque el ID se genera en la nueva tabla.De ahi que halla tantas condiciones de JOIN en el WHERE, estoy haciendolo a mano
PRINT '- Llenando Tabla bonos...'
SET IDENTITY_INSERT KFC.bonos ON
INSERT INTO KFC.bonos
          (
			    bono_id
			  , afil_id
			  , plan_id
			  , fecha_compra
			  , fecha_impresion
          )
SELECT DISTINCT m.Bono_Consulta_Numero
        , a.afil_id
        , m.Plan_Med_Codigo
        , m.Compra_Bono_Fecha
        , m.Bono_Consulta_Fecha_Impresion
FROM
          GD2C2016.gd_esquema.Maestra m
        , KFC.afiliados               a
WHERE
          m.Compra_Bono_Fecha        IS NOT NULL
          AND m.Bono_Consulta_Numero IS NOT NULL
          AND m.Paciente_Nombre                = a.nombre
          AND m.Paciente_Apellido              = a.apellido
          AND m.Paciente_Dni                   = a.numero_doc
ORDER BY
          m.Bono_Consulta_Numero
SET IDENTITY_INSERT KFC.bonos OFF





--Tomo Datos de Tabla Maestra y los Inserto en Tabla  Atenciones
PRINT '- Llenando Tabla atenciones...'
INSERT INTO KFC.atenciones
          (
			    turno_id
			  , hora_llegada
			  , sintomas
			  , diagnostico
			  , bono_id
          )
SELECT DISTINCT Turno_Numero
        , Bono_Consulta_Fecha_Impresion --Considero la Fecha de la Impresion del Bono como la de la Atencion (unicamente para Turnos Migrados), Ya que consideramos que el Bono se Imprime al momento de su uso (en el sistema anterior)
        ,  UPPER(Consulta_Sintomas)
        ,  UPPER(Consulta_Enfermedades)
        , Bono_Consulta_Numero
FROM
          GD2C2016.gd_esquema.Maestra
WHERE
          Turno_Numero             IS NOT NULL
          AND Bono_Consulta_Numero IS NOT NULL
ORDER BY
          Turno_Numero
 
 PRINT 'TABLAS POBLADAS'