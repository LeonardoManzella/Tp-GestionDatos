DECLARE @true BIT
SET @true = 1

-- Insercion Estados Civiles del Enunciado
INSERT INTO KFC.estado_civil(descripcion) VALUES ('Soltero/a')
INSERT INTO KFC.estado_civil(descripcion) VALUES ('Casado/a')
INSERT INTO KFC.estado_civil(descripcion) VALUES ('Viudo/a')
INSERT INTO KFC.estado_civil(descripcion) VALUES ('Concubinato')
INSERT INTO KFC.estado_civil(descripcion) VALUES ('Divorciado/a')

-- Insercion Funcionalidades


-- Insercion Roles del Enunciado
INSERT INTO KFC.roles(descripcion, habilitado) VALUES ('afiliado', @true)
INSERT INTO KFC.roles(descripcion, habilitado) VALUES ('profesional', @true)
INSERT INTO KFC.roles(descripcion, habilitado) VALUES ('administrativo', @true)

-- Insercion Funcionalidades por Roles


-- Insercion Usuarios del Enunciado
INSERT INTO KFC.usuarios(nick,pass,habilitado) VALUES ('admin', 'w23e', @true)

--TODO Agrego Usuarios para Afiliados, pedido por el Enunciado

--TODO Agrego Usuarios para Profesionales, pedido por el Enunciado


-- Insercion Roles por Usuario
INSERT INTO KFC.roles_usuarios
          (us_id, rol_id
          )
SELECT
          u.us_id
        , r.rol_id
FROM
          KFC.usuarios u
        , KFC.roles    r
WHERE
          r.descripcion = 'administrativo'
          AND u.nick    = 'admin'



--Para Planes
-- El IDENTITY_INSERT me permite introducir manualmente claves donde seria autoincrementable
-- Link IDENTITY_INSERT: https://www.mssqltips.com/sqlservertutorial/2521/insert-into-sql-server-table-with-identity-column/
SET IDENTITY_INSERT KFC.planes ON
INSERT INTO KFC.planes
          (
                    plan_id
                  , descripcion
                  , cuota
                  , precio_bono_consulta
                  , precio_bono_farmacia
          )
SELECT DISTINCT Plan_Med_Codigo
        , Plan_Med_Descripcion
        , 0 --FIXME De donde Saco datos para Calcular la "Cuota" de cada plan?
        , Plan_Med_Precio_Bono_Consulta
        , Plan_Med_Precio_Bono_Farmacia
FROM
          GD2C2016.gd_esquema.Maestra
ORDER BY
          Plan_Med_Codigo
SET IDENTITY_INSERT KFC.planes OFF


--Para Afiliados
INSERT INTO KFC.afiliados
          (
                    tipo_doc
                  , numero_doc
                  , nombre
                  , apellido
                  , direccion
                  , telefono
                  , mail
                  , fecha_nacimiento
                  , plan_id
                  , habilitado
          )
		  --TODO Modificar para que use ID Usuario ingresado al principio
SELECT DISTINCT 'DNI'
        , Paciente_Dni
        , Paciente_Nombre
        , Paciente_Apellido
        , Paciente_Direccion
        , Paciente_Telefono
        , Paciente_Mail
        , Paciente_Fecha_Nac
        , Plan_Med_Codigo
        , @true
FROM
          GD2C2016.gd_esquema.Maestra
ORDER BY
          Paciente_Dni



--Para Profesionales
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
                  , habilitado
          )
		  --TODO Modificar para que use ID Usuario ingresado al principio
SELECT DISTINCT 'DNI'
        , Medico_Dni
        , Medico_Nombre
        , Medico_Apellido
        , Medico_Direccion
        , Medico_Telefono
        , Medico_Mail
        , Medico_Fecha_Nac
        , @true
FROM
          GD2C2016.gd_esquema.Maestra
WHERE
          Medico_Dni IS NOT NULL
ORDER BY
          Medico_Dni
 



--Para Tipos Especialidades
SET IDENTITY_INSERT KFC.tipos_especialidades ON
INSERT INTO KFC.tipos_especialidades
          (
			tipo_esp_id
			, descripcion
          )
SELECT DISTINCT Tipo_Especialidad_Codigo
        , Tipo_Especialidad_Descripcion
FROM
          GD2C2016.gd_esquema.Maestra
WHERE
          Tipo_Especialidad_Codigo IS NOT NULL
ORDER BY
          Tipo_Especialidad_Codigo
SET IDENTITY_INSERT KFC.tipos_especialidades OFF



--Para Especialidades
SET IDENTITY_INSERT KFC.especialidades ON
INSERT INTO KFC.especialidades
          (espe_id, descripcion, tipo_esp_id
          )
SELECT DISTINCT Especialidad_Codigo
        , Especialidad_Descripcion
        , Tipo_Especialidad_Codigo
FROM
          GD2C2016.gd_esquema.Maestra
WHERE
          Especialidad_Codigo IS NOT NULL
ORDER BY
          Especialidad_Codigo
SET IDENTITY_INSERT KFC.especialidades OFF
 



--Para Especialidad Profesional
--El ID necesito obtenerlo de la nueva tabla, no puedo obtenerlo de la vieja porque el ID se genera en la nueva tabla.
INSERT INTO KFC.especialidades_profesional
          (espe_id, prof_id
          )
SELECT DISTINCT m.Especialidad_Codigo
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
 


--Para la Agenda
-- Link CONVERT: https://msdn.microsoft.com/en-us/library/ms187928.aspx
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
SELECT DISTINCT m.Especialidad_Codigo
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
 



--Para Tipos Cancelaciones
--TODO Insertar los 2 tipos
INSERT INTO KFC.tipos_cancelaciones	Values('Por Usuario')
INSERT INTO KFC.tipos_cancelaciones	Values('Por Medico')


--Para Turnos
--El ID necesito obtenerlo de la nueva tabla, no puedo obtenerlo de la vieja porque el ID se genera en la nueva tabla.
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
        , CONVERT(TIME(0), m.Turno_Fecha) AS hora
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
 




--Para Bonos
--El ID necesito obtenerlo de la nueva tabla, no puedo obtenerlo de la vieja porque el ID se genera en la nueva tabla.
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





--Para Atenciones
INSERT INTO KFC.atenciones
          (
			  turno_id
			  , hora_llegada
			  , sintomas
			  , diagnostico
			  , bono_id
          )
SELECT DISTINCT Turno_Numero
        , Turno_Fecha --Considero la Fecha del Turno como la de la Atencion (unicamente para Turnos Migrados)
        , Consulta_Sintomas
        , Consulta_Enfermedades
        , Bono_Consulta_Numero
FROM
          GD2C2016.gd_esquema.Maestra
WHERE
          Turno_Numero             IS NOT NULL
          AND Bono_Consulta_Numero IS NOT NULL
ORDER BY
          Turno_Numero
 
