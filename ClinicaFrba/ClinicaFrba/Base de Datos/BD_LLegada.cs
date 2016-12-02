using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaFrba.Base_de_Datos
{
    public static class BD_LLegada
    {
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

        /// <summary>
        /// Obtiene los turnos para el dia de hoy del paciente
        /// </summary>
        /// <param name="afiliado_id"></param>
        /// <param name="especialidad_id"></param>
        /// <param name="profesional_id"></param>
        /// <returns></returns>
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
                parametro4.Value = DateTime.Parse(Configuracion_Global.fecha_actual);
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
                InteraccionDB.ImprimirExcepcion(e);
                throw e;
            }
        }
        
        /// <summary>
        /// registrar la llegada de un paciente al turno 
        /// </summary>
        /// <param name="id_afiliado"></param>
        /// <param name="id_turno"></param>
        /// <param name="id_bono"></param>
        /// <returns></returns>
        public static bool registrar_llegada(int id_afiliado, int id_turno, int id_bono)
        {
            try
            {

                string sql = "kfc.registrar_llegada @id_afiliado , @id_turno, @id_bono, @fecha";

                SqlParameter parametro1 = new SqlParameter("@fecha", SqlDbType.Time);
                parametro1.Value = DateTime.Parse(Configuracion_Global.fecha_actual).TimeOfDay;
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

                InteraccionDB.ejecutar_storedProcedureConRetorno(sql, parametros);

                return true;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                return false;
            }
        }
    }
}
