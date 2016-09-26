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


/* ::::::::::::::::::::: CONVENCIONES :::::::::::::::::::::
Por Favor respeten las Convenciones de Nombres, Tablas, Identacion, etc: facilita que nos entendamos entre nosotros
Sino, vallan a leer este link que les explica porque usarlas asi
http://www.codeproject.com/Articles/1065295/SQL-Server-Table-and-Column-Naming-Conventions
*/


 CREATE SCHEMA kfc AUTHORIZATION gd  
 GO
 

CREATE TABLE kfc.USUARIOS(
	us_id			INT				PRIMARY KEY IDENTITY(1,1),
	us_nick			VARCHAR(30)		UNIQUE NOT NULL,			--No quiero poner valores muy grandes para evitar que pese mucho la base de datos y ande lenta, mejor que ande rapida para nosotros
	us_pass			VARCHAR(30)		NOT NULL,
	us_habilitado	BIT				NOT NULL	
)
GO


CREATE TABLE kfc.ROLES(
	rol_id			INT				PRIMARY KEY IDENTITY(1,1),
	rol_desc		VARCHAR(50)		UNIQUE NOT NULL,
	rol_habilitado	BIT				NOT NULL
)
GO


CREATE TABLE kfc.ROLES_USUARIOS(
	us_id		INT		NOT NULL REFERENCES USUARIOS,
	rol_id		INT		NOT NULL REFERENCES	ROLES
)
GO

