namespace ClinicaFrba.AtencionesMedicas
{
    partial class RegistrarResultado
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
            this.button_Buscar = new System.Windows.Forms.Button();
            this.textBox_Apellido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_apellido = new System.Windows.Forms.Label();
            this.textBox_Documento = new System.Windows.Forms.TextBox();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.label_Id_Usuario = new System.Windows.Forms.Label();
            this.label_Usuario = new System.Windows.Forms.Label();
            this.groupBox_filtros = new System.Windows.Forms.GroupBox();
            this.dataGridView_resultados_filtros = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados_filtros)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Buscar
            // 
            this.button_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Buscar.Location = new System.Drawing.Point(626, 18);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(96, 55);
            this.button_Buscar.TabIndex = 19;
            this.button_Buscar.Text = "Buscar Afiliado";
            this.button_Buscar.UseVisualStyleBackColor = true;
            this.button_Buscar.Click += new System.EventHandler(this.button_Buscar_Click);
            // 
            // textBox_Apellido
            // 
            this.textBox_Apellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_Apellido.Location = new System.Drawing.Point(299, 23);
            this.textBox_Apellido.Name = "textBox_Apellido";
            this.textBox_Apellido.Size = new System.Drawing.Size(100, 20);
            this.textBox_Apellido.TabIndex = 8;
            this.textBox_Apellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Nombre_KeyPress);
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
            // label_apellido
            // 
            this.label_apellido.AutoSize = true;
            this.label_apellido.Location = new System.Drawing.Point(212, 26);
            this.label_apellido.Name = "label_apellido";
            this.label_apellido.Size = new System.Drawing.Size(81, 13);
            this.label_apellido.TabIndex = 7;
            this.label_apellido.Text = "Apellido Afiliado";
            // 
            // textBox_Documento
            // 
            this.textBox_Documento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_Documento.Location = new System.Drawing.Point(496, 23);
            this.textBox_Documento.Name = "textBox_Documento";
            this.textBox_Documento.Size = new System.Drawing.Size(100, 20);
            this.textBox_Documento.TabIndex = 9;
            this.textBox_Documento.TextChanged += new System.EventHandler(this.textBox_Documento_TextChanged);
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_Nombre.Location = new System.Drawing.Point(96, 23);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(100, 20);
            this.textBox_Nombre.TabIndex = 6;
            this.textBox_Nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Nombre_KeyPress);
            // 
            // label_Id_Usuario
            // 
            this.label_Id_Usuario.AutoSize = true;
            this.label_Id_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Id_Usuario.Location = new System.Drawing.Point(25, 22);
            this.label_Id_Usuario.Name = "label_Id_Usuario";
            this.label_Id_Usuario.Size = new System.Drawing.Size(0, 18);
            this.label_Id_Usuario.TabIndex = 13;
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
            // groupBox_filtros
            // 
            this.groupBox_filtros.Controls.Add(this.label_Usuario);
            this.groupBox_filtros.Controls.Add(this.label_Id_Usuario);
            this.groupBox_filtros.Controls.Add(this.textBox_Nombre);
            this.groupBox_filtros.Controls.Add(this.textBox_Documento);
            this.groupBox_filtros.Controls.Add(this.label_apellido);
            this.groupBox_filtros.Controls.Add(this.label1);
            this.groupBox_filtros.Controls.Add(this.textBox_Apellido);
            this.groupBox_filtros.Location = new System.Drawing.Point(13, 13);
            this.groupBox_filtros.Name = "groupBox_filtros";
            this.groupBox_filtros.Size = new System.Drawing.Size(607, 60);
            this.groupBox_filtros.TabIndex = 20;
            this.groupBox_filtros.TabStop = false;
            this.groupBox_filtros.Text = "Filtros de Busqueda";
            // 
            // dataGridView_resultados_filtros
            // 
            this.dataGridView_resultados_filtros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_resultados_filtros.Location = new System.Drawing.Point(14, 79);
            this.dataGridView_resultados_filtros.Name = "dataGridView_resultados_filtros";
            this.dataGridView_resultados_filtros.Size = new System.Drawing.Size(740, 181);
            this.dataGridView_resultados_filtros.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(550, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Consejo: Copiar y Pegar cosas desde Registrar Llegada";
            // 
            // RegistrarResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 494);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView_resultados_filtros);
            this.Controls.Add(this.groupBox_filtros);
            this.Controls.Add(this.button_Buscar);
            this.Name = "RegistrarResultado";
            this.Text = "RegistrarResultado";
            this.Load += new System.EventHandler(this.RegistrarResultado_Load);
            this.groupBox_filtros.ResumeLayout(false);
            this.groupBox_filtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultados_filtros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.TextBox textBox_Apellido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_apellido;
        private System.Windows.Forms.TextBox textBox_Documento;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.Label label_Id_Usuario;
        private System.Windows.Forms.Label label_Usuario;
        private System.Windows.Forms.GroupBox groupBox_filtros;
        private System.Windows.Forms.DataGridView dataGridView_resultados_filtros;
        private System.Windows.Forms.Label label2;
    }
}