﻿using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClinicaFrba.Base_de_Datos
{

    /// <summary>
    /// Contiene cosas Comunes a multiples funcionalidades
    /// </summary>
    public static class InteraccionDB
    {
        public static Usuario usuario;

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

        /// <summary>
        /// En el string "procedure" solo asignar el nombre del procedimiento sin parametros. 
        /// <para>Ejemplo: "KFC.procedimiento"</para>
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
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

        /// <summary>
        /// En el string "procedure" solo asignar el nombre del procedimiento sin parametros. 
        /// <para>Ejemplo: "KFC.procedimiento"</para>
        /// <para>Recordar definir "DbType" y "ParameterDirection" </para>
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
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


        public static void comprobarConexionBaseDatos()
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.Instance.get();
                if (conexion == null) throw new Exception("No se pueden Obtener Conexiones de la Base de Datos. Devuelve Null");
            }
            catch (Exception ex)
            {
                ImprimirExcepcion(ex);
                throw new Exception("Error al Conectar con la Base de Datos. Compruebe que exista la Base, el Esquema y las Tablas. Error: " + ex.Message);
            }
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

            int valorObtener = -1;
            bool flag_leyo_algo = false;

            //Obtengo Multiples datos
            while (reader.Read())
            {
                valorObtener = reader.GetInt32(columnaPorObtener);
                flag_leyo_algo = true;
                break;  //Unico Valor a Obtener

            }
            if (flag_leyo_algo == false) throw new Exception("Hubo un Problema al Obtener Dato Int");
            return valorObtener;
        }

        /// <summary>
        /// Obtenemos una Columna Entera en formato String del Reader. La 'cantidadColumnasPorObtener'es cuantas columnas queremos leer
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="cantidadColumnasPorObtener"></param>
        /// <returns></returns>
        public static List<string> ObtenerStringDeColumnasReader(SqlDataReader reader, int cantidadColumnasPorObtener)
        {
            //Veo si trajo datos o no
            if (!reader.HasRows) throw new Exception("Reader sin Filas");

            var strings = new List<string>();

            //Obtengo Multiples datos
            while (reader.Read() )
            {
                for (int columnaActual = 0; columnaActual < cantidadColumnasPorObtener; columnaActual++)
                {
                    string unString = reader.GetString(columnaActual);
                    strings.Add(unString);
                    unString = null;
                }
                break;
            }

            if (strings.Count <= 0) throw new Exception("No se cargaron Strings a la Lista que Representa Columna");
            return strings;
        }

        // <summary>
        /// Obtenemos Bool del Reader. La 'columnaPorObtener' empieza 0 para la primer columna y asi..
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnaPorObtener"></param>
        /// <returns></returns>
        public static bool ObtenerBoolReader(SqlDataReader reader, int columnaPorObtener)
        {
            //Veo si trajo datos o no
            if (!reader.HasRows) throw new Exception("Reader sin Filas");

            bool valorObtener = false;
            bool flag_leyo_algo = false;

            //Obtengo Multiples datos
            while (reader.Read())
            {
                valorObtener = reader.GetBoolean(columnaPorObtener);
                flag_leyo_algo = true;
                break;  //Unico Valor a Obtener

            }
            if (flag_leyo_algo == false) throw new Exception("Hubo un Problema al Obtener Dato Booleano");
            return valorObtener;
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

        public static List<string> obtener_todas_funcionalidades()
        {
            try
            {
                string funcion = "SELECT * FROM KFC.fun_obtener_todas_las_funcionalidades()";
                var parametros = new List<SqlParameter>();

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);

                List<string> funcionalidades = InteraccionDB.ObtenerStringsReader(reader, 1);

                return funcionalidades;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }


        #region llegada
        public static bool registrar_llegada(int id_afiliado, int id_turno, int id_bono)
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