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
    public partial class CancelarTurnoProfesional : Form
    {
        public Usuario usuario { get; set; }

        public CancelarTurnoProfesional()
        {
            InitializeComponent();
        }

        private void CancelarTurnoProfesional_Load(object sender, EventArgs e)
        {
            fechaDesdePicker.MinDate = DateTime.Today.AddDays(1);
            fechaHastaPicker.MinDate = DateTime.Today.AddDays(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fechaDesdePicker_ValueChanged(object sender, EventArgs e)
        {
            fechaHastaPicker.MinDate = fechaDesdePicker.Value;
        }

        private void cancelarTurnoProButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaDesde = fechaDesdePicker.Value;
                DateTime fechaHasta = fechaHastaPicker.Value;
                string motivo = motivoTextBox.Text.ToString();

                if (motivo.Trim().Equals(""))
                {
                    MessageBox.Show("Debe completar todos los campos del formulario", "Cancelar Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Base_de_Datos.BD_Turnos.cancelar_turnos_pro(fechaDesde, fechaHasta, motivo, usuario.id);
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se pudo cancelar los turnos", "Cancelar Turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }

}
