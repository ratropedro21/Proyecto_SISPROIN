namespace SISPROIN.Formularios
{
    partial class FormINICIO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormINICIO));
            this.Cmd_Cestas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Cmd_RHumanos = new System.Windows.Forms.Button();
            this.Cmd_VentasOsq = new System.Windows.Forms.Button();
            this.Cmd_Salir = new System.Windows.Forms.Button();
            this.Cmd_Configuracion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Cmd_Cestas
            // 
            this.Cmd_Cestas.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmd_Cestas.Location = new System.Drawing.Point(368, 12);
            this.Cmd_Cestas.Name = "Cmd_Cestas";
            this.Cmd_Cestas.Size = new System.Drawing.Size(172, 78);
            this.Cmd_Cestas.TabIndex = 3;
            this.Cmd_Cestas.Text = "Cestas (Proximamentes)";
            this.Cmd_Cestas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Cmd_Cestas.UseVisualStyleBackColor = true;
            this.Cmd_Cestas.Click += new System.EventHandler(this.Cmd_Cestas_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(599, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "Versión-2.2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SISPROIN.Properties.Resources.Windows_logo;
            this.pictureBox1.Location = new System.Drawing.Point(574, 154);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Cmd_RHumanos
            // 
            this.Cmd_RHumanos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmd_RHumanos.Image = global::SISPROIN.Properties.Resources.RHumanos;
            this.Cmd_RHumanos.Location = new System.Drawing.Point(546, 12);
            this.Cmd_RHumanos.Name = "Cmd_RHumanos";
            this.Cmd_RHumanos.Size = new System.Drawing.Size(172, 78);
            this.Cmd_RHumanos.TabIndex = 4;
            this.Cmd_RHumanos.Text = "Recursos Humanos";
            this.Cmd_RHumanos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Cmd_RHumanos.UseVisualStyleBackColor = true;
            this.Cmd_RHumanos.Click += new System.EventHandler(this.Cmd_RHumanos_Click);
            // 
            // Cmd_VentasOsq
            // 
            this.Cmd_VentasOsq.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmd_VentasOsq.Image = global::SISPROIN.Properties.Resources.VenObs;
            this.Cmd_VentasOsq.Location = new System.Drawing.Point(190, 12);
            this.Cmd_VentasOsq.Name = "Cmd_VentasOsq";
            this.Cmd_VentasOsq.Size = new System.Drawing.Size(172, 78);
            this.Cmd_VentasOsq.TabIndex = 2;
            this.Cmd_VentasOsq.Text = "Ventas y Obsequios";
            this.Cmd_VentasOsq.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Cmd_VentasOsq.UseVisualStyleBackColor = true;
            this.Cmd_VentasOsq.Click += new System.EventHandler(this.Cmd_VentasOsq_Click);
            // 
            // Cmd_Salir
            // 
            this.Cmd_Salir.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmd_Salir.Image = ((System.Drawing.Image)(resources.GetObject("Cmd_Salir.Image")));
            this.Cmd_Salir.Location = new System.Drawing.Point(12, 96);
            this.Cmd_Salir.Name = "Cmd_Salir";
            this.Cmd_Salir.Size = new System.Drawing.Size(172, 78);
            this.Cmd_Salir.TabIndex = 5;
            this.Cmd_Salir.Text = "Salir";
            this.Cmd_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Cmd_Salir.UseVisualStyleBackColor = true;
            this.Cmd_Salir.Click += new System.EventHandler(this.Cmd_Salir_Click);
            // 
            // Cmd_Configuracion
            // 
            this.Cmd_Configuracion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmd_Configuracion.Image = global::SISPROIN.Properties.Resources.Settings;
            this.Cmd_Configuracion.Location = new System.Drawing.Point(12, 12);
            this.Cmd_Configuracion.Name = "Cmd_Configuracion";
            this.Cmd_Configuracion.Size = new System.Drawing.Size(172, 78);
            this.Cmd_Configuracion.TabIndex = 1;
            this.Cmd_Configuracion.Text = "Configuracion";
            this.Cmd_Configuracion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Cmd_Configuracion.UseVisualStyleBackColor = true;
            this.Cmd_Configuracion.Click += new System.EventHandler(this.Cmd_Configuracion_Click);
            // 
            // FormINICIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(732, 189);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cmd_RHumanos);
            this.Controls.Add(this.Cmd_Cestas);
            this.Controls.Add(this.Cmd_VentasOsq);
            this.Controls.Add(this.Cmd_Salir);
            this.Controls.Add(this.Cmd_Configuracion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormINICIO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Control Integral";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormINICIO_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cmd_Salir;
        private System.Windows.Forms.Button Cmd_Configuracion;
        private System.Windows.Forms.Button Cmd_VentasOsq;
        private System.Windows.Forms.Button Cmd_Cestas;
        private System.Windows.Forms.Button Cmd_RHumanos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}