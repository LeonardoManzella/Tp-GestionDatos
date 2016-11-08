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

                //Veo si trajo datos o no
                if (!reader.HasRows) throw new Exception("Reader sin Filas: Usuario Inexistente, Esta mal la Contraseña o no esta habilitado el Usuario");
                int id = -1;

                //Obtengo Multiples datos
                while (reader.Read())
                {
                    id = reader.GetInt32(0);        //Obtengo Dato primer columna, la columna 0
                    break;      //Por ser unica fila la que quiero
                }
                
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

                //Veo si trajo datos o no
                if (!reader.HasRows) throw new Exception("Reader sin Filas: Afiliado Inexistente, revisar nombre y apellido");
                int id = -1;

                //Obtengo Multiples datos
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    break;
                }

                if (id == -1) throw new Exception("Error al convertir datos de la Base");

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

                SqlCommand comando_sql = new SqlCommand("kfc.alta_afiliado  @nombre, @apellido, @tipo_doc, @nro_doc, @direccion, @telefono, @mail, @sexo, @fecha_nac, @estado, @plan, @usuario", conexion);
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
                parametro0.Direction = ParameterDirection.ReturnValue;

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

                var id = (int) comando_sql.Parameters["@afil_id"].Value; 
                if (id == -1) throw new Exception("No se ha podido crear el nuevo afiliado en la base");

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

                //Veo si trajo datos o no
                if (!reader.HasRows) throw new Exception("Reader sin Filas: No hay Planes en la Base Datos");

                var planes = new List<string>();

                //Obtengo Multiples datos
                while (reader.Read())
                {
                    string plan = reader.GetString(5);
                    planes.Add(plan);
                    plan = "";

                }

                if( planes.Count <= 0 ) throw new Exception("No se cargaron Planes a la Lista");

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

                //Veo si trajo datos o no
                if (!reader.HasRows) throw new Exception("Reader sin Filas: No encontro Precio Plan Base Datos");

                int precio = 0;

                //Obtengo Multiples datos
                while (reader.Read())
                {
                    precio = reader.GetInt32(0);
                    break;

                }
                if (precio <= 0) throw new Exception("Precio No valido");

                return precio;
            }
            catch (Exception e)
            {
                ImprimirExcepcion(e);

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
    }
}
