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

namespace ClinicaFrba.Compra_Bono
{
    public partial class CompraBono : Form
    {
        public enum tipos_funcionalidad
        {
            ADMIN,
            USUARIO
        };


        public tipos_funcionalidad funcionalidad;
        public Usuario usuario;
        private int usuario_id;

        public CompraBono()
        {
            InitializeComponent();
        }

        private void resetear_comprar()
        {
            this.textBox_Plan.Text = "";
            this.textBox_Cantidad.Text = "";
        }

        private void deshabilitar_busqueda()
        {
            this.textBox_Nombre.Enabled = false;
            this.textBox_Apellido.Enabled = false;
            this.textBox_Nombre.Visible = false;
            this.textBox_Apellido.Visible = false;
        }

        private void CompraBono_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.funcionalidad == tipos_funcionalidad.USUARIO)
                {
                    deshabilitar_busqueda();
                    this.usuario_id = usuario.id;
                    mostrar_plan();
                }
                else
                    this.usuario_id = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrar_plan()
        {
            this.textBox_Plan.Text = "";    //TODO
            this.textBox_precio.Text = BD_Bonos.obtener_precio_plan(this.usuario_id).ToString();
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO actualizar this.usuario_id
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Comprar_Click(object sender, EventArgs e)
        {
            try
            {
                BD_Bonos.comprar_bono(this.usuario_id, Convert.ToInt32(textBox_Cantidad.Text) );
                MessageBox.Show("Bonos Comprados", "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
