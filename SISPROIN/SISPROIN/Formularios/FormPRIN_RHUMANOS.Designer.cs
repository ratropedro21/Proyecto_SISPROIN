namespace SISPROIN.Formularios
{
    partial class FormPRIN_RHUMANOS
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposDePersonalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inasistenciaDelDiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vacacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDePersonalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivosToolStripMenuItem,
            this.serviciosToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(764, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivosToolStripMenuItem
            // 
            this.archivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.departamentosToolStripMenuItem,
            this.gruposDePersonalToolStripMenuItem,
            this.personalToolStripMenuItem});
            this.archivosToolStripMenuItem.Name = "archivosToolStripMenuItem";
            this.archivosToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.archivosToolStripMenuItem.Text = "Archivos";
            // 
            // departamentosToolStripMenuItem
            // 
            this.departamentosToolStripMenuItem.Name = "departamentosToolStripMenuItem";
            this.departamentosToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.departamentosToolStripMenuItem.Text = "Departamentos";
            this.departamentosToolStripMenuItem.Click += new System.EventHandler(this.departamentosToolStripMenuItem_Click);
            // 
            // gruposDePersonalToolStripMenuItem
            // 
            this.gruposDePersonalToolStripMenuItem.Name = "gruposDePersonalToolStripMenuItem";
            this.gruposDePersonalToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.gruposDePersonalToolStripMenuItem.Text = "Grupos de Personal";
            this.gruposDePersonalToolStripMenuItem.Click += new System.EventHandler(this.gruposDePersonalToolStripMenuItem_Click);
            // 
            // personalToolStripMenuItem
            // 
            this.personalToolStripMenuItem.Name = "personalToolStripMenuItem";
            this.personalToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.personalToolStripMenuItem.Text = "Personal";
            this.personalToolStripMenuItem.Click += new System.EventHandler(this.personalToolStripMenuItem_Click);
            // 
            // serviciosToolStripMenuItem
            // 
            this.serviciosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inasistenciaDelDiaToolStripMenuItem,
            this.vacacionesToolStripMenuItem});
            this.serviciosToolStripMenuItem.Name = "serviciosToolStripMenuItem";
            this.serviciosToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.serviciosToolStripMenuItem.Text = "Servicios";
            // 
            // inasistenciaDelDiaToolStripMenuItem
            // 
            this.inasistenciaDelDiaToolStripMenuItem.Name = "inasistenciaDelDiaToolStripMenuItem";
            this.inasistenciaDelDiaToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.inasistenciaDelDiaToolStripMenuItem.Text = "Inasistencia del Dia ";
            this.inasistenciaDelDiaToolStripMenuItem.Click += new System.EventHandler(this.inasistenciaDelDiaToolStripMenuItem_Click);
            // 
            // vacacionesToolStripMenuItem
            // 
            this.vacacionesToolStripMenuItem.Name = "vacacionesToolStripMenuItem";
            this.vacacionesToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.vacacionesToolStripMenuItem.Text = "Vacaciones";
            this.vacacionesToolStripMenuItem.Click += new System.EventHandler(this.vacacionesToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoDePersonalToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // listadoDePersonalToolStripMenuItem
            // 
            this.listadoDePersonalToolStripMenuItem.Name = "listadoDePersonalToolStripMenuItem";
            this.listadoDePersonalToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.listadoDePersonalToolStripMenuItem.Text = "Listado de Personal";
            this.listadoDePersonalToolStripMenuItem.Click += new System.EventHandler(this.listadoDePersonalToolStripMenuItem_Click);
            // 
            // FormPRIN_RHUMANOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 550);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "FormPRIN_RHUMANOS";
            this.Text = "Sistema de Recursos Humanos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inasistenciaDelDiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gruposDePersonalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vacacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDePersonalToolStripMenuItem;
    }
}