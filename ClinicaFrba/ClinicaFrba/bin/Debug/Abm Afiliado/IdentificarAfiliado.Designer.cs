﻿namespace ClinicaFrba.Abm_Afiliado
{
    partial class IdentificarAfiliado
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
            this.btnAccion = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dataGridView_resultados_filtros = new System.Windows.Forms.DataGridView();
            this.GB_filtros = new System.Windows.Forms.GroupBox();
            this.label_Usuario = new System.Windows.Forms.Label();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.textBox_Documento = new System.Windows.Forms.TextBox();
            this.label_apellido = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Apellido = new System.Windows.Forms.TextBox();
            this.chkTitular = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados_filtros)).BeginInit();
            this.GB_filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccion
            // 
            this.btnAccion.Location = new System.Drawing.Point(39, 364);
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Size = new System.Drawing.Size(120, 37);
            this.btnAccion.TabIndex = 14;
            this.btnAccion.Text = "Filtrar";
            this.btnAccion.UseVisualStyleBackColor = true;
            this.btnAccion.Click += new System.EventHandler(this.btnAccion_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(526, 364);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 37);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(292, 364);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 37);
            this.btnLimpiar.TabIndex = 18;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dataGridView_resultados_filtros
            // 
            this.dataGridView_resultados_filtros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_resultados_filtros.Location = new System.Drawing.Point(39, 104);
            this.dataGridView_resultados_filtros.Name = "dataGridView_resultados_filtros";
            this.dataGridView_resultados_filtros.Size = new System.Drawing.Size(607, 248);
            this.dataGridView_resultados_filtros.TabIndex = 20;
            this.dataGridView_resultados_filtros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_resultados_filtros_CellContentClick);
            // 
            // GB_filtros
            // 
            this.GB_filtros.Controls.Add(this.label_Usuario);
            this.GB_filtros.Controls.Add(this.textBox_Nombre);
            this.GB_filtros.Controls.Add(this.textBox_Documento);
            this.GB_filtros.Controls.Add(this.label_apellido);
            this.GB_filtros.Controls.Add(this.label1);
            this.GB_filtros.Controls.Add(this.textBox_Apellido);
            this.GB_filtros.Location = new System.Drawing.Point(39, 24);
            this.GB_filtros.Name = "GB_filtros";
            this.GB_filtros.Size = new System.Drawing.Size(607, 60);
            this.GB_filtros.TabIndex = 19;
            this.GB_filtros.TabStop = false;
            this.GB_filtros.Text = "Filtros de Busqueda";
            // 
            // label_Usuario
            // 
            this.label_Usuario.AutoSize = true;
            this.label_Usuario.Location = new System.Drawing.Point(9, 27);
            this.label_Usuario.Name = "label_Usuario";
            this.label_Usuario.Size = new System.Drawing.Size(81, 13);
            this.label_Usuario.TabIndex = 5;
            this.label_Usuario.Text = "Nombre Afiliado";
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Location = new System.Drawing.Point(96, 23);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(100, 20);
            this.textBox_Nombre.TabIndex = 6;
            this.textBox_Nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Nombre_KeyPress);
            // 
            // textBox_Documento
            // 
            this.textBox_Documento.Location = new System.Drawing.Point(496, 23);
            this.textBox_Documento.Name = "textBox_Documento";
            this.textBox_Documento.Size = new System.Drawing.Size(100, 20);
            this.textBox_Documento.TabIndex = 9;
            // 
            // label_apellido
            // 
            this.label_apellido.AutoSize = true;
            this.label_apellido.Location = new System.Drawing.Point(212, 26);
            this.label_apellido.Name = "label_apellido";
            this.label_apellido.Size = new System.Drawing.Size(81, 13);
            this.label_apellido.TabIndex = 7;
            this.label_apellido.Text = "Apellido Afiliado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(428, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Documento";
            // 
            // textBox_Apellido
            // 
            this.textBox_Apellido.Location = new System.Drawing.Point(299, 23);
            this.textBox_Apellido.Name = "textBox_Apellido";
            this.textBox_Apellido.Size = new System.Drawing.Size(100, 20);
            this.textBox_Apellido.TabIndex = 8;
            this.textBox_Apellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Apellido_KeyPress);
            // 
            // chkTitular
            // 
            this.chkTitular.AutoSize = true;
            this.chkTitular.Location = new System.Drawing.Point(301, 12);
            this.chkTitular.Name = "chkTitular";
            this.chkTitular.Size = new System.Drawing.Size(70, 17);
            this.chkTitular.TabIndex = 21;
            this.chkTitular.Text = "Es Titular";
            this.chkTitular.UseVisualStyleBackColor = true;
            this.chkTitular.CheckedChanged += new System.EventHandler(this.chkTitular_CheckedChanged);
            // 
            // IdentificarAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 427);
            this.Controls.Add(this.chkTitular);
            this.Controls.Add(this.dataGridView_resultados_filtros);
            this.Controls.Add(this.GB_filtros);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAccion);
            this.Name = "IdentificarAfiliado";
            this.Text = "ABMAFILIADOS";
            this.Load += new System.EventHandler(this.ABMAFILIADO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados_filtros)).EndInit();
            this.GB_filtros.ResumeLayout(false);
            this.GB_filtros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAccion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dataGridView_resultados_filtros;
        private System.Windows.Forms.GroupBox GB_filtros;
        private System.Windows.Forms.Label label_Usuario;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.TextBox textBox_Documento;
        private System.Windows.Forms.Label label_apellido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Apellido;
        private System.Windows.Forms.CheckBox chkTitular;
    }
}