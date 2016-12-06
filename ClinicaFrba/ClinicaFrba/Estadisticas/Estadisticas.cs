﻿using ClinicaFrba.Clases;
using ClinicaFrba.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Estadisticas
{
    public partial class Estadisticas : Form
    {

        ComboData cero;
        public Estadisticas()
        {
            InitializeComponent();
        }


        private void btnEjecutar_Click(object sender, EventArgs e)
        {

        }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_numeros(e);
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {
            try
            {
                cero = new ComboData(0, "Sin Elegir");

                this.comboEspec.DisplayMember = "descripcion";
                this.comboEspec.ValueMember = "identificador";
                var estados = Llegada_At_Med.obtenerEspecialidades();
                this.comboEspec.Items.Add(cero);
                foreach (ComboData item in estados)
                { 
                this.comboEspec.Items.Add(item);
                }

                this.comboBox3.DisplayMember = "descripcion";
                this.comboBox3.ValueMember = "identificador";
                var planes = ABMAFIL.get_Planes_Sociales();
                this.comboEspec.Items.Add(cero);
                foreach (ComboData item in planes)
                {
                    this.comboEspec.Items.Add(item);
                }

                this.comboTop5.Items.Add(new ComboData(1, "Especialidades más canceladas"));
                this.comboTop5.Items.Add(new ComboData(2, "Profesionales más consultados"));
                this.comboTop5.Items.Add(new ComboData(3, "Profesionales que menos trabajaron"));
                this.comboTop5.Items.Add(new ComboData(4, "Afiliado que más bonos compró"));
                this.comboTop5.Items.Add(new ComboData(5, "Especialidades más concurridas"));

                this.comboSemestre.Items.Add(new ComboData(1, "Primer"));
                this.comboSemestre.Items.Add(new ComboData(2, "Segundo"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Cargar Form: ERROR: " + ex.Message, "Estadisticas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
