using ClinicaFrba.Base_de_Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Clases
{
    public class Comunes
    {
        public static TextBox textBox;
        public static Form form_nuevo;
        public static MonthCalendar calendario;

        public static void agregar_boton_dataGrid(DataGridView dataGrid, string texto_mostrar_boton, string nombre_boton)
        {
            try
            {
                DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
                boton.UseColumnTextForButtonValue = true;
                boton.Text = texto_mostrar_boton;
                boton.Name = nombre_boton;
                dataGrid.Columns.Add(boton);
            }
            catch (Exception ex)
            {
                InteraccionDB.ImprimirExcepcion(ex);
                throw new Exception("Error al Agregar Boton Datagrid. " + ex.Message);
            }
        }

        public static void llenar_dataGrid(DataGridView dataGrid, DataTable datos)
        {
            try
            {
                //Reseteo Columnas a 0
                dataGrid.Columns.Clear();

                dataGrid.ReadOnly = true;
                dataGrid.DataSource = datos;
            }
            catch (Exception ex)
            {
                InteraccionDB.ImprimirExcepcion(ex);
                throw new Exception("Error al llenar datos Datagrid. " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene un Valor String de una fila y columna determinada del Datagrid
        /// <para>Recomendacion: Usar dentro de un evento "cell_click"</para>
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="numero_columa"></param>
        /// <returns></returns>
        public static string obtenerStringDataGrid(DataGridView dataGrid, int numero_fila, int numero_columa)
        {
            return dataGrid.Rows[numero_fila].Cells[numero_columa].FormattedValue.ToString();
        }

        /// <summary>
        /// Obtiene un Valor Int de una fila y columna determinada del Datagrid
        /// <para>Recomendacion: Usar dentro de un evento "cell_click"</para>
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="numero_columa"></param>
        /// <returns></returns>
        public static int obtenerIntDataGrid(DataGridView dataGrid, int numero_fila, int numero_columa)
        {
            return Convert.ToInt32(dataGrid.Rows[numero_fila].Cells[numero_columa].FormattedValue);
        }

        internal static void limpiarDataGrid(DataGridView dataGrid)
        {
            dataGrid.Columns.Clear();
        }

        public static void DialogoElegirFecha(TextBox textBox)
        {
            Comunes.textBox = textBox;

            Comunes.calendario = new MonthCalendar();
            Comunes.form_nuevo = new Form();
            calendario.MaxSelectionCount = 1;
            calendario.DateChanged += new DateRangeEventHandler(Elegir_Fecha);
            form_nuevo.Controls.Add(calendario);

            form_nuevo.FormBorderStyle = FormBorderStyle.None;
            form_nuevo.Width = 230;
            form_nuevo.Height = 160;

            var result = form_nuevo.ShowDialog();
        }

        private static void Elegir_Fecha(object sender, EventArgs e)
        {
            string fecha = calendario.SelectionStart.Date.ToString("yyyy.MM.dd");

            Comunes.textBox.Text = fecha;

            Comunes.form_nuevo.Close();
        }
    }
}
