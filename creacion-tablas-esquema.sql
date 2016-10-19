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

CREATE SCHEMA KFC AUTHORIZATION gd

CREATE TABLE KFC.usuarios
          (
                    us_id      INT PRIMARY KEY IDENTITY(1,1)		--No hay que cambiarlo a secuencia? o sacarle el Identity porque lo manejariamos nosotros
                  , nick       VARCHAR(255) UNIQUE NOT NULL
                  , pass       VARCHAR(255) NOT NULL
                  , habilitado BIT NOT NULL
				  , intentos   INT NOT NULL DEFAULT 0
          )
		   
CREATE TABLE KFC.roles
          (
                    rol_id      INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion VARCHAR(255) UNIQUE NOT NULL
                  , habilitado  BIT NOT NULL
          )
           
CREATE TABLE KFC.roles_usuarios
          (
                    us_id  INT NOT NULL REFERENCES KFC.usuarios
                  , rol_id INT NOT NULL REFERENCES KFC.roles
				   ,CONSTRAINT pk_roles_usuarios PRIMARY KEY (us_id, rol_id)
          )
           
CREATE TABLE KFC.funcionalidades
          (
                    func_id     INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion VARCHAR(255) UNIQUE NOT NULL
          )
           
CREATE TABLE KFC.funcionalidades_roles
          (
                    rol_id  INT NOT NULL REFERENCES KFC.roles
                  , func_id INT NOT NULL REFERENCES KFC.funcionalidades
				  ,CONSTRAINT pk_funcionalidades_roles PRIMARY KEY (rol_id, func_id)
          )
           
CREATE TABLE KFC.planes
          (
                    plan_id              INT PRIMARY KEY IDENTITY(1,1)
					, descripcion VARCHAR(255) NOT NULL
                  , precio_bono_consulta NUMERIC(18,0) NOT NULL
                  , precio_bono_farmacia NUMERIC(18,0) NOT NULL
          )
           
CREATE TABLE KFC.estado_civil
          (
                    estado_id   INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion VARCHAR(255) UNIQUE NOT NULL
          )
           
CREATE TABLE KFC.afiliados
          (
                    afil_id          INT PRIMARY KEY IDENTITY(1,1)
                  , nombre           VARCHAR(255) NOT NULL
                  , apellido         VARCHAR(255) NOT NULL
                  , tipo_doc         VARCHAR(255) NOT NULL
                  , numero_doc       NUMERIC(18,0) NOT NULL
                  , direccion        VARCHAR(255) NULL
                  , telefono         NUMERIC(18, 0) NULL
                  , mail             VARCHAR(255) NULL
                  , sexo             CHAR NULL
                  , fecha_nacimiento DATETIME NOT NULL
                  , estado_id        INT NULL REFERENCES KFC.estado_civil
                  , habilitado       BIT NOT NULL
				  , personas_a_car 			 INT NULL		-- Incluye conyuge, familiars mayores o cantidad hijos
                  , plan_id          INT NOT NULL REFERENCES KFC.planes
                  , us_id            INT NOT NULL REFERENCES KFC.usuarios
          )
           
CREATE TABLE KFC.historial_afiliados
          (
                    afil_id       INT NOT NULL REFERENCES KFC.afiliados
                  , fecha         DATETIME
                  , plan_activo   INT NOT NULL REFERENCES KFC.planes
                  , motivo_cambio VARCHAR(255) NOT NULL
				  ,CONSTRAINT pk_historial_afiliados PRIMARY KEY (afil_id, fecha)
          )
           
CREATE TABLE KFC.profesionales
          (
                    prof_id          INT PRIMARY KEY IDENTITY(1,1)
                  , nombre           VARCHAR(255) NOT NULL
                  , apellido         VARCHAR(255) NOT NULL
                  , tipo_doc         VARCHAR(20) NOT NULL
                  , numero_doc       NUMERIC(18,0) NOT NULL
                  , direccion        VARCHAR(255) NULL
                  , telefono         NUMERIC(18, 0) NULL
                  , mail             VARCHAR(255) NULL
                  , fecha_nacimiento DATETIME NOT NULL
                  , matricula        VARCHAR(255) NULL
                  , us_id            INT NOT NULL REFERENCES KFC.usuarios
				  , habilitado BIT NOT NULL
          )
           
