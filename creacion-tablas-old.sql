--- Necesita ser Actualizado a Nuevo DER
 CREATE SCHEMA kfc AUTHORIZATION gd  
  
  go
  create table kfc.MEDICOS(
	Medico_Dni  numeric(18,0) Primary Key,
	Medico_Nombre Varchar(255) Null,
	Medico_Apellido Varchar(255) Null,
	Medico_Direccion Varchar(255) Null,
	Medico_Fecha_Nac datetime Null,
	Medico_Mail varchar(255) Null,
	Medico_Telefono numeric(18,0) Null,
   )
  go

  insert into kfc.MEDICOS 
  select distinct Medico_Dni, Medico_Nombre,Medico_Apellido,
		Medico_Direccion, Medico_Fecha_Nac,
		Medico_Mail, Medico_Telefono
    FROM [GD2C2016].[gd_esquema].[Maestra]
	where Medico_Dni is not null
	order by Medico_Dni

go
create table kfc.MEDICOS_ESPECIALIDAD(Medico_Dni numeric(18,0),Especialidad_Codigo Numeric(18,0))
go
insert into kfc.MEDICOS_ESPECIALIDAD
select distinct Medico_Dni,Especialidad_Codigo
FROM [GD2C2016].[gd_esquema].[Maestra]
where Medico_Dni is not null
order by Especialidad_Codigo, Medico_Dni

go

create table kfc.ESPECIALIDADES(Especialidad_Codigo Numeric(18,0) Primary Key,
								Especialidad_Descripcion varchar(255),
								Tipo_Especialidad_Codigo Numeric(18,0))
go

insert into kfc.ESPECIALIDADES
select distinct Especialidad_Codigo, Especialidad_Descripcion, Tipo_Especialidad_Codigo
FROM [GD2C2016].[gd_esquema].[Maestra]
Where Especialidad_Codigo is not null
order by Especialidad_Codigo

go

create table kfc.TIPOS_ESPECIALIDAD(Tipo_Especialidad_Codigo Numeric(18,0) Primary Key,
									Tipo_Especialidad_Descripcion Varchar(255) Not Null)

go

insert into kfc.TIPOS_ESPECIALIDAD
select distinct Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
FROM [GD2C2016].[gd_esquema].[Maestra]
Where Tipo_Especialidad_Codigo is not null
order by Tipo_Especialidad_Codigo,Tipo_Especialidad_Descripcion

go

commit

go
