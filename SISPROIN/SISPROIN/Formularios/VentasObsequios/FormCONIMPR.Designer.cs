namespace SISPROIN.Formularios.VentasObsequios
{
    partial class FormCONIMPR
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
            this.Lb_Pc_Pri = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Lb_Ip_Pri = new System.Windows.Forms.Label();
            this.Com_NomPri = new System.Windows.Forms.ComboBox();
            this.Cmd_Salir = new System.Windows.Forms.Button();
            this.Cmd_Aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lb_Pc_Pri
            // 
            this.Lb_Pc_Pri.BackColor = System.Drawing.Color.White;
            this.Lb_Pc_Pri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_Pc_Pri.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Pc_Pri.Location = new System.Drawing.Point(114, 20);
            this.Lb_Pc_Pri.Name = "Lb_Pc_Pri";
            this.Lb_Pc_Pri.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_Pc_Pri.Size = new System.Drawing.Size(256, 27);
            this.Lb_Pc_Pri.TabIndex = 225;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 224;
            this.label3.Text = "Nombre PC :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 218;
            this.label2.Text = "Impresoras :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 20);
            this.label1.TabIndex = 217;
            this.label1.Text = "IP :";
            // 
            // Lb_Ip_Pri
            // 
            this.Lb_Ip_Pri.BackColor = System.Drawing.Color.White;
            this.Lb_Ip_Pri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_Ip_Pri.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Ip_Pri.Location = new System.Drawing.Point(114, 50);
            this.Lb_Ip_Pri.Name = "Lb_Ip_Pri";
            this.Lb_Ip_Pri.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_Ip_Pri.Size = new System.Drawing.Size(151, 27);
            this.Lb_Ip_Pri.TabIndex = 221;
            // 
            // Com_NomPri
            // 
            this.Com_NomPri.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Com_NomPri.FormattingEnabled = true;
            this.Com_NomPri.Items.AddRange(new object[] {
            "DEBITO",
            "CREDITO"});
            this.Com_NomPri.Location = new System.Drawing.Point(114, 80);
            this.Com_NomPri.Name = "Com_NomPri";
            this.Com_NomPri.Size = new System.Drawing.Size(256, 28);
            this.Com_NomPri.TabIndex = 283;
            this.Com_NomPri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Com_NomPri_KeyPress);
            // 
            // Cmd_Salir
            // 
            this.Cmd_Salir.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Cmd_Salir.Image = global::SISPROIN.Properties.Resources.Salir;
            this.Cmd_Salir.Location = new System.Drawing.Point(299, 114);
            this.Cmd_Salir.Name = "Cmd_Salir";
            this.Cmd_Salir.Size = new System.Drawing.Size(75, 60);
            this.Cmd_Salir.TabIndex = 300;
            this.Cmd_Salir.Text = "Salir";
            this.Cmd_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Salir.UseVisualStyleBackColor = true;
            this.Cmd_Salir.Click += new System.EventHandler(this.Cmd_Salir_Click);
            // 
            // Cmd_Aceptar
            // 
            this.Cmd_Aceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Cmd_Aceptar.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Cmd_Aceptar.Image = global::SISPROIN.Properties.Resources.Aceptar;
            this.Cmd_Aceptar.Location = new System.Drawing.Point(218, 114);
            this.Cmd_Aceptar.Name = "Cmd_Aceptar";
            this.Cmd_Aceptar.Size = new System.Drawing.Size(75, 60);
            this.Cmd_Aceptar.TabIndex = 299;
            this.Cmd_Aceptar.Text = "Aceptar";
            this.Cmd_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Aceptar.UseVisualStyleBackColor = true;
            this.Cmd_Aceptar.Click += new System.EventHandler(this.Cmd_Aceptar_Click);
            // 
            // FormCONIMPR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(379, 179);
            this.Controls.Add(this.Cmd_Salir);
            this.Controls.Add(this.Cmd_Aceptar);
            this.Controls.Add(this.Com_NomPri);
            this.Controls.Add(this.Lb_Pc_Pri);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lb_Ip_Pri);
            this.MaximizeBox = false;
            this.Name = "FormCONIMPR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion de Impresora de Ticke";
            this.Load += new System.EventHandler(this.FormCONIMPR_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Lb_Pc_Pri;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Lb_Ip_Pri;
        private System.Windows.Forms.ComboBox Com_NomPri;
        internal System.Windows.Forms.Button Cmd_Salir;
        private System.Windows.Forms.Button Cmd_Aceptar;
    }
}