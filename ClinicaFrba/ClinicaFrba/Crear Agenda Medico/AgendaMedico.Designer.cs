namespace ClinicaFrba.AgendaMedico
{
    partial class AgendaMedico
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
            this.horariosPorDiaList = new System.Windows.Forms.ListBox();
            this.agregarHorarioButton = new System.Windows.Forms.Button();
            this.borrarHorarioButton = new System.Windows.Forms.Button();
            this.diasSemanaCombo = new System.Windows.Forms.ComboBox();
            this.horarioDesdeCombo = new System.Windows.Forms.ComboBox();
            this.horarioHastaCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // horariosPorDiaList
            // 
            this.horariosPorDiaList.FormattingEnabled = true;
            this.horariosPorDiaList.Location = new System.Drawing.Point(24, 123);
            this.horariosPorDiaList.Name = "horariosPorDiaList";
            this.horariosPorDiaList.Size = new System.Drawing.Size(246, 121);
            this.horariosPorDiaList.TabIndex = 0;
            // 
            // agregarHorarioButton
            // 
            this.agregarHorarioButton.Location = new System.Drawing.Point(285, 94);
            this.agregarHorarioButton.Name = "agregarHorarioButton";
            this.agregarHorarioButton.Size = new System.Drawing.Size(75, 23);
            this.agregarHorarioButton.TabIndex = 3;
            this.agregarHorarioButton.Text = "Agregar";
            this.agregarHorarioButton.UseVisualStyleBackColor = true;
            this.agregarHorarioButton.Click += new System.EventHandler(this.agregarHorarioButton_Click);
            // 
            // borrarHorarioButton
            // 
            this.borrarHorarioButton.Location = new System.Drawing.Point(285, 166);
            this.borrarHorarioButton.Name = "borrarHorarioButton";
            this.borrarHorarioButton.Size = new System.Drawing.Size(75, 23);
            this.borrarHorarioButton.TabIndex = 4;
            this.borrarHorarioButton.Text = "Borrar";
            this.borrarHorarioButton.UseVisualStyleBackColor = true;
            this.borrarHorarioButton.Click += new System.EventHandler(this.borrarHorarioButton_Click);
            // 
            // diasSemanaCombo
            // 
            this.diasSemanaCombo.FormattingEnabled = true;
            this.diasSemanaCombo.Location = new System.Drawing.Point(24, 45);
            this.diasSemanaCombo.Name = "diasSemanaCombo";
            this.diasSemanaCombo.Size = new System.Drawing.Size(246, 21);
            this.diasSemanaCombo.TabIndex = 5;
            this.diasSemanaCombo.SelectedIndexChanged += new System.EventHandler(this.diasSemanaCombo_SelectedIndexChanged);
            // 
            // horarioDesdeCombo
            // 
            this.horarioDesdeCombo.FormattingEnabled = true;
            this.horarioDesdeCombo.Location = new System.Drawing.Point(24, 96);
            this.horarioDesdeCombo.Name = "horarioDesdeCombo";
            this.horarioDesdeCombo.Size = new System.Drawing.Size(121, 21);
            this.horarioDesdeCombo.TabIndex = 7;
            // 
            // horarioHastaCombo
            // 
            this.horarioHastaCombo.FormattingEnabled = true;
            this.horarioHastaCombo.Location = new System.Drawing.Point(149, 96);
            this.horarioHastaCombo.Name = "horarioHastaCombo";
            this.horarioHastaCombo.Size = new System.Drawing.Size(121, 21);
            this.horarioHastaCombo.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Seleccione el dia de la semana:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(20, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Seleccione el rango horario:";
            // 
            // AgendaMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 455);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.horarioHastaCombo);
            this.Controls.Add(this.horarioDesdeCombo);
            this.Controls.Add(this.diasSemanaCombo);
            this.Controls.Add(this.borrarHorarioButton);
            this.Controls.Add(this.agregarHorarioButton);
            this.Controls.Add(this.horariosPorDiaList);
            this.Name = "AgendaMedico";
            this.Text = "Registrar Agenda";
            this.Load += new System.EventHandler(this.AgendaMedico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox horariosPorDiaList;
        private System.Windows.Forms.Button agregarHorarioButton;
        private System.Windows.Forms.Button borrarHorarioButton;
        private System.Windows.Forms.ComboBox diasSemanaCombo;
        private System.Windows.Forms.ComboBox horarioDesdeCombo;
        private System.Windows.Forms.ComboBox horarioHastaCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}