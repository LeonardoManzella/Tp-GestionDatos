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
            this.boton_salir = new System.Windows.Forms.Button();
            this.button_horarios = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.groupBox_filtros = new System.Windows.Forms.GroupBox();
            this.groupBox_filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // boton_pedirTurno
            // 
            this.boton_pedirTurno.Enabled = false;
            this.boton_pedirTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_pedirTurno.Location = new System.Drawing.Point(566, 433);
            this.boton_pedirTurno.Name = "boton_pedirTurno";
            this.boton_pedirTurno.Size = new System.Drawing.Size(106, 40);
            this.boton_pedirTurno.TabIndex = 6;
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
            this.comboHorarios.TabIndex = 5;
            this.comboHorarios.SelectedIndexChanged += new System.EventHandler(this.comboHorarios_SelectedIndexChanged);
            // 
            // comboProfesionales
            // 
            this.comboProfesionales.Enabled = false;
            this.comboProfesionales.FormattingEnabled = true;
            this.comboProfesionales.Location = new System.Drawing.Point(147, 57);
            this.comboProfesionales.Name = "comboProfesionales";
            this.comboProfesionales.Size = new System.Drawing.Size(158, 21);
            this.comboProfesionales.TabIndex = 2;
            this.comboProfesionales.SelectedIndexChanged += new System.EventHandler(this.comboProfesionales_SelectedIndexChanged);
            // 
            // comboEspecialidades
            // 
            this.comboEspecialidades.FormattingEnabled = true;
            this.comboEspecialidades.Location = new System.Drawing.Point(147, 25);
            this.comboEspecialidades.Name = "comboEspecialidades";
            this.comboEspecialidades.Size = new System.Drawing.Size(158, 21);
            this.comboEspecialidades.TabIndex = 1;
            this.comboEspecialidades.SelectedIndexChanged += new System.EventHandler(this.comboEspecialidades_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccionar Especialidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Elegir Profesional";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Elegir Fecha";
            // 
            // datePicker_fecha
            // 
            this.datePicker_fecha.Enabled = false;
            this.datePicker_fecha.Location = new System.Drawing.Point(405, 25);
            this.datePicker_fecha.Name = "datePicker_fecha";
            this.datePicker_fecha.Size = new System.Drawing.Size(200, 20);
            this.datePicker_fecha.TabIndex = 3;
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
            // boton_salir
            // 
            this.boton_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_salir.Location = new System.Drawing.Point(285, 433);
            this.boton_salir.Name = "boton_salir";
            this.boton_salir.Size = new System.Drawing.Size(103, 40);
            this.boton_salir.TabIndex = 7;
            this.boton_salir.Text = "Cancelar";
            this.boton_salir.UseVisualStyleBackColor = true;
            this.boton_salir.Click += new System.EventHandler(this.boton_salir_Click);
            // 
            // button_horarios
            // 
            this.button_horarios.Enabled = false;
            this.button_horarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_horarios.Location = new System.Drawing.Point(529, 57);
            this.button_horarios.Name = "button_horarios";
            this.button_horarios.Size = new System.Drawing.Size(76, 31);
            this.button_horarios.TabIndex = 4;
            this.button_horarios.Text = "Buscar Turnos";
            this.button_horarios.UseVisualStyleBackColor = true;
            this.button_horarios.Click += new System.EventHandler(this.button_horarios_Click);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_limpiar.Location = new System.Drawing.Point(19, 433);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(76, 40);
            this.button_limpiar.TabIndex = 14;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            // 
            // groupBox_filtros
            // 
            this.groupBox_filtros.Controls.Add(this.label1);
            this.groupBox_filtros.Controls.Add(this.comboEspecialidades);
            this.groupBox_filtros.Controls.Add(this.button_horarios);
            this.groupBox_filtros.Controls.Add(this.label2);
            this.groupBox_filtros.Controls.Add(this.comboProfesionales);
            this.groupBox_filtros.Controls.Add(this.label3);
            this.groupBox_filtros.Controls.Add(this.datePicker_fecha);
            this.groupBox_filtros.Location = new System.Drawing.Point(12, 12);
            this.groupBox_filtros.Name = "groupBox_filtros";
            this.groupBox_filtros.Size = new System.Drawing.Size(619, 100);
            this.groupBox_filtros.TabIndex = 15;
            this.groupBox_filtros.TabStop = false;
            this.groupBox_filtros.Text = "Filtros de Busqueda";
            // 
            // PedirTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 485);
            this.Controls.Add(this.groupBox_filtros);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.boton_salir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboHorarios);
            this.Controls.Add(this.boton_pedirTurno);
            this.Name = "PedirTurno";
            this.Text = "Pedir Turnos";
            this.Load += new System.EventHandler(this.PedirTurno_Load);
            this.groupBox_filtros.ResumeLayout(false);
            this.groupBox_filtros.PerformLayout();
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
        private System.Windows.Forms.Button boton_salir;
        private System.Windows.Forms.Button button_horarios;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.GroupBox groupBox_filtros;
    }
}