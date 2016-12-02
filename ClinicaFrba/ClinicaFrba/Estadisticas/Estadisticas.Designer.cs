namespace ClinicaFrba.Estadisticas
{
    partial class Estadisticas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboSemestre = new System.Windows.Forms.ComboBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboEspec = new System.Windows.Forms.ComboBox();
            this.comboTop5 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPlan = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            //this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            //this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.dataGridEstadistico = new System.Windows.Forms.DataGridView();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfApe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AfdoNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AfdoApe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AfdoGpoFliar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEstadistico)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboSemestre);
            this.groupBox1.Controls.Add(this.txtAnio);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.comboEspec);
            this.groupBox1.Controls.Add(this.comboTop5);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblPlan);
            this.groupBox1.Controls.Add(this.lblEspecialidad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Busqueda";
            // 
            // comboSemestre
            // 
            this.comboSemestre.FormattingEnabled = true;
            this.comboSemestre.Location = new System.Drawing.Point(349, 73);
            this.comboSemestre.Name = "comboSemestre";
            this.comboSemestre.Size = new System.Drawing.Size(121, 21);
            this.comboSemestre.TabIndex = 10;
            // 
            // txtAnio
            // 
            this.txtAnio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtAnio.Location = new System.Drawing.Point(349, 34);
            this.txtAnio.MaxLength = 4;
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAnio.Size = new System.Drawing.Size(121, 20);
            this.txtAnio.TabIndex = 9;
            this.txtAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnio_KeyPress);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(94, 108);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(172, 21);
            this.comboBox3.TabIndex = 8;
            // 
            // comboEspec
            // 
            this.comboEspec.FormattingEnabled = true;
            this.comboEspec.Location = new System.Drawing.Point(94, 68);
            this.comboEspec.Name = "comboEspec";
            this.comboEspec.Size = new System.Drawing.Size(172, 21);
            this.comboEspec.TabIndex = 7;
            // 
            // comboTop5
            // 
            this.comboTop5.FormattingEnabled = true;
            this.comboTop5.Location = new System.Drawing.Point(94, 29);
            this.comboTop5.Name = "comboTop5";
            this.comboTop5.Size = new System.Drawing.Size(172, 21);
            this.comboTop5.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Semestre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Año:";
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(18, 116);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(31, 13);
            this.lblPlan.TabIndex = 2;
            this.lblPlan.Text = "Plan:";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(18, 76);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(70, 13);
            this.lblEspecialidad.TabIndex = 1;
            this.lblEspecialidad.Text = "Especialidad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TOP 5:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(152, 173);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(299, 173);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(75, 23);
            this.btnEjecutar.TabIndex = 2;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // lineShape1
            // 
            //this.lineShape1.Name = "lineShape1";
            //this.lineShape1.X1 = 14;
            //this.lineShape1.X2 = 486;
            //this.lineShape1.Y1 = 211;
            //this.lineShape1.Y2 = 212;
            // 
            // shapeContainer1
            //// 
            //this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            //this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            //this.shapeContainer1.Name = "shapeContainer1";
            //this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            //this.lineShape1});
            //this.shapeContainer1.Size = new System.Drawing.Size(515, 422);
            //this.shapeContainer1.TabIndex = 3;
            //this.shapeContainer1.TabStop = false;
            // 
            // dataGridEstadistico
            // 
            this.dataGridEstadistico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEstadistico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cantidad,
            this.Especialidad,
            this.ProfNom,
            this.ProfApe,
            this.AfdoNom,
            this.AfdoApe,
            this.AfdoGpoFliar});
            this.dataGridEstadistico.Location = new System.Drawing.Point(12, 236);
            this.dataGridEstadistico.Name = "dataGridEstadistico";
            this.dataGridEstadistico.Size = new System.Drawing.Size(489, 174);
            this.dataGridEstadistico.TabIndex = 4;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cant. (Desc.)";
            this.Cantidad.Name = "Cantidad";
            // 
            // Especialidad
            // 
            this.Especialidad.HeaderText = "Especialidad";
            this.Especialidad.Name = "Especialidad";
            // 
            // ProfNom
            // 
            this.ProfNom.HeaderText = "Prof. Nom.";
            this.ProfNom.Name = "ProfNom";
            // 
            // ProfApe
            // 
            this.ProfApe.HeaderText = "Prof. Apellido";
            this.ProfApe.Name = "ProfApe";
            // 
            // AfdoNom
            // 
            this.AfdoNom.HeaderText = "Afildo. Nom.";
            this.AfdoNom.Name = "AfdoNom";
            // 
            // AfdoApe
            // 
            this.AfdoApe.HeaderText = "Afild. Apellido";
            this.AfdoApe.Name = "AfdoApe";
            // 
            // AfdoGpoFliar
            // 
            this.AfdoGpoFliar.HeaderText = "Afild. Gpo. Fliar.";
            this.AfdoGpoFliar.Name = "AfdoGpoFliar";
            this.AfdoGpoFliar.Width = 104;
            // 
            // Estadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 422);
            this.Controls.Add(this.dataGridEstadistico);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox1);
            //this.Controls.Add(this.shapeContainer1);
            this.Name = "Estadisticas";
            this.Text = "Listado Estadistico";
            this.Load += new System.EventHandler(this.Estadisticas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEstadistico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboSemestre;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboEspec;
        private System.Windows.Forms.ComboBox comboTop5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.DataGridView dataGridEstadistico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Especialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfApe;
        private System.Windows.Forms.DataGridViewTextBoxColumn AfdoNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn AfdoApe;
        private System.Windows.Forms.DataGridViewTextBoxColumn AfdoGpoFliar;
    }
}