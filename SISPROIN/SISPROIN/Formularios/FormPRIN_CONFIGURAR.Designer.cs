namespace SISPROIN.Formularios
{
    partial class FormPRIN_CONFIGURAR
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
            this.agregarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nivelesDeMenúToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.Size = new System.Drawing.Size(763, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivosToolStripMenuItem
            // 
            this.archivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarUsuariosToolStripMenuItem,
            this.nivelesDeMenúToolStripMenuItem});
            this.archivosToolStripMenuItem.Name = "archivosToolStripMenuItem";
            this.archivosToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.archivosToolStripMenuItem.Text = "Archivos";
            // 
            // agregarUsuariosToolStripMenuItem
            // 
            this.agregarUsuariosToolStripMenuItem.Name = "agregarUsuariosToolStripMenuItem";
            this.agregarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.agregarUsuariosToolStripMenuItem.Text = "Agregar Usuarios ";
            this.agregarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.agregarUsuariosToolStripMenuItem_Click);
            // 
            // nivelesDeMenúToolStripMenuItem
            // 
            this.nivelesDeMenúToolStripMenuItem.Name = "nivelesDeMenúToolStripMenuItem";
            this.nivelesDeMenúToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.nivelesDeMenúToolStripMenuItem.Text = "Niveles de Menú";
            this.nivelesDeMenúToolStripMenuItem.Click += new System.EventHandler(this.nivelesDeMenúToolStripMenuItem_Click);
            // 
            // serviciosToolStripMenuItem
            // 
            this.serviciosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.permisosDeUsuariosToolStripMenuItem});
            this.serviciosToolStripMenuItem.Name = "serviciosToolStripMenuItem";
            this.serviciosToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.serviciosToolStripMenuItem.Text = "Servicios";
            // 
            // permisosDeUsuariosToolStripMenuItem
            // 
            this.permisosDeUsuariosToolStripMenuItem.Name = "permisosDeUsuariosToolStripMenuItem";
            this.permisosDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.permisosDeUsuariosToolStripMenuItem.Text = "Permisos de Usuarios";
            this.permisosDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.permisosDeUsuariosToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // FormPRIN_CONFIGURAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 467);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "FormPRIN_CONFIGURAR";
            this.Text = "Configuracion del Sistema";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nivelesDeMenúToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisosDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
    }
}