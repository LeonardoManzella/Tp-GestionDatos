using System.Data.SqlClient;

namespace ClinicaFrba.Base_de_Datos
{
    public sealed class Conexion
    {
        private static Conexion instance = null;
        private static readonly object padlock = new object();

        private SqlConnection conexion_interna;

        /// <summary>
        /// Metodo Interno para el Singleton.
        /// </summary>
        /// <returns></returns>
        public SqlConnection get()
            { return conexion_interna; }


        /// <summary>
        /// Constructor Interno
        /// </summary>
        private Conexion()
        {
            conexion_interna = new SqlConnection("Password=gd2016;Persist Security Info=True;User ID=gd;Initial Catalog=GD2C2016;Data Source=.\\SQLSERVER2012");

            conexion_interna.Open();

            var sqlCommand = new SqlCommand("SELECT * FROM KFC.roles", conexion_interna);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            
            /* 
            //Para Pruebas, no borrar
            while (reader.Read())
            {
                string name = reader.GetString(1);
                var i = 5;
            }
            */
        }

        /// <summary>
        /// Constructor Externo. Es un Singleton. Devuelve siempre la misma conexion.
        /// </summary>
        public static Conexion Instance
        {
            get
            {
                lock(padlock)
                {
                    if(instance == null)
                    {
                        instance = new Conexion();
                    }
                    return instance;
                }
            }
        }
    }
}
