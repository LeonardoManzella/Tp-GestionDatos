namespace ClinicaFrba.AbmRol
{
    partial class ModificarRol
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_busqueda = new System.Windows.Forms.Button();
            this.checkedListBox_Funcionalidades = new System.Windows.Forms.CheckedListBox();
            this.button_modificarRol = new System.Windows.Forms.Button();
            this.checkBox_rolHabilitado = new System.Windows.Forms.CheckBox();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.comboBox_rol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione Rol:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "<Numero ROL>";
            // 
            // button_busqueda
            // 
            this.button_busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_busqueda.Location = new System.Drawing.Point(227, 18);
            this.button_busqueda.Name = "button_busqueda";
            this.button_busqueda.Size = new System.Drawing.Size(123, 34);
            this.button_busqueda.TabIndex = 2;
            this.button_busqueda.Text = "Ver Datos Rol";
            this.button_busqueda.UseVisualStyleBackColor = true;
            this.button_busqueda.Click += new System.EventHandler(this.button_busqueda_Click);
            // 
            // checkedListBox_Funcionalidades
            // 
            this.checkedListBox_Funcionalidades.Enabled = false;
            this.checkedListBox_Funcionalidades.FormattingEnabled = true;
            this.checkedListBox_Funcionalidades.Location = new System.Drawing.Point(161, 107);
            this.checkedListBox_Funcionalidades.Name = "checkedListBox_Funcionalidades";
            this.checkedListBox_Funcionalidades.Size = new System.Drawing.Size(159, 154);
            this.checkedListBox_Funcionalidades.TabIndex = 4;
            // 
            // button_modificarRol
            // 
            this.button_modificarRol.Enabled = false;
            this.button_modificarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_modificarRol.Location = new System.Drawing.Point(337, 292);
            this.button_modificarRol.Name = "button_modificarRol";
            this.button_modificarRol.Size = new System.Drawing.Size(97, 49);
            this.button_modificarRol.TabIndex = 5;
            this.button_modificarRol.Text = "Modificar Datos";
            this.button_modificarRol.UseVisualStyleBackColor = true;
            this.button_modificarRol.Click += new System.EventHandler(this.button_modificarRol_Click);
            // 
            // checkBox_rolHabilitado
            // 
            this.checkBox_rolHabilitado.AutoSize = true;
            this.checkBox_rolHabilitado.Enabled = false;
            this.checkBox_rolHabilitado.Location = new System.Drawing.Point(15, 122);
            this.checkBox_rolHabilitado.Name = "checkBox_rolHabilitado";
            this.checkBox_rolHabilitado.Size = new System.Drawing.Size(85, 17);
            this.checkBox_rolHabilitado.TabIndex = 3;
            this.checkBox_rolHabilitado.Text = "¿Habilitado?";
            this.checkBox_rolHabilitado.UseVisualStyleBackColor = true;
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(161, 299);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(115, 42);
            this.button_cancelar.TabIndex = 6;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // comboBox_rol
            // 
            this.comboBox_rol.FormattingEnabled = true;
            this.comboBox_rol.Location = new System.Drawing.Point(100, 18);
            this.comboBox_rol.Name = "comboBox_rol";
            this.comboBox_rol.Size = new System.Drawing.Size(121, 21);
            this.comboBox_rol.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(184, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Funcionalidades del Rol";
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(12, 305);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(81, 36);
            this.button_limpiar.TabIndex = 7;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // ModificarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 353);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_rol);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.checkBox_rolHabilitado);
            this.Controls.Add(this.button_modificarRol);
            this.Controls.Add(this.checkedListBox_Funcionalidades);
            this.Controls.Add(this.button_busqueda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "ModificarRol";
            this.Text = "ModificarRol";
            this.Load += new System.EventHandler(this.ModificarRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_busqueda;
        private System.Windows.Forms.CheckedListBox checkedListBox_Funcionalidades;
        private System.Windows.Forms.Button button_modificarRol;
        private System.Windows.Forms.CheckBox checkBox_rolHabilitado;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.ComboBox comboBox_rol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_limpiar;
    }
}