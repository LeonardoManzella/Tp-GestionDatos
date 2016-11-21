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

        public CompraBono()
        {
            InitializeComponent();
        }

        private void CompraBono_Load(object sender, EventArgs e)
        {
            try {
                //TODO dividir por funcionalidad, si es admin muestra todo, si es Usuario debe ocultar elementos de ADMIN
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ComprarBono", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