CREATE TABLE KFC.tipos_especialidades
          (
                    tipo_esp_id INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion VARCHAR(255) UNIQUE NOT NULL
          )
           
CREATE TABLE KFC.especialidades
          (
                    espe_id     INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion VARCHAR(255) UNIQUE NOT NULL
                  , tipo_esp_id INT NOT NULL REFERENCES KFC.tipos_especialidades
          )
           
CREATE TABLE KFC.especialidades_profesional
          (
                    espe_id INT NOT NULL REFERENCES KFC.especialidades
                  , prof_id INT NOT NULL REFERENCES KFC.profesionales
				  ,CONSTRAINT pk_especialidades_profesional PRIMARY KEY (espe_id, prof_id)
          )
           
CREATE TABLE KFC.agenda
          (
                    espe_id INT NOT NULL 
                  , prof_id INT NOT NULL
				  , dia		INT NOT NULL
				  , fecha_desde DATETIME
                  , fecha_hasta DATETIME
                  , hora_desde  TIME(0) -- 0 por Minima precicion Nanosegundos. No queremos tanta precicion
                  , hora_hasta  TIME(0)
				  ,CONSTRAINT fk_agenda_especialidades_profesional FOREIGN KEY(espe_id, prof_id) REFERENCES KFC.especialidades_profesional (espe_id, prof_id)
				  ,CONSTRAINT pk_agenda PRIMARY KEY (espe_id, prof_id, dia, fecha_desde, fecha_hasta, hora_desde, hora_hasta)	-- Habria que ver si puede acortarse la PK
          )
CREATE TABLE KFC.turnos
          (
                    turno_id   INT PRIMARY KEY IDENTITY(1,1)
                  , fecha_hora DATETIME NOT NULL
				  , hora	   TIME(0)  NOT NULL
                  , afil_id    INT NOT NULL REFERENCES KFC.afiliados
                  , espe_id    INT NOT NULL
                  , prof_id    INT NOT NULL
				  , CONSTRAINT fk_turnos_especialidades_profesional FOREIGN KEY(espe_id, prof_id) REFERENCES KFC.especialidades_profesional (espe_id, prof_id)
          )
           
CREATE TABLE KFC.tipos_cancelaciones
          (
                    tipo_cancel_id INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion    VARCHAR(255) UNIQUE NOT NULL
          )
           
CREATE TABLE KFC.cancelaciones
          (
                    cancel_id      INT PRIMARY KEY IDENTITY(1,1)
                  , turno_id       INT NOT NULL REFERENCES KFC.turnos
                  , detalle_cancel VARCHAR(255) UNIQUE NOT NULL
				  , fecha_cancel   DATETIME
                  , tipo_cancel_id INT NOT NULL REFERENCES KFC.tipos_cancelaciones
          )
           
CREATE TABLE KFC.bonos
          (
                    bono_id INT PRIMARY KEY IDENTITY(1,1)
                  , plan_id INT NOT NULL REFERENCES KFC.planes
                  , afil_id INT NOT NULL REFERENCES KFC.afiliados
				  , fecha_compra DATETIME NOT NULL
				  , fecha_impresion DATETIME NULL
				  , consumido BIT NOT NULL DEFAULT 0			-- Por defecto (Bonos Nuevos) estan sin consumir
          ) 
           
CREATE TABLE KFC.atenciones
          (
                    atencion_id  INT PRIMARY KEY IDENTITY(1,1)
                  , turno_id     INT NOT NULL REFERENCES KFC.turnos
                  , hora_llegada TIME(0) NOT NULL -- 0 por Minima precicion Nanosegundos. No queremos tanta precicion
                  , sintomas     VARCHAR(255) NOT NULL
                  , diagnostico  VARCHAR(255) NOT NULL
                  , bono_id      INT NOT NULL REFERENCES KFC.bonos
          )
