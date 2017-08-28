namespace SISPROIN.Formularios.Configuracion
{
    partial class FormNIVELESMENU
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
            this.Cmd_Salir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView0 = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Txt_Nombre = new System.Windows.Forms.TextBox();
            this.Cmd_Cancelar = new System.Windows.Forms.Button();
            this.Cmd_Aceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Cmd_AgrNivel2 = new System.Windows.Forms.Button();
            this.Cmd_AgrNivel1 = new System.Windows.Forms.Button();
            this.Cmd_AgrNivel0 = new System.Windows.Forms.Button();
            this.Txt_Nivel = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cmd_Salir
            // 
            this.Cmd_Salir.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Cmd_Salir.Image = global::SISPROIN.Properties.Resources.Salir;
            this.Cmd_Salir.Location = new System.Drawing.Point(539, 396);
            this.Cmd_Salir.Name = "Cmd_Salir";
            this.Cmd_Salir.Size = new System.Drawing.Size(75, 62);
            this.Cmd_Salir.TabIndex = 42;
            this.Cmd_Salir.Text = "Salir";
            this.Cmd_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Salir.UseVisualStyleBackColor = true;
            this.Cmd_Salir.Click += new System.EventHandler(this.Cmd_Salir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(4, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(406, 33);
            this.label3.TabIndex = 41;
            this.label3.Text = "Niveles de Accesos de Menús";
            // 
            // listView2
            // 
            this.listView2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.listView2.AllowColumnReorder = true;
            this.listView2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.FullRowSelect = true;
            this.listView2.Location = new System.Drawing.Point(419, 62);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(195, 205);
            this.listView2.TabIndex = 40;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView2_ItemSelectionChanged);
            // 
            // listView1
            // 
            this.listView1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.listView1.AllowColumnReorder = true;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(218, 62);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(195, 205);
            this.listView1.TabIndex = 39;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // listView0
            // 
            this.listView0.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.listView0.AllowColumnReorder = true;
            this.listView0.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listView0.FullRowSelect = true;
            this.listView0.HideSelection = false;
            this.listView0.Location = new System.Drawing.Point(11, 62);
            this.listView0.MultiSelect = false;
            this.listView0.Name = "listView0";
            this.listView0.Size = new System.Drawing.Size(195, 205);
            this.listView0.TabIndex = 38;
            this.listView0.UseCompatibleStateImageBehavior = false;
            this.listView0.View = System.Windows.Forms.View.Details;
            this.listView0.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView0_ItemSelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.Txt_Nombre);
            this.panel1.Controls.Add(this.Txt_Nivel);
            this.panel1.Controls.Add(this.Cmd_Cancelar);
            this.panel1.Controls.Add(this.Cmd_Aceptar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(147, 319);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 139);
            this.panel1.TabIndex = 37;
            this.panel1.Visible = false;
            // 
            // Txt_Nombre
            // 
            this.Txt_Nombre.BackColor = System.Drawing.Color.White;
            this.Txt_Nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_Nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_Nombre.Enabled = false;
            this.Txt_Nombre.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Txt_Nombre.Location = new System.Drawing.Point(84, 46);
            this.Txt_Nombre.Name = "Txt_Nombre";
            this.Txt_Nombre.Size = new System.Drawing.Size(237, 25);
            this.Txt_Nombre.TabIndex = 15;
            this.Txt_Nombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_Nombre_KeyDown);
            // 
            // Cmd_Cancelar
            // 
            this.Cmd_Cancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmd_Cancelar.Image = global::SISPROIN.Properties.Resources.Cancelar;
            this.Cmd_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Cmd_Cancelar.Location = new System.Drawing.Point(204, 77);
            this.Cmd_Cancelar.Name = "Cmd_Cancelar";
            this.Cmd_Cancelar.Size = new System.Drawing.Size(75, 54);
            this.Cmd_Cancelar.TabIndex = 9;
            this.Cmd_Cancelar.Text = "Cancelar";
            this.Cmd_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Cancelar.UseVisualStyleBackColor = true;
            this.Cmd_Cancelar.Click += new System.EventHandler(this.Cmd_Cancelar_Click);
            // 
            // Cmd_Aceptar
            // 
            this.Cmd_Aceptar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmd_Aceptar.Image = global::SISPROIN.Properties.Resources.Aceptar;
            this.Cmd_Aceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Cmd_Aceptar.Location = new System.Drawing.Point(84, 77);
            this.Cmd_Aceptar.Name = "Cmd_Aceptar";
            this.Cmd_Aceptar.Size = new System.Drawing.Size(75, 54);
            this.Cmd_Aceptar.TabIndex = 8;
            this.Cmd_Aceptar.Text = "Aceptar";
            this.Cmd_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Aceptar.UseVisualStyleBackColor = true;
            this.Cmd_Aceptar.Click += new System.EventHandler(this.Cmd_Aceptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo:";
            // 
            // Cmd_AgrNivel2
            // 
            this.Cmd_AgrNivel2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmd_AgrNivel2.Image = global::SISPROIN.Properties.Resources.Mas;
            this.Cmd_AgrNivel2.Location = new System.Drawing.Point(497, 273);
            this.Cmd_AgrNivel2.Name = "Cmd_AgrNivel2";
            this.Cmd_AgrNivel2.Size = new System.Drawing.Size(47, 40);
            this.Cmd_AgrNivel2.TabIndex = 36;
            this.Cmd_AgrNivel2.UseVisualStyleBackColor = true;
            this.Cmd_AgrNivel2.Visible = false;
            this.Cmd_AgrNivel2.Click += new System.EventHandler(this.Cmd_AgrNivel2_Click);
            // 
            // Cmd_AgrNivel1
            // 
            this.Cmd_AgrNivel1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmd_AgrNivel1.Image = global::SISPROIN.Properties.Resources.Mas;
            this.Cmd_AgrNivel1.Location = new System.Drawing.Point(289, 273);
            this.Cmd_AgrNivel1.Name = "Cmd_AgrNivel1";
            this.Cmd_AgrNivel1.Size = new System.Drawing.Size(47, 40);
            this.Cmd_AgrNivel1.TabIndex = 35;
            this.Cmd_AgrNivel1.UseVisualStyleBackColor = true;
            this.Cmd_AgrNivel1.Visible = false;
            this.Cmd_AgrNivel1.Click += new System.EventHandler(this.Cmd_AgrNivel1_Click);
            // 
            // Cmd_AgrNivel0
            // 
            this.Cmd_AgrNivel0.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmd_AgrNivel0.Image = global::SISPROIN.Properties.Resources.Mas;
            this.Cmd_AgrNivel0.Location = new System.Drawing.Point(80, 273);
            this.Cmd_AgrNivel0.Name = "Cmd_AgrNivel0";
            this.Cmd_AgrNivel0.Size = new System.Drawing.Size(47, 40);
            this.Cmd_AgrNivel0.TabIndex = 34;
            this.Cmd_AgrNivel0.UseVisualStyleBackColor = true;
            this.Cmd_AgrNivel0.Click += new System.EventHandler(this.Cmd_AgrNivel0_Click);
            // 
            // Txt_Nivel
            // 
            this.Txt_Nivel.BackColor = System.Drawing.Color.White;
            this.Txt_Nivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_Nivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_Nivel.Enabled = false;
            this.Txt_Nivel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Txt_Nivel.Location = new System.Drawing.Point(84, 15);
            this.Txt_Nivel.Name = "Txt_Nivel";
            this.Txt_Nivel.Size = new System.Drawing.Size(37, 25);
            this.Txt_Nivel.TabIndex = 14;
            this.Txt_Nivel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_Nivel_KeyDown);
            // 
            // FormNIVELESMENU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(618, 464);
            this.Controls.Add(this.Cmd_Salir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listView0);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Cmd_AgrNivel2);
            this.Controls.Add(this.Cmd_AgrNivel1);
            this.Controls.Add(this.Cmd_AgrNivel0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNIVELESMENU";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Niveles de Acceso de Menú y Sub-Menú";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Cmd_Salir;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView0;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.TextBox Txt_Nombre;
        private System.Windows.Forms.Button Cmd_Cancelar;
        private System.Windows.Forms.Button Cmd_Aceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cmd_AgrNivel2;
        private System.Windows.Forms.Button Cmd_AgrNivel1;
        private System.Windows.Forms.Button Cmd_AgrNivel0;
        internal System.Windows.Forms.TextBox Txt_Nivel;
    }
}