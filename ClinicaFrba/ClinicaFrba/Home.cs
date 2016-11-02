using ClinicaFrba.Abm_Afiliado;
using System;
using System.Windows.Forms;



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
            /*
           this.afiliadoToolStripMenuItem.Enabled = false;
            this.profesionalesToolStripMenuItem.Enabled = false;
            this.turnosToolStripMenuItem.Enabled = false;
            this.adminToolStripMenuItem.Enabled = false;
            */
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
                this.user = textBox_usuario.Text.Trim();
                this.password = textBox_password.Text.Trim();

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
            altaAfiliado.funcionalidad = ABM_AFILIADO.tipos_funcionalidad.ALTA;
            altaAfiliado.ShowDialog();
        }

        private void modificarAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var altaAfiliado = new ABM_AFILIADO();
            altaAfiliado.funcionalidad = ABM_AFILIADO.tipos_funcionalidad.MODIFICACION;
            altaAfiliado.ShowDialog();
        }

        private void bajaAfiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var altaAfiliado = new ABM_AFILIADO();
            altaAfiliado.funcionalidad = ABM_AFILIADO.tipos_funcionalidad.BAJA;
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
            new CancelarTurno.CancelarTurnoAfiliado().ShowDialog();
        }

        private void pedirTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Pedir_Turno.PedirTurno().ShowDialog();
        }

        private void comprarBonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Compra_Bono.CompraBono();
            form.funcionalidad = Compra_Bono.CompraBono.tipos_funcionalidad.USUARIO;
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
    }
}
