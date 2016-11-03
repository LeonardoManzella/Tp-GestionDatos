using System;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaFrba.Base_de_Datos
{

    public static class InteraccionDB
    {

        public static Usuario log_in(string usuario, string password)
        {
            try
            {
                //TODO pasar todo esto a metodo con Variable Args para parameters y fijo primer parametro string sql
                SqlConnection conexion = Conexion.Instance.get();

                SqlCommand comando_sql = new SqlCommand("SELECT KFC.fun_validar_usuario(@user, @contrasenia)", conexion);
                SqlParameter parametro1 = new SqlParameter("@user", SqlDbType.Text);
                parametro1.Value = usuario.ToUpper();
                SqlParameter parametro2 = new SqlParameter("@contrasenia", SqlDbType.Text);
                parametro2.Value = password.ToUpper();
                comando_sql.Parameters.Add(parametro1);
                comando_sql.Parameters.Add(parametro2);

                //EL ERROR es al convertir a INT32 que no se porque no le gusta. Una vez solucionado eso deberia andar
                Int32 id = (Int32)comando_sql.ExecuteScalar();

                if (id == -1) throw new Exception("Usuario Inexistente, Esta mal la Contraseña o no esta habilitado el Usuario");


                var user = new Usuario();
                user.id = id;
                //Otros valores falta ver que hacemos con eso. No es necesario Obtenerlos de la Base.
                return user;
            }
            catch (Exception e)
            {
                //Imprimir para DEBUG enserio
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.InnerException);
                System.Diagnostics.Debug.WriteLine(e.HelpLink);
                System.Diagnostics.Debug.Write(e.StackTrace);


                //Imprimir para Consola :/
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                Console.WriteLine(e.HelpLink);
                Console.Write(e.StackTrace);

                throw e;
            }
        }



    }
}
