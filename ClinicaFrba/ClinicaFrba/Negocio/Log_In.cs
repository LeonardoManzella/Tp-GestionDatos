using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Base_de_Datos;

namespace ClinicaFrba.Negocio
{
     public static class Log_In
    {
        public static Usuario Ingresar_App(string usuario,string password)
        {
            try
            {
                var valido = validar_datos_login(usuario, password);
                if (valido)
                    return InteraccionDB.log_in(usuario, password);
                else
                    throw new  Exception("Ha ocurrido un problema, ni el usuario ni la contraseña pueden estar en blanco");

            }
            catch(Exception e)
            {
                throw e; 
            }

        }
        private static bool validar_datos_login(string usuario, string password)
        {
            return !(String.IsNullOrEmpty(usuario) && String.IsNullOrEmpty(password));
        }
    }
}
