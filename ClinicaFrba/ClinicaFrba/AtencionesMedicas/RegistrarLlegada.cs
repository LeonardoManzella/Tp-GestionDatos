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

namespace ClinicaFrba.AtencionesMedicas
{
    public partial class RegistrarLlegada : Form
    {
        private ComboData cero = new ComboData(0, "Sin elegir");
        private ComboData vacio = new ComboData("", "Sin elegir");

        public RegistrarLlegada()
        {
            InitializeComponent();
        }

        private void RegistrarAtencion_Load(object sender, EventArgs e)
        {
            try
            {
                this.comboBox1.DisplayMember = "descripcion";
                this.comboBox1.ValueMember = "identificador";
                this.comboEspecialidades.DisplayMember = "descripcion";
                this.comboEspecialidades.ValueMember = "identificador";
                this.cmb_turnos.DisplayMember = "descripcion";
                this.cmb_turnos.ValueMember = "identificador";
                this.cmbBono.DisplayMember = "descripcion";
                this.cmbBono.ValueMember = "identificador";
                this.cmbPlan.DisplayMember = "descripcion";
                this.cmbPlan.ValueMember = "identificador";

                limpiar();

                var profesionales = Llegada_At_Med.obtener_profesionales(0);
                this.comboBox1.Items.AddRange(profesionales.ToArray());

                var especialidades = Llegada_At_Med.obtenerEspecialidades();
                this.comboEspecialidades.Items.AddRange(profesionales.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Cargar Form: ERROR: " + ex.Message, "ABM_AFILIADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void limpiar()
        {
            this.comboBox1.Items.Clear();
            this.comboEspecialidades.Items.Clear();
            this.cmbBono.Items.Clear();
            this.cmb_turnos.Items.Clear();
            this.cmbPlan.Items.Clear();

            this.comboBox1.Items.Add(cero);
            this.comboEspecialidades.Items.Add(vacio);
            this.cmbBono.Items.Add(cero);
            this.cmb_turnos.Items.Add(cero);
            this.cmbPlan.Items.Add(cero);

            this.cmb_turnos.SelectedIndex = 0;
            this.cmbBono.SelectedIndex = 0;
            this.comboBox1.SelectedIndex = 0;
            this.comboEspecialidades.SelectedIndex = 0;
            this.cmbPlan.SelectedIndex = 0;

            this.txtDNI.Text = "";

            this.cmbBono.Enabled = false;
            this.cmb_turnos.Enabled = false;
            this.cmbPlan.Enabled = false;
            this.btnBuscar.Enabled = false;
            this.btnRegistrar.Enabled = false;
        }
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_numeros(e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!(ComboData.obtener_identificador(comboBox1) == 0))
            {
                int afiliado = Int32.Parse(txtDNI.Text);
                int plan = ComboData.obtener_identificador(cmbPlan);
                this.cmbBono.Items.AddRange(Llegada_At_Med.obtener_bonos(afiliado, plan).ToArray());
            }
            else
            {
                MessageBox.Show("Para Realizar la Búsqueda debe indicarse el profesional");
            }
        }

        private void cmbBono_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboData.obtener_identificador(this.cmbBono) > 0 && ComboData.obtener_identificador(this.cmb_turnos) > 0)
            {
                this.btnRegistrar.Enabled = true;
            }
            else
            {
                this.btnRegistrar.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboData.obtener_identificador(this.comboBox1) > 0)
            {
                this.btnBuscar.Enabled = true;
            }
            else
            {
                this.btnBuscar.Enabled = false;
            }
        }

        private void cmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboData.obtener_identificador(cmbPlan) > 0)
            {
                this.cmbBono.Enabled = true;
            }
            else
            {
                this.cmbBono.Enabled = false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void txtDNI_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDNI.Text.Trim()))
            {
                this.cmbPlan.Items.Clear();
                this.cmbPlan.Items.Add(cero);
                //this.cmbPlan.Items.AddRange(Llegada_At_Med.pedir_planes_usuario().ToArray());
            }
        }
    }
}
