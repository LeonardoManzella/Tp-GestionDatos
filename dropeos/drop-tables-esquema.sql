--TODO hay que limpiar Metadata que genera el sistema para las tablas e indices

/* :::::: Importante :::::
Recordar que hay que borrar las tablas en orden inverso a la creacion, por las FK
Explicacion porque lo ha  asi: http://stackoverflow.com/questions/7887011/how-to-drop-a-table-if-it-exists-in-sql-server
*/

begin
IF OBJECT_ID('kfc.atenciones', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.atenciones;
          
          DROP TABLE kfc.atenciones;

END
IF OBJECT_ID('kfc.bonos', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.bonos;
          
          DROP TABLE kfc.bonos;

END 
IF OBJECT_ID('kfc.cancelaciones', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.cancelaciones;
          
          DROP TABLE kfc.cancelaciones;

END  
IF OBJECT_ID('kfc.tipos_cancelaciones', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.tipos_cancelaciones;
          
          DROP TABLE kfc.tipos_cancelaciones;

END  
IF OBJECT_ID('kfc.turnos', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.turnos;
          
          DROP TABLE kfc.turnos;

END  
IF OBJECT_ID('kfc.agenda', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.agenda;
          
          DROP TABLE kfc.agenda;

END  
IF OBJECT_ID('kfc.especialidades_profesional', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.especialidades_profesional;
          
          DROP TABLE kfc.especialidades_profesional;

END  
IF OBJECT_ID('kfc.especialidades', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.especialidades;
          
          DROP TABLE kfc.especialidades;

END  
IF OBJECT_ID('kfc.tipos_especialidades', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.tipos_especialidades;
          
          DROP TABLE kfc.tipos_especialidades;

END  
IF OBJECT_ID('kfc.profesionales', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.profesionales;
          
          DROP TABLE kfc.profesionales;

END  
IF OBJECT_ID('kfc.historial_afiliados', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.historial_afiliados;
          
          DROP TABLE kfc.historial_afiliados;

END  
IF OBJECT_ID('kfc.afiliados', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.afiliados;
          
          DROP TABLE kfc.afiliados;

END  
IF OBJECT_ID('kfc.estado_civil', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.estado_civil;
          
          DROP TABLE kfc.estado_civil;

END  
IF OBJECT_ID('kfc.planes', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.planes;
          
          DROP TABLE kfc.planes;

END  
IF OBJECT_ID('kfc.funcionalidades_roles', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.funcionalidades_roles;
          
          DROP TABLE kfc.funcionalidades_roles;

END  
IF OBJECT_ID('kfc.funcionalidades', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.funcionalidades;
          
          DROP TABLE kfc.funcionalidades;

END  
IF OBJECT_ID('kfc.roles_usuarios', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.roles_usuarios;
          
          DROP TABLE kfc.roles_usuarios;

END  
IF OBJECT_ID('kfc.roles', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.roles;
          
          DROP TABLE kfc.roles;

END  
IF OBJECT_ID('kfc.usuarios', 'U') IS NOT NULL
BEGIN
          TRUNCATE TABLE kfc.usuarios;
          
          DROP TABLE kfc.usuarios;

END  

DROP SCHEMA KFC  
end
