using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AtencionesMedicas
{
    public partial class RegistrarResultado : Form
    {
        public RegistrarResultado()
        {
            InitializeComponent();
        }

        private void RegistrarResultado_Load(object sender, EventArgs e)
        {

        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras(e);
        }
    }
}
