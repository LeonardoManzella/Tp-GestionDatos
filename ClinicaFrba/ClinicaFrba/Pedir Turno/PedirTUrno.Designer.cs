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
            this.comboEspecialidades = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.datePicker_fecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.boton_salir = new System.Windows.Forms.Button();
            this.button_horarios = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.groupBox_filtros = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_apellido = new System.Windows.Forms.TextBox();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView_resultados_filtros = new System.Windows.Forms.DataGridView();
            this.groupBox_filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados_filtros)).BeginInit();
            this.SuspendLayout();
            // 
            // comboEspecialidades
            // 
            this.comboEspecialidades.FormattingEnabled = true;
            this.comboEspecialidades.Location = new System.Drawing.Point(376, 25);
            this.comboEspecialidades.Name = "comboEspecialidades";
            this.comboEspecialidades.Size = new System.Drawing.Size(158, 21);
            this.comboEspecialidades.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccionar Especialidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Elegir Fecha";
            // 
            // datePicker_fecha
            // 
            this.datePicker_fecha.Location = new System.Drawing.Point(334, 57);
            this.datePicker_fecha.Name = "datePicker_fecha";
            this.datePicker_fecha.Size = new System.Drawing.Size(200, 20);
            this.datePicker_fecha.TabIndex = 3;
            this.datePicker_fecha.Value = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.datePicker_fecha.ValueChanged += new System.EventHandler(this.datePicker_fecha_ValueChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(216, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Turnos Disponibles";
            // 
            // boton_salir
            // 
            this.boton_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_salir.Location = new System.Drawing.Point(277, 387);
            this.boton_salir.Name = "boton_salir";
            this.boton_salir.Size = new System.Drawing.Size(103, 40);
            this.boton_salir.TabIndex = 7;
            this.boton_salir.Text = "Cancelar";
            this.boton_salir.UseVisualStyleBackColor = true;
            this.boton_salir.Click += new System.EventHandler(this.boton_salir_Click);
            // 
            // button_horarios
            // 
            this.button_horarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_horarios.Location = new System.Drawing.Point(562, 50);
            this.button_horarios.Name = "button_horarios";
            this.button_horarios.Size = new System.Drawing.Size(82, 36);
            this.button_horarios.TabIndex = 4;
            this.button_horarios.Text = "Buscar Turnos";
            this.button_horarios.UseVisualStyleBackColor = true;
            this.button_horarios.Click += new System.EventHandler(this.button_horarios_Click);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_limpiar.Location = new System.Drawing.Point(12, 387);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(76, 40);
            this.button_limpiar.TabIndex = 14;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // groupBox_filtros
            // 
            this.groupBox_filtros.Controls.Add(this.label7);
            this.groupBox_filtros.Controls.Add(this.textBox_apellido);
            this.groupBox_filtros.Controls.Add(this.textBox_nombre);
            this.groupBox_filtros.Controls.Add(this.label6);
            this.groupBox_filtros.Controls.Add(this.label5);
            this.groupBox_filtros.Controls.Add(this.label1);
            this.groupBox_filtros.Controls.Add(this.label3);
            this.groupBox_filtros.Controls.Add(this.comboEspecialidades);
            this.groupBox_filtros.Controls.Add(this.datePicker_fecha);
            this.groupBox_filtros.Location = new System.Drawing.Point(12, 12);
            this.groupBox_filtros.Name = "groupBox_filtros";
            this.groupBox_filtros.Size = new System.Drawing.Size(544, 100);
            this.groupBox_filtros.TabIndex = 15;
            this.groupBox_filtros.TabStop = false;
            this.groupBox_filtros.Text = "Filtros de Busqueda";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(263, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "(Obligatorio)";
            // 
            // textBox_apellido
            // 
            this.textBox_apellido.Location = new System.Drawing.Point(120, 61);
            this.textBox_apellido.Name = "textBox_apellido";
            this.textBox_apellido.Size = new System.Drawing.Size(100, 20);
            this.textBox_apellido.TabIndex = 10;
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(120, 26);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(100, 20);
            this.textBox_nombre.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Apellido Profesional";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nombre Profesional";
            // 
            // dataGridView_resultados_filtros
            // 
            this.dataGridView_resultados_filtros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_resultados_filtros.Location = new System.Drawing.Point(12, 155);
            this.dataGridView_resultados_filtros.Name = "dataGridView_resultados_filtros";
            this.dataGridView_resultados_filtros.Size = new System.Drawing.Size(685, 216);
            this.dataGridView_resultados_filtros.TabIndex = 16;
            this.dataGridView_resultados_filtros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_resultados_filtros_CellContentClick);
            // 
            // PedirTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 439);
            this.Controls.Add(this.dataGridView_resultados_filtros);
            this.Controls.Add(this.groupBox_filtros);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.boton_salir);
            this.Controls.Add(this.button_horarios);
            this.Controls.Add(this.label4);
            this.Name = "PedirTurno";
            this.Text = "Pedir Turnos";
            this.Load += new System.EventHandler(this.PedirTurno_Load);
            this.groupBox_filtros.ResumeLayout(false);
            this.groupBox_filtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados_filtros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboEspecialidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datePicker_fecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button boton_salir;
        private System.Windows.Forms.Button button_horarios;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.GroupBox groupBox_filtros;
        private System.Windows.Forms.DataGridView dataGridView_resultados_filtros;
        private System.Windows.Forms.TextBox textBox_apellido;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
    }
}