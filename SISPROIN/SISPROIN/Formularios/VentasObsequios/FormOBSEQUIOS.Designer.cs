namespace SISPROIN.Formularios.VentasObsequios
{
    partial class FormOBSEQUIOS
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
            this.Txt_CedPer = new System.Windows.Forms.TextBox();
            this.Lb_CedPer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Lb_CodMov = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Lb_FecDoc = new System.Windows.Forms.Label();
            this.Lb_NomPer = new System.Windows.Forms.Label();
            this.Lb_StaDoc = new System.Windows.Forms.Label();
            this.Txt_CodPro = new System.Windows.Forms.TextBox();
            this.Lb_DesPro = new System.Windows.Forms.Label();
            this.Txt_CanMov = new System.Windows.Forms.TextBox();
            this.Lb_UndUnm = new System.Windows.Forms.Label();
            this.Txt_CatMov = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.Cmd_UltmVac = new System.Windows.Forms.Button();
            this.Cmd_UltmPre = new System.Windows.Forms.Button();
            this.Cmd_UltmEntr = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Txt_ComDoc = new System.Windows.Forms.TextBox();
            this.Lb_ComDoc = new System.Windows.Forms.Label();
            this.ToolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.ToolStrip1.Size = new System.Drawing.Size(697, 25);
            this.ToolStrip1.TabIndex = 298;
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
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Txt_CedPer);
            this.panel1.Controls.Add(this.Lb_CedPer);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Lb_CodMov);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Lb_FecDoc);
            this.panel1.Controls.Add(this.Lb_NomPer);
            this.panel1.Controls.Add(this.Lb_StaDoc);
            this.panel1.Controls.Add(this.Txt_ComDoc);
            this.panel1.Controls.Add(this.Lb_ComDoc);
            this.panel1.Location = new System.Drawing.Point(6, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 192);
            this.panel1.TabIndex = 293;
            // 
            // Txt_CedPer
            // 
            this.Txt_CedPer.BackColor = System.Drawing.Color.White;
            this.Txt_CedPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_CedPer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_CedPer.Enabled = false;
            this.Txt_CedPer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_CedPer.Location = new System.Drawing.Point(139, 53);
            this.Txt_CedPer.Name = "Txt_CedPer";
            this.Txt_CedPer.Size = new System.Drawing.Size(133, 27);
            this.Txt_CedPer.TabIndex = 302;
            this.Txt_CedPer.Visible = false;
            this.Txt_CedPer.Enter += new System.EventHandler(this.Txt_CedPer_Enter);
            this.Txt_CedPer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_CedPer_KeyDown);
            this.Txt_CedPer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_CedPer_KeyPress);
            // 
            // Lb_CedPer
            // 
            this.Lb_CedPer.BackColor = System.Drawing.Color.White;
            this.Lb_CedPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_CedPer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_CedPer.Location = new System.Drawing.Point(139, 53);
            this.Lb_CedPer.Name = "Lb_CedPer";
            this.Lb_CedPer.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_CedPer.Size = new System.Drawing.Size(133, 27);
            this.Lb_CedPer.TabIndex = 301;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(494, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 229;
            this.label4.Text = "Status :";
            // 
            // Lb_CodMov
            // 
            this.Lb_CodMov.AutoSize = true;
            this.Lb_CodMov.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_CodMov.ForeColor = System.Drawing.Color.DarkRed;
            this.Lb_CodMov.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lb_CodMov.Location = new System.Drawing.Point(133, 7);
            this.Lb_CodMov.Name = "Lb_CodMov";
            this.Lb_CodMov.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Lb_CodMov.Size = new System.Drawing.Size(0, 34);
            this.Lb_CodMov.TabIndex = 211;
            this.Lb_CodMov.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label2.Location = new System.Drawing.Point(45, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 118;
            this.label2.Text = "Trabajador :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label3.Location = new System.Drawing.Point(83, 152);
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
            // Lb_FecDoc
            // 
            this.Lb_FecDoc.BackColor = System.Drawing.Color.White;
            this.Lb_FecDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_FecDoc.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Lb_FecDoc.Location = new System.Drawing.Point(139, 152);
            this.Lb_FecDoc.Name = "Lb_FecDoc";
            this.Lb_FecDoc.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_FecDoc.Size = new System.Drawing.Size(115, 27);
            this.Lb_FecDoc.TabIndex = 222;
            // 
            // Lb_NomPer
            // 
            this.Lb_NomPer.BackColor = System.Drawing.Color.White;
            this.Lb_NomPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_NomPer.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Lb_NomPer.Location = new System.Drawing.Point(139, 86);
            this.Lb_NomPer.Name = "Lb_NomPer";
            this.Lb_NomPer.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_NomPer.Size = new System.Drawing.Size(537, 27);
            this.Lb_NomPer.TabIndex = 221;
            // 
            // Lb_StaDoc
            // 
            this.Lb_StaDoc.BackColor = System.Drawing.Color.White;
            this.Lb_StaDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_StaDoc.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_StaDoc.Location = new System.Drawing.Point(559, 16);
            this.Lb_StaDoc.Name = "Lb_StaDoc";
            this.Lb_StaDoc.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_StaDoc.Size = new System.Drawing.Size(117, 27);
            this.Lb_StaDoc.TabIndex = 230;
            // 
            // Txt_CodPro
            // 
            this.Txt_CodPro.BackColor = System.Drawing.Color.White;
            this.Txt_CodPro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_CodPro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_CodPro.Enabled = false;
            this.Txt_CodPro.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Txt_CodPro.Location = new System.Drawing.Point(6, 255);
            this.Txt_CodPro.Name = "Txt_CodPro";
            this.Txt_CodPro.Size = new System.Drawing.Size(86, 27);
            this.Txt_CodPro.TabIndex = 301;
            this.Txt_CodPro.Visible = false;
            this.Txt_CodPro.Enter += new System.EventHandler(this.Txt_CodPro_Enter);
            this.Txt_CodPro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_CodPro_KeyDown);
            this.Txt_CodPro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_CodPro_KeyPress);
            // 
            // Lb_DesPro
            // 
            this.Lb_DesPro.BackColor = System.Drawing.Color.White;
            this.Lb_DesPro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_DesPro.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Lb_DesPro.Location = new System.Drawing.Point(94, 255);
            this.Lb_DesPro.Name = "Lb_DesPro";
            this.Lb_DesPro.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_DesPro.Size = new System.Drawing.Size(335, 27);
            this.Lb_DesPro.TabIndex = 305;
            this.Lb_DesPro.Visible = false;
            // 
            // Txt_CanMov
            // 
            this.Txt_CanMov.BackColor = System.Drawing.Color.White;
            this.Txt_CanMov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_CanMov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_CanMov.Enabled = false;
            this.Txt_CanMov.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Txt_CanMov.Location = new System.Drawing.Point(481, 255);
            this.Txt_CanMov.Name = "Txt_CanMov";
            this.Txt_CanMov.Size = new System.Drawing.Size(93, 27);
            this.Txt_CanMov.TabIndex = 303;
            this.Txt_CanMov.Visible = false;
            this.Txt_CanMov.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_CanMov_KeyDown);
            this.Txt_CanMov.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_CanMov_KeyPress);
            // 
            // Lb_UndUnm
            // 
            this.Lb_UndUnm.BackColor = System.Drawing.Color.White;
            this.Lb_UndUnm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_UndUnm.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Lb_UndUnm.Location = new System.Drawing.Point(431, 255);
            this.Lb_UndUnm.Name = "Lb_UndUnm";
            this.Lb_UndUnm.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_UndUnm.Size = new System.Drawing.Size(48, 27);
            this.Lb_UndUnm.TabIndex = 306;
            this.Lb_UndUnm.Visible = false;
            // 
            // Txt_CatMov
            // 
            this.Txt_CatMov.BackColor = System.Drawing.Color.White;
            this.Txt_CatMov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_CatMov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_CatMov.Enabled = false;
            this.Txt_CatMov.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Txt_CatMov.Location = new System.Drawing.Point(576, 255);
            this.Txt_CatMov.Name = "Txt_CatMov";
            this.Txt_CatMov.Size = new System.Drawing.Size(115, 27);
            this.Txt_CatMov.TabIndex = 307;
            this.Txt_CatMov.Visible = false;
            this.Txt_CatMov.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_CatMov_KeyDown);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Información";
            // 
            // listView1
            // 
            this.listView1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.listView1.AllowColumnReorder = true;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(6, 285);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(685, 171);
            this.listView1.TabIndex = 310;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // Cmd_UltmVac
            // 
            this.Cmd_UltmVac.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Cmd_UltmVac.Image = global::SISPROIN.Properties.Resources.UtiVac;
            this.Cmd_UltmVac.Location = new System.Drawing.Point(194, 460);
            this.Cmd_UltmVac.Name = "Cmd_UltmVac";
            this.Cmd_UltmVac.Size = new System.Drawing.Size(95, 71);
            this.Cmd_UltmVac.TabIndex = 311;
            this.Cmd_UltmVac.Text = "Insert";
            this.Cmd_UltmVac.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_UltmVac.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_UltmVac.UseVisualStyleBackColor = true;
            this.Cmd_UltmVac.Visible = false;
            this.Cmd_UltmVac.Click += new System.EventHandler(this.Cmd_UltmVac_Click);
            // 
            // Cmd_UltmPre
            // 
            this.Cmd_UltmPre.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Cmd_UltmPre.Image = global::SISPROIN.Properties.Resources.UtPre;
            this.Cmd_UltmPre.Location = new System.Drawing.Point(97, 460);
            this.Cmd_UltmPre.Name = "Cmd_UltmPre";
            this.Cmd_UltmPre.Size = new System.Drawing.Size(95, 71);
            this.Cmd_UltmPre.TabIndex = 309;
            this.Cmd_UltmPre.Text = "Page Down";
            this.Cmd_UltmPre.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_UltmPre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_UltmPre.UseVisualStyleBackColor = true;
            this.Cmd_UltmPre.Visible = false;
            this.Cmd_UltmPre.Click += new System.EventHandler(this.Cmd_UltmPre_Click);
            this.Cmd_UltmPre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmd_UltmPre_KeyDown);
            // 
            // Cmd_UltmEntr
            // 
            this.Cmd_UltmEntr.BackColor = System.Drawing.Color.Transparent;
            this.Cmd_UltmEntr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Cmd_UltmEntr.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Cmd_UltmEntr.Image = global::SISPROIN.Properties.Resources.UtiEntr;
            this.Cmd_UltmEntr.Location = new System.Drawing.Point(6, 460);
            this.Cmd_UltmEntr.Name = "Cmd_UltmEntr";
            this.Cmd_UltmEntr.Size = new System.Drawing.Size(89, 71);
            this.Cmd_UltmEntr.TabIndex = 308;
            this.Cmd_UltmEntr.Text = "Page Up";
            this.Cmd_UltmEntr.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cmd_UltmEntr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Cmd_UltmEntr.UseVisualStyleBackColor = false;
            this.Cmd_UltmEntr.Visible = false;
            this.Cmd_UltmEntr.Click += new System.EventHandler(this.Cmd_UltmEntr_Click);
            this.Cmd_UltmEntr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmd_UltmEntr_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label5.Location = new System.Drawing.Point(39, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 304;
            this.label5.Text = "Comentario :";
            // 
            // Txt_ComDoc
            // 
            this.Txt_ComDoc.BackColor = System.Drawing.Color.White;
            this.Txt_ComDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_ComDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_ComDoc.Enabled = false;
            this.Txt_ComDoc.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Txt_ComDoc.Location = new System.Drawing.Point(139, 119);
            this.Txt_ComDoc.Name = "Txt_ComDoc";
            this.Txt_ComDoc.Size = new System.Drawing.Size(537, 27);
            this.Txt_ComDoc.TabIndex = 303;
            this.Txt_ComDoc.Visible = false;
            this.Txt_ComDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_ComDoc_KeyDown);
            // 
            // Lb_ComDoc
            // 
            this.Lb_ComDoc.BackColor = System.Drawing.Color.White;
            this.Lb_ComDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lb_ComDoc.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Lb_ComDoc.Location = new System.Drawing.Point(139, 119);
            this.Lb_ComDoc.Name = "Lb_ComDoc";
            this.Lb_ComDoc.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Lb_ComDoc.Size = new System.Drawing.Size(537, 27);
            this.Lb_ComDoc.TabIndex = 305;
            // 
            // FormOBSEQUIOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(697, 461);
            this.Controls.Add(this.Cmd_UltmVac);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Cmd_UltmPre);
            this.Controls.Add(this.Cmd_UltmEntr);
            this.Controls.Add(this.Txt_CatMov);
            this.Controls.Add(this.Txt_CodPro);
            this.Controls.Add(this.Lb_DesPro);
            this.Controls.Add(this.Txt_CanMov);
            this.Controls.Add(this.Lb_UndUnm);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormOBSEQUIOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Obsequios";
            this.Load += new System.EventHandler(this.FormOBSEQUIOS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormOBSEQUIOS_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label Lb_StaDoc;
        private System.Windows.Forms.Label Lb_CodMov;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Lb_FecDoc;
        internal System.Windows.Forms.Label Lb_NomPer;
        internal System.Windows.Forms.TextBox Txt_CedPer;
        internal System.Windows.Forms.Label Lb_CedPer;
        internal System.Windows.Forms.TextBox Txt_CodPro;
        internal System.Windows.Forms.Label Lb_DesPro;
        internal System.Windows.Forms.TextBox Txt_CanMov;
        internal System.Windows.Forms.Label Lb_UndUnm;
        internal System.Windows.Forms.TextBox Txt_CatMov;
        internal System.Windows.Forms.Button Cmd_UltmPre;
        private System.Windows.Forms.Button Cmd_UltmEntr;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListView listView1;
        internal System.Windows.Forms.Button Cmd_UltmVac;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox Txt_ComDoc;
        internal System.Windows.Forms.Label Lb_ComDoc;
    }
}