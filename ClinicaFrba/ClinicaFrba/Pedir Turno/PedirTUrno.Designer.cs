namespace ClinicaFrba.Pedir_Turno
{
    partial class PedirTurno
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
            this.boton_pedirTurno = new System.Windows.Forms.Button();
            this.comboHorarios = new System.Windows.Forms.ComboBox();
            this.comboProfesionales = new System.Windows.Forms.ComboBox();
            this.comboEspecialidades = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.datePicker_fecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.boton_salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boton_pedirTurno
            // 
            this.boton_pedirTurno.Enabled = false;
            this.boton_pedirTurno.Location = new System.Drawing.Point(225, 196);
            this.boton_pedirTurno.Name = "boton_pedirTurno";
            this.boton_pedirTurno.Size = new System.Drawing.Size(106, 64);
            this.boton_pedirTurno.TabIndex = 0;
            this.boton_pedirTurno.Text = "Pedir Turno";
            this.boton_pedirTurno.UseVisualStyleBackColor = true;
            this.boton_pedirTurno.Click += new System.EventHandler(this.boton_pedirTurno_Click);
            // 
            // comboHorarios
            // 
            this.comboHorarios.Enabled = false;
            this.comboHorarios.FormattingEnabled = true;
            this.comboHorarios.Location = new System.Drawing.Point(18, 219);
            this.comboHorarios.Name = "comboHorarios";
            this.comboHorarios.Size = new System.Drawing.Size(166, 21);
            this.comboHorarios.TabIndex = 1;
            this.comboHorarios.SelectedIndexChanged += new System.EventHandler(this.comboHorarios_SelectedIndexChanged);
            // 
            // comboProfesionales
            // 
            this.comboProfesionales.Enabled = false;
            this.comboProfesionales.FormattingEnabled = true;
            this.comboProfesionales.Location = new System.Drawing.Point(192, 94);
            this.comboProfesionales.Name = "comboProfesionales";
            this.comboProfesionales.Size = new System.Drawing.Size(158, 21);
            this.comboProfesionales.TabIndex = 2;
            this.comboProfesionales.SelectedIndexChanged += new System.EventHandler(this.comboProfesionales_SelectedIndexChanged);
            // 
            // comboEspecialidades
            // 
            this.comboEspecialidades.FormattingEnabled = true;
            this.comboEspecialidades.Location = new System.Drawing.Point(19, 94);
            this.comboEspecialidades.Name = "comboEspecialidades";
            this.comboEspecialidades.Size = new System.Drawing.Size(150, 21);
            this.comboEspecialidades.TabIndex = 3;
            this.comboEspecialidades.SelectedIndexChanged += new System.EventHandler(this.comboEspecialidades_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccionar Especialidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Elegir Profesional";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(421, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Elegir Turno";
            // 
            // datePicker_fecha
            // 
            this.datePicker_fecha.Enabled = false;
            this.datePicker_fecha.Location = new System.Drawing.Point(367, 94);
            this.datePicker_fecha.Name = "datePicker_fecha";
            this.datePicker_fecha.Size = new System.Drawing.Size(200, 20);
            this.datePicker_fecha.TabIndex = 7;
            this.datePicker_fecha.ValueChanged += new System.EventHandler(this.datePicker_fecha_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Horarios Disponibles";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.YellowGreen;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(66, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.YellowGreen;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(238, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 26);
            this.label6.TabIndex = 10;
            this.label6.Text = "2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.YellowGreen;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(415, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 26);
            this.label7.TabIndex = 11;
            this.label7.Text = "3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.YellowGreen;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(66, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 26);
            this.label8.TabIndex = 12;
            this.label8.Text = "4";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.YellowGreen;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(269, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 26);
            this.label9.TabIndex = 13;
            this.label9.Text = "5";
            // 
            // boton_salir
            // 
            this.boton_salir.Location = new System.Drawing.Point(470, 196);
            this.boton_salir.Name = "boton_salir";
            this.boton_salir.Size = new System.Drawing.Size(106, 64);
            this.boton_salir.TabIndex = 14;
            this.boton_salir.Text = "Cancelar";
            this.boton_salir.UseVisualStyleBackColor = true;
            this.boton_salir.Click += new System.EventHandler(this.boton_salir_Click);
            // 
            // PedirTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 298);
            this.Controls.Add(this.boton_salir);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.datePicker_fecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboEspecialidades);
            this.Controls.Add(this.comboProfesionales);
            this.Controls.Add(this.comboHorarios);
            this.Controls.Add(this.boton_pedirTurno);
            this.Name = "PedirTurno";
            this.Text = "Pedir Turnos";
            this.Load += new System.EventHandler(this.PedirTurno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button boton_pedirTurno;
        private System.Windows.Forms.ComboBox comboHorarios;
        private System.Windows.Forms.ComboBox comboProfesionales;
        private System.Windows.Forms.ComboBox comboEspecialidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datePicker_fecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button boton_salir;
    }
}