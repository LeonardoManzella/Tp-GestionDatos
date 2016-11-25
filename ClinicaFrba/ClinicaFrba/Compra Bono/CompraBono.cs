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
        public Usuario usuario_o_administrador;
        private int id_afiliado_que_compra;

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
            this.label_Usuario.Visible = false;
            this.label_apellido.Visible = false;
        }

        private void deshabilitar_comprar()
        {
            this.label_Id_Usuario.Text = "";
            this.textBox_Cantidad.Enabled = false;
            this.button_Comprar.Enabled = false;
        }


        private void habilitar_comprar()
        {
            this.label_Id_Usuario.Text = "ID Afiliado: " + id_afiliado_que_compra.ToString();
            this.textBox_Cantidad.Enabled = true;
            this.button_Comprar.Enabled = true;
        }

        private void CompraBono_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.funcionalidad == tipos_funcionalidad.USUARIO)
                {
                    deshabilitar_busqueda();
                    this.id_afiliado_que_compra = BD_Afiliados.obtenerID_afiliado(usuario_o_administrador.nombre, usuario_o_administrador.apellido, usuario_o_administrador.id); ;
                    mostrar_plan();
                }
                else
                {
                    this.id_afiliado_que_compra = -1;
                    deshabilitar_comprar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrar_plan()
        {
            this.textBox_Plan.Text = BD_Bonos.obtener_nombre_plan(this.id_afiliado_que_compra);
            this.textBox_precio.Text = BD_Bonos.obtener_precio_plan(this.id_afiliado_que_compra).ToString();
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = this.textBox_Nombre.Text.Trim();
                string apellido = this.textBox_Apellido.Text.Trim();
                string documento = this.textBox_Documento.Text.Trim();

                try
                {
                    this.id_afiliado_que_compra = BD_Afiliados.obtenerID_afiliado(nombre, apellido, documento);
                }
                catch (Exception ex)
                {
                    InteraccionDB.ImprimirExcepcion(ex);
                    resetear_comprar();
                    throw new Exception("No existe el Afiliado, por favor revisar Nombre y Apellido");
                }

                mostrar_plan();
                habilitar_comprar();

            }
            catch (Exception ex)
            {
                resetear_comprar();
                MessageBox.Show("Error al Buscar. ERROR: " + ex.Message, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button_Comprar_Click(object sender, EventArgs e)
        {
            try
            {
                BD_Bonos.comprar_bono(this.id_afiliado_que_compra, Convert.ToInt32(textBox_Cantidad.Text));
                MessageBox.Show("Bonos Comprados", "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBox_Cantidad.Text = "";
            }
            catch (Exception ex)
            {
                this.textBox_Cantidad.Text = "";
                MessageBox.Show(ex.Message, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
