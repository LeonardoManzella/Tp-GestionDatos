--TODO hay que limpiar Metadata que genera el sistema para las tablas e indices

/* :::::: Importante :::::
Recordar que hay que borrar las tablas en orden inverso a la creacion, por las FK
Explicacion porque lo hago asi: http://stackoverflow.com/questions/7887011/how-to-drop-a-table-if-it-exists-in-sql-server
*/


IF OBJECT_ID('kfc.atenciones', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.atenciones;

END GO
IF OBJECT_ID('kfc.bonos', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.bonos;

END GO
IF OBJECT_ID('kfc.cancelaciones', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.cancelaciones;

END GO
IF OBJECT_ID('kfc.tipos_cancelaciones', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.tipos_cancelaciones;

END GO
IF OBJECT_ID('kfc.turnos', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.turnos;

END GO
IF OBJECT_ID('kfc.agenda', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.agenda;

END GO
IF OBJECT_ID('kfc.especialidades_profesional', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.especialidades_profesional;

END GO
IF OBJECT_ID('kfc.especialidades', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.especialidades;

END GO
IF OBJECT_ID('kfc.tipos_especialidades', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.tipos_especialidades;

END GO
IF OBJECT_ID('kfc.profesionales', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.profesionales;

END GO
IF OBJECT_ID('kfc.historial_afiliados', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.historial_afiliados;

END GO
IF OBJECT_ID('kfc.afiliados', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.afiliados;

END GO
IF OBJECT_ID('kfc.estado_civil', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.estado_civil;

END GO
IF OBJECT_ID('kfc.planes', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.planes;

END GO
IF OBJECT_ID('kfc.funcionalidades_roles', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.funcionalidades_roles;

END GO
IF OBJECT_ID('kfc.funcionalidades', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.funcionalidades;

END GO
IF OBJECT_ID('kfc.roles_usuarios', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.roles_usuarios;

END GO
IF OBJECT_ID('kfc.roles', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.roles;

END GO
IF OBJECT_ID('kfc.usuarios', 'U') IS NOT NULL
BEGIN
          DROP TABLE kfc.usuarios;

END GO



