using ClinicaFrba.Base_de_Datos;
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

namespace ClinicaFrba.Pedir_Turno
{
    public partial class PedirTurno : Form
    {
        public Usuario usuario { get; set; }
        private string descripcion_especialidad;
        private string apellido_nombre_profesional;
        private DateTime fecha;
        private string horario;

        public PedirTurno()
        {
            InitializeComponent();
        }

        private void PedirTurno_Load(object sender, EventArgs e)
        {
            ComboData.llenarCombo( comboEspecialidades, InteraccionDB.obtener_todas_especialidades() );
            descripcion_especialidad = null;
            apellido_nombre_profesional = null;
        }

        private void comboEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboProfesionales.Enabled = true;
            descripcion_especialidad = ComboData.obtener_descripcion(comboEspecialidades);
            var lista = InteraccionDB.obtener_todos_profesionales_para_especialid(descripcion_especialidad);

            ComboData.llenarCombo( comboProfesionales, lista );
        }

        private void comboProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            datePicker_fecha.Enabled = true;
        }

        private void datePicker_fecha_ValueChanged(object sender, EventArgs e)
        {
            comboHorarios.Enabled = true;
            apellido_nombre_profesional = ComboData.obtener_descripcion(comboProfesionales);
            fecha = datePicker_fecha.Value.Date;
            var lista = InteraccionDB.obtener_turnos_disponibles(apellido_nombre_profesional, fecha);

            ComboData.llenarCombo(comboHorarios, lista);
        }

        private void comboHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            boton_pedirTurno.Enabled = true;
            horario = ComboData.obtener_descripcion(comboHorarios);
        }

        private void boton_pedirTurno_Click(object sender, EventArgs e)
        {
            try
            {
                InteraccionDB.asignar_turno(apellido_nombre_profesional, fecha, horario, descripcion_especialidad, usuario.id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pedir Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void boton_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
