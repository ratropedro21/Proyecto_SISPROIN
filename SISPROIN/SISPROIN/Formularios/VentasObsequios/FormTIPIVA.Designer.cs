namespace SISPROIN.Formularios.VentasObsequios
{
    partial class FormTIPIVA
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
            this.label4 = new System.Windows.Forms.Label();
            this.Lb_CodTiv = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_DesTiv = new System.Windows.Forms.TextBox();
            this.Lb_StaTiv = new System.Windows.Forms.Label();
            this.Txt_TipTiv = new System.Windows.Forms.TextBox();
            this.Lb_DesTiv = new System.Windows.Forms.Label();
            this.Lb_TipTiv = new System.Windows.Forms.Label();
            this.Che_StaTiv = new System.Windows.Forms.CheckBox();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.ToolStrip1.Size = new System.Drawing.Size(594, 54);
            this.ToolStrip1.TabIndex = 230;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(383, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 240;
            this.label4.Text = "Status :";
            // 
            // Lb_CodTiv
            // 
            this.Lb_CodTiv.BackColor = System.Drawing.Color.White;
            this.Lb_CodTiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_CodTiv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_CodTiv.Location = new System.Drawing.Point(186, 67);
            this.Lb_CodTiv.Name = "Lb_CodTiv";
            this.Lb_CodTiv.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_CodTiv.Size = new System.Drawing.Size(83, 27);
            this.Lb_CodTiv.TabIndex = 238;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 20);
            this.label3.TabIndex = 237;
            this.label3.Text = "Cod. de Tipo de IVA. :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 232;
            this.label2.Text = "Des. de Tipo de IVA. :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 231;
            this.label1.Text = "Tipo de IVA. :";
            // 
            // Txt_DesTiv
            // 
            this.Txt_DesTiv.BackColor = System.Drawing.Color.White;
            this.Txt_DesTiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_DesTiv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_DesTiv.Enabled = false;
            this.Txt_DesTiv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_DesTiv.Location = new System.Drawing.Point(186, 127);
            this.Txt_DesTiv.Name = "Txt_DesTiv";
            this.Txt_DesTiv.Size = new System.Drawing.Size(379, 27);
            this.Txt_DesTiv.TabIndex = 234;
            this.Txt_DesTiv.Visible = false;
            this.Txt_DesTiv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_DesTiv_KeyDown);
            // 
            // Lb_StaTiv
            // 
            this.Lb_StaTiv.BackColor = System.Drawing.Color.White;
            this.Lb_StaTiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_StaTiv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_StaTiv.Location = new System.Drawing.Point(448, 66);
            this.Lb_StaTiv.Name = "Lb_StaTiv";
            this.Lb_StaTiv.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_StaTiv.Size = new System.Drawing.Size(117, 27);
            this.Lb_StaTiv.TabIndex = 241;
            // 
            // Txt_TipTiv
            // 
            this.Txt_TipTiv.BackColor = System.Drawing.Color.White;
            this.Txt_TipTiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_TipTiv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_TipTiv.Enabled = false;
            this.Txt_TipTiv.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Txt_TipTiv.Location = new System.Drawing.Point(186, 97);
            this.Txt_TipTiv.MaxLength = 2;
            this.Txt_TipTiv.Name = "Txt_TipTiv";
            this.Txt_TipTiv.Size = new System.Drawing.Size(61, 27);
            this.Txt_TipTiv.TabIndex = 236;
            this.Txt_TipTiv.Visible = false;
            this.Txt_TipTiv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_TipTiv_KeyDown);
            // 
            // Lb_DesTiv
            // 
            this.Lb_DesTiv.BackColor = System.Drawing.Color.White;
            this.Lb_DesTiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_DesTiv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_DesTiv.Location = new System.Drawing.Point(186, 127);
            this.Lb_DesTiv.Name = "Lb_DesTiv";
            this.Lb_DesTiv.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_DesTiv.Size = new System.Drawing.Size(379, 27);
            this.Lb_DesTiv.TabIndex = 233;
            // 
            // Lb_TipTiv
            // 
            this.Lb_TipTiv.BackColor = System.Drawing.Color.White;
            this.Lb_TipTiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_TipTiv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_TipTiv.Location = new System.Drawing.Point(186, 97);
            this.Lb_TipTiv.Name = "Lb_TipTiv";
            this.Lb_TipTiv.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_TipTiv.Size = new System.Drawing.Size(61, 27);
            this.Lb_TipTiv.TabIndex = 235;
            // 
            // Che_StaTiv
            // 
            this.Che_StaTiv.AutoSize = true;
            this.Che_StaTiv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Che_StaTiv.Location = new System.Drawing.Point(448, 68);
            this.Che_StaTiv.Name = "Che_StaTiv";
            this.Che_StaTiv.Size = new System.Drawing.Size(136, 24);
            this.Che_StaTiv.TabIndex = 239;
            this.Che_StaTiv.Text = "Activo / Inactivo";
            this.Che_StaTiv.Visible = false;
            // 
            // FormTIPIVA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(594, 161);
            this.Controls.Add(this.Lb_StaTiv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Lb_CodTiv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Che_StaTiv);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.Txt_TipTiv);
            this.Controls.Add(this.Lb_TipTiv);
            this.Controls.Add(this.Txt_DesTiv);
            this.Controls.Add(this.Lb_DesTiv);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormTIPIVA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo de IVA";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormTIPIVA_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label Lb_CodTiv;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox Txt_DesTiv;
        internal System.Windows.Forms.Label Lb_StaTiv;
        internal System.Windows.Forms.TextBox Txt_TipTiv;
        internal System.Windows.Forms.Label Lb_DesTiv;
        internal System.Windows.Forms.Label Lb_TipTiv;
        private System.Windows.Forms.CheckBox Che_StaTiv;
    }
}