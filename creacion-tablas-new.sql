/*	::::::::::::::::::::: ORDEN CREACION TABLAS :::::::::::::::::::::
	(De primero a ultimo, todos los nombres en minusculas para respetar Snake Case)
	
	usuarios
	roles
	roles_usuarios
	funcionalidades
	funcionalidades_roles
	
	planes
	afiliados
	historial_afiliados
	
	profesionales
	tipos_especialidades
	especialidades
	especialidades_profesional
	agenda
	
	tipos_cancelaciones
	cancelaciones
	turnos
	bonos
	atenciones
*/

CREATE SCHEMA kfc AUTHORIZATION gd GO

CREATE TABLE kfc.usuarios
          (
                    us_id      INT PRIMARY KEY IDENTITY(1,1)
                  , nick       VARCHAR(30) UNIQUE NOT NULL --No quiero poner valores muy grandes para evitar que pese mucho la base de datos y ande lenta, mejor que ande rapida para nosotros
                  , pass       VARCHAR(30) NOT NULL
                  , habilitado BIT NOT NULL
          )
          GO
CREATE TABLE kfc.roles
          (
                    rol_id      INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion VARCHAR(50) UNIQUE NOT NULL
                  , habilitado  BIT NOT NULL
          )
          GO
CREATE TABLE kfc.roles_usuarios
          (
                    us_id  INT NOT NULL REFERENCES usuarios
                  , rol_id INT NOT NULL REFERENCES roles
          )
          GO
CREATE TABLE kfc.funcionalidades
          (
                    func_id     INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion VARCHAR(50) UNIQUE NOT NULL
          )
          GO
CREATE TABLE kfc.funcionalidades_roles
          (
                    rol_id  INT NOT NULL REFERENCES roles
                  , func_id INT NOT NULL REFERENCES funcionalidades
          )
          GO
CREATE TABLE kfc.planes
          (
                    plan_id              INT PRIMARY KEY IDENTITY(1,1)
					, descripcion VARCHAR(50) NOT NULL
                  , cuota                NUMERIC(18,0)
                  , precio_bono_consulta NUMERIC(18,0) NOT NULL
                  , precio_bono_farmacia NUMERIC(18,0) NOT NULL
          )
          GO
CREATE TABLE kfc.estado_civil
          (
                    estado_id   INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion VARCHAR(50) UNIQUE NOT NULL
          )
          GO
CREATE TABLE kfc.afiliados
          (
                    afil_id          INT PRIMARY KEY IDENTITY(1,1)
                  , nombre           VARCHAR(50) NOT NULL
                  , apellido         VARCHAR(50) NOT NULL
                  , tipo_doc         VARCHAR(10) NOT NULL
                  , numero_doc       NUMERIC(18,0) NOT NULL
                  , direccion        VARCHAR(50) NULL
                  , telefono         NUMERIC(18, 0) NULL
                  , mail             VARCHAR(50) NULL
                  , sexo             CHAR NULL
                  , fecha_nacimiento DATETIME NOT NULL
                  , estado_id        INT NULL REFERENCES estado_civil
                  , habilitado       BIT NOT NULL
				  , personas_a_cargo			 INT NULL		-- Incluye conyuge, familiars mayores o cantidad hijos
                  , plan_id          INT NOT NULL REFERENCES planes
                  , us_id            INT NULL REFERENCES usuarios
          )
          GO
CREATE TABLE kfc.historial_afiliados
          (
                    afil_id       INT NOT NULL REFERENCES afiliados
                  , fecha         DATETIME
                  , plan_activo   INT NOT NULL REFERENCES planes
                  , motivo_cambio VARCHAR(30) NOT NULL
          )
          GO
CREATE TABLE kfc.profesionales
          (
                    prof_id          INT PRIMARY KEY IDENTITY(1,1)
                  , nombre           VARCHAR(50) NOT NULL
                  , apellido         VARCHAR(50) NOT NULL
                  , tipo_doc         VARCHAR(10) NOT NULL
                  , numero_doc       NUMERIC(18,0) NOT NULL
                  , direccion        VARCHAR(50) NULL
                  , telefono         NUMERIC(18, 0) NULL
                  , mail             VARCHAR(50) NULL
                  , fecha_nacimiento DATETIME NOT NULL
                  , matricula        VARCHAR(50) NULL
                  , us_id            INT NOT NULL REFERENCES usuarios
          )
          GO
CREATE TABLE kfc.tipos_especialidades
          (
                    tipo_esp_id INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion VARCHAR(50) UNIQUE NOT NULL
          )
          GO
CREATE TABLE kfc.especialidades
          (
                    espe_id     INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion VARCHAR(50) UNIQUE NOT NULL
                  , tipo_esp_id INT NOT NULL REFERENCES tipos_especialidades
          )
          GO
CREATE TABLE kfc.especialidades_profesional
          (
                    espe_id INT NOT NULL REFERENCES especialidades
                  , prof_id INT NOT NULL REFERENCES profesionales
          )
          GO
CREATE TABLE kfc.agenda
          (
                    espe_id     INT NOT NULL REFERENCES especialidades_profesional
                  , prof_id     INT NOT NULL REFERENCES especialidades_profesional
                  , hora_desde  TIME(0) -- 0 por Minima precicion Nanosegundos. No queremos tanta precicion
                  , hora_hasta  TIME(0)
                  , fecha_desde DATETIME
                  , fecha_hasta DATETIME
          )
          GO
CREATE TABLE kfc.turnos
          (
                    turno_id   INT PRIMARY KEY IDENTITY(1,1)
                  , fecha_hora DATETIME NOT NULL
				  , hora	   TIME(0)  NOT NULL
                  , afil_id    INT NOT NULL REFERENCES afiliados
                  , espe_id    INT NOT NULL REFERENCES especialidades_profesional
                  , prof_id    INT NOT NULL REFERENCES especialidades_profesional
          )
          GO
CREATE TABLE kfc.tipos_cancelaciones
          (
                    tipo_cancel_id INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion    VARCHAR(50) UNIQUE NOT NULL
          )
          GO
CREATE TABLE kfc.cancelaciones
          (
                    cancel_id      INT PRIMARY KEY IDENTITY(1,1)
                  , turno_id       INT NOT NULL REFERENCES turnos
                  , detalle_cancel VARCHAR(50) UNIQUE NOT NULL
				  , fecha_cancel   DATETIME
                  , tipo_cancel_id INT NOT NULL REFERENCES tipos_cancelaciones
          )
          GO
CREATE TABLE kfc.bonos
          (
                    bono_id INT PRIMARY KEY IDENTITY(1,1)
                  , plan_id INT NOT NULL REFERENCES planes
                  , afil_id INT NOT NULL REFERENCES afiliados
				  , fecha_compra DATETIME NOT NULL
				  , fecha_impresion DATETIME NULL
          ) 
          GO
CREATE TABLE kfc.atenciones
          (
                    atencion_id  INT PRIMARY KEY IDENTITY(1,1)
                  , turno_id     INT NOT NULL REFERENCES turnos
                  , hora_llegada TIME(0) NOT NULL -- 0 por Minima precicion Nanosegundos. No queremos tanta precicion
                  , sintomas     VARCHAR(50) UNIQUE NOT NULL
                  , diagnostico  VARCHAR(50) UNIQUE NOT NULL
                  , bono_id      INT NOT NULL REFERENCES bonos
          )
          GO