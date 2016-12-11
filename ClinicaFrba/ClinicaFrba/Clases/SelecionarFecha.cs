using ClinicaFrba.Clases;
using System;
using System.Windows.Forms;

namespace ClinicaFrba.Clases
{
    public partial class SelecionarFecha : Form
    {
        public DateTime fecha;

        public SelecionarFecha()
        {
            InitializeComponent();
        }


        private void SeleccionarFecha_Load(object sender, EventArgs e)
        {
            this.monthCalendar.TodayDate = DateTime.Parse(Configuracion_Global.fecha_actual);
            this.monthCalendar.MaxSelectionCount = 1;
            this.fecha = monthCalendar.SelectionRange.Start.Date;
            this.monthCalendar.SelectionStart = this.monthCalendar.TodayDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {
            this.fecha = monthCalendar.SelectionRange.Start.Date;
        }
    }
}
