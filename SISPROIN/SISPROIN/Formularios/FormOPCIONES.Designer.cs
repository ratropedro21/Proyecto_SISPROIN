namespace SISPROIN.Formularios
{
    partial class FormOPCIONES
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Lb_Titulo2 = new System.Windows.Forms.Label();
            this.Lb_Titulo1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(15, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 100);
            this.panel1.TabIndex = 5;
            // 
            // Lb_Titulo2
            // 
            this.Lb_Titulo2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Lb_Titulo2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Lb_Titulo2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Titulo2.Location = new System.Drawing.Point(0, 136);
            this.Lb_Titulo2.Name = "Lb_Titulo2";
            this.Lb_Titulo2.Size = new System.Drawing.Size(309, 31);
            this.Lb_Titulo2.TabIndex = 4;
            this.Lb_Titulo2.Text = "label1";
            this.Lb_Titulo2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Lb_Titulo1
            // 
            this.Lb_Titulo1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Lb_Titulo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Lb_Titulo1.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.Lb_Titulo1.Location = new System.Drawing.Point(0, 0);
            this.Lb_Titulo1.Name = "Lb_Titulo1";
            this.Lb_Titulo1.Size = new System.Drawing.Size(309, 32);
            this.Lb_Titulo1.TabIndex = 3;
            this.Lb_Titulo1.Text = "label1";
            this.Lb_Titulo1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormOPCIONES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(309, 167);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Lb_Titulo2);
            this.Controls.Add(this.Lb_Titulo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOPCIONES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opciones";
            this.Load += new System.EventHandler(this.FormOPCIONES_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label Lb_Titulo2;
        public System.Windows.Forms.Label Lb_Titulo1;
    }
}