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
            this.profesionalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaProfesionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarProfesionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaProfesionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMTurnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedirTurnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarTurnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprarBonosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionalidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sesiónToolStripMenuItem,
            this.afiliadoToolStripMenuItem,
            this.profesionalesToolStripMenuItem,
            this.turnosToolStripMenuItem,
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
            this.logInToolStripMenuItem.Text = "Log &In";
            this.logInToolStripMenuItem.Click += new System.EventHandler(this.logInToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.salirToolStripMenuItem.Text = "Sali&r";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // afiliadoToolStripMenuItem
            // 
            this.afiliadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMAfiliadoToolStripMenuItem});
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
            this.aBMAfiliadoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
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
            // 
            // bajaAfiliadoToolStripMenuItem
            // 
            this.bajaAfiliadoToolStripMenuItem.Name = "bajaAfiliadoToolStripMenuItem";
            this.bajaAfiliadoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.bajaAfiliadoToolStripMenuItem.Text = "&Baja Afiliado";
            // 
            // profesionalesToolStripMenuItem
            // 
            this.profesionalesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMToolStripMenuItem,
            this.agendaToolStripMenuItem});
            this.profesionalesToolStripMenuItem.Name = "profesionalesToolStripMenuItem";
            this.profesionalesToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.profesionalesToolStripMenuItem.Text = "&Profesionales";
            // 
            // aBMToolStripMenuItem
            // 
            this.aBMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaProfesionalToolStripMenuItem,
            this.modificarProfesionalToolStripMenuItem,
            this.bajaProfesionalToolStripMenuItem});
            this.aBMToolStripMenuItem.Name = "aBMToolStripMenuItem";
            this.aBMToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aBMToolStripMenuItem.Text = "A&BM ";
            // 
            // altaProfesionalToolStripMenuItem
            // 
            this.altaProfesionalToolStripMenuItem.Name = "altaProfesionalToolStripMenuItem";
            this.altaProfesionalToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.altaProfesionalToolStripMenuItem.Text = "&Alta Profesional";
            // 
            // modificarProfesionalToolStripMenuItem
            // 
            this.modificarProfesionalToolStripMenuItem.Name = "modificarProfesionalToolStripMenuItem";
            this.modificarProfesionalToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.modificarProfesionalToolStripMenuItem.Text = "&Modificar Profesional";
            // 
            // bajaProfesionalToolStripMenuItem
            // 
            this.bajaProfesionalToolStripMenuItem.Name = "bajaProfesionalToolStripMenuItem";
            this.bajaProfesionalToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.bajaProfesionalToolStripMenuItem.Text = "&Baja Profesional";
            // 
            // agendaToolStripMenuItem
            // 
            this.agendaToolStripMenuItem.Name = "agendaToolStripMenuItem";
            this.agendaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agendaToolStripMenuItem.Text = "Administrar A&genda";
            // 
            // turnosToolStripMenuItem
            // 
            this.turnosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMTurnosToolStripMenuItem,
            this.comprarBonosToolStripMenuItem});
            this.turnosToolStripMenuItem.Name = "turnosToolStripMenuItem";
            this.turnosToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.turnosToolStripMenuItem.Text = "&Turnos";
            // 
            // aBMTurnosToolStripMenuItem
            // 
            this.aBMTurnosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pedirTurnoToolStripMenuItem,
            this.cancelarTurnoToolStripMenuItem});
            this.aBMTurnosToolStripMenuItem.Name = "aBMTurnosToolStripMenuItem";
            this.aBMTurnosToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.aBMTurnosToolStripMenuItem.Text = "&ABM Turnos";
            // 
            // pedirTurnoToolStripMenuItem
            // 
            this.pedirTurnoToolStripMenuItem.Name = "pedirTurnoToolStripMenuItem";
            this.pedirTurnoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pedirTurnoToolStripMenuItem.Text = "Pedir Turno";
            // 
            // cancelarTurnoToolStripMenuItem
            // 
            this.cancelarTurnoToolStripMenuItem.Name = "cancelarTurnoToolStripMenuItem";
            this.cancelarTurnoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.cancelarTurnoToolStripMenuItem.Text = "Cancelar Turno";
            // 
            // comprarBonosToolStripMenuItem
            // 
            this.comprarBonosToolStripMenuItem.Name = "comprarBonosToolStripMenuItem";
            this.comprarBonosToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.comprarBonosToolStripMenuItem.Text = "Comprar &Bonos";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rolesToolStripMenuItem,
            this.funcionalidadesToolStripMenuItem});
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
            this.rolesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.rolesToolStripMenuItem.Text = "Roles";
            // 
            // nuevRolToolStripMenuItem
            // 
            this.nuevRolToolStripMenuItem.Name = "nuevRolToolStripMenuItem";
            this.nuevRolToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.nuevRolToolStripMenuItem.Text = "&Alta Rol";
            // 
            // bajaRolToolStripMenuItem
            // 
            this.bajaRolToolStripMenuItem.Name = "bajaRolToolStripMenuItem";
            this.bajaRolToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.bajaRolToolStripMenuItem.Text = "&Baja Rol";
            // 
            // funcionalidadesToolStripMenuItem
            // 
            this.funcionalidadesToolStripMenuItem.Name = "funcionalidadesToolStripMenuItem";
            this.funcionalidadesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.funcionalidadesToolStripMenuItem.Text = "Funcionalidades";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 237);
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
        private System.Windows.Forms.ToolStripMenuItem turnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaAfiliadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMTurnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedirTurnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarTurnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprarBonosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionalidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaProfesionalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarProfesionalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaProfesionalToolStripMenuItem;
    }
}

