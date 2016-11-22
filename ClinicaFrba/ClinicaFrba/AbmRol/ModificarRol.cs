﻿using ClinicaFrba.Base_de_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class ModificarRol : Form
    {
        private int id_rol;
        private string nombreRol;
        private List<string> funcionalidades_del_rol;
        private List<string> funcionalidades_posibles;


        public ModificarRol()
        {
            InitializeComponent();
        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {
            try
            {
                id_rol = 0;
                nombreRol = null;
                funcionalidades_del_rol = new List<string>();
                funcionalidades_posibles = InteraccionDB.obtener_todas_funcionalidades();

                resetear_botones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_busqueda_Click(object sender, EventArgs e)
        {
            try
            {
                resetear_botones();


                this.nombreRol = textBox_nombreRol.Text.Trim();
                if (String.IsNullOrEmpty(nombreRol)) throw new Exception("Nombre Vacio");

                id_rol = BD_Roles.obtenerID_rol(nombreRol);

                funcionalidades_del_rol = BD_Roles.obtener_funcionalidades_rol(id_rol);

                foreach (string func in funcionalidades_del_rol)
                {
                    checkedListBox_Funcionalidades.Items.Add(func, true);
                }

                //Agrego los sin Seleccionar para el Rol
                var sinSeleccionar = funcionalidadesSinSeleccionar();
                foreach (string func in sinSeleccionar)
                {
                    checkedListBox_Funcionalidades.Items.Add(func, false);
                }

                this.checkBox_rolHabilitado.Checked = BD_Roles.obtener_estado_habilitado_rol(id_rol);

                this.label3.Text = id_rol.ToString();
                this.checkedListBox_Funcionalidades.Enabled = true;
                this.checkBox_rolHabilitado.Enabled         = true;
                this.button_modificarRol.Enabled            = true;
            }
            catch (Exception ex)
            {
                resetear_botones();
                MessageBox.Show(ex.Message, "Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetear_botones()
        {
            this.checkedListBox_Funcionalidades.Items.Clear();
            this.label3.Text = "";
            this.checkedListBox_Funcionalidades.Enabled = false;
            this.checkBox_rolHabilitado.Enabled = false;
            this.button_modificarRol.Enabled = false;
        }

        private List<string> funcionalidadesSinSeleccionar()
        {
            //genero copia para trabajar
            List<string> sinSeleccionar = new List<string>(funcionalidades_posibles);

            //Quito los Duplicados
            foreach (var fun_del_rol in funcionalidades_del_rol)
            {
                sinSeleccionar.Remove(fun_del_rol);
            }

            return sinSeleccionar;
        }

        private void button_modificarRol_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtengo items elegidos y convierto a strings
                List<string> funcionalidades_elegidas = new List<string>();
                var objects = checkedListBox_Funcionalidades.CheckedItems;
                if (objects.Count <= 0) throw new Exception("No hay Funcionalidades Elegidas");

                foreach (var item in objects)
                {
                    string fun = Convert.ToString(item);
                    funcionalidades_elegidas.Add(fun);
                    //MessageBox.Show(fun, "Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                var funcs_por_agregar = funcionalidades_por_agregar(funcionalidades_elegidas);
                foreach (string func in funcs_por_agregar)
                {
                    BD_Roles.insertar_funcionalidad(id_rol,func);
                }

                var funcs_por_quitar = funcionalidades_por_quitar(funcionalidades_elegidas);
                foreach (string func in funcs_por_quitar)
                {
                    BD_Roles.quitar_funcionalidad(id_rol, func);
                }


                bool estado = this.checkBox_rolHabilitado.Checked;
                BD_Roles.setear_habilitacion(id_rol,estado);

                MessageBox.Show("Rol Modificado con Exito", "Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> funcionalidades_por_agregar(List<string> funcionalidades_elegidas)
        {
            //Busco las que no estaban antes que fueron seleccionadas ahora, ahora hay que agregarlas
            return funcionalidades_elegidas.FindAll(f => !this.funcionalidades_del_rol.Contains(f) );
        }

        private List<string> funcionalidades_por_quitar(List<string> funcionalidades_elegidas)
        {
            //Busco las que estaban antes que no fueron seleccionadas ahora, ahora hay que quitarlas
            return this.funcionalidades_del_rol.FindAll(f => !funcionalidades_elegidas.Contains(f));
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_eliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
