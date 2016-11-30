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
            try
            {
                this.comboEspecialidades.DropDownStyle = ComboBoxStyle.DropDownList;
                this.comboHorarios.DropDownStyle = ComboBoxStyle.DropDownList;
                this.comboProfesionales.DropDownStyle = ComboBoxStyle.DropDownList;
                ComboData.llenarCombo(comboEspecialidades, InteraccionDB.obtener_todas_especialidades());
                descripcion_especialidad = null;
                apellido_nombre_profesional = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pedir Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboProfesionales.Enabled = true;
                comboProfesionales.Items.Clear();

                descripcion_especialidad = ComboData.obtener_descripcion(comboEspecialidades);
                var lista = BD_Turnos.obtener_todos_profesionales_para_especialid(descripcion_especialidad);

                ComboData.llenarCombo(comboProfesionales, lista);
            }
            catch (Exception ex)
            {
                comboProfesionales.Items.Clear();
                MessageBox.Show(ex.Message, "Pedir Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            datePicker_fecha.Enabled = true;
            button_horarios.Enabled = true;
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
                BD_Turnos.asignar_turno(apellido_nombre_profesional, fecha, horario, descripcion_especialidad, usuario.id);
                MessageBox.Show("Turno Asignado", "Pedir Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.boton_pedirTurno.Enabled = false;
                this.comboHorarios.Enabled = false;
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

        private void button_horarios_Click(object sender, EventArgs e)
        {
            try
            {
                apellido_nombre_profesional = ComboData.obtener_descripcion(comboProfesionales);
                fecha = datePicker_fecha.Value.Date;
                List<string> lista = null;
                try
                {
                    lista = BD_Turnos.obtener_turnos_disponibles(apellido_nombre_profesional, fecha);
                }
                catch
                {
                    MessageBox.Show("No hay Turnos Disponibles ese Dia", "Pedir Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                comboHorarios.Enabled = true;
                comboHorarios.Items.Clear();

                ComboData.llenarCombo(comboHorarios, lista);
            }
            catch (Exception ex)
            {
                comboHorarios.Items.Clear();
                MessageBox.Show(ex.Message, "Pedir Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
