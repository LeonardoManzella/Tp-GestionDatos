namespace ClinicaFrba
{
    partial class Home
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afiliadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMAfiliadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoAfiliadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarAfiliadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaAfiliadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedirTurnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarTurnosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.comprarBonoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profesionalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarTurnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atencionMedicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarLlegadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarResultadoDiagnosticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprarBonoUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boton_loguear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_rol = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sesiónToolStripMenuItem,
            this.afiliadoToolStripMenuItem,
            this.profesionalesToolStripMenuItem,
            this.adminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(563, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sesiónToolStripMenuItem
            // 
            this.sesiónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logInToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.sesiónToolStripMenuItem.Name = "sesiónToolStripMenuItem";
            this.sesiónToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.sesiónToolStripMenuItem.Text = "&Sesión";
            // 
            // logInToolStripMenuItem
            // 
            this.logInToolStripMenuItem.Name = "logInToolStripMenuItem";
            this.logInToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.logInToolStripMenuItem.Text = "&Log In";
            this.logInToolStripMenuItem.Click += new System.EventHandler(this.logInToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // afiliadoToolStripMenuItem
            // 
            this.afiliadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMAfiliadoToolStripMenuItem,
            this.pedirTurnoToolStripMenuItem,
            this.cancelarTurnosToolStripMenuItem1,
            this.comprarBonoToolStripMenuItem});
            this.afiliadoToolStripMenuItem.Name = "afiliadoToolStripMenuItem";
            this.afiliadoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.afiliadoToolStripMenuItem.Text = "&Afiliado";
            // 
            // aBMAfiliadoToolStripMenuItem
            // 
            this.aBMAfiliadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoAfiliadoToolStripMenuItem,
            this.modificarAfiliadoToolStripMenuItem,
            this.bajaAfiliadoToolStripMenuItem});
            this.aBMAfiliadoToolStripMenuItem.Name = "aBMAfiliadoToolStripMenuItem";
            this.aBMAfiliadoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.aBMAfiliadoToolStripMenuItem.Text = "ABM Afiliado";
            // 
            // nuevoAfiliadoToolStripMenuItem
            // 
            this.nuevoAfiliadoToolStripMenuItem.Name = "nuevoAfiliadoToolStripMenuItem";
            this.nuevoAfiliadoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.nuevoAfiliadoToolStripMenuItem.Text = "&Alta Afiliado";
            this.nuevoAfiliadoToolStripMenuItem.Click += new System.EventHandler(this.nuevoAfiliadoToolStripMenuItem_Click);
            // 
            // modificarAfiliadoToolStripMenuItem
            // 
            this.modificarAfiliadoToolStripMenuItem.Name = "modificarAfiliadoToolStripMenuItem";
            this.modificarAfiliadoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.modificarAfiliadoToolStripMenuItem.Text = "&Modificar Afiliado";
            this.modificarAfiliadoToolStripMenuItem.Click += new System.EventHandler(this.modificarAfiliadoToolStripMenuItem_Click);
            // 
            // bajaAfiliadoToolStripMenuItem
            // 
            this.bajaAfiliadoToolStripMenuItem.Name = "bajaAfiliadoToolStripMenuItem";
            this.bajaAfiliadoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.bajaAfiliadoToolStripMenuItem.Text = "&Baja Afiliado";
            this.bajaAfiliadoToolStripMenuItem.Click += new System.EventHandler(this.bajaAfiliadoToolStripMenuItem_Click);
            // 
            // pedirTurnoToolStripMenuItem
            // 
            this.pedirTurnoToolStripMenuItem.Name = "pedirTurnoToolStripMenuItem";
            this.pedirTurnoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.pedirTurnoToolStripMenuItem.Text = "Pedir Turno";
            this.pedirTurnoToolStripMenuItem.Click += new System.EventHandler(this.pedirTurnoToolStripMenuItem_Click);
            // 
            // cancelarTurnosToolStripMenuItem1
            // 
            this.cancelarTurnosToolStripMenuItem1.Name = "cancelarTurnosToolStripMenuItem1";
            this.cancelarTurnosToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.cancelarTurnosToolStripMenuItem1.Text = "Cancelar Turnos";
            this.cancelarTurnosToolStripMenuItem1.Click += new System.EventHandler(this.cancelarTurnosToolStripMenuItem1_Click);
            // 
            // comprarBonoToolStripMenuItem
            // 
            this.comprarBonoToolStripMenuItem.Name = "comprarBonoToolStripMenuItem";
            this.comprarBonoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.comprarBonoToolStripMenuItem.Text = "Comprar Bono";
            this.comprarBonoToolStripMenuItem.Click += new System.EventHandler(this.comprarBonoToolStripMenuItem_Click);
            // 
            // profesionalesToolStripMenuItem
            // 
            this.profesionalesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agendaToolStripMenuItem,
            this.cancelarTurnosToolStripMenuItem,
            this.atencionMedicaToolStripMenuItem});
            this.profesionalesToolStripMenuItem.Name = "profesionalesToolStripMenuItem";
            this.profesionalesToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.profesionalesToolStripMenuItem.Text = "&Profesionales";
            // 
            // agendaToolStripMenuItem
            // 
            this.agendaToolStripMenuItem.Name = "agendaToolStripMenuItem";
            this.agendaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.agendaToolStripMenuItem.Text = "Crear &Agenda";
            this.agendaToolStripMenuItem.Click += new System.EventHandler(this.agendaToolStripMenuItem_Click);
            // 
            // cancelarTurnosToolStripMenuItem
            // 
            this.cancelarTurnosToolStripMenuItem.Name = "cancelarTurnosToolStripMenuItem";
            this.cancelarTurnosToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.cancelarTurnosToolStripMenuItem.Text = "&Cancelar Turnos";
            this.cancelarTurnosToolStripMenuItem.Click += new System.EventHandler(this.cancelarTurnosToolStripMenuItem_Click);
            // 
            // atencionMedicaToolStripMenuItem
            // 
            this.atencionMedicaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarLlegadaToolStripMenuItem,
            this.registrarResultadoDiagnosticoToolStripMenuItem});
            this.atencionMedicaToolStripMenuItem.Name = "atencionMedicaToolStripMenuItem";
            this.atencionMedicaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.atencionMedicaToolStripMenuItem.Text = "Atencion Medica";
            // 
            // registrarLlegadaToolStripMenuItem
            // 
            this.registrarLlegadaToolStripMenuItem.Name = "registrarLlegadaToolStripMenuItem";
            this.registrarLlegadaToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.registrarLlegadaToolStripMenuItem.Text = "Registrar Llegada";
            this.registrarLlegadaToolStripMenuItem.Click += new System.EventHandler(this.registrarLlegadaToolStripMenuItem_Click);
            // 
            // registrarResultadoDiagnosticoToolStripMenuItem
            // 
            this.registrarResultadoDiagnosticoToolStripMenuItem.Name = "registrarResultadoDiagnosticoToolStripMenuItem";
            this.registrarResultadoDiagnosticoToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.registrarResultadoDiagnosticoToolStripMenuItem.Text = "Registrar Resultado Diagnostico";
            this.registrarResultadoDiagnosticoToolStripMenuItem.Click += new System.EventHandler(this.registrarResultadoDiagnosticoToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rolesToolStripMenuItem,
            this.comprarBonoUsuarioToolStripMenuItem,
            this.estadisticasToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "A&dmin";
            // 
            // rolesToolStripMenuItem
            // 
            this.rolesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevRolToolStripMenuItem,
            this.bajaRolToolStripMenuItem});
            this.rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            this.rolesToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.rolesToolStripMenuItem.Text = "Roles";
            // 
            // nuevRolToolStripMenuItem
            // 
            this.nuevRolToolStripMenuItem.Name = "nuevRolToolStripMenuItem";
            this.nuevRolToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.nuevRolToolStripMenuItem.Text = "&Nuevo Rol";
            this.nuevRolToolStripMenuItem.Click += new System.EventHandler(this.nuevRolToolStripMenuItem_Click);
            // 
            // bajaRolToolStripMenuItem
            // 
            this.bajaRolToolStripMenuItem.Name = "bajaRolToolStripMenuItem";
            this.bajaRolToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.bajaRolToolStripMenuItem.Text = "&Modificar y Eliminar Roles";
            this.bajaRolToolStripMenuItem.Click += new System.EventHandler(this.bajaRolToolStripMenuItem_Click);
            // 
            // comprarBonoUsuarioToolStripMenuItem
            // 
            this.comprarBonoUsuarioToolStripMenuItem.Name = "comprarBonoUsuarioToolStripMenuItem";
            this.comprarBonoUsuarioToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.comprarBonoUsuarioToolStripMenuItem.Text = "Comprar Bono Usuario";
            this.comprarBonoUsuarioToolStripMenuItem.Click += new System.EventHandler(this.comprarBonoUsuarioToolStripMenuItem_Click);
            // 
            // estadisticasToolStripMenuItem
            // 
            this.estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            this.estadisticasToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.estadisticasToolStripMenuItem.Text = "Estadisticas";
            this.estadisticasToolStripMenuItem.Click += new System.EventHandler(this.estadisticasToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.Location = new System.Drawing.Point(149, 108);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(213, 20);
            this.textBox_usuario.TabIndex = 3;
            this.textBox_usuario.Text = "ADMIN";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(149, 154);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(213, 20);
            this.textBox_password.TabIndex = 4;
            this.textBox_password.Text = "W23E";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(92, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bienvenido a Clinica FRBA";
            // 
            // boton_loguear
            // 
            this.boton_loguear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton_loguear.Location = new System.Drawing.Point(382, 100);
            this.boton_loguear.Name = "boton_loguear";
            this.boton_loguear.Size = new System.Drawing.Size(109, 74);
            this.boton_loguear.TabIndex = 7;
            this.boton_loguear.Text = "Loguear";
            this.boton_loguear.UseVisualStyleBackColor = true;
            this.boton_loguear.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Rol a Usar";
            // 
            // comboBox_rol
            // 
            this.comboBox_rol.FormattingEnabled = true;
            this.comboBox_rol.Location = new System.Drawing.Point(210, 218);
            this.comboBox_rol.Name = "comboBox_rol";
            this.comboBox_rol.Size = new System.Drawing.Size(212, 21);
            this.comboBox_rol.TabIndex = 9;
            this.comboBox_rol.Text = "ADMINISTRATIVO";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 294);
            this.Controls.Add(this.comboBox_rol);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.boton_loguear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_usuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "Clinica FRBA -KFC";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afiliadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profesionalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMAfiliadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoAfiliadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarAfiliadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaAfiliadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaRolToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.ToolStripMenuItem cancelarTurnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarTurnosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pedirTurnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprarBonoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprarBonoUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadisticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atencionMedicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarLlegadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarResultadoDiagnosticoToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button boton_loguear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_rol;
    }
}