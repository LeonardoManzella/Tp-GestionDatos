/*
IF OBJECT_ID('KFC.Obtener_Roles_Usuario') IS NOT NULL
DROP FUNCTION KFC.Obtener_Roles_Usuario;

IF OBJECT_ID('KFC.Obtener_Todos_los_Roles') IS NOT NULL
DROP FUNCTION KFC.Obtener_Todos_los_Roles;

IF OBJECT_ID('KFC.Validar_Usuario') IS NOT NULL
DROP FUNCTION KFC.Validar_Usuario;

IF OBJECT_ID('KFC.deshabilitar_usuario') IS NOT NULL
DROP PROCEDURE KFC.deshabilitar_usuario;

IF OBJECT_ID('KFC.habilitar_rol') IS NOT NULL
DROP PROCEDURE KFC.habilitar_rol;

IF OBJECT_ID('KFC.deshabilitar_rol') IS NOT NULL
DROP PROCEDURE KFC.deshabilitar_rol;

IF OBJECT_ID('KFC.aumentar_intentos') IS NOT NULL
DROP PROCEDURE KFC.aumentar_intentos;

IF OBJECT_ID('KFC.reiniciar_intentos') IS NOT NULL
DROP PROCEDURE KFC.reiniciar_intentos;

IF OBJECT_ID('KFC.obtener_funcion_rol') IS NOT NULL
DROP FUNCTION KFC.obtener_funcion_rol;

IF OBJECT_ID('KFC.obtener_todas_las_funcionalidades') IS NOT NULL
DROP FUNCTION KFC.obtener_todas_las_funcionalidades;

IF OBJECT_ID('KFC.verificar_funcion_rol') IS NOT NULL
DROP PROCEDURE KFC.verificar_funcion_rol;

IF OBJECT_ID('KFC.obtener_planes_afiliado') IS NOT NULL
DROP FUNCTION KFC.obtener_planes_afiliado;

IF OBJECT_ID('KFC.obtener_todos_los_planes') IS NOT NULL
DROP FUNCTION KFC.obtener_todos_los_planes;

IF OBJECT_ID('KFC.obtener_especialidades') IS NOT NULL
DROP FUNCTION KFC.obtener_especialidades;

IF OBJECT_ID('KFC.obtener_profesionales_por_especialidad') IS NOT NULL
DROP FUNCTION KFC.obtener_profesionales_por_especialidad;

IF OBJECT_ID('KFC.eliminar_rol_usuario') IS NOT NULL
DROP PROCEDURE KFC.eliminar_rol_usuario;

IF OBJECT_ID('KFC.obtener_turnos_del_dia') IS NOT NULL
DROP FUNCTION KFC.obtener_turnos_del_dia;

IF OBJECT_ID('KFC.obtener_bonos_afiliado') IS NOT NULL
DROP FUNCTION obtener_bonos_afiliado;

IF OBJECT_ID('KFC.crear_agenda_profesional') IS NOT NULL
DROP PROCEDURE KFC.crear_agenda_profesional;

IF OBJECT_ID('KFC.baja_afiliado') IS NOT NULL
DROP PROCEDURE KFC.baja_afiliado;

IF OBJECT_ID('KFC.liberar_turnos') IS NOT NULL
DROP PROCEDURE KFC.liberar_turnos;

IF OBJECT_ID('KFC.registrar_llegada_atencion') IS NOT NULL
DROP PROCEDURE KFC.registrar_llegada_atencion;

IF OBJECT_ID('KFC.top_5_cancelaciones_especialidad') IS NOT NULL
DROP FUNCTION KFC.top_5_cancelaciones_especialidad;

IF OBJECT_ID('KFC.top_5_profesional_popular') IS NOT NULL
DROP FUNCTION KFC.top_5_profesional_popular;

IF OBJECT_ID('KFC.obtener_titular') IS NOT NULL
DROP FUNCTION KFC.obtener_titular;

IF OBJECT_ID('KFC.top_5_compradores_bonos') IS NOT NULL
DROP FUNCTION KFC.top_5_compradores_bonos;

IF OBJECT_ID('KFC.top_5_especialidad_Atenciones') IS NOT NULL
DROP FUNCTION KFC.top_5_especialidad_Atenciones;

IF OBJECT_ID('KFC.top_5_profesional_menos_tiempo_trabajado') IS NOT NULL
DROP FUNCTION KFC.top_5_profesional_menos_tiempo_trabajado;
*/
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
IF OBJECT_ID('KFC.fun_obtener_especialidades') IS NOT NULL
DROP FUNCTION KFC.fun_obtener_especialidades;
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

IF OBJECT_ID('KFC.get_afiliado') IS NOT NULL
DROP PROCEDURE KFC.get_afiliado;
GO


