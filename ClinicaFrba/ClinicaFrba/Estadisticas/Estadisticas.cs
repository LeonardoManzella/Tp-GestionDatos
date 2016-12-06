using ClinicaFrba.Clases;
using ClinicaFrba.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Estadisticas
{
    public partial class Estadisticas : Form
    {
        public Estadisticas()
        {
            InitializeComponent();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {

        }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_numeros(e);
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {
            try
            {
                var vacio = new ComboData(null, "Sin Elegir");

                this.comboEspec.DisplayMember = "descripcion";
                this.comboEspec.ValueMember = "identificador";
                var estados = Llegada_At_Med.obtenerEspecialidades();
                this.comboEspec.Items.Add(vacio);
                this.comboEspec.Items.AddRange(estados.ToArray());

                this.comboBox3.DisplayMember = "descripcion";
                this.comboBox3.ValueMember = "identificador";
                var planes = ABMAFIL.get_Planes_Sociales();
                this.comboEspec.Items.Add(vacio);
                this.comboEspec.Items.AddRange(planes.ToArray());

                this.comboTop5.Items.Add(new ComboData(1, "Especialidades más canceladas"));
                this.comboTop5.Items.Add(new ComboData(2, "Profesionales más consultados"));
                this.comboTop5.Items.Add(new ComboData(3, "Profesionales que menos trabajaron"));
                this.comboTop5.Items.Add(new ComboData(4, "Afiliado que más bonos compró"));
                this.comboTop5.Items.Add(new ComboData(5, "Especialidades más concurridas"));

                this.comboSemestre.Items.Add(new ComboData(1, "Primer"));
                this.comboSemestre.Items.Add(new ComboData(2, "Segundo"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Cargar Form: " + ex.Message, "Estadisticas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
