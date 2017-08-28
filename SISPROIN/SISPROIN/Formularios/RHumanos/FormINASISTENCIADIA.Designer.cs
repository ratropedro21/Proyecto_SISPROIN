namespace SISPROIN.Formularios.RHumanos
{
    partial class FormINASISTENCIADIA
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
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Cmd_Guardar = new System.Windows.Forms.ToolStripButton();
            this.Cmd_Nuevo = new System.Windows.Forms.ToolStripButton();
            this.Cmd_Modificar = new System.Windows.Forms.ToolStripButton();
            this.Cmd_Primero = new System.Windows.Forms.ToolStripButton();
            this.Cmd_Anterior = new System.Windows.Forms.ToolStripButton();
            this.Cmd_Siguiente = new System.Windows.Forms.ToolStripButton();
            this.Cmd_Ultimo = new System.Windows.Forms.ToolStripButton();
            this.Cmd_Buscar = new System.Windows.Forms.ToolStripButton();
            this.Cmd_Eliminar = new System.Windows.Forms.ToolStripButton();
            this.Cmd_Imprimir = new System.Windows.Forms.ToolStripButton();
            this.Cmd_Aceptar = new System.Windows.Forms.ToolStripButton();
            this.Cmd_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.Che_StaAsd = new System.Windows.Forms.CheckBox();
            this.Lb_StaAsd = new System.Windows.Forms.Label();
            this.Lb_CodAsd = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Lb_FecAsd = new System.Windows.Forms.Label();
            this.lblFecAsd = new System.Windows.Forms.Label();
            this.Txt_CedPer = new System.Windows.Forms.TextBox();
            this.Lb_NomPer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Txt_ComAsd = new System.Windows.Forms.TextBox();
            this.ToolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(6, 185);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(685, 171);
            this.listView1.TabIndex = 310;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cmd_Guardar,
            this.Cmd_Nuevo,
            this.Cmd_Modificar,
            this.Cmd_Primero,
            this.Cmd_Anterior,
            this.Cmd_Siguiente,
            this.Cmd_Ultimo,
            this.Cmd_Buscar,
            this.Cmd_Eliminar,
            this.Cmd_Imprimir,
            this.Cmd_Aceptar,
            this.Cmd_Cancelar});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(697, 25);
            this.ToolStrip1.TabIndex = 309;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // Cmd_Guardar
            // 
            this.Cmd_Guardar.Image = global::SISPROIN.Properties.Resources.Guarda;
            this.Cmd_Guardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Cmd_Guardar.Name = "Cmd_Guardar";
            this.Cmd_Guardar.Size = new System.Drawing.Size(76, 51);
            this.Cmd_Guardar.Text = "Guardar-F11";
            this.Cmd_Guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Guardar.ToolTipText = "Guardar Registro";
            this.Cmd_Guardar.Visible = false;
            this.Cmd_Guardar.Click += new System.EventHandler(this.Cmd_Guardar_Click);
            // 
            // Cmd_Nuevo
            // 
            this.Cmd_Nuevo.Image = global::SISPROIN.Properties.Resources.Nuevo;
            this.Cmd_Nuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Cmd_Nuevo.Name = "Cmd_Nuevo";
            this.Cmd_Nuevo.Size = new System.Drawing.Size(63, 51);
            this.Cmd_Nuevo.Text = "Nuevo-F1";
            this.Cmd_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Nuevo.ToolTipText = "Nuevo Registro";
            this.Cmd_Nuevo.Visible = false;
            this.Cmd_Nuevo.Click += new System.EventHandler(this.Cmd_Nuevo_Click);
            // 
            // Cmd_Modificar
            // 
            this.Cmd_Modificar.Image = global::SISPROIN.Properties.Resources.Modificar;
            this.Cmd_Modificar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Cmd_Modificar.Name = "Cmd_Modificar";
            this.Cmd_Modificar.Size = new System.Drawing.Size(79, 51);
            this.Cmd_Modificar.Text = "Modificar-F2";
            this.Cmd_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Modificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Modificar.ToolTipText = "Modificar Registro";
            this.Cmd_Modificar.Visible = false;
            this.Cmd_Modificar.Click += new System.EventHandler(this.Cmd_Modificar_Click);
            // 
            // Cmd_Primero
            // 
            this.Cmd_Primero.Image = global::SISPROIN.Properties.Resources.Primero;
            this.Cmd_Primero.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Cmd_Primero.Name = "Cmd_Primero";
            this.Cmd_Primero.Size = new System.Drawing.Size(70, 51);
            this.Cmd_Primero.Text = "Primero-F3";
            this.Cmd_Primero.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Primero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Primero.ToolTipText = "Primer Registro";
            this.Cmd_Primero.Visible = false;
            this.Cmd_Primero.Click += new System.EventHandler(this.Cmd_Primero_Click);
            // 
            // Cmd_Anterior
            // 
            this.Cmd_Anterior.Image = global::SISPROIN.Properties.Resources.Anterio;
            this.Cmd_Anterior.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Cmd_Anterior.Name = "Cmd_Anterior";
            this.Cmd_Anterior.Size = new System.Drawing.Size(71, 51);
            this.Cmd_Anterior.Text = "Anterior-F4";
            this.Cmd_Anterior.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Anterior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Anterior.ToolTipText = "Anterior Registro";
            this.Cmd_Anterior.Visible = false;
            this.Cmd_Anterior.Click += new System.EventHandler(this.Cmd_Anterior_Click);
            // 
            // Cmd_Siguiente
            // 
            this.Cmd_Siguiente.Image = global::SISPROIN.Properties.Resources.Siguiente;
            this.Cmd_Siguiente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Cmd_Siguiente.Name = "Cmd_Siguiente";
            this.Cmd_Siguiente.Size = new System.Drawing.Size(77, 51);
            this.Cmd_Siguiente.Text = "Siguiente-F5";
            this.Cmd_Siguiente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Siguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Siguiente.ToolTipText = "Siguiente Registro";
            this.Cmd_Siguiente.Visible = false;
            this.Cmd_Siguiente.Click += new System.EventHandler(this.Cmd_Siguiente_Click);
            // 
            // Cmd_Ultimo
            // 
            this.Cmd_Ultimo.Image = global::SISPROIN.Properties.Resources.Ultimo;
            this.Cmd_Ultimo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Cmd_Ultimo.Name = "Cmd_Ultimo";
            this.Cmd_Ultimo.Size = new System.Drawing.Size(64, 51);
            this.Cmd_Ultimo.Text = "Ultimo-F6";
            this.Cmd_Ultimo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Ultimo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Ultimo.ToolTipText = "Siguiente Registro";
            this.Cmd_Ultimo.Visible = false;
            this.Cmd_Ultimo.Click += new System.EventHandler(this.Cmd_Ultimo_Click);
            // 
            // Cmd_Buscar
            // 
            this.Cmd_Buscar.Image = global::SISPROIN.Properties.Resources.Busqueda;
            this.Cmd_Buscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Cmd_Buscar.Name = "Cmd_Buscar";
            this.Cmd_Buscar.Size = new System.Drawing.Size(63, 51);
            this.Cmd_Buscar.Text = "Buscar-F7";
            this.Cmd_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Buscar.ToolTipText = "Buscar Registro";
            this.Cmd_Buscar.Visible = false;
            this.Cmd_Buscar.Click += new System.EventHandler(this.Cmd_Buscar_Click);
            // 
            // Cmd_Eliminar
            // 
            this.Cmd_Eliminar.Image = global::SISPROIN.Properties.Resources.Eliminar;
            this.Cmd_Eliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Cmd_Eliminar.Name = "Cmd_Eliminar";
            this.Cmd_Eliminar.Size = new System.Drawing.Size(63, 51);
            this.Cmd_Eliminar.Text = "Anular-F8";
            this.Cmd_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Eliminar.ToolTipText = "Anular Movimiento";
            this.Cmd_Eliminar.Visible = false;
            this.Cmd_Eliminar.Click += new System.EventHandler(this.Cmd_Eliminar_Click);
            // 
            // Cmd_Imprimir
            // 
            this.Cmd_Imprimir.Image = global::SISPROIN.Properties.Resources.Imprimir;
            this.Cmd_Imprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Cmd_Imprimir.Name = "Cmd_Imprimir";
            this.Cmd_Imprimir.Size = new System.Drawing.Size(74, 51);
            this.Cmd_Imprimir.Text = "Imprimir-F9";
            this.Cmd_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Imprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Imprimir.ToolTipText = "Imprimir";
            this.Cmd_Imprimir.Visible = false;
            this.Cmd_Imprimir.Click += new System.EventHandler(this.Cmd_Imprimir_Click);
            // 
            // Cmd_Aceptar
            // 
            this.Cmd_Aceptar.Image = global::SISPROIN.Properties.Resources.Aceptar;
            this.Cmd_Aceptar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Cmd_Aceptar.Name = "Cmd_Aceptar";
            this.Cmd_Aceptar.Size = new System.Drawing.Size(75, 51);
            this.Cmd_Aceptar.Text = "Aceptar-F10";
            this.Cmd_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Aceptar.ToolTipText = "Aceptar";
            this.Cmd_Aceptar.Visible = false;
            this.Cmd_Aceptar.Click += new System.EventHandler(this.Cmd_Aceptar_Click);
            // 
            // Cmd_Cancelar
            // 
            this.Cmd_Cancelar.Image = global::SISPROIN.Properties.Resources.Cancelar;
            this.Cmd_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Cmd_Cancelar.Name = "Cmd_Cancelar";
            this.Cmd_Cancelar.Size = new System.Drawing.Size(80, 51);
            this.Cmd_Cancelar.Text = "Cancelar-F12";
            this.Cmd_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Cancelar.ToolTipText = "Cancelar";
            this.Cmd_Cancelar.Visible = false;
            this.Cmd_Cancelar.Click += new System.EventHandler(this.Cmd_Cancelar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Che_StaAsd);
            this.panel1.Controls.Add(this.Lb_StaAsd);
            this.panel1.Controls.Add(this.Lb_CodAsd);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Lb_FecAsd);
            this.panel1.Controls.Add(this.lblFecAsd);
            this.panel1.Location = new System.Drawing.Point(6, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 91);
            this.panel1.TabIndex = 308;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(477, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 225;
            this.label4.Text = "Status :";
            // 
            // Che_StaAsd
            // 
            this.Che_StaAsd.AutoSize = true;
            this.Che_StaAsd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Che_StaAsd.Location = new System.Drawing.Point(542, 16);
            this.Che_StaAsd.Name = "Che_StaAsd";
            this.Che_StaAsd.Size = new System.Drawing.Size(136, 24);
            this.Che_StaAsd.TabIndex = 224;
            this.Che_StaAsd.Text = "Activo / Inactivo";
            this.Che_StaAsd.Visible = false;
            // 
            // Lb_StaAsd
            // 
            this.Lb_StaAsd.BackColor = System.Drawing.Color.White;
            this.Lb_StaAsd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_StaAsd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_StaAsd.Location = new System.Drawing.Point(542, 14);
            this.Lb_StaAsd.Name = "Lb_StaAsd";
            this.Lb_StaAsd.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_StaAsd.Size = new System.Drawing.Size(117, 27);
            this.Lb_StaAsd.TabIndex = 226;
            // 
            // Lb_CodAsd
            // 
            this.Lb_CodAsd.AutoSize = true;
            this.Lb_CodAsd.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_CodAsd.ForeColor = System.Drawing.Color.DarkRed;
            this.Lb_CodAsd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lb_CodAsd.Location = new System.Drawing.Point(133, 7);
            this.Lb_CodAsd.Name = "Lb_CodAsd";
            this.Lb_CodAsd.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Lb_CodAsd.Size = new System.Drawing.Size(0, 34);
            this.Lb_CodAsd.TabIndex = 211;
            this.Lb_CodAsd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label3.Location = new System.Drawing.Point(83, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 115;
            this.label3.Text = "Fecha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label1.Location = new System.Drawing.Point(61, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 113;
            this.label1.Text = "No Mov. :";
            // 
            // Lb_FecAsd
            // 
            this.Lb_FecAsd.BackColor = System.Drawing.Color.White;
            this.Lb_FecAsd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_FecAsd.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Lb_FecAsd.Location = new System.Drawing.Point(139, 54);
            this.Lb_FecAsd.Name = "Lb_FecAsd";
            this.Lb_FecAsd.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_FecAsd.Size = new System.Drawing.Size(172, 25);
            this.Lb_FecAsd.TabIndex = 223;
            // 
            // lblFecAsd
            // 
            this.lblFecAsd.BackColor = System.Drawing.Color.White;
            this.lblFecAsd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFecAsd.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblFecAsd.Location = new System.Drawing.Point(139, 54);
            this.lblFecAsd.Name = "lblFecAsd";
            this.lblFecAsd.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblFecAsd.Size = new System.Drawing.Size(172, 25);
            this.lblFecAsd.TabIndex = 222;
            this.lblFecAsd.Visible = false;
            // 
            // Txt_CedPer
            // 
            this.Txt_CedPer.BackColor = System.Drawing.Color.White;
            this.Txt_CedPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_CedPer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_CedPer.Enabled = false;
            this.Txt_CedPer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_CedPer.Location = new System.Drawing.Point(6, 155);
            this.Txt_CedPer.Name = "Txt_CedPer";
            this.Txt_CedPer.Size = new System.Drawing.Size(133, 27);
            this.Txt_CedPer.TabIndex = 302;
            this.Txt_CedPer.Visible = false;
            this.Txt_CedPer.Enter += new System.EventHandler(this.Txt_CedPer_Enter);
            this.Txt_CedPer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_CedPer_KeyDown);
            // 
            // Lb_NomPer
            // 
            this.Lb_NomPer.BackColor = System.Drawing.Color.White;
            this.Lb_NomPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_NomPer.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Lb_NomPer.Location = new System.Drawing.Point(141, 155);
            this.Lb_NomPer.Name = "Lb_NomPer";
            this.Lb_NomPer.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_NomPer.Size = new System.Drawing.Size(274, 27);
            this.Lb_NomPer.TabIndex = 221;
            this.Lb_NomPer.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Txt_ComAsd
            // 
            this.Txt_ComAsd.BackColor = System.Drawing.Color.White;
            this.Txt_ComAsd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_ComAsd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_ComAsd.Enabled = false;
            this.Txt_ComAsd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ComAsd.Location = new System.Drawing.Point(417, 155);
            this.Txt_ComAsd.Name = "Txt_ComAsd";
            this.Txt_ComAsd.Size = new System.Drawing.Size(274, 27);
            this.Txt_ComAsd.TabIndex = 312;
            this.Txt_ComAsd.Visible = false;
            this.Txt_ComAsd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_ComAsd_KeyDown);
            // 
            // FormINASISTENCIADIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(697, 362);
            this.Controls.Add(this.Txt_CedPer);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Lb_NomPer);
            this.Controls.Add(this.Txt_ComAsd);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormINASISTENCIADIA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inasistecias del Dia";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormINASISTENCIADIA_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton Cmd_Guardar;
        internal System.Windows.Forms.ToolStripButton Cmd_Nuevo;
        internal System.Windows.Forms.ToolStripButton Cmd_Modificar;
        internal System.Windows.Forms.ToolStripButton Cmd_Primero;
        internal System.Windows.Forms.ToolStripButton Cmd_Anterior;
        internal System.Windows.Forms.ToolStripButton Cmd_Siguiente;
        internal System.Windows.Forms.ToolStripButton Cmd_Ultimo;
        internal System.Windows.Forms.ToolStripButton Cmd_Buscar;
        internal System.Windows.Forms.ToolStripButton Cmd_Eliminar;
        internal System.Windows.Forms.ToolStripButton Cmd_Imprimir;
        internal System.Windows.Forms.ToolStripButton Cmd_Aceptar;
        internal System.Windows.Forms.ToolStripButton Cmd_Cancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Lb_CodAsd;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label lblFecAsd;
        internal System.Windows.Forms.TextBox Txt_CedPer;
        internal System.Windows.Forms.Label Lb_NomPer;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Label Lb_FecAsd;
        internal System.Windows.Forms.TextBox Txt_ComAsd;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Che_StaAsd;
        internal System.Windows.Forms.Label Lb_StaAsd;
    }
}