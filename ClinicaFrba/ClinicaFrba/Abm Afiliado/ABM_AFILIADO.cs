using System;
using System.Windows.Forms;
using ClinicaFrba.Clases;
using Microsoft.VisualBasic;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ABM_AFILIADO : Form
    {
        public enum tipos_funcionalidad
        {
            ALTA,
            MODIFICACION,
            BAJA
        };


        public tipos_funcionalidad funcionalidad;
        public Usuario usuario;
        public Afiliado afiliado;
        public int? afiliado_principal;

        public ABM_AFILIADO()
        {
            InitializeComponent();
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            try
            {
                var cerrar = false;

               if (funcionalidad == tipos_funcionalidad.MODIFICACION)
                //Modific
                {
                    mapAfiliado_Vista();
                    Negocio.ABMAFIL.modifica_afiliado(afiliado);
                    MessageBox.Show("Se ha modificado el afiliado sastifactoriamente");
                }
                else if (funcionalidad == tipos_funcionalidad.ALTA)
                {  //alta
                    mapAfiliado_Vista();
                    var id_us = Negocio.ABMAFIL.alta_afiliado(afiliado);
                    this.txtAfilId.Text = id_us.ToString();
                    MessageBox.Show("Se ha realizado el alta correctamente");
                    funcionalidad = tipos_funcionalidad.MODIFICACION;
                }
                else if (funcionalidad == tipos_funcionalidad.BAJA)
                //Baja
                {
                    var respuesta = Negocio.ABMAFIL.baja_afiliado(afiliado.id);
                    if (respuesta)
                        MessageBox.Show("Se ha realizado la baja correctamente");
                    else
                        MessageBox.Show("Ha ocurrido un error la baja no ha podido realizarse");

                    cerrar = true;
                };

                if (cerrar)
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ABM_AFILIADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ABMAFILIADO_Load(object sender, EventArgs e)
        {
            try
            {
                cargar_pantalla();
                txtAfilId.Enabled = false;
                if (funcionalidad == tipos_funcionalidad.ALTA)
                {
                    btnLimpiar_Click(sender, e);
                    this.Text = "ALTA AFILIADO";
                }
                else if (funcionalidad == tipos_funcionalidad.MODIFICACION)
                {
                    this.Text = "MODIFICA AFILIADO";
                    this.afiliado = Negocio.ABMAFIL.Get_Afiliado(afiliado.id);
                    afiliado_en_pantalla();
                }
                else
                {
                    this.Text = "ELIMINA AFILIADO";
                    this.afiliado = Negocio.ABMAFIL.Get_Afiliado(afiliado.id);
                    afiliado_en_pantalla();
                    bloquearTodo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Cargar Form. " + ex.Message, "ABM_AFILIADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void afiliado_en_pantalla()
        {
            txtApellido.Text = afiliado.apellido;
            txtDireccion.Text = afiliado.direccion;
            cmbEstadoCiv.SelectedIndex = ComboData.obtener_indice(afiliado.estado_civil, cmbEstadoCiv);
            TxtMail.Text = afiliado.e_mail;
            dtFNac.Value = afiliado.fecha_nac;
            txtAfilId.Text = afiliado.id.ToString();
            txtNombre.Text = afiliado.nombre;
            txtNroDoc.Text = afiliado.nro_doc.ToString();
            cmbPlan.SelectedIndex = ComboData.obtener_indice(afiliado.plan_id.Value, cmbPlan);
            txtNroTelefono.Text = afiliado.telefono;
            //selecciono el item que tiene de descripcion
            cmbSexo.SelectedIndex = ComboData.obtener_indice(afiliado.sexo, cmbSexo);
            //selecciono el item que tiene de descripcion
            cmbTipoDoc.SelectedIndex = ComboData.obtener_indice(afiliado.tipo_doc, cmbTipoDoc);

        }

        private void bloquearTodo()
        {
            txtApellido.Enabled = false;
            txtDireccion.Enabled = false;
            cmbEstadoCiv.Enabled = false;
            TxtMail.Enabled = false;
            dtFNac.Enabled = false;
            txtAfilId.Enabled = false;
            txtNombre.Enabled = false;
            txtNroDoc.Enabled = false;
            cmbPlan.Enabled = false;
            txtNroTelefono.Enabled = false;
            cmbSexo.Enabled = false;
            cmbTipoDoc.Enabled = false;
            btnLimpiar.Visible = false;

        }

        private void cargar_pantalla()
        {
            #region combos

            //cargo el combo de sexo
            this.cmbSexo.DisplayMember = "descripcion";
            this.cmbSexo.ValueMember = "identificador";
            this.cmbSexo.Items.Clear();
            this.cmbSexo.Items.Add(new ComboData(77, "M"));
            this.cmbSexo.Items.Add(new ComboData(70, "F"));

            this.cmbEstadoCiv.DisplayMember = "descripcion";
            this.cmbEstadoCiv.ValueMember = "identificador";
            var estados = Negocio.ABMAFIL.get_Estados_Civiles();

            foreach (ComboData estado in estados)
            {
                this.cmbEstadoCiv.Items.Add(estado);
            }

            this.cmbPlan.DisplayMember = "descripcion";
            this.cmbPlan.ValueMember = "identificador";
            var planes = Negocio.ABMAFIL.get_Planes_Sociales();

            foreach (ComboData plan in planes)
            {
                this.cmbPlan.Items.Add(plan);
            }

            //Cargo el combo de tipos de documentos

            var tipos = Negocio.ABMAFIL.get_Tipos_Documentos();
            this.cmbTipoDoc.DataSource = tipos;
            this.cmbTipoDoc.DisplayMember = "descripcion";
            this.cmbTipoDoc.ValueMember = "identificador";
            
            #endregion
        }

        private void mapAfiliado_Vista()
        {
            afiliado.apellido = txtApellido.Text;
            afiliado.direccion = txtDireccion.Text;
            afiliado.estado_civil = ComboData.obtener_identificador(cmbEstadoCiv);
            afiliado.e_mail = TxtMail.Text;
            afiliado.fecha_nac = dtFNac.Value;
            if (!String.IsNullOrEmpty(txtAfilId.Text.Trim()))
                afiliado.id = Int32.Parse(txtAfilId.Text);

            afiliado.nombre = txtNombre.Text;

            if (!String.IsNullOrEmpty(txtNroDoc.Text.Trim()))
                afiliado.nro_doc = Int32.Parse(txtNroDoc.Text);

            afiliado.plan_id = ComboData.obtener_identificador(cmbPlan);
            afiliado.sexo = ComboData.obtener_descripcion(cmbSexo)[0];
            afiliado.telefono = txtNroTelefono.Text;
            afiliado.tipo_doc = ComboData.obtener_descripcion(cmbTipoDoc);            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras(e);
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_numeros(e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras_y_numeros(e);
        }

        private void txtNroTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_numeros(e);
        }

        private void TxtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras_y_arroba(e);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            var new_afil = new Afiliado() { id = this.afiliado.id, id_principal = this.afiliado.id_principal , usuario = this.afiliado.usuario};
            this.afiliado = new_afil;
            txtApellido.Text = afiliado.apellido;
            txtDireccion.Text = afiliado.direccion;
            TxtMail.Text = afiliado.e_mail;
            dtFNac.Value = dtFNac.MinDate;
            txtAfilId.Text = (afiliado.id == 0) ? string.Empty : afiliado.id.ToString();
            txtNombre.Text = afiliado.nombre;
            txtNroDoc.Text = (afiliado.nro_doc == 0) ? string.Empty : afiliado.nro_doc.ToString();
            txtNroTelefono.Text = afiliado.telefono;
            cmbTipoDoc.SelectedIndex = 0;
            cmbPlan.SelectedIndex = 0;
            cmbSexo.SelectedIndex = 0;
            cmbEstadoCiv.SelectedIndex = 0;

        }
    }
}
