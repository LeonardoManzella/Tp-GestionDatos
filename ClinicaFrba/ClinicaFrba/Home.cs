using ClinicaFrba.Abm_Afiliado;
using ClinicaFrba.Base_de_Datos;
using ClinicaFrba.Clases;
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
            this.nuevoAfiliadoToolStripMenuItem.Enabled                     = false;
            this.modificarAfiliadoToolStripMenuItem.Enabled                 = false;
            this.bajaAfiliadoToolStripMenuItem.Enabled                      = false;
            this.pedirTurnoToolStripMenuItem.Enabled                        = false;
            this.cancelarTurnosProfesional_ToolStripMenuItem.Enabled        = false;
            this.comprarBonoUsuario_ToolStripMenuItem.Enabled               = false;
            this.agendaCrearTurnos_ToolStripMenuItem.Enabled                = false;
            this.cancelarTurnosUsuario_ToolStripMenuItem.Enabled            = false;
            this.registrarLlegadaToolStripMenuItem.Enabled                  = false;
            this.registrarResultadoDiagnosticoToolStripMenuItem.Enabled     = false;
            this.nuevRolToolStripMenuItem.Enabled                           = false;
            this.modificarRol_ToolStripMenuItem.Enabled                     = false;
            this.comprarBonoAdmin_ToolStripMenuItem.Enabled                 = false;
            this.estadisticasToolStripMenuItem.Enabled                      = false;

        }
        private void habilitar_componentes()
        {
            //En base a los Permisos, vemos las Pestañas a Habilitar para Usar
            if (this.usuario.permisos.Contains("ALTA_AFILIADO"))                this.nuevoAfiliadoToolStripMenuItem.Enabled                     = true;
            if (this.usuario.permisos.Contains("MODIFICAR_AFILIADO"))           this.modificarAfiliadoToolStripMenuItem.Enabled                 = true;
            if (this.usuario.permisos.Contains("BAJA_AFILIADO"))                this.bajaAfiliadoToolStripMenuItem.Enabled                      = true;
            if (this.usuario.permisos.Contains("PEDIR_TURNO"))                  this.pedirTurnoToolStripMenuItem.Enabled                        = true;
            if (this.usuario.permisos.Contains("CANCELAR_TURNO"))               this.cancelarTurnosUsuario_ToolStripMenuItem.Enabled            = true;
            if (this.usuario.permisos.Contains("COMPRAR_BONO"))                 this.comprarBonoUsuario_ToolStripMenuItem.Enabled               = true;
            if (this.usuario.permisos.Contains("CREAR_AGENDA"))                 this.agendaCrearTurnos_ToolStripMenuItem.Enabled                = true;
            if (this.usuario.permisos.Contains("CANCELAR_TURNOS_AGENDA"))       this.cancelarTurnosProfesional_ToolStripMenuItem.Enabled        = true;
            if (this.usuario.permisos.Contains("REGISTRAR_LLEGADA"))            this.registrarLlegadaToolStripMenuItem.Enabled                  = true;
            if (this.usuario.permisos.Contains("REGISTRAR_DIAGNOSTICO"))        this.registrarResultadoDiagnosticoToolStripMenuItem.Enabled     = true;
            if (this.usuario.permisos.Contains("CREAR_ROL"))                    this.nuevRolToolStripMenuItem.Enabled                           = true;
            if (this.usuario.permisos.Contains("MODIFICAR_ROL"))                this.modificarRol_ToolStripMenuItem.Enabled                     = true;
            if (this.usuario.permisos.Contains("COMPRA_BONO_ADMINISTRADOR"))    this.comprarBonoAdmin_ToolStripMenuItem.Enabled                 = true;
            if (this.usuario.permisos.Contains("ESTADISTICAS"))                 this.estadisticasToolStripMenuItem.Enabled                      = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            deshabilitar_componentes();
            this.AcceptButton = boton_loguear;

            Configuracion_Global.cargar_archivo_configuracion();

            try
            {
                var lista = BD_Roles.obtener_roles();
                ComboData.llenarCombo(this.comboBox_rol, lista);
            }
            catch (Exception ex)
            {
                InteraccionDB.ImprimirExcepcion(ex);
                MessageBox.Show("Error al Pedir Roles contra la Base. Compruebe que la Base de Datos este Poblada. ERROR: " + ex.Message, "Log_In", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                this.user = textBox_usuario.Text.Trim();
                this.password = textBox_password.Text.Trim();
                this.rol_descripcion = comboBox_rol.Text.Trim();

                this.usuario = Negocio.Log_In.Ingresar_App(this.user, this.password, this.rol_descripcion);
                this.usuario.nick_usuario = user;
                this.usuario.password = this.password;

                MessageBox.Show("Login Exitoso", "Log_In", MessageBoxButtons.OK, MessageBoxIcon.Information);

                habilitar_componentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Ingresar Datos para Loguear. ERROR: " + ex.Message, "Log_In", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var cancelarTurnoPro = new CancelarTurno.CancelarTurnoProfesional();
            cancelarTurnoPro.usuario = this.usuario;
            cancelarTurnoPro.ShowDialog();
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
            form.usuario_o_administrador = this.usuario;
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
