namespace SISPROIN.Formularios.VentasObsequios
{
    partial class FormTIPTRANSA
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
            this.label4 = new System.Windows.Forms.Label();
            this.Che_StaTra = new System.Windows.Forms.CheckBox();
            this.Lb_CodTra = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_DesTra = new System.Windows.Forms.TextBox();
            this.Lb_StaTra = new System.Windows.Forms.Label();
            this.Txt_TipTra = new System.Windows.Forms.TextBox();
            this.Lb_DesTra = new System.Windows.Forms.Label();
            this.Lb_TipTra = new System.Windows.Forms.Label();
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(357, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 226;
            this.label4.Text = "Status :";
            // 
            // Che_StaTra
            // 
            this.Che_StaTra.AutoSize = true;
            this.Che_StaTra.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Che_StaTra.Location = new System.Drawing.Point(422, 69);
            this.Che_StaTra.Name = "Che_StaTra";
            this.Che_StaTra.Size = new System.Drawing.Size(136, 24);
            this.Che_StaTra.TabIndex = 225;
            this.Che_StaTra.Text = "Activo / Inactivo";
            this.Che_StaTra.Visible = false;
            // 
            // Lb_CodTra
            // 
            this.Lb_CodTra.BackColor = System.Drawing.Color.White;
            this.Lb_CodTra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_CodTra.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_CodTra.Location = new System.Drawing.Point(180, 68);
            this.Lb_CodTra.Name = "Lb_CodTra";
            this.Lb_CodTra.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_CodTra.Size = new System.Drawing.Size(83, 27);
            this.Lb_CodTra.TabIndex = 224;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 223;
            this.label3.Text = "Codigo de la Tran. :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 20);
            this.label2.TabIndex = 218;
            this.label2.Text = "Descripción de la Tran. :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 217;
            this.label1.Text = "Transacción :";
            // 
            // Txt_DesTra
            // 
            this.Txt_DesTra.BackColor = System.Drawing.Color.White;
            this.Txt_DesTra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_DesTra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_DesTra.Enabled = false;
            this.Txt_DesTra.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_DesTra.Location = new System.Drawing.Point(180, 128);
            this.Txt_DesTra.Name = "Txt_DesTra";
            this.Txt_DesTra.Size = new System.Drawing.Size(389, 27);
            this.Txt_DesTra.TabIndex = 220;
            this.Txt_DesTra.Visible = false;
            this.Txt_DesTra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_DesTra_KeyDown);
            // 
            // Lb_StaTra
            // 
            this.Lb_StaTra.BackColor = System.Drawing.Color.White;
            this.Lb_StaTra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_StaTra.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_StaTra.Location = new System.Drawing.Point(422, 67);
            this.Lb_StaTra.Name = "Lb_StaTra";
            this.Lb_StaTra.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_StaTra.Size = new System.Drawing.Size(117, 27);
            this.Lb_StaTra.TabIndex = 227;
            // 
            // Txt_TipTra
            // 
            this.Txt_TipTra.BackColor = System.Drawing.Color.White;
            this.Txt_TipTra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_TipTra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_TipTra.Enabled = false;
            this.Txt_TipTra.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Txt_TipTra.Location = new System.Drawing.Point(180, 98);
            this.Txt_TipTra.MaxLength = 4;
            this.Txt_TipTra.Name = "Txt_TipTra";
            this.Txt_TipTra.Size = new System.Drawing.Size(61, 27);
            this.Txt_TipTra.TabIndex = 222;
            this.Txt_TipTra.Visible = false;
            this.Txt_TipTra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_TipTra_KeyDown);
            // 
            // Lb_DesTra
            // 
            this.Lb_DesTra.BackColor = System.Drawing.Color.White;
            this.Lb_DesTra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_DesTra.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_DesTra.Location = new System.Drawing.Point(180, 128);
            this.Lb_DesTra.Name = "Lb_DesTra";
            this.Lb_DesTra.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_DesTra.Size = new System.Drawing.Size(390, 27);
            this.Lb_DesTra.TabIndex = 219;
            // 
            // Lb_TipTra
            // 
            this.Lb_TipTra.BackColor = System.Drawing.Color.White;
            this.Lb_TipTra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_TipTra.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_TipTra.Location = new System.Drawing.Point(180, 98);
            this.Lb_TipTra.Name = "Lb_TipTra";
            this.Lb_TipTra.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_TipTra.Size = new System.Drawing.Size(61, 27);
            this.Lb_TipTra.TabIndex = 221;
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
            this.ToolStrip1.Size = new System.Drawing.Size(576, 25);
            this.ToolStrip1.TabIndex = 228;
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
            this.Cmd_Eliminar.Size = new System.Drawing.Size(71, 51);
            this.Cmd_Eliminar.Text = "Eliminar-F8";
            this.Cmd_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_Eliminar.ToolTipText = "Eliminar Registro";
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
            // listView1
            // 
            this.listView1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.listView1.CheckBoxes = true;
            this.listView1.Enabled = false;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(7, 161);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(563, 172);
            this.listView1.TabIndex = 293;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // FormTIPTRANSA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(576, 337);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Lb_CodTra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lb_StaTra);
            this.Controls.Add(this.Che_StaTra);
            this.Controls.Add(this.Txt_TipTra);
            this.Controls.Add(this.Lb_DesTra);
            this.Controls.Add(this.Txt_DesTra);
            this.Controls.Add(this.Lb_TipTra);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormTIPTRANSA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transacción";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormTIPTRANSA_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Che_StaTra;
        internal System.Windows.Forms.Label Lb_CodTra;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox Txt_DesTra;
        internal System.Windows.Forms.Label Lb_StaTra;
        internal System.Windows.Forms.TextBox Txt_TipTra;
        internal System.Windows.Forms.Label Lb_DesTra;
        internal System.Windows.Forms.Label Lb_TipTra;
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
        private System.Windows.Forms.ListView listView1;
    }
}