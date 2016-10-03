CREATE SCHEMA kfc AUTHORIZATION gd
GO
CREATE TABLE kfc.MEDICOS
          (
                    Medico_Dni       NUMERIC(18,0) PRIMARY KEY
                  , Medico_Nombre    VARCHAR(255) NULL
                  , Medico_Apellido  VARCHAR(255) NULL
                  , Medico_Direccion VARCHAR(255) NULL
                  , Medico_Fecha_Nac DATETIME NULL
                  , Medico_Mail      VARCHAR(255) NULL
                  , Medico_Telefono  NUMERIC(18,0) NULL
                  ,
           )
GO
INSERT INTO kfc.MEDICOS
SELECT DISTINCT Medico_Dni
        , Medico_Nombre
        , Medico_Apellido
        , Medico_Direccion
        , Medico_Fecha_Nac
        , Medico_Mail
        , Medico_Telefono
FROM
          [GD2C2016].[gd_esquema].[Maestra]
WHERE
          Medico_Dni IS NOT NULL
ORDER BY
          Medico_Dni
GO
CREATE TABLE kfc.MEDICOS_ESPECIALIDAD
          (
                    Medico_Dni          NUMERIC(18,0)
                  , Especialidad_Codigo NUMERIC(18,0)
          )
GO
INSERT INTO kfc.MEDICOS_ESPECIALIDAD
SELECT DISTINCT Medico_Dni
        , Especialidad_Codigo
FROM
          [GD2C2016].[gd_esquema].[Maestra]
WHERE
          Medico_Dni IS NOT NULL
ORDER BY
          Especialidad_Codigo
        , Medico_Dni
GO
CREATE TABLE kfc.ESPECIALIDADES
          (
                    Especialidad_Codigo      NUMERIC(18,0) PRIMARY KEY
                  , Especialidad_Descripcion VARCHAR(255)
                  , Tipo_Especialidad_Codigo NUMERIC(18,0)
          )
GO
INSERT INTO kfc.ESPECIALIDADES
SELECT DISTINCT Especialidad_Codigo
        , Especialidad_Descripcion
        , Tipo_Especialidad_Codigo
FROM
          gd_esquema.Maestra
WHERE
          (
                    Especialidad_Codigo IS NOT NULL
          )
ORDER BY
          Especialidad_Codigo
GO
CREATE TABLE kfc.TIPOS_ESPECIALIDAD
          (
                    Tipo_Especialidad_Codigo      NUMERIC(18,0) PRIMARY KEY
                  , Tipo_Especialidad_Descripcion VARCHAR(255) NOT NULL
          )
GO
INSERT INTO kfc.TIPOS_ESPECIALIDAD
SELECT DISTINCT Tipo_Especialidad_Codigo
        , Tipo_Especialidad_Descripcion
FROM
          [GD2C2016].[gd_esquema].[Maestra]
WHERE
          Tipo_Especialidad_Codigo IS NOT NULL
ORDER BY
          Tipo_Especialidad_Codigo
        , Tipo_Especialidad_Descripcion
GO
COMMIT
GO