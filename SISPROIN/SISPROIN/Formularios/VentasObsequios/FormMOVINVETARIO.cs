using LibPrintTicket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISPROIN.Clases;
using SISPROIN.Funciones;
using System.Net;
using System.Runtime.InteropServices;

namespace SISPROIN.Formularios.VentasObsequios
{
    public partial class FormMOVINVETARIO : Form
    {
        string[] TUsuario = new string[7];
        string Evento = "";
        string Evento2 = "";
        string vTipTid = "INV";
        bool SwActivoM = false;
        public static string cNomPc, cIp, cNomImp;
        public static IPAddress[] aIP;

       // [DllImport("user32.dll")]
       // static public extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
       // int SB_HORZ = 0;
       // int SB_VERT = 1;
       //// int SB_BOTH = 3;




        Fun_CONFPRINT FunCONFPRINT = new Fun_CONFPRINT();
        Utilitarios Util = new Utilitarios();
        _MOVINV MOVINV = new _MOVINV();
        Fun_MOVINV FunMOVINV = new Fun_MOVINV();
        Fun_PRODUCTOS FunPR = new Fun_PRODUCTOS();
        Fun_TIPTRAN FunTIPTRA = new Fun_TIPTRAN();

        public FormMOVINVETARIO(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
            LoadConfPrint();
            BotonesNormal(true);
            GenColumnas();
            MOVINV = FunMOVINV.BuscarUltimo();
            Asignar();

            // listView1.Scrollable = false;
            // ShowScrollBar(listView1.Handle, (int)SB_VERT, true);
            //ShowScrollBar(listView1.Handle, SB_VERT, false);

            //    ShowScrollBar(listView1.Handle, SB_HORZ, false);
        }

        private int GetTamaUltColum()
        {
            int Tam = 0;
            for (int i = 0; i < listView1.Columns.Count - 1; i++)
            {
                Tam += listView1.Columns[i].Width;
            }
            return listView1.Width - Tam;
        }
        private void ResideCol()
        {
            //listView1.Columns[0].Width = Width - 4 - SystemInformation.HorizontalScrollBarArrowWidth;
            if (((listView1.Height - 21.28)) < 21.28 * listView1.Items.Count)
            {

                listView1.Columns[listView1.Columns.Count - 1].Width = GetTamaUltColum() - 20;

            }
            else
            {

                listView1.Columns[listView1.Columns.Count - 1].Width = GetTamaUltColum();

            }
          
        }

