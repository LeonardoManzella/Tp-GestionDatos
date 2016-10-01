/*	::::::::::::::::::::: ORDEN CREACION TABLAS :::::::::::::::::::::
	(De primero a ultimo, todos los nombres en mayusculas)
	
	USUARIOS
	ROLES
	ROLES_USUARIOS
	FUNCIONALIDADES
	FUNCIONALIDADES_ROLES
	
	PLANES
	AFILIADOS
	HISTORIAL_AFILIADOS
	
	PROFESIONALES
	TIPOS_ESPECIALIDADES
	ESPECIALIDADES
	ESPECIALIDADES_PROFESIONAL
	
	TIPOS_CANCELACIONES
	CANCELACIONES
	TURNOS
	BONOS
*/

CREATE SCHEMA kfc AUTHORIZATION gd GO

CREATE TABLE kfc.USUARIOS
          (
                    us_id         INT PRIMARY KEY IDENTITY(1,1)
                  , nick       VARCHAR(30) UNIQUE NOT NULL --No quiero poner valores muy grandes para evitar que pese mucho la base de datos y ande lenta, mejor que ande rapida para nosotros
                  , pass       VARCHAR(30) NOT NULL
                  , habilitado BIT NOT NULL
          )
          GO
CREATE TABLE kfc.ROLES
          (
                    rol_id         INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion       VARCHAR(50) UNIQUE NOT NULL
                  , habilitado BIT NOT NULL
          )
          GO
CREATE TABLE kfc.ROLES_USUARIOS
          (
                    us_id  INT NOT NULL REFERENCES USUARIOS
                  , rol_id INT NOT NULL REFERENCES ROLES
          )
          GO
CREATE TABLE kfc.FUNCIONALIDADES
          (
                    func_id   INT PRIMARY KEY IDENTITY(1,1)
                  , descripcion VARCHAR(50) UNIQUE NOT NULL
          )
          GO
CREATE TABLE kfc.FUNCIONALIDADES_ROLES
          (
                    rol_id  INT NOT NULL REFERENCES ROLES
                  , func_id INT NOT NULL REFERENCES FUNCIONALIDADES
          )
          GO
CREATE TABLE kfc.PLANES
          (
                    plan_id                   INT PRIMARY KEY IDENTITY(1,1)
                  , precio_bono_consulta NUMERIC(18,0) --No existen datos de donde sacar cuotas. No esta en Tabla Original
                  , precio_bono_farmacia NUMERIC(18,0)
          )
          GO
CREATE TABLE kfc.AFILIADOS
          (
		  afil_id  INT PRIMARY KEY IDENTITY(1,1)
		  -- Faltan Datos de Persona, lo sacabamos a tabla afuera no?
		 , habilitado BIT NOT NULL
		 , cant_hijos	INT		--para que no interesa guardar esto y los hijos y conyuge?
		 , plan_id	INT NOT NULL REFERENCES PLANES
		 ,  us_id  INT NULL REFERENCES USUARIOS
          ) 
		  GO
CREATE TABLE kfc.HISTORIAL_AFILIADOS
          (
		  afil_id INT NOT NULL REFERENCES AFILIADOS
		  ,fecha DATETIME
		  ,plan_activo	INT NOT NULL REFERENCES PLANES
		  )motivo		VARCHAR(30) NOT NULL
		  GO
CREATE TABLE kfc.PROFESIONALES
          (
		  prof_id  INT PRIMARY KEY IDENTITY(1,1)
			-- Faltan Datos de Persona, lo sacabamos a tabla afuera no?
		  ,us_id  INT NOT NULL REFERENCES USUARIOS
		  )
		  GO

CREATE TABLE kfc.TIPOS_ESPECIALIDADES
(
	tipo_esp_id		INT PRIMARY KEY IDENTITY(1,1)
	, descripcion       VARCHAR(50) UNIQUE NOT NULL
)
GO
CREATE TABLE kfc.ESPECIALIDADES
(
)
GO
CREATE TABLE kfc.ESPECIALIDADES_PROFESIONAL
(
)
GO
CREATE TABLE kfc.TIPOS_CANCELACIONES
(
)
GO
CREATE TABLE kfc.CANCELACIONES
(
)
GO
CREATE TABLE kfc.TURNOS
(
)
GO
CREATE TABLE kfc.BONOS
(
)
GO

