namespace SISPROIN.Formularios.VentasObsequios
{
    partial class FormFILLRESMOINV
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.Cmd_Salir = new System.Windows.Forms.Button();
            this.Cmd_Aceptar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(150, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 100);
            this.groupBox1.TabIndex = 303;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fechas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 298;
            this.label1.Text = "Hasta :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 295;
            this.label5.Text = "Desde :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(134, 27);
            this.dateTimePicker1.TabIndex = 296;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Checked = false;
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(72, 58);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(134, 27);
            this.dateTimePicker2.TabIndex = 299;
            // 
            // Cmd_Salir
            // 
            this.Cmd_Salir.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Cmd_Salir.Image = global::SISPROIN.Properties.Resources.Salir;
            this.Cmd_Salir.Location = new System.Drawing.Point(299, 116);
            this.Cmd_Salir.Name = "Cmd_Salir";
            this.Cmd_Salir.Size = new System.Drawing.Size(75, 60);
            this.Cmd_Salir.TabIndex = 306;
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
            this.Cmd_Aceptar.Location = new System.Drawing.Point(218, 116);
            this.Cmd_Aceptar.Name = "Cmd_Aceptar";
            this.Cmd_Aceptar.Size = new System.Drawing.Size(75, 60);
            this.Cmd_Aceptar.TabIndex = 305;
            this.Cmd_Aceptar.Text = "Aceptar";
            this.Cmd_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Aceptar.UseVisualStyleBackColor = true;
            this.Cmd_Aceptar.Click += new System.EventHandler(this.Cmd_Aceptar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SISPROIN.Properties.Resources.filtros;
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 304;
            this.pictureBox1.TabStop = false;
            // 
            // FormFILLRESMOINV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(383, 187);
            this.Controls.Add(this.Cmd_Salir);
            this.Controls.Add(this.Cmd_Aceptar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FormFILLRESMOINV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen de Movimiento de Inventario";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button Cmd_Salir;
        private System.Windows.Forms.Button Cmd_Aceptar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}