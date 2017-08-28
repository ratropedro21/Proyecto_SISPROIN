namespace SISPROIN.Formularios
{
    partial class FormPASSWORD
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Cmd_Salir = new System.Windows.Forms.Button();
            this.Cmd_Aceptar = new System.Windows.Forms.Button();
            this.Txt_ClaUsu = new System.Windows.Forms.TextBox();
            this.Lbl_ClaUsu = new System.Windows.Forms.Label();
            this.Txt_UsuUsu = new System.Windows.Forms.TextBox();
            this.Lbl_CodUsu = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(63, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 33);
            this.label1.TabIndex = 32;
            this.label1.Text = "Inicio de Sesión ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Cmd_Salir);
            this.panel1.Controls.Add(this.Cmd_Aceptar);
            this.panel1.Controls.Add(this.Txt_ClaUsu);
            this.panel1.Controls.Add(this.Lbl_ClaUsu);
            this.panel1.Controls.Add(this.Txt_UsuUsu);
            this.panel1.Controls.Add(this.Lbl_CodUsu);
            this.panel1.Location = new System.Drawing.Point(19, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 156);
            this.panel1.TabIndex = 31;
            // 
            // Cmd_Salir
            // 
            this.Cmd_Salir.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Cmd_Salir.Image = global::SISPROIN.Properties.Resources.Salir;
            this.Cmd_Salir.Location = new System.Drawing.Point(149, 81);
            this.Cmd_Salir.Name = "Cmd_Salir";
            this.Cmd_Salir.Size = new System.Drawing.Size(75, 60);
            this.Cmd_Salir.TabIndex = 29;
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
            this.Cmd_Aceptar.Image = global::SISPROIN.Properties.Resources.User;
            this.Cmd_Aceptar.Location = new System.Drawing.Point(24, 81);
            this.Cmd_Aceptar.Name = "Cmd_Aceptar";
            this.Cmd_Aceptar.Size = new System.Drawing.Size(75, 60);
            this.Cmd_Aceptar.TabIndex = 28;
            this.Cmd_Aceptar.Text = "Aceptar";
            this.Cmd_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Aceptar.UseVisualStyleBackColor = true;
            this.Cmd_Aceptar.Click += new System.EventHandler(this.Cmd_Aceptar_Click);
            // 
            // Txt_ClaUsu
            // 
            this.Txt_ClaUsu.BackColor = System.Drawing.Color.White;
            this.Txt_ClaUsu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_ClaUsu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_ClaUsu.Enabled = false;
            this.Txt_ClaUsu.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Txt_ClaUsu.Location = new System.Drawing.Point(103, 42);
            this.Txt_ClaUsu.Name = "Txt_ClaUsu";
            this.Txt_ClaUsu.PasswordChar = '*';
            this.Txt_ClaUsu.Size = new System.Drawing.Size(117, 27);
            this.Txt_ClaUsu.TabIndex = 26;
            this.Txt_ClaUsu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_ClaUsu_KeyDown);
            // 
            // Lbl_ClaUsu
            // 
            this.Lbl_ClaUsu.AutoSize = true;
            this.Lbl_ClaUsu.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Lbl_ClaUsu.Location = new System.Drawing.Point(45, 42);
            this.Lbl_ClaUsu.Name = "Lbl_ClaUsu";
            this.Lbl_ClaUsu.Size = new System.Drawing.Size(52, 20);
            this.Lbl_ClaUsu.TabIndex = 27;
            this.Lbl_ClaUsu.Text = "Clave :";
            // 
            // Txt_UsuUsu
            // 
            this.Txt_UsuUsu.BackColor = System.Drawing.Color.White;
            this.Txt_UsuUsu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_UsuUsu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_UsuUsu.Enabled = false;
            this.Txt_UsuUsu.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Txt_UsuUsu.Location = new System.Drawing.Point(103, 10);
            this.Txt_UsuUsu.Name = "Txt_UsuUsu";
            this.Txt_UsuUsu.Size = new System.Drawing.Size(117, 27);
            this.Txt_UsuUsu.TabIndex = 24;
            this.Txt_UsuUsu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_UsuUsu_KeyDown);
            // 
            // Lbl_CodUsu
            // 
            this.Lbl_CodUsu.AutoSize = true;
            this.Lbl_CodUsu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CodUsu.Location = new System.Drawing.Point(31, 10);
            this.Lbl_CodUsu.Name = "Lbl_CodUsu";
            this.Lbl_CodUsu.Size = new System.Drawing.Size(66, 20);
            this.Lbl_CodUsu.TabIndex = 25;
            this.Lbl_CodUsu.Text = "Usuario :";
            // 
            // FormPASSWORD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(296, 232);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPASSWORD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Sesión ";
            this.Load += new System.EventHandler(this.FormPASSWORD_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button Cmd_Salir;
        private System.Windows.Forms.Button Cmd_Aceptar;
        internal System.Windows.Forms.TextBox Txt_ClaUsu;
        internal System.Windows.Forms.Label Lbl_ClaUsu;
        internal System.Windows.Forms.TextBox Txt_UsuUsu;
        internal System.Windows.Forms.Label Lbl_CodUsu;
    }
}