using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Negocio
{
    public static class ABMAFIL
    { //Acá irían si hubieran validaciones sobre los datos que no sean sobre el  tipo


        /// <summary>
        /// Obtiene los datos necesarios para el alta del nuevo afiliado
        /// </summary>
        /// <param name="afil"></param>
        public static void alta_afiliado(Afiliado afil)
        {
            Base_de_Datos.InteraccionDB.alta_afiliado(afil);
        }

        public static List<ComboData> get_Estados_Civiles()
        {
            return Base_de_Datos.InteraccionDB.get_estados_civiles();
        }

        public static List<ComboData> get_Planes_Sociales()
        {
            return Base_de_Datos.InteraccionDB.get_planes_sociales();
        }

        public static List<ComboData> get_Tipos_Documentos()
        {
            return Base_de_Datos.InteraccionDB.get_cmb_tipos_documentos();
        }
    }
}
