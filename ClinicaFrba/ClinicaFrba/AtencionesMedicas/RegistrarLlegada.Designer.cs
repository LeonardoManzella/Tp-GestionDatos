namespace ClinicaFrba.AtencionesMedicas
{
    partial class RegistrarLlegada
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
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboEspecialidades = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_afiliado_apellido = new System.Windows.Forms.TextBox();
            this.label_afiliado_apellido = new System.Windows.Forms.Label();
            this.textBox_afiliado_nombre = new System.Windows.Forms.TextBox();
            this.label_afiliado_nombre = new System.Windows.Forms.Label();
            this.button_Registrar = new System.Windows.Forms.Button();
            this.combo_Bono = new System.Windows.Forms.ComboBox();
            this.cmb_turnos = new System.Windows.Forms.ComboBox();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_resultados_filtros = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.label_Afiliado = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados_filtros)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(79, 35);
            this.txtDNI.MaxLength = 10;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDNI.Size = new System.Drawing.Size(211, 20);
            this.txtDNI.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID Afiliado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccionar Especialidad:";
            // 
            // comboEspecialidades
            // 
            this.comboEspecialidades.FormattingEnabled = true;
            this.comboEspecialidades.Location = new System.Drawing.Point(145, 61);
            this.comboEspecialidades.Name = "comboEspecialidades";
            this.comboEspecialidades.Size = new System.Drawing.Size(223, 21);
            this.comboEspecialidades.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Seleccionar Profesional:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(142, 101);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(211, 21);
            this.comboBox1.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Turnos:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(447, 401);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Bonos:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 425);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 32);
            this.btnLimpiar.TabIndex = 18;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(521, 49);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(79, 35);
            this.btnBuscar.TabIndex = 19;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_afiliado_apellido);
            this.groupBox1.Controls.Add(this.comboEspecialidades);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label_afiliado_apellido);
            this.groupBox1.Controls.Add(this.textBox_afiliado_nombre);
            this.groupBox1.Controls.Add(this.label_afiliado_nombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 97);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // textBox_afiliado_apellido
            // 
            this.textBox_afiliado_apellido.Location = new System.Drawing.Point(338, 24);
            this.textBox_afiliado_apellido.Name = "textBox_afiliado_apellido";
            this.textBox_afiliado_apellido.Size = new System.Drawing.Size(140, 20);
            this.textBox_afiliado_apellido.TabIndex = 31;
            // 
            // label_afiliado_apellido
            // 
            this.label_afiliado_apellido.AutoSize = true;
            this.label_afiliado_apellido.Location = new System.Drawing.Point(251, 27);
            this.label_afiliado_apellido.Name = "label_afiliado_apellido";
            this.label_afiliado_apellido.Size = new System.Drawing.Size(81, 13);
            this.label_afiliado_apellido.TabIndex = 30;
            this.label_afiliado_apellido.Text = "Apellido Afiliado";
            // 
            // textBox_afiliado_nombre
            // 
            this.textBox_afiliado_nombre.Location = new System.Drawing.Point(103, 24);
            this.textBox_afiliado_nombre.Name = "textBox_afiliado_nombre";
            this.textBox_afiliado_nombre.Size = new System.Drawing.Size(140, 20);
            this.textBox_afiliado_nombre.TabIndex = 31;
            // 
            // label_afiliado_nombre
            // 
            this.label_afiliado_nombre.AutoSize = true;
            this.label_afiliado_nombre.Location = new System.Drawing.Point(10, 27);
            this.label_afiliado_nombre.Name = "label_afiliado_nombre";
            this.label_afiliado_nombre.Size = new System.Drawing.Size(81, 13);
            this.label_afiliado_nombre.TabIndex = 30;
            this.label_afiliado_nombre.Text = "Nombre Afiliado";
            // 
            // button_Registrar
            // 
            this.button_Registrar.Location = new System.Drawing.Point(711, 419);
            this.button_Registrar.Name = "button_Registrar";
            this.button_Registrar.Size = new System.Drawing.Size(97, 44);
            this.button_Registrar.TabIndex = 24;
            this.button_Registrar.Text = "REGISTRAR LLEGADA";
            this.button_Registrar.UseVisualStyleBackColor = true;
            this.button_Registrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // combo_Bono
            // 
            this.combo_Bono.FormattingEnabled = true;
            this.combo_Bono.Location = new System.Drawing.Point(493, 398);
            this.combo_Bono.Name = "combo_Bono";
            this.combo_Bono.Size = new System.Drawing.Size(194, 21);
            this.combo_Bono.TabIndex = 25;
            // 
            // cmb_turnos
            // 
            this.cmb_turnos.FormattingEnabled = true;
            this.cmb_turnos.Location = new System.Drawing.Point(70, 67);
            this.cmb_turnos.Name = "cmb_turnos";
            this.cmb_turnos.Size = new System.Drawing.Size(220, 21);
            this.cmb_turnos.TabIndex = 26;
            // 
            // cmbPlan
            // 
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Location = new System.Drawing.Point(93, 128);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(211, 21);
            this.cmbPlan.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Plan Afiliado";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.cmbPlan);
            this.groupBox2.Controls.Add(this.txtDNI);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmb_turnos);
            this.groupBox2.Location = new System.Drawing.Point(632, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 156);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "esto hay que borrarlo";
            // 
            // dataGridView_resultados_filtros
            // 
            this.dataGridView_resultados_filtros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_resultados_filtros.Location = new System.Drawing.Point(12, 185);
            this.dataGridView_resultados_filtros.Name = "dataGridView_resultados_filtros";
            this.dataGridView_resultados_filtros.Size = new System.Drawing.Size(822, 207);
            this.dataGridView_resultados_filtros.TabIndex = 30;
            this.dataGridView_resultados_filtros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_resultados_filtros_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(252, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 18);
            this.label3.TabIndex = 30;
            this.label3.Text = "Turnos Encontrados";
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(350, 425);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(93, 32);
            this.button_cancelar.TabIndex = 31;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // label_Afiliado
            // 
            this.label_Afiliado.AutoSize = true;
            this.label_Afiliado.Location = new System.Drawing.Point(157, 401);
            this.label_Afiliado.Name = "label_Afiliado";
            this.label_Afiliado.Size = new System.Drawing.Size(0, 13);
            this.label_Afiliado.TabIndex = 32;
            // 
            // RegistrarLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 480);
            this.Controls.Add(this.label_Afiliado);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.dataGridView_resultados_filtros);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combo_Bono);
            this.Controls.Add(this.button_Registrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label7);
            this.Name = "RegistrarLlegada";
            this.Text = "Registrar Llegada";
            this.Load += new System.EventHandler(this.RegistrarAtencion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados_filtros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboEspecialidades;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Button button_Registrar;
        private System.Windows.Forms.ComboBox combo_Bono;
        private System.Windows.Forms.ComboBox cmb_turnos;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_afiliado_apellido;
        private System.Windows.Forms.Label label_afiliado_apellido;
        private System.Windows.Forms.TextBox textBox_afiliado_nombre;
        private System.Windows.Forms.Label label_afiliado_nombre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_resultados_filtros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Label label_Afiliado;
    }
}