using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Clases;
using ClinicaFrba.Base_de_Datos;
using System.Data;
using System.Windows.Forms;

namespace ClinicaFrba.Base_de_Datos
{
    class BD_Bonos
    {
        
        public static int obtener_precio_plan(int id_usuario)
        {
            try
            {
                string funcion = "SELECT KFC.fun_devolver_precio_bono(@afiliado_id)";
                SqlParameter parametro = new SqlParameter("@afiliado_id", SqlDbType.Text);
                parametro.Value = id_usuario;

                var parametros = new List<SqlParameter>();
                parametros.Add(parametro);

                var reader = InteraccionDB.ejecutar_funcion(funcion, parametros);

                int precio = InteraccionDB.ObtenerIntReader(reader, 0);

                return precio;
            }
            catch (Exception e)
            {
                InteraccionDB.ImprimirExcepcion(e);

                throw e;
            }
        }

        public static void comprar_bono(int id_afiliado, int cantidad_bonos)
        {
            try
            {
                //Ejecuta tantas veces como Bonos Pedidos por el usuario
                for (int i = 0; i < cantidad_bonos; i++)
                {
                    string procedure = "KFC.pro_comprar_bono  @afil_id";
                    SqlParameter parametro = new SqlParameter("@afil_id", SqlDbType.Text);
                    parametro.Value = id_afiliado;

                    var parametros = new List<SqlParameter>();
                    parametros.Add(parametro);

                    var reader = InteraccionDB.ejecutar_storedProcedure(procedure, parametros);

                    //Veo si trajo datos o no
                    if (reader.RecordsAffected <= 0) throw new Exception("No se pudo Asignar el Turno. Fallo Ejecucion Procedure");
                    MessageBox.Show("Comprado Bono", "Comprar Bonos", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

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
