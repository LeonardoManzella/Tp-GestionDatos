PRINT 'Borrando Procedures...'

IF OBJECT_ID('KFC.pro_deshabilitar_rol_usuarios') IS NOT NULL
DROP PROCEDURE KFC.pro_deshabilitar_rol_usuarios;
GO
IF OBJECT_ID('KFC.pro_asignar_turno') IS NOT NULL
DROP PROCEDURE KFC.pro_asignar_turno;
GO
IF OBJECT_ID('KFC.pro_deshabilitar_usuario') IS NOT NULL
DROP PROCEDURE KFC.pro_deshabilitar_usuario;
GO
IF OBJECT_ID('KFC.pro_habilitar_rol') IS NOT NULL
DROP PROCEDURE KFC.pro_habilitar_rol;
GO
IF OBJECT_ID('KFC.pro_deshabilitar_rol') IS NOT NULL
DROP PROCEDURE KFC.pro_deshabilitar_rol;
GO
IF OBJECT_ID('KFC.pro_aumentar_intentos') IS NOT NULL
DROP PROCEDURE KFC.pro_aumentar_intentos;
GO
IF OBJECT_ID('KFC.pro_reiniciar_intentos') IS NOT NULL
DROP PROCEDURE KFC.pro_reiniciar_intentos;
GO
IF OBJECT_ID('KFC.pro_verificar_funcion_rol') IS NOT NULL
DROP PROCEDURE KFC.pro_verificar_funcion_rol;
GO
IF OBJECT_ID('KFC.pro_eliminar_rol_usuario') IS NOT NULL
DROP PROCEDURE KFC.pro_eliminar_rol_usuario;
GO
IF OBJECT_ID('KFC.pro_grabar_resultado_atencion') IS NOT NULL
DROP PROCEDURE KFC.pro_grabar_resultado_atencion;
GO
IF OBJECT_ID('KFC.pro_comprar_bono') IS NOT NULL
DROP PROCEDURE KFC.pro_comprar_bono;
GO
IF OBJECT_ID('KFC.pro_modificar_afiliado') IS NOT NULL
DROP PROCEDURE KFC.pro_modificar_afiliado;
GO
IF OBJECT_ID('KFC.pro_crear_rol') IS NOT NULL
DROP PROCEDURE KFC.pro_crear_rol;
GO
IF OBJECT_ID('KFC.pro_crear_funcionalidad_de_rol') IS NOT NULL
DROP PROCEDURE KFC.pro_crear_funcionalidad_de_rol;
GO
IF OBJECT_ID('KFC.pro_quitar_funcionalidad_de_rol') IS NOT NULL
DROP PROCEDURE KFC.pro_quitar_funcionalidad_de_rol;
GO
IF OBJECT_ID('KFC.pro_baja_logica_rol') IS NOT NULL
DROP PROCEDURE KFC.pro_baja_logica_rol;
GO
IF OBJECT_ID('KFC.modifica_afiliado') IS NOT NULL
DROP PROCEDURE KFC.modifica_afiliado;
GO
IF OBJECT_ID('KFC.get_cmb_estado_civil') IS NOT NULL
DROP PROCEDURE KFC.get_cmb_estado_civil;
GO
IF OBJECT_ID('KFC.get_afiliado') IS NOT NULL
DROP PROCEDURE KFC.get_afiliado;
GO
IF OBJECT_ID('KFC.alta_afiliado') IS NOT NULL
DROP PROCEDURE KFC.alta_afiliado;
GO

IF OBJECT_ID('KFC.get_cmb_planes_sociales') IS NOT NULL
DROP PROCEDURE KFC.get_cmb_planes_sociales;
GO

IF OBJECT_ID('KFC.registrar_llegada') IS NOT NULL
DROP PROCEDURE KFC.registrar_llegada;
GO

IF OBJECT_ID('KFC.get_bonos_afiliado') IS NOT NULL
DROP PROCEDURE KFC.get_bonos_afiliado;
GO

IF OBJECT_ID('KFC.get_turno_hoy') IS NOT NULL
DROP PROCEDURE KFC.get_turno_hoy;
GO

IF OBJECT_ID('KFC.get_cmb_prof_x_esp') IS NOT NULL
DROP PROCEDURE KFC.get_cmb_prof_x_esp;
GO

IF OBJECT_ID('KFC.get_afiliado') IS NOT NULL
DROP PROCEDURE KFC.get_afiliado;
GO

IF OBJECT_ID('KFC.pro_setear_rol_estado_habilitacion') IS NOT NULL
DROP PROCEDURE KFC.pro_setear_rol_estado_habilitacion;
GO

IF OBJECT_ID('KFC.pro_cancelar_turno') IS NOT NULL
DROP PROCEDURE KFC.pro_cancelar_turno;
GO

IF OBJECT_ID('KFC.pro_cancelar_turno_profesional') IS NOT NULL
DROP PROCEDURE KFC.pro_cancelar_turno_profesional;
GO

IF OBJECT_ID('KFC.pro_crear_agenda_profesional') IS NOT NULL
DROP PROCEDURE KFC.pro_crear_agenda_profesional;
GO
PRINT 'Procedures Borrados'





PRINT 'Borrando Funciones...'

-- Ahora las Funciones

