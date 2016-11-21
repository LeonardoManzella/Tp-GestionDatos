using ClinicaFrba.Base_de_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class ModificarRol : Form
    {
        private int id_rol;
        private string nombreRol;
        private List<string> funcionalidades_del_rol;
        private List<string> funcionalidades_posibles;


        public ModificarRol()
        {
            InitializeComponent();
        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {
            try
            {
                id_rol = 0;
                nombreRol = null;
                funcionalidades_del_rol = new List<string>();
                funcionalidades_posibles = InteraccionDB.obtener_todas_funcionalidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_busqueda_Click(object sender, EventArgs e)
        {
            try
            {
                this.nombreRol = textBox_nombreRol.Text.Trim();
                if (String.IsNullOrEmpty(nombreRol)) throw new Exception("Nombre Vacio");

                id_rol = BD_Roles.obtenerID_rol(nombreRol);

                funcionalidades_del_rol = BD_Roles.obtener_funcionalidades_rol(id_rol);

                foreach (string func in funcionalidades_del_rol)
                {
                    checkedListBox_Funcionalidades.Items.Add(func, true);
                }

                //Agrego los sin Seleccionar para el Rol
                var sinSeleccionar = funcionalidadesSinSeleccionar();
                foreach (string func in sinSeleccionar)
                {
                    checkedListBox_Funcionalidades.Items.Add(func, false);
                }

                this.label3.Text = id_rol.ToString();
                this.checkedListBox_Funcionalidades.Enabled = true;
                this.checkBox_rolHabilitado.Enabled         = true;
                this.button_modificarRol.Enabled            = true;
            }
            catch (Exception ex)
            {
                this.label3.Text = "";
                MessageBox.Show(ex.Message, "Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> funcionalidadesSinSeleccionar()
        {
            //genero copia para trabajar
            List<string> sinSeleccionar = new List<string>(funcionalidades_posibles);

            //Quito los Duplicados
            foreach (var fun_del_rol in funcionalidades_del_rol)
            {
                sinSeleccionar.Remove(fun_del_rol);
            }

            return sinSeleccionar;
        }

        private void button_modificarRol_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtengo items elegidos y convierto a strings
                List<string> funcionalidades_elegidas = new List<string>();
                var objects = checkedListBox_Funcionalidades.CheckedItems;
                if (objects.Count <= 0) throw new Exception("No hay Funcionalidades Elegidas");

                foreach (var item in objects)
                {
                    string fun = Convert.ToString(item);
                    funcionalidades_elegidas.Add(fun);
                    //MessageBox.Show(fun, "Crear Rol", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
