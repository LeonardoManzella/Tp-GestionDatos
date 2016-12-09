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

        ComboData cero;
        public Estadisticas()
        {
            InitializeComponent();
        }


        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            var estadistica = ComboData.obtener_identificador(this.comboTop5);
            switch (estadistica)
            {
                case 1: //Especialidades_mas_canceladas();
                    break;
                case 2://Profesionales_mas_consultados();
                    break;
                case 3://Profesionales_que_menos_trabajaron();
                    break;
                case 4://Afiliado_que_mas_bonos_compro();
                    break;
                case 5://Especialidades_mas_concurridas();
                    break;
            };
        }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_numeros(e);
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {
            try
            {

                #region combos
                cero = new ComboData(0, "Indistinto");

                this.comboEspec.DisplayMember = "descripcion";
                this.comboEspec.ValueMember = "identificador";
                var estados = Llegada_At_Med.obtenerEspecialidades();
                this.comboEspec.Items.Add(cero);
                foreach (ComboData item in estados)
                { 
                this.comboEspec.Items.Add(item);
                }

                this.comboBox3.DisplayMember = "descripcion";
                this.comboBox3.ValueMember = "identificador";
                var planes = ABMAFIL.get_Planes_Sociales();
                this.comboBox3.Items.Add(cero);
                foreach (ComboData item in planes)
                {
                    this.comboBox3.Items.Add(item);
                }


                this.comboTop5.DisplayMember = "descripcion";
                this.comboTop5.ValueMember = "identificador";
                this.comboTop5.Items.Add(new ComboData(1, "Especialidades más canceladas"));
                this.comboTop5.Items.Add(new ComboData(2, "Profesionales más consultados"));
                this.comboTop5.Items.Add(new ComboData(3, "Profesionales que menos trabajaron"));
                this.comboTop5.Items.Add(new ComboData(4, "Afiliado que más bonos compró"));
                this.comboTop5.Items.Add(new ComboData(5, "Especialidades más concurridas"));

                this.comboSemestre.DisplayMember = "descripcion";
                this.comboSemestre.ValueMember = "identificador";
                this.comboSemestre.Items.Add(new ComboData(1, "Primer"));
                this.comboSemestre.Items.Add(new ComboData(2, "Segundo"));

                this.cmbQuienCancela.DisplayMember = "descripcion";
                this.cmbQuienCancela.ValueMember = "identificador";
                this.cmbQuienCancela.Items.Add(cero);
                this.cmbQuienCancela.Items.Add(new ComboData(1, "Profesional"));
                this.cmbQuienCancela.Items.Add(new ComboData(2, "Afiliado"));
                #endregion

                btnLimpiar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Cargar Form: " + ex.Message, "Estadisticas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtAnio.Text = string.Empty;
            this.cmbQuienCancela.SelectedIndex = ComboData.obtener_indice( 0, this.cmbQuienCancela);
            comboBox3.SelectedIndex = ComboData.obtener_indice(0, this.comboBox3); 
            comboSemestre.SelectedIndex = ComboData.obtener_indice(1, this.comboSemestre); 
            comboTop5.SelectedIndex = ComboData.obtener_indice(1, this.comboTop5);
            comboEspec.SelectedIndex = ComboData.obtener_indice(0, this.comboEspec);
        }

        private void comboTop5_SelectedIndexChanged(object sender, EventArgs e)
        {
            var estadistica = ComboData.obtener_identificador(this.comboTop5);
            switch (estadistica)
            {
                case 1: //Especialidades_mas_canceladas();
                    this.lblEspecialidad.Visible = false;
                    this.comboEspec.Visible = false;
                    this.lblPlan.Visible = false;
                    this.comboBox3.Visible = false;
                    this.lblCance.Visible = true;
                    this.cmbQuienCancela.Visible = true;
                    break;
                case 2://Profesionales_mas_consultados();
                    this.lblEspecialidad.Visible = false;
                    this.comboEspec.Visible = false;
                    this.lblPlan.Visible = true;
                    this.comboBox3.Visible = true;
                    this.lblCance.Visible = false;
                    this.cmbQuienCancela.Visible = false; 
                    break;
                case 3://Profesionales_que_menos_trabajaron();
                    this.lblEspecialidad.Visible = true;
                    this.comboEspec.Visible = true;
                    this.lblPlan.Visible = true;
                    this.comboBox3.Visible = true;
                    this.lblCance.Visible = false;
                    this.cmbQuienCancela.Visible = false;
                    break;
                case 4://Afiliado_que_mas_bonos_compro();
                    this.lblEspecialidad.Visible = false;
                    this.comboEspec.Visible = false;
                    this.lblPlan.Visible = false;
                    this.comboBox3.Visible = false;
                    this.lblCance.Visible = false;
                    this.cmbQuienCancela.Visible = false;
                    break;
                case 5://Especialidades_mas_concurridas();
                    this.lblEspecialidad.Visible = false;
                    this.comboEspec.Visible = false;
                    this.lblPlan.Visible = false;
                    this.comboBox3.Visible = false;
                    this.lblCance.Visible = false;
                    this.cmbQuienCancela.Visible = false;
                    break;
            };
        }
    }
}