IF OBJECT_ID('KFC.fun_obtener_roles_usuario') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_roles_usuario;
GO
IF OBJECT_ID('KFC.fun_validar_usuario') IS NOT NULL
DROP FUNCTION KFC.fun_validar_usuario;
GO
IF OBJECT_ID('KFC.fun_obtener_funcion_rol') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_funcion_rol;
GO
IF OBJECT_ID('KFC.fun_obtener_todas_las_funcionalidades') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_todas_las_funcionalidades;
GO
IF OBJECT_ID('KFC.fun_obtener_planes_afiliado') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_planes_afiliado;
GO
IF OBJECT_ID('KFC.fun_obtener_todos_los_planes') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_todos_los_planes;
GO
IF OBJECT_ID('KFC.fun_obtener_especialidades_prof') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_especialidades_prof;
GO
IF OBJECT_ID('KFC.fun_obtener_profesionales_por_especialidad') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_profesionales_por_especialidad;
GO
IF OBJECT_ID('KFC.fun_obtener_turnos_del_dia') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_turnos_del_dia;
GO
IF OBJECT_ID('KFC.fun_obtener_bonos_afiliado') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_bonos_afiliado;
GO
IF OBJECT_ID('KFC.fun_retornar_id_afildo') IS NOT NULL
DROP FUNCTION KFC.fun_retornar_id_afildo;
GO
IF OBJECT_ID('KFC.fun_devolver_turnos_prof_afildo') IS NOT NULL
DROP FUNCTION KFC.fun_devolver_turnos_prof_afildo;
GO
IF OBJECT_ID('KFC.fun_devolver_precio_bono') IS NOT NULL
DROP FUNCTION KFC.fun_devolver_precio_bono;
GO
IF OBJECT_ID('KFC.fun_devolver_afiliado_y_su_nombre') IS NOT NULL
DROP FUNCTION KFC.fun_devolver_afiliado_y_su_nombre;
GO
IF OBJECT_ID('KFC.fun_devolver_afiliado') IS NOT NULL
DROP FUNCTION KFC.fun_devolver_afiliado;
GO
IF OBJECT_ID('KFC.fun_obtener_todas_los_roles') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_todas_los_roles;
GO
IF OBJECT_ID('KFC.fun_obtener_turnos_profesional') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_turnos_profesional;
GO

IF OBJECT_ID('KFC.fun_obtener_id_especialidad') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_id_especialidad;
GO

IF OBJECT_ID('KFC.fun_obtener_id_profesional') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_id_profesional;
GO

IF OBJECT_ID('KFC.fun_obtener_especialidades') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_especialidades;
GO

IF OBJECT_ID('KFC.fun_retornar_id_funcionalidad') IS NOT NULL
DROP FUNCTION KFC.fun_retornar_id_funcionalidad;
GO

IF OBJECT_ID('KFC.fun_retornar_id_rol') IS NOT NULL
DROP FUNCTION KFC.fun_retornar_id_rol;
GO

IF OBJECT_ID('KFC.fun_obtener_habilitacion_rol') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_habilitacion_rol;
GO

IF OBJECT_ID('KFC.fun_top_5_cancelaciones_especialidad') IS NOT NULL
DROP FUNCTION KFC.fun_top_5_cancelaciones_especialidad;

IF OBJECT_ID('KFC.fun_top_5_profesional_popular') IS NOT NULL
DROP FUNCTION KFC.fun_top_5_profesional_popular;

IF OBJECT_ID('KFC.obtener_titular') IS NOT NULL
DROP FUNCTION KFC.obtener_titular;

IF OBJECT_ID('KFC.fun_fun_obtener_titular') IS NOT NULL
DROP FUNCTION KFC.fun_fun_obtener_titular;

IF OBJECT_ID('KFC.fun_top_5_compradores_bonos') IS NOT NULL
DROP FUNCTION KFC.fun_top_5_compradores_bonos;

IF OBJECT_ID('KFC.fun_top_5_especialidad_Atenciones') IS NOT NULL
DROP FUNCTION KFC.fun_top_5_especialidad_Atenciones;

IF OBJECT_ID('KFC.fun_top_5_profesional_menos_tiempo_trabajado') IS NOT NULL
DROP FUNCTION KFC.fun_top_5_profesional_menos_tiempo_trabajado;

IF OBJECT_ID('KFC.fun_obtener_turnos_cancelables') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_turnos_cancelables;

IF OBJECT_ID('KFC.fun_obtener_funcionalidades_usuario') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_funcionalidades_usuario;

IF OBJECT_ID('KFC.fun_obtener_datos_usuario') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_datos_usuario;

IF OBJECT_ID('KFC.obtener_afiliados_filtros') IS NOT NULL
DROP FUNCTION KFC.obtener_afiliados_filtros;

IF OBJECT_ID('KFC.get_especialidades') IS NOT NULL
DROP FUNCTION KFC.get_especialidades;
GO

IF OBJECT_ID('KFC.fun_retornar_id_afildo_por_id') IS NOT NULL
DROP FUNCTION KFC.fun_retornar_id_afildo_por_id;
GO

IF OBJECT_ID('KFC.fun_obtener_rango_agenda') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_rango_agenda;
GO

IF OBJECT_ID('KFC.fun_obtener_id_profesional_x_user_id') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_id_profesional_x_user_id;
GO

PRINT 'Funciones Borradas'