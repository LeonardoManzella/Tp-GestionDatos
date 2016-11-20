using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;

namespace ClinicaFrba.Negocio
{
    public static class Llegada_At_Med
    {
        public static List<ComboData> obtenerEspecialidades()
        {
            return Base_de_Datos.InteraccionDB.get_especialidades();
        }

        public static List<ComboData> obtener_bonos(int paciente, int plan)
        {
            return Base_de_Datos.InteraccionDB.get_bonos_afiliado(paciente, plan);
        }
        public static List<ComboData> obtener_profesionales(int especialidad)
        {
            return Base_de_Datos.InteraccionDB.obtener_Profesionales_x_Profesion(especialidad);
        }
        public static List<ComboData> get_turnos_hoy(int afiliado, int especialidad, int profesional)
        {
            return Base_de_Datos.InteraccionDB.get_turno_hoy(afiliado, especialidad, profesional);
        }
        public static void registrarLLegada(int afiliado, int turno, int bono)
        {
            var rta = Base_de_Datos.InteraccionDB.registrar_llegada(afiliado, turno, bono);
            if (!rta)
            { throw new Exception("No se ha podido registrar la llegada"); }
        }
    }
}
