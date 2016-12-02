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
        private Afiliado afiliado;

        public ABM_AFILIADO()
        {
            InitializeComponent();
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            try
            {
                var cerrar = false;

                mapAfiliado_Vista();

                if (funcionalidad == tipos_funcionalidad.MODIFICACION)
                //Modific
                {
                    Negocio.ABMAFIL.modifica_afiliado(afiliado);
                    MessageBox.Show("Se ha modificado el afiliado sastifactoriamente");
                }
                else if (funcionalidad == tipos_funcionalidad.ALTA)
                {  //alta

                    if (this.chk_titular.Checked)
                    {
                        //afiliado.id =  Negocio.ABMUSUARIO.altaUsuario(user);
                        afiliado.usuario = 1;
                    }
                    else
                    {
                        var nick = Interaction.InputBox("Ingrese el nick del usuario del titular");
                        //user.id =  Negocio.ABMUSUARIO.obtenerUsuario(nick);
                        afiliado.usuario = Int32.Parse(nick);
                    }
                    var id_us  = Negocio.ABMAFIL.alta_afiliado(afiliado);
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
                {  //alta
                    chk_titular.Visible = true;
                    this.afiliado = new Afiliado();
                }
                else if (funcionalidad == tipos_funcionalidad.MODIFICACION)
                {
                    chk_titular.Visible = false;
                    var afiliado_id = Int32.Parse(Interaction.InputBox("Ingrese el numero de afiliado a modificar"));
                    this.afiliado = Negocio.ABMAFIL.Get_Afiliado(afiliado_id);
                    afiliado_en_pantalla();
                }
                else
                {
                    chk_titular.Visible = false;
                    var afiliado_id = Int32.Parse(Interaction.InputBox("Ingrese el numero de afiliado a modificar"));
                    this.afiliado = Negocio.ABMAFIL.Get_Afiliado(afiliado_id);
                    afiliado_en_pantalla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Cargar Form: ERROR: " + ex.Message, "ABM_AFILIADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void cargar_pantalla()
        {
            #region combos

            //cargo el combo de sexo
            this.cmbSexo.DisplayMember = "descripcion";
            this.cmbSexo.ValueMember = "identificador";
            this.cmbSexo.Items.Add(new ComboData(1, "M"));
            this.cmbSexo.Items.Add(new ComboData(1, "F"));

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


            /*
            foreach (ComboData tipo in tipos)
            {
                this.cmbTipoDoc.Items.Add(tipo);
            }
            */
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
    }
}
