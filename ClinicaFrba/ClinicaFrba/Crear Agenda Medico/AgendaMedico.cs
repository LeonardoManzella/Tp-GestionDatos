using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Clases;

namespace ClinicaFrba.AgendaMedico
{
    public partial class AgendaMedico : Form
    {

        private Dictionary<string, int> diasSemana;
        private List<HorariosDia> diasAgenda;
        List<string> horariosComun = new List<string>();
        List<string> horariosSabado = new List<string>();

        public AgendaMedico()
        {
            InitializeComponent();
            this.diasSemana.Add("Lunes", 2);
            this.diasSemana.Add("Martes", 3);
            this.diasSemana.Add("Miercoles", 4);
            this.diasSemana.Add("Jueves", 5);
            this.diasSemana.Add("Viernes", 6);
            this.diasSemana.Add("Sabado", 7);

            this.horariosComun.Add("07:00");
            this.horariosComun.Add("07:30");
            this.horariosComun.Add("08:00");
            this.horariosComun.Add("08:30");
            this.horariosComun.Add("09:00");
            this.horariosComun.Add("09:30");
            this.horariosComun.Add("10:00");
            this.horariosComun.Add("10:30");
            this.horariosComun.Add("11:00");
            this.horariosComun.Add("11:30");
            this.horariosComun.Add("12:00");
            this.horariosComun.Add("12:30");
            this.horariosComun.Add("13:00");
            this.horariosComun.Add("13:30");
            this.horariosComun.Add("14:00");
            this.horariosComun.Add("14:30");
            this.horariosComun.Add("15:00");
            this.horariosComun.Add("15:30");
            this.horariosComun.Add("16:00");
            this.horariosComun.Add("16:30");
            this.horariosComun.Add("17:00");
            this.horariosComun.Add("17:30");
            this.horariosComun.Add("18:00");
            this.horariosComun.Add("18:30");
            this.horariosComun.Add("19:00");
            this.horariosComun.Add("19:30");
            this.horariosComun.Add("20:00");

            this.horariosSabado.Add("10:00");
            this.horariosSabado.Add("10:30");
            this.horariosSabado.Add("11:00");
            this.horariosSabado.Add("11:30");
            this.horariosSabado.Add("12:00");
            this.horariosSabado.Add("12:30");
            this.horariosSabado.Add("13:00");
            this.horariosSabado.Add("13:30");
            this.horariosSabado.Add("14:00");
            this.horariosSabado.Add("14:30");
            this.horariosSabado.Add("15:00");
        }

        private void llenarHorariosDesde(ComboBox horarioComboBox, Boolean isSabado)
        {
            if (isSabado)
            {
                ComboData.llenarCombo(horarioComboBox, this.horariosSabado);
                horarioComboBox.Items.Remove("15:00");
            }
            else
            {
                ComboData.llenarCombo(horarioComboBox, this.horariosComun);
                horarioComboBox.Items.Remove("20:00");
            }
        }

        private void llenarHorariosHasta(ComboBox horarioComboBox, Boolean isSabado)
        {
            if (isSabado)
            {
                ComboData.llenarCombo(horarioComboBox, this.horariosSabado);
                horarioComboBox.Items.Remove("10:00");
            }
            else
            {
                ComboData.llenarCombo(horarioComboBox, this.horariosComun);
                horarioComboBox.Items.Remove("07:00");
            }
        }

        private void AgendaMedico_Load(object sender, EventArgs e)
        {
            horarioDesdeCombo.Items.Clear();
            horarioHastaCombo.Items.Clear();
            this.llenarHorariosDesde(horarioDesdeCombo, false);
            this.llenarHorariosHasta(horarioHastaCombo, false);

            List<string> keyList = new List<string>(this.diasSemana.Keys);
            ComboData.llenarCombo(diasSemanaCombo, keyList);
            
        }

        private void diasSemanaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(String.Compare(diasSemanaCombo.SelectedValue.ToString(), "Sabado") ==  0)
            {
                horarioDesdeCombo.Items.Clear();
                horarioHastaCombo.Items.Clear();
                this.llenarHorariosDesde(horarioDesdeCombo, true);
                this.llenarHorariosHasta(horarioHastaCombo, true);
            }
            else
            {
                horarioDesdeCombo.Items.Clear();
                horarioHastaCombo.Items.Clear();
                this.llenarHorariosDesde(horarioDesdeCombo, false);
                this.llenarHorariosHasta(horarioHastaCombo, false);
            }
        }

        private void agregarHorarioButton_Click(object sender, EventArgs e)
        {
            string nombreDiaSemana = diasSemanaCombo.SelectedValue.ToString();
            int diaSemana = diasSemana[nombreDiaSemana];
            diasSemanaCombo.Items.Remove(nombreDiaSemana);
            string horaDesde = horarioDesdeCombo.SelectedValue.ToString();
            string horaHasta = horarioHastaCombo.SelectedValue.ToString();

            if(Int32.Parse(horaDesde.Substring(0,2)) > Int32.Parse(horaHasta.Substring(0,2)) ||
                (Int32.Parse(horaDesde.Substring(0, 2)) == Int32.Parse(horaHasta.Substring(0, 2)) &&
                Int32.Parse(horaDesde.Substring(3, 2)) >= Int32.Parse(horaHasta.Substring(3, 2)))) {
                MessageBox.Show("El horario final no puede ser menor o igual al inicial", "Registrar Agenda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                diasSemanaCombo.Items.Add(nombreDiaSemana);
                return;
            }

            HorariosDia diaNuevo = new HorariosDia(diaSemana, horaDesde, horaHasta, nombreDiaSemana);
            diasAgenda.Add(diaNuevo);
            horariosPorDiaList.Items.Add(diaNuevo);
        }

        private void borrarHorarioButton_Click(object sender, EventArgs e)
        {
            if(horariosPorDiaList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione los horarios a borrar", "Registrar Agenda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach(Object selectedItem in horariosPorDiaList.SelectedItems)
            {
                HorariosDia diaHorarioBorrar = (HorariosDia)selectedItem;
                diasSemanaCombo.Items.Add(diaHorarioBorrar.nombreDiaSemana);
                diasAgenda.Remove(diaHorarioBorrar);
            }

        }
    }
}
