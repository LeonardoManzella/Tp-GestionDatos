namespace ClinicaFrba.AbmRol
{
    partial class CrearRol
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_funcionalidades = new System.Windows.Forms.CheckedListBox();
            this.textBox_nombre_rol = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(357, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 71);
            this.button1.TabIndex = 0;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(357, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 71);
            this.button2.TabIndex = 1;
            this.button2.Text = "Crear Rol";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre Rol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Funcionalidades";
            // 
            // checkBox_funcionalidades
            // 
            this.checkBox_funcionalidades.FormattingEnabled = true;
            this.checkBox_funcionalidades.Location = new System.Drawing.Point(200, 49);
            this.checkBox_funcionalidades.Name = "checkBox_funcionalidades";
            this.checkBox_funcionalidades.Size = new System.Drawing.Size(120, 214);
            this.checkBox_funcionalidades.TabIndex = 4;
            // 
            // textBox_nombre_rol
            // 
            this.textBox_nombre_rol.Location = new System.Drawing.Point(23, 117);
            this.textBox_nombre_rol.Name = "textBox_nombre_rol";
            this.textBox_nombre_rol.Size = new System.Drawing.Size(143, 20);
            this.textBox_nombre_rol.TabIndex = 5;
            // 
            // CrearRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 327);
            this.Controls.Add(this.textBox_nombre_rol);
            this.Controls.Add(this.checkBox_funcionalidades);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "CrearRol";
            this.Text = "Crear Rol";
            this.Load += new System.EventHandler(this.CrearRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkBox_funcionalidades;
        private System.Windows.Forms.TextBox textBox_nombre_rol;
    }
}