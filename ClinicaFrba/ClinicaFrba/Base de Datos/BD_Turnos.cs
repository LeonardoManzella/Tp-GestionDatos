using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Base_de_Datos
{
    class BD_Turnos
    {

        


        /// <summary>
        /// Ojo devuelve Lista de Apellido Con Nombre Profesional
        /// </summary>
        /// <param name="descripcionEspecialidad"></param>
        /// <returns></returns>
        public static List<string> obtener_todos_profesionales_para_especialid(string descripcionEspecialidad)
        {
            try
            {
                string funcion = "SELECT  * FROM KFC.fun_obtener_profesionales_por_especialidad(@desc_esp)";
                SqlParameter parametro = new SqlParameter("@desc_esp", SqlDbType.Text);
                parametro.Value = descripcionEspecialidad;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);

                List<string> profesionales = InteraccionDB.ObtenerStringsReader(reader, 1);

                return profesionales;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }

        public static List<string> obtener_turnos_cancelables(Usuario usuario)
        {
            try
            {
                int idAfiliado = BD_Afiliados.obtenerID_afiliado(usuario.nombre, usuario.apellido, usuario.id);

                string funcion = "SELECT  * FROM KFC.fun_obtener_turnos_cancelables(@afil_id)";
                SqlParameter parametro = new SqlParameter("@afil_id", SqlDbType.Int);
                parametro.Value = idAfiliado;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);

                if (!reader.HasRows) throw new Exception("Reader sin filas");

                List<string> turnos = new List<string>();

                while (reader.Read())
                {
                    string profesional = reader.GetString(0);
                    string fecha = reader.GetString(1);
                    string hora = reader.GetString(2);
                    string especialidad = reader.GetString(3);

                    string turno = profesional + " - " + especialidad + " - " + fecha + " - " + hora;
                    turnos.Add(turno);

                }

                if (turnos.Count == 0)
                    throw new Exception("No se encontraron los turnos cancelables");

                return turnos;

            }
            catch(Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                throw e;
            }
        
        }

        internal static void cancelar_turnos_pro(DateTime fechaDesde, DateTime fechaHasta, string motivo, int id)
        {
            throw new NotImplementedException();
        }

        public static void cancelar_turno(string nombreProfesional, string apellidoProfesional, string especialidad, DateTime fecha, string hora, string motivo, string tipo)
        {
            try
            {

                string procedure = "KFC.pro_cancelar_turno";
                SqlParameter parametro1 = new SqlParameter("@fecha", SqlDbType.Date);
                parametro1.Value = fecha;
                SqlParameter parametro2 = new SqlParameter("@hora", SqlDbType.Text);
                parametro2.Value = hora;
                SqlParameter parametro3 = new SqlParameter("@espe_desc", SqlDbType.Text);
                parametro3.Value = especialidad;
                SqlParameter parametro4 = new SqlParameter("@prof_nombre", SqlDbType.Text);
                parametro4.Value = nombreProfesional;
                SqlParameter parametro5 = new SqlParameter("@prof_apellido", SqlDbType.Text);
                parametro5.Value = apellidoProfesional;
                SqlParameter parametro6 = new SqlParameter("@motivo", SqlDbType.Text);
                parametro6.Value = motivo;
                SqlParameter parametro7 = new SqlParameter("@tipo", SqlDbType.Text);
                parametro7.Value = tipo;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);
                parametros.Add(parametro5);
                parametros.Add(parametro6);
                parametros.Add(parametro7);

                var reader = InteraccionDB.ejecutar_storedProcedure(procedure, parametros);

                if (reader.RecordsAffected <= 0) throw new Exception("No se pudo cancelar el turno. Fallo la ejecucion del procedure");

                return;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);
                throw e;
            }
        }

        public static List<string> obtener_turnos_disponibles(string apellidoConNombre, DateTime fecha)
        {
            try
            {
                //Debo hacer la separacion aca en C# porque no puedo hacerla facilmente en SQL
                string apellido = apellidoConNombre.Split(',')[0];
                string nombre = apellidoConNombre.Split(',')[1];



                string funcion = "SELECT  * FROM KFC.fun_obtener_turnos_profesional(@prof_nombre, @prof_apellido, @fecha)";
                SqlParameter parametro1 = new SqlParameter("@prof_nombre", SqlDbType.Text);
                parametro1.Value = nombre;
                SqlParameter parametro2 = new SqlParameter("@prof_apellido", SqlDbType.Text);
                parametro2.Value = apellido;
                SqlParameter parametro3 = new SqlParameter("@fecha", SqlDbType.DateTime);
                parametro3.Value = fecha;
                /*
                SqlParameter parametro3 = new SqlParameter("@fecha", SqlDbType.Text);
                parametro3.Value = "2016.01.01";
                */

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);

                List<string> especialidades = InteraccionDB.ObtenerStringsReader(reader, 0);

                return especialidades;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

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
                string apellido = apellidoConNombre.Split(',')[0];
                string nombre = apellidoConNombre.Split(',')[1];

                string procedure = "KFC.pro_asignar_turno";
                SqlParameter parametro1 = new SqlParameter("@fecha", SqlDbType.Date);
                parametro1.Value = fecha;
                SqlParameter parametro2 = new SqlParameter("@hora", SqlDbType.Text);
                parametro2.Value = horario;
                SqlParameter parametro3 = new SqlParameter("@espe_desc", SqlDbType.Text);
                parametro3.Value = descripcionEspecialidad;
                SqlParameter parametro4 = new SqlParameter("@prof_nombre", SqlDbType.Text);
                parametro4.Value = nombre;
                SqlParameter parametro5 = new SqlParameter("@prof_apellido", SqlDbType.Text);
                parametro5.Value = apellido;
                SqlParameter parametro6 = new SqlParameter("@afil_id", SqlDbType.Int);
                parametro6.Value = id_afiliado;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);
                parametros.Add(parametro5);
                parametros.Add(parametro6);

                var reader = InteraccionDB.ejecutar_storedProcedure(procedure, parametros);

                //Veo si trajo datos o no
                if (reader.RecordsAffected <= 0) throw new Exception("No se pudo Asignar el Turno. Fallo Ejecucion Procedure");

                return;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }
    }
}
