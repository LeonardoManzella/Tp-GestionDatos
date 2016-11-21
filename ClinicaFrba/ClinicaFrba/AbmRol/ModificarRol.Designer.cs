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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_nombreRol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_busqueda = new System.Windows.Forms.Button();
            this.checkedListBox_Funcionalidades = new System.Windows.Forms.CheckedListBox();
            this.button_modificarRol = new System.Windows.Forms.Button();
            this.checkBox_rolHabilitado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "INCLUYE HABILITAR Y DESHABILITAR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ingrese Nombre Rol:";
            // 
            // textBox_nombreRol
            // 
            this.textBox_nombreRol.Location = new System.Drawing.Point(14, 82);
            this.textBox_nombreRol.Name = "textBox_nombreRol";
            this.textBox_nombreRol.Size = new System.Drawing.Size(100, 20);
            this.textBox_nombreRol.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(399, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "<Numero ROL>";
            // 
            // button_busqueda
            // 
            this.button_busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_busqueda.Location = new System.Drawing.Point(133, 52);
            this.button_busqueda.Name = "button_busqueda";
            this.button_busqueda.Size = new System.Drawing.Size(95, 34);
            this.button_busqueda.TabIndex = 4;
            this.button_busqueda.Text = "Buscar Rol";
            this.button_busqueda.UseVisualStyleBackColor = true;
            this.button_busqueda.Click += new System.EventHandler(this.button_busqueda_Click);
            // 
            // checkedListBox_Funcionalidades
            // 
            this.checkedListBox_Funcionalidades.Enabled = false;
            this.checkedListBox_Funcionalidades.FormattingEnabled = true;
            this.checkedListBox_Funcionalidades.Location = new System.Drawing.Point(264, 18);
            this.checkedListBox_Funcionalidades.Name = "checkedListBox_Funcionalidades";
            this.checkedListBox_Funcionalidades.Size = new System.Drawing.Size(120, 169);
            this.checkedListBox_Funcionalidades.TabIndex = 5;
            // 
            // button_modificarRol
            // 
            this.button_modificarRol.Enabled = false;
            this.button_modificarRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_modificarRol.Location = new System.Drawing.Point(390, 121);
            this.button_modificarRol.Name = "button_modificarRol";
            this.button_modificarRol.Size = new System.Drawing.Size(136, 66);
            this.button_modificarRol.TabIndex = 6;
            this.button_modificarRol.Text = "Modificar";
            this.button_modificarRol.UseVisualStyleBackColor = true;
            this.button_modificarRol.Click += new System.EventHandler(this.button_modificarRol_Click);
            // 
            // checkBox_rolHabilitado
            // 
            this.checkBox_rolHabilitado.AutoSize = true;
            this.checkBox_rolHabilitado.Enabled = false;
            this.checkBox_rolHabilitado.Location = new System.Drawing.Point(402, 82);
            this.checkBox_rolHabilitado.Name = "checkBox_rolHabilitado";
            this.checkBox_rolHabilitado.Size = new System.Drawing.Size(85, 17);
            this.checkBox_rolHabilitado.TabIndex = 7;
            this.checkBox_rolHabilitado.Text = "¿Habilitado?";
            this.checkBox_rolHabilitado.UseVisualStyleBackColor = true;
            // 
            // ModificarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 215);
            this.Controls.Add(this.checkBox_rolHabilitado);
            this.Controls.Add(this.button_modificarRol);
            this.Controls.Add(this.checkedListBox_Funcionalidades);
            this.Controls.Add(this.button_busqueda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_nombreRol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModificarRol";
            this.Text = "ModificarRol";
            this.Load += new System.EventHandler(this.ModificarRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_nombreRol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_busqueda;
        private System.Windows.Forms.CheckedListBox checkedListBox_Funcionalidades;
        private System.Windows.Forms.Button button_modificarRol;
        private System.Windows.Forms.CheckBox checkBox_rolHabilitado;
    }
}