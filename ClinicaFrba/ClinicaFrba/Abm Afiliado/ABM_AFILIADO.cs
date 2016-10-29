using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Clases;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ABM_AFILIADO : Form
    {
        public int funcionalidad;
        public ABM_AFILIADO()
        {
            InitializeComponent();
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            try
            {
                var afiliado = mapAfiliado_Vista();
                if (funcionalidad == 101)
                    //alta
                    MessageBox.Show("Hice un alta");
                else if (funcionalidad == 102)
                    //Modific
                    funcionalidad = 0;
                else if (funcionalidad == 103)
                    //Baja
                    funcionalidad = 0;
                ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ABM_AFILIADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ABMAFILIADO_Load(object sender, EventArgs e)
        {
            if (funcionalidad == 101)
                //alta
                MessageBox.Show("Entro un alta");
            else if (funcionalidad == 102)
                //Modific
                funcionalidad = 0;
            else if (funcionalidad == 103)
                //Baja
                funcionalidad = 0;
            ;
        }

        private Afiliado mapAfiliado_Vista()
        {
            var afiliado = new Afiliado();

            var conn = Base_de_Datos.Conexion.Instance.get();

            afiliado.apellido = txtApellido.Text;
            afiliado.direccion = txtDireccion.Text;
            afiliado.estado_civil = Int32.Parse(cmbEstadoCiv.SelectedValue.ToString().Trim());
            afiliado.e_mail = TxtMail.Text;
            afiliado.fecha_nac = dtFNac.Value;
            if (!String.IsNullOrEmpty(txtAfilId.Text.Trim()))
                afiliado.id = Int32.Parse(txtAfilId.Text);

            afiliado.nombre = txtNombre.Text;

            if (!String.IsNullOrEmpty(txtNroDoc.Text.Trim()))
                afiliado.nro_doc = Int32.Parse(txtNroDoc.Text);

            afiliado.plan_id = Int32.Parse(cmbPlan.SelectedValue.ToString());
            afiliado.sexo = cmbSexo.SelectedValue.ToString()[0];
            afiliado.telefono = txtNroTelefono.Text;
            afiliado.tipo_doc = cmbTipoDoc.SelectedText.ToString();

            return afiliado;
        }
    }
}