        protected void GenColumnas()
        {
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            listView1.HideSelection = false;
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Cod. Producto", 84, HorizontalAlignment.Left);
            listView1.Columns.Add("Descripcion del Producto", 355, HorizontalAlignment.Center);
            listView1.Columns.Add("Unid.", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("Cant. KLG", 96, HorizontalAlignment.Center);
            listView1.Columns.Add("Cant. UND", 96, HorizontalAlignment.Center);
            listView1.Columns.Add("Costo", 96, HorizontalAlignment.Center);
            listView1.Columns.Add("Total", 120, HorizontalAlignment.Center);
        }

        private void BotonesNormal(bool Mostrar)
        {
            Cmd_Nuevo.Visible = Mostrar;
            //Cmd_Modificar.Visible = Mostrar;
            Cmd_Primero.Visible = Mostrar;
            Cmd_Anterior.Visible = Mostrar;
            Cmd_Siguiente.Visible = Mostrar;
            Cmd_Ultimo.Visible = Mostrar;
            Cmd_Eliminar.Visible = Mostrar;
            Cmd_Imprimir.Visible = Mostrar;
            Cmd_Buscar.Visible = Mostrar;
        }

        private void BotonesControl(bool Mostrar)
        {
            Cmd_Guardar.Visible = Mostrar;
            Cmd_Cancelar.Visible = Mostrar;
        }

        private void Lbl(bool Mostrar)
        {
            Lb_TipTra.Visible = Mostrar;
            Lb_ComMov.Visible = Mostrar;
            Lb_FecMov.Visible = Mostrar;
            Lb_StaMov.Visible = Mostrar;
        }

        private void Bloqueos()
        {
            BotonesNormal(true);
            BotonesControl(false);
            Lbl(true);
            MenulistView(false);
            listView1.Items.Clear();
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox IMPUT = ctrl as TextBox;
                    IMPUT.Visible = false;
                    IMPUT.Enabled = false;
                    IMPUT.BackColor = Color.White;
                }
            }
            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox IMPUT = ctrl as TextBox;
                    IMPUT.Clear();
                    IMPUT.Enabled = false;
                    IMPUT.BackColor = Color.White;
                }
            }
            foreach (Control ctrl in Controls)
            {
                if (ctrl is Label)
                {
                    Label IMPUT = ctrl as Label;
                    IMPUT.Text = "";
                    IMPUT.Enabled = false;
                    IMPUT.BackColor = Color.White;
                }
            }
        }
        private void Desbloqueos()
        {
            BotonesNormal(false);
            BotonesControl(true);
            Lbl(false);
            if (Evento.CompareTo("Nuevo") == 0)
            {
                listView1.Items.Clear();
                foreach (Control ctrl in panel1.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        TextBox IMPUT = ctrl as TextBox;
                        IMPUT.Clear();
                        IMPUT.Visible = true;
                    }
                }
            }
            else
            {
                if (Evento.CompareTo("Modificar") == 0)
                {
                    foreach (Control ctrl in panel1.Controls)
                    {
                        if (ctrl is TextBox)
                        {
                            TextBox IMPUT = ctrl as TextBox;
                            IMPUT.Visible = true;
                        }
                    }
                }
            }
        }

        private void Asignar()
        {
            AsignarENC();
            AsignarDET();
        }

        private void AsignarENC()
        {
            Txt_TipTra.Text = MOVINV.tiptra;
            Txt_ComMov.Text = MOVINV.commov;
            Txt_DotMov.Text = MOVINV.dotmov;
            Llenar_Lb_TipTra(MOVINV.tiptra);
            Lb_TipTra.Text = MOVINV.tiptra;
            Lb_CodMov.Text = MOVINV.codmov.ToString().PadLeft(8, '0');
            Lb_FecMov.Text = MOVINV.fecmov.ToShortDateString();
            Lb_ComMov.Text = MOVINV.commov;
            Lb_DotMov.Text = MOVINV.dotmov;
            if (MOVINV.stamov == 1)
            {
                Lb_StaMov.Text = "Activo";
                Lb_StaMov.ForeColor = Color.Green;
            }
            else
            {
                Lb_StaMov.Text = "Anulado";
                Lb_StaMov.ForeColor = Color.Red;
            }
        }

        private void AsignarDET()
        {
            FunMOVINV.GetLisMOVINVENTARIO(Convert.ToInt32(Lb_CodMov.Text), listView1);
           // ResideCol();
        }

        private void Actualizar()
        {
            MOVINV = FunMOVINV.Buscar(MOVINV.codmov);
            Asignar();
        }

        private void Cmd_Guardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (Evento.CompareTo("Nuevo") == 0)
                {
                    DialogResult result1;
                    result1 = MessageBox.Show("¿Desea guardar el Movimiento?", "Seleccione una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result1 == DialogResult.Yes)
                    {
                        int vStaMov = 1;
                        MOVINV = new _MOVINV(Convert.ToInt32(FunMOVINV.Correlativo()), Util.GetDate(), Txt_TipTra.Text, Txt_ComMov.Text, Txt_DotMov.Text, vStaMov);
                        if (FunMOVINV.Nuevo(MOVINV))
                        {
                            for (int i = 0; i < listView1.Items.Count; i++)
                            {
                                MOVINV = new _MOVINV(Convert.ToInt32(Lb_CodMov.Text), MOVINV.cedper, Convert.ToInt32(listView1.Items[i].SubItems[0].Text), Util.GetDate(),
                                    Txt_TipTra.Text, Util.FormatDecimal(listView1.Items[i].SubItems[3].Text), Convert.ToInt32(listView1.Items[i].SubItems[4].Text),
                                    Util.FormatDecimal(listView1.Items[i].SubItems[5].Text), MOVINV.predoc, Util.FormatDecimal(listView1.Items[i].SubItems[6].Text), vTipTid, listView1.Items[i].SubItems[2].Text, FunPR.Sent_TipIVA(Convert.ToInt32(listView1.Items[i].SubItems[0].Text)), vStaMov, TUsuario[0]);
                                FunMOVINV.NuevoDET(MOVINV);
                            }
                            DialogResult result2;
                            result2 = MessageBox.Show("¿Desea imprimir la ticket de Movimiento?", "Seleccione una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result2 == DialogResult.Yes)
                            {
                                PrintTicket();
                            }
                            Bloqueos();
                            Actualizar();
                        }
                        else
                        {
                            MessageBox.Show("El correlativo ya existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
        }

        public bool ValidarDatos()
        {
            if (Txt_ComMov.Text.Trim() == "" || !(listView1.Items.Count > 0))
            {
                MessageBox.Show("Debe llenar todos los campos.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
                return true;
        }

        private void Cmd_Nuevo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TUsuario[6]) < 5)
            {
                Evento = "Nuevo";
                Desbloqueos();
                Lb_CodMov.Text = FunMOVINV.Correlativo().PadLeft(8, '0'); 
                Txt_TipTra.Enabled = true;
                Txt_TipTra.BackColor = Color.Turquoise;
                Txt_TipTra.Focus();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Modificar_Click(object sender, EventArgs e)
        {
           
        }

        private void Cmd_Primero_Click(object sender, EventArgs e)
        {
            MOVINV = FunMOVINV.BuscarPrimero();
            Asignar();
        }

        private void Cmd_Anterior_Click(object sender, EventArgs e)
        {
            MOVINV = FunMOVINV.BuscarAnterior(MOVINV);
            Asignar();
        }

        private void Cmd_Siguiente_Click(object sender, EventArgs e)
        {
            MOVINV = FunMOVINV.BuscarSiguiente(MOVINV);
            Asignar();
        }

        private void Cmd_Ultimo_Click(object sender, EventArgs e)
        {
            MOVINV = FunMOVINV.BuscarUltimo();
            Asignar();
        }

        private void Cmd_Buscar_Click(object sender, EventArgs e)
        {
            FormBUSQUEDAS f = new FormBUSQUEDAS();
            f.ListaMovimientos();
            f.ShowDialog();
            if (f._CodInv != "")
            {
                MOVINV = FunMOVINV.Buscar(Convert.ToInt32(f._CodInv));
                Actualizar();
            }
        }

        private void Cmd_Eliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TUsuario[6]) < 3)
            {
                MOVINV = FunMOVINV.Buscar(Convert.ToInt32(Lb_CodMov.Text));
                if (MOVINV.stamov == 1)
                {
                    DialogResult result;
                    result = MessageBox.Show("¿Esta seguro que desea anular el movimiento.?", "Seleccione una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int vStaMov = 0;
                        MOVINV = new _MOVINV(Convert.ToInt32(Lb_CodMov.Text), vStaMov);
                        if (FunMOVINV.AnularENC_MOV(MOVINV))
                        {
                            for (int i = 0; i < listView1.Items.Count; i++)
                            {
                                MOVINV = new _MOVINV(Convert.ToInt32(Lb_CodMov.Text), vStaMov, TUsuario[0]);
                                FunMOVINV.AnularDET_MOV(MOVINV);
                            }
                            MessageBox.Show("El documento se anuló correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Actualizar();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El documento se encuentra anulado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Actualizar();
                }
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void Cmd_Imprimir_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TUsuario[6]) < 4)
            {
                MOVINV = FunMOVINV.Buscar(MOVINV.codmov);
                if (MOVINV.stamov == 1)
                {
                    PrintTicket();
                }
                else
                {
                    PrintTicketNullified();
                }
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Aceptar_Click(object sender, EventArgs e)
        {

        }

        private void Cmd_Cancelar_Click(object sender, EventArgs e)
        {
            Bloqueos();
            MOVINV = FunMOVINV.BuscarUltimo();
            Asignar();
        }

        private void MenulistView(bool Mostrar)
        {
            Txt_CodPro.Visible = Mostrar;
            Lb_DesPro.Visible = Mostrar;
            Lb_UndUnm.Visible = Mostrar;
            Txt_CanMov.Visible = Mostrar;
            Txt_CatMov.Visible = Mostrar;
            Lb_CosMov.Visible = Mostrar;
        }

        private void MenulistViewReset()
        {
            Txt_CodPro.Clear();
            Txt_CodPro.Enabled = false;
            Txt_CodPro.BackColor = Color.White;

            Txt_CanMov.Clear();
            Txt_CanMov.Enabled = false;
            Txt_CanMov.BackColor = Color.White;

            Txt_CatMov.Clear();
            Txt_CatMov.Enabled = false;
            Txt_CatMov.BackColor = Color.White;
        }


        private void MenuProductoLimpial()
        {
            Txt_CodPro.Text = "";
            Lb_DesPro.Text = "";
            Lb_UndUnm.Text = "";
            Txt_CanMov.Text = "";
            Txt_CatMov.Text = "";
            Lb_CosMov.Text = "";
        }

        private void Llenar_Lb_DesPro(int vcodigo)
        {
            Lb_DesPro.Text = FunPR.Sent_DesPro(vcodigo);
        }

        private void Llenar_Lb_UndUnm(int vcodigo)
        {
            Lb_UndUnm.Text = FunPR.Sent_UndUnm(vcodigo);
        }

        private void Llenar_Lb_PrePro(int vcodigo)
        {
            Lb_CosMov.Text = FunPR.Sent_PrePro(vcodigo);
        }

        private void Llenar_Lb_TipTra(string vcodigo)
        {
            Lb_DesTra.Text = FunTIPTRA.Search_TipTra(vcodigo);
        }

        private void Txt_TipTra_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_TipTra.Text.Trim() != "")
                    {
                        if (FunTIPTRA.Existe(Txt_TipTra.Text))
                        {
                            if (FunTIPTRA.StatusAI(Txt_TipTra.Text))
                            {
                                Llenar_Lb_TipTra(Txt_TipTra.Text);
                                Util.CambiarTxt(Txt_TipTra, Txt_ComMov);
                            }
                            else
                            {
                                MessageBox.Show("La transacción se encuentra inactiva", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Txt_TipTra.SelectAll();
                            }

                        }
                        else
                        {
                            MessageBox.Show("La transacción no existe en el sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_TipTra.SelectAll();
                        }
                    }
                    else
                    {
                        FormBUSQUEDAS f = new FormBUSQUEDAS();
                        f.ListaTransaccionesAI();
                        f.ShowDialog();
                        if (f._TipTra != "")
                        {
                            Txt_TipTra.Text = f._TipTra;
                            Llenar_Lb_TipTra(Txt_TipTra.Text);
                            Util.CambiarTxt(Txt_TipTra, Txt_ComMov);
                           
                        }
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Cmd_Cancelar.PerformClick();
                    break;
            }
        }

    
        private void Txt_ComMov_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_ComMov.Text.Trim() != "")
                    {
                        Util.CambiarTxt(Txt_ComMov, Txt_DotMov);
                    }
                    else
                    {
                        MessageBox.Show("El campo de comentario está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_ComMov, Txt_TipTra);
                    break;
            }
        }

        private void Txt_DotMov_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    MenulistView(true);
                        Util.CambiarTxt(Txt_DotMov, Txt_CodPro);
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_DotMov, Txt_ComMov);
                    break;
            }
        }

        private void Txt_CodPro_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_CodPro.Text.Trim() != "")
                    {
                        if (FunPR.Existe(Convert.ToInt32(Txt_CodPro.Text)))
                        {
                            if (FunPR.StatudAI(Convert.ToInt32(Txt_CodPro.Text)))
                            {
                                Llenar_Lb_DesPro(Convert.ToInt32(Txt_CodPro.Text));
                                Llenar_Lb_UndUnm(Convert.ToInt32(Txt_CodPro.Text));
                                Llenar_Lb_PrePro(Convert.ToInt32(Txt_CodPro.Text));
                                Util.CambiarTxt(Txt_CodPro, Txt_CanMov);
                                Txt_CanMov.Text = "0";
                                Txt_CanMov.SelectAll();
                            }
                            else
                            {
                                MessageBox.Show("El producto se encuentra inativo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Txt_CodPro.SelectAll();
                            }
                        }
                        else
                        {
                            MessageBox.Show("El producto no extiste.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_CodPro.SelectAll();
                        }
                    }
                    else
                    {
                        FormBUSQUEDAS f = new FormBUSQUEDAS();
                        f.ListaProductosAI();
                        f.ShowDialog();
                        if (f._CodPro != "")
                        {
                            Txt_CodPro.Text = f._CodPro;
                            Llenar_Lb_DesPro(Convert.ToInt32(Txt_CodPro.Text));
                            Llenar_Lb_UndUnm(Convert.ToInt32(Txt_CodPro.Text));
                            Llenar_Lb_PrePro(Convert.ToInt32(Txt_CodPro.Text));
                            Util.CambiarTxt(Txt_CodPro, Txt_CanMov);
                            Txt_CanMov.Text = "0";
                            Txt_CanMov.SelectAll();
                        }
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_CodPro, Txt_DotMov);
                    MenulistView(false);
                    Txt_CodPro.Text = "";
                    break;
            }
        }

      
        private void Txt_CanMov_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_CanMov.Text.Trim() != "" && Convert.ToDecimal(Txt_CanMov.Text) > 0)
                    {
                        Util.CambiarTxt(Txt_CanMov, Txt_CatMov);
                        Txt_CatMov.Text = "0";
                        Txt_CatMov.SelectAll();
                    }
                    else
                    {
                        MessageBox.Show("El campo de cantidad debe ser mayor a 0 ó esta vaio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Txt_CanMov.SelectAll();
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_CanMov, Txt_CodPro);
                    SwActivoM = false;
                    break;
            }
        }

        private void Txt_CatMov_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
                    e.SuppressKeyPress = false;
                    if (Txt_CatMov.Text.Trim() != "" && Convert.ToInt32(Txt_CatMov.Text) > 0)
                    {
                        if (Evento.CompareTo("Nuevo") == 0)
                        {
                            decimal Total = Convert.ToDecimal(Txt_CanMov.Text.Trim()) * Convert.ToDecimal(Lb_CosMov.Text.Trim());
                            string Result = string.Format("{0:0.00}", Total);
                            string Vindex = Txt_CodPro.Text.PadLeft(8, '0');
                            ListViewItem itmx = listView1.FindItemWithText(Vindex);
                            if (itmx == null)
                            {
                                string[] Arra = { Txt_CodPro.Text.Trim().PadLeft(8, '0'), Lb_DesPro.Text.Trim(), Lb_UndUnm.Text, Txt_CanMov.Text.Trim(), Txt_CatMov.Text.Trim(), Lb_CosMov.Text, Result };
                                ListViewItem itm = new ListViewItem(Arra);
                                listView1.Items.Add(itm);
                                listView1.SelectedItems.Clear();
                                listView1.FocusedItem = null;
                                listView1.Refresh();
                                Util.CambiarTxt(Txt_CatMov, Txt_CodPro);
                                MenuProductoLimpial();
                            }
                            else
                            {
                                if (Evento2.CompareTo("Modificar") == 0 && SwActivoM == true)
                                {
                                    listView1.SelectedItems[0].SubItems[3].Text = Txt_CanMov.Text;
                                    listView1.SelectedItems[0].SubItems[4].Text = Txt_CatMov.Text;
                                    Util.CambiarTxt(Txt_CatMov, Txt_CodPro);
                                    MenuProductoLimpial();
                                    SwActivoM = false;
                                }
                                else
                                {
                                    MessageBox.Show("El producto ya existe en la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    //itmx.Remove();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo de cantidad debe ser mayor a 0 ó esta vaio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Txt_CanMov.SelectAll();
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_CatMov, Txt_CanMov);
                    
                    break;
            }
        }

        private void PrintTicket()
        {
            MOVINV = FunMOVINV.Buscar(Convert.ToInt32(Lb_CodMov.Text));
            DateTime now = Util.GetDate();
            string cPath;

            Ticket ticket = new Ticket();
            cPath = Application.ExecutablePath.Replace("SISPROIN.exe", "") + @"logo.png";
            //cPath = cPath.Replace("SGVB.EXE", "");
            //cPath = cPath.Replace("sgvb.exe", "");
            //cPath = cPath.Replace("SGVB.exe", "");
            //cPath = cPath.Replace("sgvb.EXE", "");

            ticket.HeaderImage = Image.FromFile(cPath);
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("          TODOVITO I, C.A");
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("RIF: J-29633565-6");
            ticket.AddHeaderLine("DIREC: Carretera panamericana Km.35sector cumbre roja entrada caña ");
            ticket.AddHeaderLine("larga.");
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("Documento: Movimiento de Inventario");
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("Realizado Por:"+ TUsuario[1]);
            ticket.AddHeaderLine("MOVIMIENTO Ticket #" + Lb_CodMov.Text);
            ticket.AddHeaderLine("***********************************");
            ticket.AddHeaderLine("Condición: "+ Lb_DesTra.Text);
            ticket.AddSubHeaderLine("Fecha:" + MOVINV.fecmov.ToShortDateString() + " Hora:" + MOVINV.fecmov.ToShortTimeString());

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ticket.AddItem(Util.FormatDecimal(listView1.Items[i].SubItems[3].Text).ToString("N2") + "" + listView1.Items[i].SubItems[2].Text, "       " + listView1.Items[i].SubItems[1].Text, "");
            }

            cNomImp = FunCONFPRINT.LoadPRINT(cNomPc, cIp);
            if (cNomImp != "")
            {
                ticket.PrintTicket(cNomImp);//Nombre de la impresora ticketera
            }
            else
            {
                MessageBox.Show("No ha configurado la impresora de ticket", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void PrintTicketNullified()
        {
            MOVINV = FunMOVINV.Buscar(Convert.ToInt32(Lb_CodMov.Text));
            DateTime now = Util.GetDate();
            string cPath;

            Ticket ticket = new Ticket();
            cPath = Application.ExecutablePath.Replace("SISPROIN.exe", "") + @"logo.png";
            //cPath = cPath.Replace("SGVB.EXE", "");
            //cPath = cPath.Replace("sgvb.exe", "");
            //cPath = cPath.Replace("SGVB.exe", "");
            //cPath = cPath.Replace("sgvb.EXE", "");

            ticket.HeaderImage = Image.FromFile(cPath);
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("          TODOVITO I, C.A");
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("RIF: J-29633565-6");
            ticket.AddHeaderLine("DIREC: Carretera panamericana Km.35sector cumbre roja entrada caña ");
            ticket.AddHeaderLine("larga.");
            ticket.AddHeaderLine("        DOCUMENTO ANULADO");
            ticket.AddHeaderLine("Documento: Movimiento de Inventario");
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("Realizado Por:" + TUsuario[1]);
            ticket.AddHeaderLine("MOVIMIENTO Ticket #" + Lb_CodMov.Text);
            ticket.AddHeaderLine("***********************************");
            ticket.AddHeaderLine("Condición: " + Lb_DesTra.Text);
            ticket.AddSubHeaderLine("Fecha:" + MOVINV.fecmov.ToShortDateString() + " Hora:" + MOVINV.fecmov.ToShortTimeString());

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ticket.AddItem(Util.FormatDecimal(listView1.Items[i].SubItems[3].Text).ToString("N2") + "" + listView1.Items[i].SubItems[2].Text, "       " + listView1.Items[i].SubItems[1].Text, "");
            }

            cNomImp = FunCONFPRINT.LoadPRINT(cNomPc, cIp);
            if (cNomImp != "")
            {
                ticket.PrintTicket(cNomImp);//Nombre de la impresora ticketera
            }
            else
            {
                MessageBox.Show("No ha configurado la impresora de ticket", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoadConfPrint()
        {
            string server_ip = "";
            int i;
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress a in localIPs)
            {
                if (a.ToString().Length <= 15 & a.ToString().Substring(0, 3) == "192")
                {
                    server_ip = server_ip + a.ToString();
                }
            }
            cIp = server_ip;
            cNomPc = Dns.GetHostName();

            if (cIp == "" || cIp == null)
            {
                aIP = Dns.GetHostAddresses(cNomPc);

                for (i = 0; i < aIP.Length; i++)
                {
                    cIp = aIP[i].ToString();
                }
            }

            if (cIp == null)
            {
                cIp = "";
            }
        }


        private void Txt_CodPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.SoloNumero(e);
        }

        private void Txt_CanMov_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.SoloNumeroDecimales(sender, e, Txt_CanMov);
        }

        private void Txt_CosMov_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Txt_CodPro_Enter(object sender, EventArgs e)
        {
            Lb_DesPro.Text = "";
            Lb_UndUnm.Text = "";
            Lb_CosMov.Text = "";
            Txt_CanMov.Clear();
            Txt_CatMov.Clear();
        }

        private void FormMOVINVETARIO_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    e.SuppressKeyPress = true;
                    Cmd_Nuevo.PerformClick();
                    break;
                case Keys.F2:
                    e.SuppressKeyPress = true;
                    Cmd_Modificar.PerformClick();
                    break;
                case Keys.F3:
                    e.SuppressKeyPress = true;
                    Cmd_Primero.PerformClick();
                    break;
                case Keys.F4:
                    e.SuppressKeyPress = true;
                    Cmd_Anterior.PerformClick();
                    break;
                case Keys.F5:
                    e.SuppressKeyPress = true;
                    Cmd_Siguiente.PerformClick();
                    break;
                case Keys.F6:
                    e.SuppressKeyPress = true;
                    Cmd_Ultimo.PerformClick();
                    break;
                case Keys.F7:
                    e.SuppressKeyPress = true;
                    Cmd_Buscar.PerformClick();
                    break;
                case Keys.F8:
                    e.SuppressKeyPress = true;
                    Cmd_Eliminar.PerformClick();
                    break;
                case Keys.F9:
                    e.SuppressKeyPress = true;
                    Cmd_Imprimir.PerformClick();
                    break;
                case Keys.F10:
                    e.SuppressKeyPress = true;
                    Cmd_Aceptar.PerformClick();
                    break;
                case Keys.F11:
                    e.SuppressKeyPress = true;
                    Cmd_Guardar.PerformClick();
                    break;
                case Keys.F12:
                    e.SuppressKeyPress = true;
                    Cmd_Cancelar.PerformClick();
                    break;
            }
        }

        private void Txt_CatMov_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.SoloNumero(e);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (Evento.CompareTo("Nuevo") == 0)
            {
                AcOpcion();
            }
        }

        private void Txt_TipTra_Enter(object sender, EventArgs e)
        {
            Lb_DesTra.Text = "";
            listView1.Items.Clear();
        }

        private void AcOpcion()
        {
            FormOPCIONES F = new FormOPCIONES();
            F.Lb_Titulo1.Text = "Opciones";
            F.Lb_Titulo2.Text = "ESC - Salir";
            F.Opc = new string[] { "Nuevo", "Modificar", "Eliminar" };
            //this.Hide();
            F.ShowDialog();
            this.Show();
            // MessageBox.Show(F.Returno);
            switch (F.Returno)
            {
                case "1":
                    Evento2 = "Nuevo";
                    MenulistView(true);
                    MenulistViewReset();
                    Txt_CodPro.Clear();
                    Txt_CodPro.Enabled = true;
                    Txt_CodPro.Focus();
                    Txt_CodPro.SelectAll();
                    Txt_CodPro.BackColor = Color.Turquoise;
                    break;
                case "2":
                    if (listView1.SelectedItems.Count > 0)
                    {
                        Evento2 = "Modificar";
                        MenulistView(true);
                        MenulistViewReset();


                        Txt_CodPro.Text = listView1.SelectedItems[0].SubItems[0].Text;
                        Lb_DesPro.Text = listView1.SelectedItems[0].SubItems[1].Text;
                        Lb_UndUnm.Text = listView1.SelectedItems[0].SubItems[2].Text;
                        Txt_CanMov.Text = listView1.SelectedItems[0].SubItems[3].Text;
                        Txt_CatMov.Text = listView1.SelectedItems[0].SubItems[4].Text;
                        Lb_CosMov.Text = listView1.SelectedItems[0].SubItems[5].Text;

                        Txt_CanMov.Enabled = true;
                        Txt_CanMov.Focus();
                        Txt_CanMov.SelectAll();
                        Txt_CanMov.BackColor = Color.Turquoise;
                        SwActivoM = true;
                    }
                    break;
                case "3":
                    foreach (ListViewItem item in listView1.SelectedItems)
                    {
                        listView1.Items.Remove(item);
                    }
                    if (listView1.Items.Count == 0)
                    {
                        Evento2 = "Nuevo";
                        MenulistView(true);
                        MenulistViewReset();

                        Txt_CodPro.Clear();
                        Txt_CodPro.Enabled = true;
                        Txt_CodPro.Focus();
                        Txt_CodPro.SelectAll();
                        Txt_CodPro.BackColor = Color.Turquoise;
                    }
                    break;
                default:
                    //MessageBox.Show("ESCAPE");
                    break;
            }
        }
    }
}
