using ClinicaFrba.Abm_Afiliado;
using ClinicaFrba.Pedir_Turno;
using System;
using System.Windows.Forms;



namespace ClinicaFrba
{
    public partial class Home : Form
    {
        public string user;
        public string password;
        public string rol_descripcion;
        public Usuario usuario;

        public void asegurarConeccion()
        {
        }
        public Home()
        {
            InitializeComponent();

        }

        private void deshabilitar_componentes()
        {
            this.afiliadoToolStripMenuItem.Enabled = false;
            this.profesionalesToolStripMenuItem.Enabled = false;
            this.adminToolStripMenuItem.Enabled = false;

        }
        private void habilitar_componentes()
        {
            //TODO Cambiar a que use cada permiso de cada pestaña!
            if (usuario.rol_seleccionado_descripcion.Equals("AFILIADO")) this.afiliadoToolStripMenuItem.Enabled = true;
            if (usuario.rol_seleccionado_descripcion.Equals("PROFESIONAL")) this.profesionalesToolStripMenuItem.Enabled = true;
            if (usuario.rol_seleccionado_descripcion.Equals("ADMINISTRATIVO"))
            {
                this.afiliadoToolStripMenuItem.Enabled      = true;
                this.profesionalesToolStripMenuItem.Enabled = true;
                this.adminToolStripMenuItem.Enabled         = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO restablecer
            //deshabilitar_componentes();
            this.AcceptButton = boton_loguear;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Log In de cualquier Usuario en la Base Datos
        /// </summary>
        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loguear();
        }

        private void loguear()
        {
            try
            {
                this.user               = textBox_usuario.Text.Trim();
                this.password           = textBox_password.Text.Trim();
                this.rol_descripcion    = textBox_rol.Text.Trim();

                this.usuario = Negocio.Log_In.Ingresar_App(this.user, this.password, this.rol_descripcion);

                MessageBox.Show("Login Exitoso", "Log_In", MessageBoxButtons.OK, MessageBoxIcon.Information);

                habilitar_componentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Log_In", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var altaAfiliado = new ABM_AFILIADO();
            altaAfiliado.funcionalidad = ABM_AFILIADO.tipos_funcionalidad.ALTA;
            altaAfiliado.usuario = this.usuario;
            altaAfiliado.ShowDialog();
        }

        private void modificarAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var altaAfiliado = new ABM_AFILIADO();
            altaAfiliado.funcionalidad = ABM_AFILIADO.tipos_funcionalidad.MODIFICACION;
            altaAfiliado.usuario = this.usuario;
            altaAfiliado.ShowDialog();
        }

        private void bajaAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var altaAfiliado = new ABM_AFILIADO();
            altaAfiliado.funcionalidad = ABM_AFILIADO.tipos_funcionalidad.BAJA;
            altaAfiliado.usuario = this.usuario;
            altaAfiliado.ShowDialog();
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AgendaMedico.AgendaMedico().ShowDialog();
        }

        private void cancelarTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CancelarTurno.CancelarTurnoProfesional().ShowDialog();
        }

        private void cancelarTurnosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var cancelarTurnoAfiliado = new CancelarTurno.CancelarTurnoAfiliado();
            cancelarTurnoAfiliado.usuario = this.usuario;
            cancelarTurnoAfiliado.ShowDialog();
        }

        private void pedirTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pedir_turno = new PedirTurno();
            pedir_turno.usuario = this.usuario;
            pedir_turno.ShowDialog();
        }

        private void comprarBonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Compra_Bono.CompraBono();
            form.funcionalidad = Compra_Bono.CompraBono.tipos_funcionalidad.USUARIO;
            form.usuario = this.usuario;
            form.ShowDialog();
        }

        private void comprarBonoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Compra_Bono.CompraBono();
            form.funcionalidad = Compra_Bono.CompraBono.tipos_funcionalidad.ADMIN;
            form.ShowDialog();
        }

        private void nuevRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AbmRol.CrearRol().ShowDialog();
        }

        private void bajaRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AbmRol.ModificarRol().ShowDialog();
        }

        private void estadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Estadisticas.Estadisticas().ShowDialog();
        }

        private void registrarLlegadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AtencionesMedicas.RegistrarLlegada().ShowDialog();
        }

        private void registrarResultadoDiagnosticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AtencionesMedicas.RegistrarResultado().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loguear();
        }
    }
}
