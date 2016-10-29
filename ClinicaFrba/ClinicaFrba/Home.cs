using ClinicaFrba.Abm_Afiliado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ClinicaFrba
{
    public partial class Home : Form
    {
        public string user;
        public string password;
        public Usuario usuario;

        public void asegurarConeccion()
        {
        }
        public Home()
        {
            InitializeComponent();

        }

        private void DeshabilitarComponentes()
        {
           //this.afiliadoToolStripMenuItem.Enabled = false;
            this.profesionalesToolStripMenuItem.Enabled = false;
            this.turnosToolStripMenuItem.Enabled = false;
            this.adminToolStripMenuItem.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DeshabilitarComponentes();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio.Log_In.Ingresar_App(this.user, this.password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Log_In", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void nuevoAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var altaAfiliado = new ABM_AFILIADO();
            altaAfiliado.funcionalidad = 101;
            altaAfiliado.ShowDialog();
        }
    }
}
