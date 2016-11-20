﻿using System;
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

        public static List<string> obtener_turnos_disponibles(string apellidoConNombre, DateTime fecha)
        {
            try
            {
                //Debo hacer la separacion aca en C# porque no puedo hacerla facilmente en SQL
                string nombre = apellidoConNombre.Split(',')[0];
                string apellido = apellidoConNombre.Split(',')[1];



                string funcion = "SELECT  * FROM KFC.fun_obtener_turnos_profesional(@prof_nombre, @prof_apellido, @fecha)";
                SqlParameter parametro1 = new SqlParameter("@prof_nombre", SqlDbType.Text);
                parametro1.Value = nombre;
                SqlParameter parametro2 = new SqlParameter("@prof_apellido", SqlDbType.Text);
                parametro2.Value = apellido;
                SqlParameter parametro3 = new SqlParameter("@fecha", SqlDbType.Date);
                parametro3.Value = fecha;

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
                string nombre = apellidoConNombre.Split(',')[0];
                string apellido = apellidoConNombre.Split(',')[1];

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
