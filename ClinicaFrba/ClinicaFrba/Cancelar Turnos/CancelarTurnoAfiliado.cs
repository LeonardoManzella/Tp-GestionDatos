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

namespace ClinicaFrba.CancelarTurno
{
    public partial class CancelarTurnoAfiliado : Form
    {
        public Usuario usuario { get; set; }

        public CancelarTurnoAfiliado()
        {
            InitializeComponent();
        }

        private void CancelarAtencion_Load(object sender, EventArgs e)
        {
            List<string> turnosCancelables = Base_de_Datos.BD_Turnos.obtener_turnos_cancelables(usuario);
            ComboData.llenarCombo(comboCancelarTurno, turnosCancelables);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string turnoCancelar = comboCancelarTurno.SelectedItem.ToString();
                string motivo = motivoCancelacion.Text.ToString();

                if (turnoCancelar.Trim().Equals("") || motivo.Trim().Equals(""))
                {
                    MessageBox.Show("Debe completar todos los campos del formulario", "Cancelar Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string[] turno = turnoCancelar.Split('-');

                string apellidoProfesional = turno[0].Split(',')[0].Trim();
                string nombreProfesional = turno[0].Split(',')[1].Trim();
                string especialidad = turno[1].Trim();
                DateTime fecha = DateTime.Parse(turno[2].Trim());;
                string hora = turno[3].Trim();

                Base_de_Datos.BD_Turnos.cancelar_turno(nombreProfesional, apellidoProfesional, especialidad, fecha, hora);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cancelar Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
