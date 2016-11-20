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
            Base_de_Datos.BD_Afiliados.alta_afiliado(afil);
        }

        /// <summary>
        /// Obtiene los datos necesarios para el alta del nuevo afiliado
        /// </summary>
        /// <param name="afil"></param>
        public static void modifica_afiliado(Afiliado afil)
        {
            Base_de_Datos.BD_Afiliados.modifica_afiliado(afil);
        }

        /// <summary>
        /// Obtiene los estados civiles para llenar el combo
        /// </summary>
        /// <returns></returns>
        public static List<ComboData> get_Estados_Civiles()
        {
            return Base_de_Datos.InteraccionDB.get_estados_civiles();
        }

        /// <summary>
        /// obtiene los planes sociales para el combo
        /// </summary>
        /// <returns></returns>
        public static List<ComboData> get_Planes_Sociales()
        {
            return Base_de_Datos.InteraccionDB.get_planes_sociales();
        }

        /// <summary>
        /// obtiene los distintos tipos de documentos para el combo
        /// </summary>
        /// <returns></returns>
        public static List<ComboData> get_Tipos_Documentos()
        {
            return Base_de_Datos.InteraccionDB.get_cmb_tipos_documentos();
        }


        public static Afiliado Get_Afiliado(int afiliado_id)
        {
            return Base_de_Datos.BD_Afiliados.get_afiliado(afiliado_id);
        }

    }
}
