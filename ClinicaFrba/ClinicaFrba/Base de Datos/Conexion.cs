using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicaFrba.Base_de_Datos
{
    public sealed class Conexion
    {
        private static Conexion instance = null;
        private static readonly object padlock = new object();

        private SqlConnection conn;

        public SqlConnection get()
            { return conn; }

        private Conexion()
        {
            conn = new SqlConnection("Password=gd2016;Persist Security Info=True;User ID=gd;Initial Catalog=GD2C2016;Data Source=.\\SQLSERVER2012");

            //
            //String connectionString;
            //connectionString = "user id=" + "gd";
            //connectionString += ";password=" + "gd2016";
            //connectionString += ";server=localhost";
            //connectionString += ";Trusted_Connection=yes";
            //connectionString += ";database=GD2C2016";
            //connectionString += ";connection timeout=30";
            //conn.ConnectionString = connectionString;

            conn.Open();

            var sqlCommand = new SqlCommand("SELECT * FROM KFC.roles", conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(1);
                var i = 5;
            }
        }

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
