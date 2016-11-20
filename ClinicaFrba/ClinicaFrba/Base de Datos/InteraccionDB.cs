using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaFrba.Base_de_Datos
{

    /// <summary>
    /// Contiene cosas Comunes a multiples funcionalidades
    /// </summary>
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


        public static void ImprimirExcepcion(Exception e)
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
        public static List<string> ObtenerStringsReader(SqlDataReader reader, int columnaPorObtener)
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
        public static int ObtenerIntReader(SqlDataReader reader, int columnaPorObtener)
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


        public static Usuario log_in(string usuario, string password, string rol_descripcion)
        {
            try
            {
                string funcion = "SELECT KFC.fun_validar_usuario(@user, @contrasenia, @rol_desc)";
                SqlParameter parametro1 = new SqlParameter("@user", SqlDbType.Text);
                parametro1.Value = usuario.ToUpper();
                SqlParameter parametro2 = new SqlParameter("@contrasenia", SqlDbType.Text);
                parametro2.Value = password.ToUpper();
                SqlParameter parametro3 = new SqlParameter("@rol_desc", SqlDbType.Text);
                parametro3.Value = rol_descripcion.ToUpper();

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);

                var reader = ejecutar_funcion(funcion, parametros);


                int id = -1;
                try
                {
                    id = ObtenerIntReader(reader, 0);
                }
                catch (Exception e)
                {
                    ImprimirExcepcion(e);
                    throw new Exception("Fallo Obtener Datos: Usuario Inexistente, Esta mal la Contraseña, el Rol o no esta habilitado el Usuario");
                }

                if (id == -1) throw new Exception("Usuario Inexistente, Esta mal la Contraseña, el Rol o no esta habilitado el Usuario");

                Usuario user = cargar_datos(id);

                return user;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);

                throw e;
            }
        }

        private static Usuario cargar_datos(int usuario_id)
        {
            try
            {
                var usuario = new Usuario();
                usuario.id = usuario_id;

                string funcion = "SELECT * FROM KFC.fun_obtener_roles_usuario(@usuario_id)";
                SqlParameter parametro = new SqlParameter("@usuario_id", SqlDbType.Int);
                parametro.Value = usuario_id;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

                var reader = ejecutar_funcion(funcion, parametros);
                usuario.permisos = ObtenerStringsReader(reader, 1);

                //Otros valores falta ver que hacemos con eso. No es necesario Obtenerlos de la Base.
                return usuario;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);

                throw e;
            }
        }

        public static List<string> obtener_todas_especialidades()
        {
            try
            {
                string funcion = "SELECT * FROM KFC.fun_obtener_especialidades()";
                var parametros = new List<SqlParameter>();

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);

                List<string> especialidades = InteraccionDB.ObtenerStringsReader(reader, 1);

                return especialidades;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }

        public static List<string> pedir_planes_usuario(int id_usuario)
        {
            try
            {
                string funcion = "SELECT * FROM  KFC.fun_obtener_planes_afiliado(@afiliado_id)";
                SqlParameter parametro = new SqlParameter("@afiliado_id", SqlDbType.Text);
                parametro.Value = id_usuario;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);

                List<string> planes = InteraccionDB.ObtenerStringsReader(reader, 5);

                return planes;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }


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

                string sql = "select * from kfc.fun_obtener_todos_los_planes";

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

       
        #endregion
    }
}
