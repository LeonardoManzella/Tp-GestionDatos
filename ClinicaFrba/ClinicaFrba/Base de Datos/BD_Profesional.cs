using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                SqlParameter parametro = new SqlParameter("@id_profesional", SqlDbType.Text);
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

        public static List<DateTime> getRangoOcupadoAgenda(int profID)
        {
            try
            {
                string funcion = "SELECT * FROM  KFC.fun_obtener_rango_agenda(@prof_id)";
                SqlParameter parametro = new SqlParameter("@id_profesional", SqlDbType.Text);
                parametro.Value = profID;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);

                if (!reader.HasRows)
                    throw new Exception("Reader sin filas");

                var rango = new List<DateTime>();

                int i = 0;
                while (reader.Read())
                {
                    DateTime min = reader.GetDateTime(i);
                    rango.Add(min);
                    i++;
                }

                if (rango.Count <= 0) throw new Exception("No se cargaron las fechas a la lista");
                return rango;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                throw e;
            }
        }
    }
}
