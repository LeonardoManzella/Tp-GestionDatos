using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.AgendaMedico;

namespace ClinicaFrba.Base_de_Datos
{
    class BD_Profesional
    {
        public static int obtenerID_profesional(int user_id)
        {
            try
            {
                string funcion = "SELECT KFC.fun_obtener_id_profesional_x_user_id(@us_id)";
                SqlParameter parametro1 = new SqlParameter("@us_id", SqlDbType.Int);
                parametro1.Value = user_id;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);

                int id = InteraccionDB.ObtenerIntReader(reader, 0);

                return id;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                throw e;
            }

        }

        public static List<string> getEspecialidadesProfesional(int profID)
        {
            try
            {
                string funcion = "SELECT * FROM  KFC.fun_obtener_especialidades_prof(@id_profesional)";
                SqlParameter parametro = new SqlParameter("@id_profesional", SqlDbType.Int);
                parametro.Value = profID;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

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

        public static DateTime getUltimaFechaAgenda(int profID)
        {
            try
            {
                string funcion = "SELECT KFC.fun_obtener_rango_agenda(@prof_id)";
                SqlParameter parametro = new SqlParameter("@prof_id", SqlDbType.Int);
                parametro.Value = profID;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);

                if (!reader.HasRows)
                    throw new Exception("Reader sin Filas");

                DateTime maxFecha = DateTime.Now;
                bool flag_leyo_algo = false;

                while (reader.Read())
                {
                    maxFecha = reader.GetDateTime(0);
                    flag_leyo_algo = true;
                    break;
                }
                if (flag_leyo_algo == false)
                    throw new Exception("Hubo un problema al obtener la maxima fecha de la agenda");
                return maxFecha;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                throw e;
            }
        }

        internal static void crearAgenda(int idProfesional, DateTime fechaDesde, DateTime fechaHasta, List<HorariosDia> diasAgenda)
        {
            throw new NotImplementedException();
        }
    }
}
