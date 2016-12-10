﻿using System;
using System.Windows.Forms;
using ClinicaFrba.Clases;
using Microsoft.VisualBasic;
using ClinicaFrba.Base_de_Datos;
using System.Data;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class IdentificarAfiliado
        : Form
    {
        public ABM_AFILIADO siguiente { get; set; }

        public Usuario usuario;

        private int afiliado_id;

        public IdentificarAfiliado()
        {
            InitializeComponent();
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.chkTitular.Checked == true)
                {
                    if (siguiente != null)
                    {
                        if (siguiente.funcionalidad != ABM_AFILIADO.tipos_funcionalidad.ALTA)
                        {
                            this.siguiente.afiliado.id = this.afiliado_id;
                        }
                        else
                        {
                            this.siguiente.afiliado_principal = new Afiliado();
                            this.siguiente.afiliado_principal.id = this.afiliado_id;
                        }
                        this.siguiente.ShowDialog();
                    }
                    this.Close();

                }
                else
                { 
                string nombre = this.textBox_Nombre.Text.Trim();
                string apellido = this.textBox_Apellido.Text.Trim();
                string documento = this.textBox_Documento.Text.Trim();


                //DATAGRID
                DataTable datos = BD_Afiliados.obtener_afiliados_filtros(nombre, apellido, documento);

                if (datos.Rows.Count <= 0) throw new Exception("No hay Afiliados para Estos Filtros");

                //Lleno el DataGrid
                Comunes.llenar_dataGrid(dataGridView_resultados_filtros, datos);

                //Agrego Boton
                Comunes.agregar_boton_dataGrid(dataGridView_resultados_filtros, "Seleccionar", "seleccionar");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Buscar Afiliado con Filtros. ERROR:  " + ex.Message, "identificarAfiliado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //No me deja renombrarlo,pero lo reconoce bien
        private void ABMAFILIADO_Load(object sender, EventArgs e)
        {
            if (siguiente != null)
            {
                this.siguiente.afiliado = new Afiliado();
                this.siguiente.afiliado_principal = new Afiliado();
                if (siguiente.funcionalidad == ABM_AFILIADO.tipos_funcionalidad.ALTA)
                {
                    chkTitular.Visible = true;
                    chkTitular.Checked = false;
                }
                else
                {
                    chkTitular.Visible = false;
                    chkTitular.Checked = false;
                }
            }
            this.btnAccion_Click(sender, e);
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void textBox_Documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_numeros(e);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_Nombre.Text = "";
                textBox_Apellido.Text = "";
                textBox_Documento.Text = "";

                btnAccion_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "IdentificarAfiliado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_Apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras(e);
        }

        private void textBox_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_letras(e);
        }

        private void dataGridView_resultados_filtros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dataGridView_resultados_filtros.Columns[e.ColumnIndex].Name == "seleccionar")
                {
                    //Hago cosas con los valores de la fila seleccionada
                    this.afiliado_id = Comunes.obtenerIntDataGrid(dataGridView_resultados_filtros, e.RowIndex, 0);


                    this.textBox_Nombre.Text = Comunes.obtenerStringDataGrid(dataGridView_resultados_filtros, e.RowIndex, 1);
                    this.textBox_Apellido.Text = Comunes.obtenerStringDataGrid(dataGridView_resultados_filtros, e.RowIndex, 2);
                    this.textBox_Documento.Text = Comunes.obtenerStringDataGrid(dataGridView_resultados_filtros, e.RowIndex, 3);
                    var choise = MessageBox.Show("Seguro desea seleccionar el Afiliado: " + this.textBox_Nombre.Text + " " + this.textBox_Apellido.Text, "Identificar Afiliado", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (choise == DialogResult.OK)
                    {

                        if (siguiente != null)
                        {
                            if (siguiente.funcionalidad != ABM_AFILIADO.tipos_funcionalidad.ALTA)
                            {
                                this.siguiente.afiliado.id = this.afiliado_id;                                
                            }
                            else
                            {
                                // SI es un alta sólo se pasa un id cuando es un nuevo afiliado a cargo del seleccionado
                                this.siguiente.afiliado_principal.id = ((int)this.afiliado_id / 100) * 100 + 1;
                            }
                            this.siguiente.ShowDialog();
                        }
                        this.Close();
                    };

                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener Datos Columna. ERROR: " + ex.Message, "Identificar Afiliado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkTitular_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkTitular.Checked == true)
            {
                GB_filtros.Visible = false;
                dataGridView_resultados_filtros.Visible = false;
                btnLimpiar.Visible = false;
                btnAccion.Text = "Crear";
            }
            else
            {
                GB_filtros.Visible = true;
                dataGridView_resultados_filtros.Visible = true;
                btnLimpiar.Visible = true;
                btnAccion.Text = "Filtrar";
            }
        }

        private void textBox_Documento_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Helper.permitir_numeros(e);
        }
    }
}
