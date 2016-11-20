using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaFrba.Base_de_Datos
{

    public static class InteraccionDB
    {

        public static SqlDataReader ejecutar_funcion(string funcion, List<SqlParameter> parametros)
        {
            SqlConnection conexion = Conexion.Instance.get();
            SqlCommand comando_sql = new SqlCommand(funcion, conexion);

            foreach (var parametro in parametros)
            {
                comando_sql.Parameters.Add(parametro);
            }

            return comando_sql.ExecuteReader();
        }

        public static SqlDataReader ejecutar_storedProcedure(string procedure, List<SqlParameter> parametros)
        {
            SqlConnection conexion = Conexion.Instance.get();
            SqlCommand comando_sql = new SqlCommand(procedure, conexion);
            comando_sql.CommandType = CommandType.StoredProcedure;


            foreach (var parametro in parametros)
            {
                comando_sql.Parameters.Add(parametro);
            }

            //TODO Pendiente ver cual realmente es el que hay que usar
            //rowsAffected = comando_sql.ExecuteNonQuery();
            return comando_sql.ExecuteReader();
        }

        public static SqlCommand ejecutar_storedProcedureConRetorno(string procedure, List<SqlParameter> parametros)
        {
            SqlConnection conexion = Conexion.Instance.get();
            SqlCommand comando_sql = new SqlCommand(procedure, conexion);
            comando_sql.CommandType = CommandType.StoredProcedure;


            foreach (var parametro in parametros)
            {
                comando_sql.Parameters.Add(parametro);
            }

            int rowsAffected = comando_sql.ExecuteNonQuery();

            //Veo si trajo datos o no
            if (rowsAffected <= 0) throw new Exception("No se modificaron Columnas. Fallo Ejecucion Procedure");

            return comando_sql;
        }


        private static void ImprimirExcepcion(Exception e)
        {
            //Imprimir para DEBUG
            System.Diagnostics.Debug.WriteLine(e.Message);
            System.Diagnostics.Debug.WriteLine(e.InnerException);
            System.Diagnostics.Debug.WriteLine(e.HelpLink);
            System.Diagnostics.Debug.Write(e.StackTrace);


            //Imprimir para Consola :/
            Console.WriteLine(e.Message);
            Console.WriteLine(e.InnerException);
            Console.WriteLine(e.HelpLink);
            Console.Write(e.StackTrace);
        }

        /// <summary>
        /// Obtenemos Lista de Strings del Reader. La 'columnaPorObtener' empieza 0 para la primer columna y asi..
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnaPorObtener"></param>
        /// <returns></returns>
        private static List<string> ObtenerStringsReader(SqlDataReader reader, int columnaPorObtener)
        {

            //Veo si trajo datos o no
            if (!reader.HasRows) throw new Exception("Reader sin Filas");

            var strings = new List<string>();

            //Obtengo Multiples datos
            while (reader.Read())
            {
                string unString = reader.GetString(columnaPorObtener);
                strings.Add(unString);
                unString = null;

            }

            if (strings.Count <= 0) throw new Exception("No se cargaron Strings a la Lista");
            return strings;
        }


        /// <summary>
        /// Obtenemos Int del Reader. La 'columnaPorObtener' empieza 0 para la primer columna y asi..
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnaPorObtener"></param>
        /// <returns></returns>
        private static int ObtenerIntReader(SqlDataReader reader, int columnaPorObtener)
        {
            //Veo si trajo datos o no
            if (!reader.HasRows) throw new Exception("Reader sin Filas");

            int valorObtener = 0;

            //Obtengo Multiples datos
            while (reader.Read())
            {
                valorObtener = reader.GetInt32(columnaPorObtener);
                break;  //Unico Valor a Obtener

            }
            if (valorObtener <= 0) throw new Exception("Hubo un Problema al Obtener Dato");
            return valorObtener;
        }


        public static Usuario log_in(string usuario, string password)
        {
            try
            {
                string funcion = "SELECT KFC.fun_validar_usuario(@user, @contrasenia)";
                SqlParameter parametro1 = new SqlParameter("@user", SqlDbType.Text);
                parametro1.Value = usuario.ToUpper();
                SqlParameter parametro2 = new SqlParameter("@contrasenia", SqlDbType.Text);
                parametro2.Value = password.ToUpper();

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);

                var reader = ejecutar_funcion(funcion, parametros);


                int id = -1;
                id = ObtenerIntReader(reader, 0);

                if (id == -1) throw new Exception("Usuario Inexistente, Esta mal la Contraseña o no esta habilitado el Usuario");

                var user = new Usuario();
                user.id = id;
                //Otros valores falta ver que hacemos con eso. No es necesario Obtenerlos de la Base.
                return user;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);

                throw e;
            }
        }

        /// <summary>
        /// Obtiene el id de un afiliado a partir de su nombre y apellido
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <returns></returns>

        public static int obtenerID_afiliado(string nombre, string apellido)
        {
            try
            {
                string funcion = "SELECT KFC.fun_retornar_id_afildo(@nombre, @apellido)";
                SqlParameter parametro1 = new SqlParameter("@nombre", SqlDbType.Text);
                parametro1.Value = nombre.ToUpper();
                SqlParameter parametro2 = new SqlParameter("@apellido", SqlDbType.Text);
                parametro2.Value = apellido.ToUpper();

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);

                var reader = ejecutar_funcion(funcion, parametros);

                int id = ObtenerIntReader(reader, 0);

                return id;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);

                throw e;
            }
        }


        /// <summary>
        /// Parametriza los datos y administra la conexion con la BD para el alta del afiliado
        /// </summary>
        /// <param name="afiliado"></param>
        /// <returns></returns>
        public static int alta_afiliado(Afiliado afiliado)
        {
            try
            {
                //TODO pasar todo esto a metodo con Variable Args para parameters y fijo primer parametro string sql
                SqlConnection conexion = Conexion.Instance.get();

                SqlCommand comando_sql = new SqlCommand("kfc.alta_afiliado  @nombre, @apellido, @tipo_doc, @nro_doc, @direccion, @telefono, @mail, @sexo, @fecha_nac, @estado, @plan, @usuario, @afil_id OUTPUT", conexion);

                var parametro1 = new SqlParameter("@nombre", SqlDbType.Text);
                var parametro2 = new SqlParameter("@apellido", SqlDbType.Text);
                var parametro3 = new SqlParameter("@tipo_doc", SqlDbType.Text);
                var parametro3_5 = new SqlParameter("@nro_doc", SqlDbType.Int);
                var parametro4 = new SqlParameter("@direccion", SqlDbType.Text);
                var parametro5 = new SqlParameter("@telefono", SqlDbType.Int);
                var parametro6 = new SqlParameter("@mail", SqlDbType.Text);
                var parametro7 = new SqlParameter("@sexo", SqlDbType.Char);
                var parametro8 = new SqlParameter("@fecha_nac", SqlDbType.DateTime);
                var parametro9 = new SqlParameter("@estado", SqlDbType.Int);
                var parametro10 = new SqlParameter("@plan", SqlDbType.Int);
                var parametro11 = new SqlParameter("@usuario", SqlDbType.Int);
                var parametro0 = new SqlParameter("@afil_id", SqlDbType.Int);

                parametro1.Value = afiliado.nombre.ToUpper();
                parametro2.Value = afiliado.apellido.ToUpper();
                parametro3_5.Value = afiliado.nro_doc;
                parametro3.Value = afiliado.tipo_doc.ToUpper();
                parametro4.Value = afiliado.direccion.ToUpper();
                parametro5.Value = afiliado.telefono.ToUpper();
                parametro6.Value = afiliado.e_mail.ToUpper();
                parametro7.Value = afiliado.sexo;
                parametro8.Value = afiliado.fecha_nac;
                parametro9.Value = afiliado.estado_civil;
                parametro10.Value = afiliado.plan_id;
                parametro11.Value = afiliado.usuario;
                parametro0.Direction = ParameterDirection.Output;

                comando_sql.Parameters.Add(parametro1);
                comando_sql.Parameters.Add(parametro2);
                comando_sql.Parameters.Add(parametro3);
                comando_sql.Parameters.Add(parametro3_5);
                comando_sql.Parameters.Add(parametro4);
                comando_sql.Parameters.Add(parametro5);
                comando_sql.Parameters.Add(parametro6);
                comando_sql.Parameters.Add(parametro7);
                comando_sql.Parameters.Add(parametro8);
                comando_sql.Parameters.Add(parametro9);
                comando_sql.Parameters.Add(parametro10);
                comando_sql.Parameters.Add(parametro11);
                comando_sql.Parameters.Add(parametro0);

                comando_sql.ExecuteReader();

                var id = (int)comando_sql.Parameters["@afil_id"].Value;
                if (id <= 0) throw new Exception("No se ha podido crear el nuevo afiliado en la base");

                return id;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);

                throw e;
            }
        }

        /// Parametriza los datos y administra la conexion con la BD para la modificación del afiliado
        /// </summary>
        /// <param name="afiliado"></param>
        /// <returns></returns>
        public static void modifica_afiliado(Afiliado afiliado)
        {
            try
            {
                //TODO pasar todo esto a metodo con Variable Args para parameters y fijo primer parametro string sql
                SqlConnection conexion = Conexion.Instance.get();

                SqlCommand comando_sql = new SqlCommand("kfc.modifica_afiliado @afiliado, @nombre, @apellido, @tipo_doc, @direccion, @telefono, @mail, @sexo, @fecha_nac, @estado, @plan, @usuario", conexion);
                var parametro0 = new SqlParameter("@afiliado", SqlDbType.Int);
                var parametro1 = new SqlParameter("@nombre", SqlDbType.Text);
                var parametro2 = new SqlParameter("@apellido", SqlDbType.Text);
                var parametro3 = new SqlParameter("@tipo_doc", SqlDbType.Text);
                var parametro3_5 = new SqlParameter("@nro_doc", SqlDbType.Int);
                var parametro4 = new SqlParameter("@direccion", SqlDbType.Text);
                var parametro5 = new SqlParameter("@telefono", SqlDbType.Int);
                var parametro6 = new SqlParameter("@mail", SqlDbType.Text);
                var parametro7 = new SqlParameter("@sexo", SqlDbType.Char);
                var parametro8 = new SqlParameter("@fecha_nac", SqlDbType.DateTime);
                var parametro9 = new SqlParameter("@estado", SqlDbType.Int);
                var parametro10 = new SqlParameter("@plan", SqlDbType.Int);
                var parametro11 = new SqlParameter("@usuario", SqlDbType.Int);

                parametro0.Value = afiliado.id;
                parametro1.Value = afiliado.nombre.ToUpper();
                parametro2.Value = afiliado.apellido.ToUpper();
                parametro3.Value = afiliado.tipo_doc.ToUpper();
                parametro3_5.Value = afiliado.nro_doc;
                parametro4.Value = afiliado.direccion.ToUpper();
                parametro5.Value = afiliado.telefono.ToUpper();
                parametro6.Value = afiliado.e_mail.ToUpper();
                parametro7.Value = afiliado.sexo;
                parametro8.Value = afiliado.fecha_nac;
                parametro9.Value = afiliado.estado_civil;
                parametro10.Value = afiliado.plan_id;
                parametro11.Value = afiliado.usuario;

                comando_sql.Parameters.Add(parametro0);
                comando_sql.Parameters.Add(parametro1);
                comando_sql.Parameters.Add(parametro2);
                comando_sql.Parameters.Add(parametro3);
                comando_sql.Parameters.Add(parametro3_5);
                comando_sql.Parameters.Add(parametro4);
                comando_sql.Parameters.Add(parametro5);
                comando_sql.Parameters.Add(parametro6);
                comando_sql.Parameters.Add(parametro7);
                comando_sql.Parameters.Add(parametro8);
                comando_sql.Parameters.Add(parametro9);
                comando_sql.Parameters.Add(parametro10);
                comando_sql.Parameters.Add(parametro11);

                comando_sql.ExecuteReader();

            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);

                throw e;
            }
        }

        /// <summary>
        /// Baja de afiliado si la baja ha sido exitosa,devuelve ok
        /// </summary>
        /// <param name="afil_id"></param>
        /// <returns></returns>
        public static bool baja_afiliado(int afil_id)
        {
            try
            {

                SqlConnection conexion = Conexion.Instance.get();

                SqlCommand comando_sql = new SqlCommand("kfc.baja_afiliado @afiliado, @fecha", conexion);
                var parametro0 = new SqlParameter("@afiliado", SqlDbType.Int);
                var parametro1 = new SqlParameter("@fecha", SqlDbType.DateTime);

                parametro0.Value = afil_id;
                parametro1.Value = DateTime.Now;

                comando_sql.Parameters.Add(parametro0);
                comando_sql.Parameters.Add(parametro1);

                comando_sql.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);
                return false;
            }
        }

        #region Bonos

        public static List<string> pedir_planes_usuario(int id_usuario)
        {
            try
            {
                string funcion = "SELECT KFC.fun_obtener_planes_afiliado(@afiliado_id)";
                SqlParameter parametro = new SqlParameter("@afiliado_id", SqlDbType.Text);
                parametro.Value = id_usuario;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

                var reader = ejecutar_funcion(funcion, parametros);

                List<string> planes = ObtenerStringsReader(reader, 5);

                return planes;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);

                throw e;
            }
        }

        public static int obtener_precio_plan(int id_usuario)
        {
            try
            {
                string funcion = "SELECT KFC.fun_devolver_precio_bono(@afiliado_id)";
                SqlParameter parametro = new SqlParameter("@afiliado_id", SqlDbType.Text);
                parametro.Value = id_usuario;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

                var reader = ejecutar_funcion(funcion, parametros);

                int precio = ObtenerIntReader(reader, 0);

                return precio;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);

                throw e;
            }
        }

        public static void comprar_bono(int id_afiliado, int cantidad_bonos)
        {
            try
            {
                //Ejecuta tantas veces como Bonos Pedidos por el usuario
                for (int i = 0; i < cantidad_bonos; i++)
                {
                    string procedure = "KFC.pro_comprar_bono  @afil_id";
                    SqlParameter parametro = new SqlParameter("@afil_id", SqlDbType.Text);
                    parametro.Value = id_afiliado;

                    var parametros = new List<SqlParameter>();
                    parametros.Add(parametro);

                    var reader = ejecutar_storedProcedure(procedure, parametros);

                    //Veo si trajo datos o no
                    if (reader.RecordsAffected <= 0) throw new Exception("No se pudo Asignar el Turno. Fallo Ejecucion Procedure");
                }

                return;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);

                throw e;
            }
        }

        public static Afiliado get_afiliado(int afiliado_id)
        {
            try
            {
                //Declaro un Objeto del tipo del retorno
                var afiliado = new Afiliado();

                //creo la tabla que va a traer los registros
                DataTable dt = new DataTable();

                SqlConnection conexion = Conexion.Instance.get();
                SqlCommand cmd = new SqlCommand("kfc.get_afiliado @id_afiliado", conexion);

                var parametro1 = new SqlParameter("@id_afiliado", SqlDbType.Int);
                parametro1.Value = afiliado_id;
                cmd.Parameters.Add(parametro1);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //Lleno la tabla
                da.Fill(dt);

                //La recorro para armar la lista
                foreach (DataRow pRow in dt.Rows)
                {
                    afiliado = new Afiliado();

                    afiliado.id = Int32.Parse(pRow["afil_id"].ToString());
                    afiliado.nombre = pRow["nombre"].ToString();
                    afiliado.apellido = pRow["apellido"].ToString();
                    afiliado.tipo_doc = pRow["tipo_doc"].ToString();
                    afiliado.nro_doc = Int32.Parse(pRow["numero_doc"].ToString());
                    afiliado.direccion = pRow["direccion"].ToString();
                    afiliado.telefono = pRow["telefono"].ToString();
                    afiliado.e_mail = pRow["mail"].ToString();
                    afiliado.sexo = pRow["sexo"].ToString()[0];
                    afiliado.fecha_nac = DateTime.Parse(pRow["fecha_nacimiento"].ToString());
                    afiliado.estado_civil = Int32.Parse(pRow["estado_id"].ToString());
                    afiliado.plan_id = Int32.Parse(pRow["plan_id"].ToString());
                    afiliado.usuario = Int32.Parse(pRow["us_id"].ToString());
                }

                return afiliado;

            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);
                throw e;
            }

        }

        #endregion

        #region Turnos

        public static List<string> obtener_todas_especialidades()
        {
            try
            {
                string funcion = "SELECT KFC.fun_obtener_especialidades()";
                var parametros = new List<SqlParameter>();

                var reader = ejecutar_funcion(funcion, parametros);

                List<string> especialidades = ObtenerStringsReader(reader, 1);

                return especialidades;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);

                throw e;
            }
        }


        /// <summary>
        /// Ojo devuelve Lista de Apellido Con Nombre Profesional
        /// </summary>
        /// <param name="descripcionEspecialidad"></param>
        /// <returns></returns>
        public static List<string> obtener_todos_profesionales_para_especialid(string descripcionEspecialidad)
        {
            try
            {
                string funcion = "SELECT KFC.fun_obtener_profesionales_por_especialidad(@desc_esp)";
                SqlParameter parametro = new SqlParameter("@desc_esp", SqlDbType.Text);
                parametro.Value = descripcionEspecialidad;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

                var reader = ejecutar_funcion(funcion, parametros);

                List<string> profesionales = ObtenerStringsReader(reader, 1);

                return profesionales;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);

                throw e;
            }
        }

        public static List<string> obtener_turnos_disponibles(string apellidoConNombre, DateTime fecha)
        {
            try
            {
                //Debo hacer la separacion aca en C# porque no puedo hacerla facilmente en SQL
                string nombre = apellidoConNombre.Split('/')[0];
                string apellido = apellidoConNombre.Split('/')[1]; ;



                string funcion = "SELECT KFC.fun_obtener_turnos_profesional(@prof_nombre, @prof_apellido, @fecha)";
                SqlParameter parametro1 = new SqlParameter("@prof_nombre", SqlDbType.Text);
                parametro1.Value = nombre;
                SqlParameter parametro2 = new SqlParameter("@prof_apellido", SqlDbType.Text);
                parametro2.Value = apellido;
                SqlParameter parametro3 = new SqlParameter("@fecha", SqlDbType.Text);
                parametro3.Value = fecha;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);

                var reader = ejecutar_funcion(funcion, parametros);

                List<string> especialidades = ObtenerStringsReader(reader, 0);

                return especialidades;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);

                throw e;
            }
        }

        /// <summary>
        /// Devuelve Excepcion si falla, Caso contrario se ejecuto correctamente
        /// </summary>
        /// <param name="apellidoConNombre"></param>
        /// <param name="fecha"></param>
        /// <param name="descripcionEspecialidad"></param>
        /// <param name="id_afiliado"></param>
        public static void asignar_turno(string apellidoConNombre, DateTime fecha, string horario, string descripcionEspecialidad, int id_afiliado)
        {
            try
            {
                //Debo hacer la separacion aca en C# porque no puedo hacerla facilmente en SQL
                string nombre = apellidoConNombre.Split('/')[0];
                string apellido = apellidoConNombre.Split('/')[1]; ;

                string procedure = "KFC.pro_asignar_turno @fecha, @hora, @afil_id, @espe_desc, @prof_nombre, @prof_apellido ";
                SqlParameter parametro1 = new SqlParameter("@fecha", SqlDbType.Text);
                parametro1.Value = fecha;
                SqlParameter parametro2 = new SqlParameter("@hora", SqlDbType.Text);
                parametro2.Value = horario;
                SqlParameter parametro3 = new SqlParameter("@espe_desc", SqlDbType.Text);
                parametro3.Value = descripcionEspecialidad;
                SqlParameter parametro4 = new SqlParameter("@prof_nombre", SqlDbType.Text);
                parametro4.Value = nombre;
                SqlParameter parametro5 = new SqlParameter("@prof_apellido", SqlDbType.Text);
                parametro5.Value = apellido;
                SqlParameter parametro6 = new SqlParameter("@afil_id", SqlDbType.Text);
                parametro6.Value = id_afiliado;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);
                parametros.Add(parametro5);
                parametros.Add(parametro6);

                var reader = ejecutar_storedProcedure(procedure, parametros);

                //Veo si trajo datos o no
                if (reader.RecordsAffected <= 0) throw new Exception("No se pudo Asignar el Turno. Fallo Ejecucion Procedure");

                return;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);

                throw e;
            }
        }



        #endregion


        #region Roles

        public static void crear_rol(string nombre_rol, List<String> funcionalidades_descripcion)
        {
            try
            {
                string procedure = "KFC.pro_crear_rol @descripcion, @id OUTPUT ";
                SqlParameter parametro1 = new SqlParameter("@descripcion", SqlDbType.Text);
                parametro1.Value = nombre_rol;
                SqlParameter parametroOutput = new SqlParameter("@id", SqlDbType.Text);
                parametroOutput.DbType = DbType.Int32;
                parametroOutput.Direction = ParameterDirection.Output;


                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametroOutput);

                SqlCommand procedureEjecutado = ejecutar_storedProcedureConRetorno(procedure, parametros);

                int id_rol_creado = 0;
                id_rol_creado = Convert.ToInt32(procedureEjecutado.Parameters["@id"].Value);
                if (id_rol_creado <= 0) throw new Exception("No se creo el Rol, trajo ID invalido. Fallo Ejecucion Procedure");

                //Inserto Cada Funcionalidad
                foreach (var funcionalidad in funcionalidades_descripcion)
                {
                    insertar_funcionalidad(id_rol_creado, funcionalidad);
                }

                return;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);

                throw e;
            }
        }

        public static void insertar_funcionalidad(int id_rol, string descripcion_funcionalidad)
        {
            try
            {
                string procedure = "KFC.pro_crear_funcionalidad_de_rol @func_desc, @rol_id ";
                SqlParameter parametro1 = new SqlParameter("@func_desc", SqlDbType.Text);
                SqlParameter parametro2 = new SqlParameter("@rol_id", SqlDbType.Text);

                parametro1.Value = descripcion_funcionalidad;
                parametro2.Value = id_rol;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);


                var reader = ejecutar_storedProcedure(procedure, parametros);

                //Veo si trajo datos o no
                if (reader.RecordsAffected <= 0) throw new Exception("No se pudo asignar la Funcionalidad al Rol:'" + id_rol + "'. Fallo Ejecucion Procedure");

                return;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);

                throw e;
            }
        }

        #endregion

        #region llegada
        public static bool registrar_llegada(int id_afiliado , int id_turno, int id_bono)
        {
            try
            {
                
                string sql = "kfc.registrar_llegada @id_afiliado , @id_turno, @id_bono, @fecha";
                
                SqlParameter parametro1 = new SqlParameter("@fecha", SqlDbType.Time);
                parametro1.Value = DateTime.Now.TimeOfDay;
                SqlParameter parametro2 = new SqlParameter("@id_turno", SqlDbType.Int);
                parametro2.Value = id_turno;
                SqlParameter parametro3 = new SqlParameter("@id_afiliado", SqlDbType.Int);
                parametro3.Value = id_afiliado;
                SqlParameter parametro4 = new SqlParameter("@id_bono", SqlDbType.Int);
                parametro4.Value = id_bono;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);

                ejecutar_storedProcedureConRetorno(sql, parametros);

                return true;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);
                return false;
            }
        }
        #endregion
        #region Combos

        /// <summary>
        /// Obtiene los estados civiles desde la BD
        /// </summary>
        /// <returns></returns>
        public static List<ComboData> get_estados_civiles()
        {
            try
            {
                //Declaro un Objeto del tipo del retorno
                var lista_estados_civiles = new List<ComboData>();

                //creo la tabla que va a traer los registros
                DataTable dt = new DataTable();

                SqlConnection conexion = Conexion.Instance.get();

                string sql = "kfc.get_cmb_estado_civil";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //Lleno la tabla
                da.Fill(dt);

                //La recorro para armar la lista
                foreach (DataRow pRow in dt.Rows)
                {
                    var estado_civ = new ComboData(pRow["estado_id"], pRow["descripcion"]);
                    lista_estados_civiles.Add(estado_civ);
                }

                return lista_estados_civiles;

            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);
                throw e;
            }
        }

        /// <summary>
        /// Obtiene todos planes sociales de nuestro sistema
        /// </summary>
        /// <returns></returns>
        public static List<ComboData> get_planes_sociales()
        {
            try
            {
                //Declaro un Objeto del tipo del retorno
                var lista_planes_sociales = new List<ComboData>();

                //creo la tabla que va a traer los registros
                DataTable dt = new DataTable();

                SqlConnection conexion = Conexion.Instance.get();

                string sql = "kfc.get_cmb_planes_sociales";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //Lleno la tabla
                da.Fill(dt);


                //La recorro para armar la lista
                foreach (DataRow pRow in dt.Rows)
                {
                    var plan = new ComboData(pRow["id"], pRow["descripcion"]);
                    lista_planes_sociales.Add(plan);
                }

                return lista_planes_sociales;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);
                throw e;
            }
        }

        /// <summary>
        /// Obtiene los distintos tipos de documentos de identidad que reconoce nuestro sistema
        /// </summary>
        /// <returns></returns>
        public static List<ComboData> get_cmb_tipos_documentos()
        {
            try
            {
                //Declaro un Objeto del tipo del retorno
                var lista_tipos_documentos = new List<ComboData>();

                lista_tipos_documentos.Add(new ComboData(1, "DNI"));
                lista_tipos_documentos.Add(new ComboData(2, "Pasaporte"));
                lista_tipos_documentos.Add(new ComboData(3, "LE"));
                lista_tipos_documentos.Add(new ComboData(4, "LC"));
                return lista_tipos_documentos;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);
                throw e;
            }
        }

        /// <summary>
        /// Obtiene las especialidades para atencion 
        /// </summary>
        /// <returns></returns>
        public static List<ComboData> get_especialidades()
        {
            try
            {
                //Declaro un Objeto del tipo del retorno
                var lista_especialidades = new List<ComboData>();

                //creo la tabla que va a traer los registros
                DataTable dt = new DataTable();

                SqlConnection conexion = Conexion.Instance.get();

                string sql = "kfc.get_cmb_especialidades";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //Lleno la tabla
                da.Fill(dt);

                //La recorro para armar la lista
                foreach (DataRow pRow in dt.Rows)
                {
                    var esp = new ComboData(pRow["id"], pRow["descripcion"]);
                    lista_especialidades.Add(esp);
                }

                return lista_especialidades;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);
                throw e;
            }
        }

        /// <summary>
        /// permite obtener los Profesionales seleccionando  una Profesion
        /// </summary>
        /// <param name="profesion_id"></param>
        /// <returns></returns>
        public static List<ComboData> obtener_Profesionales_x_Profesion(int profesion_id)
        {

            try
            {
                //Declaro un Objeto del tipo del retorno
                var lista_profesionales = new List<ComboData>();

                //creo la tabla que va a traer los registros
                DataTable dt = new DataTable();

                SqlConnection conexion = Conexion.Instance.get();

                string sql = "kfc.get_cmb_prof_x_esp @prof_id";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                var parametro1 = new SqlParameter("@prof_id", SqlDbType.Int);
                parametro1.Value = profesion_id;
                cmd.Parameters.Add(parametro1);

                //Lleno la tabla
                da.Fill(dt);

                //La recorro para armar la lista
                foreach (DataRow pRow in dt.Rows)
                {
                    var esp = new ComboData(pRow["id"], pRow["descripcion"]);
                    lista_profesionales.Add(esp);
                }

                return lista_profesionales;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);
                throw e;
            }
        }

        /// <summary>
        /// Obtener los bonos sin usar de un afiliado
        /// </summary>
        /// <param name="afiliado_id"></param>
        /// <param name="plan_id"></param>
        /// <returns></returns>
        public static List<ComboData> get_bonos_afiliado(int afiliado_id, int plan_id)
        {

            try
            {
                //Declaro un Objeto del tipo del retorno
                var lista_bonos = new List<ComboData>();

                //creo la tabla que va a traer los registros
                DataTable dt = new DataTable();

                SqlConnection conexion = Conexion.Instance.get();

                string sql = "kfc.get_bonos_afiliado @afiliado_id, @plan_id";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                var parametro1 = new SqlParameter("@afiliado_id", SqlDbType.Int);
                var parametro2 = new SqlParameter("@plan_id", SqlDbType.Int);
                parametro1.Value = afiliado_id;
                parametro2.Value = plan_id;
                cmd.Parameters.Add(parametro1);
                cmd.Parameters.Add(parametro2);
                //Lleno la tabla
                da.Fill(dt);

                //La recorro para armar la lista
                foreach (DataRow pRow in dt.Rows)
                {
                    var esp = new ComboData(pRow["id"], pRow["descripcion"]);
                    lista_bonos.Add(esp);
                }

                return lista_bonos;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);
                throw e;
            }
        }

        /*
        /// <summary>
        /// Obtiene los turnos para el dia de hoy del paciente
        /// </summary>
        /// <param name="afiliado_id"></param>
        /// <param name="especialidad_id"></param>
        /// <param name="profesional_id"></param>
        /// <returns></returns>
        public static List<Turno> get_turno_hoy_paciente(int afiliado_id, int especialidad_id, int profesional_id)
        {

            try
            {
                //Declaro un Objeto del tipo del retorno
                var lista_turnos = new List<ComboData>();

                //creo la tabla que va a traer los registros
                DataTable dt = new DataTable();

                SqlConnection conexion = Conexion.Instance.get();

                string sql = "kfc.get_turno_hoy_paciente @afiliado_id, @especialidad_id, @profesional_id, @fecha ";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                var parametro1 = new SqlParameter("@afiliado_id", SqlDbType.Int);
                var parametro2 = new SqlParameter("@especialidad_id", SqlDbType.Int);
                var parametro3 = new SqlParameter("@profesional_id", SqlDbType.Int);
                var parametro4 = new SqlParameter("@fecha", SqlDbType.DateTime);
                parametro1.Value = afiliado_id;
                parametro2.Value = especialidad_id;
                parametro3.Value = profesional_id;
                parametro4.Value = DateTime.Today;
                cmd.Parameters.Add(parametro1);
                cmd.Parameters.Add(parametro2);
                cmd.Parameters.Add(parametro3);
                cmd.Parameters.Add(parametro4);
                //Lleno la tabla
                da.Fill(dt);

                //La recorro para armar la lista
                foreach (DataRow pRow in dt.Rows)
                {
                    //...
                    lista_turnos.Add(esp);
                }

                return lista_turnos;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);
                throw e;
            }
        }
        */

        public static List<ComboData> get_turno_hoy(int afiliado_id, int especialidad_id, int profesional_id)
        {

            try
            {
                //Declaro un Objeto del tipo del retorno
                var lista_turnos = new List<ComboData>();

                //creo la tabla que va a traer los registros
                DataTable dt = new DataTable();

                SqlConnection conexion = Conexion.Instance.get();

                string sql = "kfc.get_turno_hoy @afiliado_id, @especialidad_id, @profesional_id, @fecha ";

                SqlCommand cmd = new SqlCommand(sql, conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                var parametro1 = new SqlParameter("@afiliado_id", SqlDbType.Int);
                var parametro2 = new SqlParameter("@especialidad_id", SqlDbType.Int);
                var parametro3 = new SqlParameter("@profesional_id", SqlDbType.Int);
                var parametro4 = new SqlParameter("@fecha", SqlDbType.Time);
                parametro1.Value = afiliado_id;
                parametro2.Value = especialidad_id;
                parametro3.Value = profesional_id;
                parametro4.Value = DateTime.Now.TimeOfDay;
                cmd.Parameters.Add(parametro1);
                cmd.Parameters.Add(parametro2);
                cmd.Parameters.Add(parametro3);
                cmd.Parameters.Add(parametro4);
                //Lleno la tabla
                da.Fill(dt);

                //La recorro para armar la lista
                foreach (DataRow pRow in dt.Rows)
                {
                    var esp = new ComboData(pRow["id"], pRow["descripcion"]);
                    lista_turnos.Add(esp);
                }

                return lista_turnos;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);
                throw e;
            }
        }
        #endregion


    }
}
