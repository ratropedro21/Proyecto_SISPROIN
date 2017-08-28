using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibPrintTicket;
using System.Net;
using SISPROIN.Clases;
using SISPROIN.Funciones;
using System.Runtime.InteropServices;

namespace SISPROIN.Formularios.VentasObsequios
{
    public partial class FormOBSEQUIOS : Form
    {
        string[] TUsuario = new string[7];
        string Evento = "";
        string Evento2 = "";
        string vTipTid = "OBS";
        string Gift = "S005";
        string Present = "S006";
        string Vacation = "S007";
        bool isPresent = false;
        bool isVacation = false;
        bool SwActivoM = false;
        public static string cNomPc, cIp, cNomImp;
        public static IPAddress[] aIP;
        DateTime mondayOfTheWeek = new DateTime();
        DateTime sundayOfTheWeek = new DateTime();
        DateTime StartMonth = new DateTime();
        DateTime EndMonth = new DateTime();



        _PERSONAL empleado;
        Utilitarios Util = new Utilitarios();
        Fun_CONFPRINT FunCONFPRINT = new Fun_CONFPRINT();
        _VENOBSDOC VOD = new _VENOBSDOC();
        _MOVINV MOVINV = new _MOVINV();
        _PERSONAL PER = new _PERSONAL();
        _VACACION VAC;
        Fun_VENOBSDOC FunVOD = new Fun_VENOBSDOC();
        Fun_PERSONAL FunPER = new Fun_PERSONAL();
        Fun_PRODUCTOS FunPR = new Fun_PRODUCTOS();
        Fun_MOVINV FunMOVINV = new Fun_MOVINV();
        Fun_ASISTEDIA FunASD = new Fun_ASISTEDIA();
        Fun_GRUPCOMOBS FunGCO = new Fun_GRUPCOMOBS();
        Fun_VACACION FunVAC = new Fun_VACACION();
        Fun_TIPTRAN FunTIPTRA = new Fun_TIPTRAN();

        public FormOBSEQUIOS(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
            LoadConfPrint();
            BotonesNormal(true);
            GenColumnas();
            VOD = FunVOD.BuscarUltimo();
            Asignar();
        }

        public void semana()
        {
            DateTime referenceDate = Util.GetDate();
            DayOfWeek referenceDayOfWeek = referenceDate.DayOfWeek;

            int diffDaysFromMonday = DayOfWeek.Monday - referenceDayOfWeek;
            if (diffDaysFromMonday > 0) { diffDaysFromMonday -= 7; }
            mondayOfTheWeek = referenceDate.AddDays(diffDaysFromMonday);

            int diffDaysToSunday = (DayOfWeek.Sunday - referenceDayOfWeek);
            if (diffDaysToSunday < 0) { diffDaysToSunday += 7; }
            sundayOfTheWeek = referenceDate.AddDays(diffDaysToSunday);
            //vLunes = mondayOfTheWeek;
            //vDomingo = sundayOfTheWeek;
            // return;
            //mondayOfTheWeek = referenceDate;
            //while (mondayOfTheWeek.DayOfWeek != DayOfWeek.Monday)
            //{
            //    mondayOfTheWeek = mondayOfTheWeek.AddDays(-1);
            //}

            //sundayOfTheWeek = referenceDate;
            //while (sundayOfTheWeek.DayOfWeek != DayOfWeek.Sunday)
            //{
            //    sundayOfTheWeek = sundayOfTheWeek.AddDays(1);
            //}
        }

        public void mesual()
        {
            DateTime referenceDate = Util.GetDate();
            referenceDate = DateTime.Today;
            StartMonth = new DateTime(referenceDate.Year, referenceDate.Month, 1);
            EndMonth = new DateTime(referenceDate.Year, referenceDate.Month + 1, 1).AddDays(-1);
        }

        protected void GenColumnas()
        {
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            listView1.HideSelection = false;
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Cod. Producto", 84, HorizontalAlignment.Left);
            listView1.Columns.Add("Descripcion del Producto", 338, HorizontalAlignment.Center);
            listView1.Columns.Add("Unid.", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("Cant. KLG", 96, HorizontalAlignment.Center);
            listView1.Columns.Add("Cant. UND", 96, HorizontalAlignment.Center);
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
            //Cmd_UltmEntr.Visible = Mostrar;
            //Cmd_UltmPre.Visible = Mostrar;
        }

        private void BotonesControl(bool Mostrar)
        {
            Cmd_Guardar.Visible = Mostrar;
            Cmd_Cancelar.Visible = Mostrar;
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

        private void Lbl(bool Mostrar)
        {
            Lb_CedPer.Visible = Mostrar;
            Lb_FecDoc.Visible = Mostrar;
            Lb_StaDoc.Visible = Mostrar;
        }

        private void MenulistView(bool Mostrar)
        {
            Txt_CodPro.Visible = Mostrar;
            Lb_DesPro.Visible = Mostrar;
            Lb_UndUnm.Visible = Mostrar;
            Txt_CanMov.Visible = Mostrar;
            Txt_CatMov.Visible = Mostrar;
            Cmd_UltmEntr.Visible = Mostrar;
            Cmd_UltmPre.Visible = Mostrar;
            Cmd_UltmVac.Visible = Mostrar;
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

        private void MenulistViewLimpial()
        {
            Txt_CodPro.Text = "";
            Lb_DesPro.Text = "";
            Lb_UndUnm.Text = "";
            Txt_CanMov.Text = "";
            Txt_CatMov.Text = "";
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
            Txt_CedPer.Text = VOD.cedper.ToString();
            Txt_ComDoc.Text = VOD.comdoc;
            Lb_CodMov.Text = VOD.codmov.ToString().PadLeft(8, '0');

            Lb_CedPer.Text = VOD.cedper.ToString();
            Lb_ComDoc.Text = VOD.comdoc;
            Lb_FecDoc.Text = VOD.fecdoc.ToShortDateString();
            Llenar_Lb_NomPer(VOD.cedper);

            if (VOD.stadoc == 1)
            {
                Lb_StaDoc.Text = "Activo";
                Lb_StaDoc.ForeColor = Color.Green;
            }
            else
            {
                Lb_StaDoc.Text = "Anulado";
                Lb_StaDoc.ForeColor = Color.Red;
            }
        }

        private void AsignarDET()
        {
            FunMOVINV.GetLisOBSEQUIO(Convert.ToInt32(Lb_CodMov.Text), listView1);
            //ResideCol();
        }

        private void Actualizar()
        {
            VOD = FunVOD.Buscar(VOD.codmov);
            Asignar();
        }

        private void Llenar_Lb_NomPer(int vcedper)
        {
            Lb_NomPer.Text = FunPER.Sent_NomPer(vcedper);
        }

        private void Llenar_Lb_DesPro(int vcodpro)
        {
            Lb_DesPro.Text = FunPR.Sent_DesPro(vcodpro);
        }

        private void Llenar_Lb_UndUnm(int vcodpro)
        {
            Lb_UndUnm.Text = FunPR.Sent_UndUnm(vcodpro);
        }

        private void Cmd_Guardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (Evento.CompareTo("Nuevo") == 0)
                {
                    int vCxcDoc = 1;
                    string vEstDoc = "PAGADA";
                    string vConDoc = "CONTADO";
                    int vStaMov = 1;
                    string vTipTra1 = "S005";

                    DateTime now = Util.GetDate();
                    DialogResult result1;
                    result1 = MessageBox.Show("¿Desea guardar el Obsequio?", "Seleccione una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result1 == DialogResult.Yes)
                    {
                        VOD = new _VENOBSDOC(Convert.ToInt32(FunVOD.Correlativo()), Convert.ToInt32(Txt_CedPer.Text.Trim()), now, VOD.netdoc, VOD.brudoc, VOD.mtidoc,
                        VOD.codrec, vTipTid, vCxcDoc, vEstDoc, vConDoc, vStaMov, Txt_ComDoc.Text);
                        if (FunVOD.NuevoOBS(VOD))
                        {

                            for (int i = 0; i < listView1.Items.Count; i++)
                            {
                                empleado = FunPER.findById(Convert.ToInt32(Txt_CedPer.Text));
                                if (Convert.ToInt32(listView1.Items[i].SubItems[0].Text) == 1 && empleado.isBirthday() && listView1.Items[i].SubItems[1].Text.Contains("CUMPLEAÑO"))
                                {
                                    MOVINV = new _MOVINV(Convert.ToInt32(Lb_CodMov.Text), Convert.ToInt32(Txt_CedPer.Text), Convert.ToInt32(listView1.Items[i].SubItems[0].Text), Util.GetDate(),
                                        Present, Util.FormatDecimal(listView1.Items[i].SubItems[3].Text), Convert.ToInt32(listView1.Items[i].SubItems[4].Text),
                                        MOVINV.cosmov, MOVINV.predoc, MOVINV.totmov, vTipTid, listView1.Items[i].SubItems[2].Text, FunPR.Sent_TipIVA(Convert.ToInt32(listView1.Items[i].SubItems[0].Text)), vStaMov, TUsuario[0]);
                                    FunMOVINV.NuevoDET(MOVINV);
                                }
                                else if (VAC.codvac != 0 && listView1.Items[i].SubItems[1].Text.Contains("VACACIONES") )
                                {
                                    MOVINV = new _MOVINV(Convert.ToInt32(Lb_CodMov.Text), Convert.ToInt32(Txt_CedPer.Text), Convert.ToInt32(listView1.Items[i].SubItems[0].Text), Util.GetDate(),
                                        Vacation, Util.FormatDecimal(listView1.Items[i].SubItems[3].Text), Convert.ToInt32(listView1.Items[i].SubItems[4].Text),
                                        MOVINV.cosmov, MOVINV.predoc, MOVINV.totmov, vTipTid, listView1.Items[i].SubItems[2].Text, FunPR.Sent_TipIVA(Convert.ToInt32(listView1.Items[i].SubItems[0].Text)), vStaMov, TUsuario[0]);
                                    FunMOVINV.NuevoDET(MOVINV);
                                }
                                else
                                {
                                    MOVINV = new _MOVINV(Convert.ToInt32(Lb_CodMov.Text), Convert.ToInt32(Txt_CedPer.Text), Convert.ToInt32(listView1.Items[i].SubItems[0].Text), now,
                                   vTipTra1, Util.FormatDecimal(listView1.Items[i].SubItems[3].Text), Convert.ToInt32(listView1.Items[i].SubItems[4].Text),
                                   MOVINV.cosmov, MOVINV.predoc, MOVINV.totmov, vTipTid, listView1.Items[i].SubItems[2].Text, FunPR.Sent_TipIVA(Convert.ToInt32(listView1.Items[i].SubItems[0].Text)), vStaMov, TUsuario[0]);
                                    FunMOVINV.NuevoDET(MOVINV);
                                }
                            }
                            DialogResult result;
                            result = MessageBox.Show("¿Desea imprimir la factura?", "Seleccione una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                PrintTicket();
                                PrintTicketCopy();
                            }
                            Bloqueos();
                            Actualizar();
                            Size = new Size(713, 500);
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
            if (Txt_CedPer.Text.Trim() == "" || !(listView1.Items.Count > 0))
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
                isPresent = false;
                Desbloqueos();
                Lb_CodMov.Text = FunVOD.Correlativo().PadLeft(8, '0');
                Txt_CedPer.Enabled = true;
                Txt_CedPer.BackColor = Color.Turquoise;
                Txt_CedPer.Focus();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Modificar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TUsuario[6]) < 4)
            {
                Evento = "Modificar";
                Desbloqueos();
                Txt_CedPer.Enabled = true;
                Txt_CedPer.BackColor = Color.Turquoise;
                Txt_CedPer.Focus();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Primero_Click(object sender, EventArgs e)
        {
            VOD = FunVOD.BuscarPrimero();
            Asignar();
        }

        private void Cmd_Anterior_Click(object sender, EventArgs e)
        {
            VOD = FunVOD.BuscarAnterior(VOD);
            Asignar();
        }

        private void Cmd_Siguiente_Click(object sender, EventArgs e)
        {
            VOD = FunVOD.BuscarSiguiente(VOD);
            Asignar();
        }

        private void Cmd_Ultimo_Click(object sender, EventArgs e)
        {
            VOD = FunVOD.BuscarUltimo();
            Asignar();
        }

        private void Cmd_Buscar_Click(object sender, EventArgs e)
        {
            FormBUSQUEDAS f = new FormBUSQUEDAS();
            f.ListaObsequios();
            f.ShowDialog();
            if (f._CodObs != "")
            {
                VOD = FunVOD.Buscar(Convert.ToInt32(f._CodObs));
                Actualizar();
            }
        }

        private void Cmd_Eliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TUsuario[6]) < 3)
            {
                VOD = FunVOD.Buscar(Convert.ToInt32(Lb_CodMov.Text));
                if (VOD.stadoc == 1)
                {
                    DialogResult result;
                    result = MessageBox.Show("¿Esta seguro que desea anular el obsequio.?", "Seleccione una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int vStaMov = 0;
                        VOD = new _VENOBSDOC(Convert.ToInt32(Lb_CodMov.Text), Convert.ToInt32(Txt_CedPer.Text.Trim()), VOD.codrec, vTipTid, vStaMov);
                        if (FunVOD.AnularENC_OBS(VOD))
                        {
                            for (int i = 0; i < listView1.Items.Count; i++)
                            {
                                MOVINV = new _MOVINV(Convert.ToInt32(Lb_CodMov.Text), vStaMov, TUsuario[0]);
                                FunMOVINV.AnularDET_OBS(MOVINV);
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
        }

        private void Cmd_Imprimir_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TUsuario[6]) < 4)
            {
                MOVINV = FunMOVINV.Buscar(MOVINV.codmov);
                if (MOVINV.stamov == 1)
                {
                     //   PrintTicket();
                        PrintTicketCopy();
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
            Size = new Size(713, 500);
            VOD = FunVOD.BuscarUltimo();
            Asignar();
        }

        private void Weekly_Employee()
        {
            DateTime now = Util.GetDate();
            semana();
            int AmountofMovement = FunMOVINV.QuantityEmployeeMotion(Gift, Convert.ToInt32(Txt_CedPer.Text), mondayOfTheWeek.Date, sundayOfTheWeek.Date);
            int CheckCotillon = FunTIPTRA.ProductOfTheTransaction(Gift);
            if (CheckCotillon == AmountofMovement)
            {
                MessageBox.Show("Al trabajador ya se le entrego todo los beneficio correspondiente para esta semana", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Txt_CedPer.Focus();
            }
            else
            {
                empleado = FunPER.findById(Convert.ToInt32(Txt_CedPer.Text));
                if (empleado.isBirthday())
                {
                    _MOVINV[] arr = FunMOVINV.SearchTransByPersoRangeDate(Present, empleado.cedper, DateTime.Parse($"{now.Date.ToString("yyyy")}-01-01"), now.Date);
                    if (arr.Count() > 0)
                        isPresent = true;
                }

                VAC = FunVAC.IsVacationAct(Convert.ToInt32(Txt_CedPer.Text), now.Date, now.Date);
                if (VAC.codvac != 0)
                {
                    MessageBox.Show("El trabajador puede retirar sus obsequios por vacaciones", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _MOVINV[] arr = FunMOVINV.SearchTransByPersoRangeDate(Vacation, VAC.cedper, VAC.feavac, VAC.fefvac);
                    if (arr.Count() > 0)
                    {
                        isVacation = true;
                        if (VAC.isVacation())
                        {
                            MessageBox.Show("Al trabajador ya le entrego el beneficio de vaciones y actualmente se encuentra de vacaciones", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_CedPer.Focus();
                        }
                        else
                        {
                            Llenar_Lb_NomPer(Convert.ToInt32(Txt_CedPer.Text));
                            MenulistView(true);
                            Size = new Size(713, 576);
                            Util.CambiarTxt(Txt_CedPer, Txt_ComDoc);
                        }
                    }
                    else
                    {
                        Llenar_Lb_NomPer(Convert.ToInt32(Txt_CedPer.Text));
                        MenulistView(true);
                        Size = new Size(713, 576);
                        Util.CambiarTxt(Txt_CedPer, Txt_ComDoc);
                    }
                }
                else
                {
                    Llenar_Lb_NomPer(Convert.ToInt32(Txt_CedPer.Text));
                    MenulistView(true);
                    Size = new Size(713, 576);
                    Util.CambiarTxt(Txt_CedPer, Txt_ComDoc);
                }
            }
        }

        private void Month_Employee()
        {
            DateTime now = Util.GetDate();
            mesual();
            int AmountofMovement = FunMOVINV.QuantityEmployeeMotion(Gift, Convert.ToInt32(Txt_CedPer.Text), StartMonth.Date, EndMonth.Date);
            int CheckCotillon = FunTIPTRA.ProductOfTheTransaction(Gift);
            if (CheckCotillon == AmountofMovement)
            {
                MessageBox.Show("Al trabajador ya se le entrego todo los beneficio correspondiente para este mes", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Txt_CedPer.Focus();
            }
            else
            {
                empleado = FunPER.findById(Convert.ToInt32(Txt_CedPer.Text));
                if (empleado.isBirthday())
                {
                    _MOVINV[] arr = FunMOVINV.SearchTransByPersoRangeDate(Present, empleado.cedper, DateTime.Parse($"{now.Date.ToString("yyyy")}-01-01"), now.Date);
                    if (arr.Count() > 0)
                        isPresent = true;
                }

                VAC = FunVAC.IsVacationAct(Convert.ToInt32(Txt_CedPer.Text), now.Date, now.Date);
                if (VAC.codvac != 0)
                {
                    MessageBox.Show("El trabajador puede retirar sus obsequios por vacaciones", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _MOVINV[] arr = FunMOVINV.SearchTransByPersoRangeDate(Vacation, VAC.cedper, VAC.feavac, VAC.fefvac);
                    if (arr.Count() > 0)
                    {
                        isVacation = true;
                        if (VAC.isVacation())
                        {
                            MessageBox.Show("Al trabajador ya le entrego el beneficio de vaciones y actualmente se encuentra de vacaciones", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_CedPer.Focus();
                        }
                        else
                        {
                            Llenar_Lb_NomPer(Convert.ToInt32(Txt_CedPer.Text));
                            MenulistView(true);
                            Size = new Size(713, 576);
                            Util.CambiarTxt(Txt_CedPer, Txt_ComDoc);
                        }
                    }
                    else
                    {
                        Llenar_Lb_NomPer(Convert.ToInt32(Txt_CedPer.Text));
                        MenulistView(true);
                        Size = new Size(713, 576);
                        Util.CambiarTxt(Txt_CedPer, Txt_ComDoc);
                    }
                }
                else
                {
                    Llenar_Lb_NomPer(Convert.ToInt32(Txt_CedPer.Text));
                    MenulistView(true);
                    Size = new Size(713, 576);
                    Util.CambiarTxt(Txt_CedPer, Txt_ComDoc);
                }
            }
        }

        private void Txt_CedPer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_CedPer.Text.Trim() != "")
                    {
                        DateTime now = Util.GetDate();
                        if (FunPER.Existe(Convert.ToInt32(Txt_CedPer.Text)))
                        {
                            if (FunPER.StatudAI(Convert.ToInt32(Txt_CedPer.Text)))
                            {
                                if (FunVOD.BuscarCompraOBS(Convert.ToInt32(Txt_CedPer.Text), now.Date))
                                {
                                    if (FunASD.InasistenciaDia(Convert.ToInt32(Txt_CedPer.Text), now.Date))
                                    {
                                        if (FunGCO.GrupoOBSEQUIO(Convert.ToInt32(Txt_CedPer.Text)))
                                        {
                                            PER = FunPER.Buscar(Convert.ToInt32(Txt_CedPer.Text));
                                            if (PER.retper == 1)
                                            {
                                                Weekly_Employee();
                                            }
                                            else
                                            {
                                                if (PER.retper == 2)
                                                {
                                                    Month_Employee();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("El trabajador pertenece a un grupo que no permite este beneficio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            Txt_CedPer.Clear();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El trabajador(a) esta inasistente el día de hoy debe de pasar por recurso humano para cambiar el status ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        Txt_CedPer.Clear();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se puede realizar la operacion, trabajador ya retiro su obsequio el dia de hoy", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    Txt_CedPer.Clear();
                                }
                            }
                            else
                            {
                                MessageBox.Show("El trabajador se encuentra egresado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Txt_CedPer.Clear();
                            }

                        }
                        else
                        {
                            MessageBox.Show("El trabajador no extiste.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_CedPer.SelectAll();
                        }
                    }
                    else
                    {
                        FormBUSQUEDAS f = new FormBUSQUEDAS();
                        f.ListaPersonalAI();
                        f.ShowDialog();
                        if (f._CedPer != "")
                        {
                            DateTime now = Util.GetDate();
                            Txt_CedPer.Text = f._CedPer;
                            if (FunVOD.BuscarCompraOBS(Convert.ToInt32(Txt_CedPer.Text), now.Date))
                            {
                                if (FunASD.InasistenciaDia(Convert.ToInt32(Txt_CedPer.Text), now.Date))
                                {
                                    if (FunGCO.GrupoOBSEQUIO(Convert.ToInt32(Txt_CedPer.Text)))
                                    {
                                        PER = FunPER.Buscar(Convert.ToInt32(Txt_CedPer.Text));
                                        if (PER.retper == 1)
                                        {
                                            Weekly_Employee();
                                        }
                                        else
                                        {
                                            if (PER.retper == 2)
                                            {
                                                Month_Employee();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El trabajador pertenece a un grupo que no permite este beneficio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        Txt_CedPer.Clear();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El trabajador(a) esta inasistente el día de hoy debe de pasar por recurso humano para cambiar el status ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    Txt_CedPer.Clear();
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se puede realizar la operacion, trabajador ya retiro su obsequio el dia de hoy", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Txt_CedPer.Clear();
                            }
                        }
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Cmd_Cancelar.PerformClick();
                    Txt_CodPro.Text = "";
                    break;
            }
        }
        private void Txt_ComDoc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_ComDoc, Txt_CodPro);
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_ComDoc, Txt_CedPer);
                    MenulistView(false);
                    Size = new Size(713, 500);
                    break;
            }
        }

        private void Weekly_Product()
        {
            DateTime now = Util.GetDate();
            semana();
            if (FunMOVINV.QuantityProductsMotion(Gift, Convert.ToInt32(Txt_CedPer.Text), Convert.ToInt32(Txt_CodPro.Text), mondayOfTheWeek.Date, sundayOfTheWeek.Date))
            {
                Llenar_Lb_DesPro(Convert.ToInt32(Txt_CodPro.Text));
                Llenar_Lb_UndUnm(Convert.ToInt32(Txt_CodPro.Text));
                Util.CambiarTxt(Txt_CodPro, Txt_CanMov);
                Txt_CanMov.Text = "0";
                Txt_CanMov.SelectAll();
                Txt_CatMov.Text = "2";

                if (Convert.ToInt32(Txt_CodPro.Text) == 1 && !isPresent && empleado.isBirthday())
                {
                    DialogResult result;
                    result = MessageBox.Show("¿Desea agregar el beneficio de cumpleaño?", "Seleccione una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        isPresent = false;
                        Lb_DesPro.Text = FunPR.Sent_DesPro(Convert.ToInt32(Txt_CodPro.Text)) + " CUMPLEAÑO";
                        Llenar_Lb_UndUnm(Convert.ToInt32(Txt_CodPro.Text));
                        Util.CambiarTxt(Txt_CodPro, Txt_CanMov);
                        Txt_CanMov.Text = "0";
                        Txt_CanMov.SelectAll();
                        Txt_CatMov.Text = "2";
                    }
                }

                if (FunVAC.ExisteProdTras(Vacation, Convert.ToInt32(Txt_CodPro.Text)) && !isVacation && VAC.codvac != 0)
                {
                    DialogResult result1;
                    result1 = MessageBox.Show("¿Desea agregar el beneficio de vacaciones?", "Seleccione una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result1 == DialogResult.Yes)
                    {
                        isVacation = false;
                        Lb_DesPro.Text = FunPR.Sent_DesPro(Convert.ToInt32(Txt_CodPro.Text)) + " VACACIONES";
                        Llenar_Lb_UndUnm(Convert.ToInt32(Txt_CodPro.Text));
                        Util.CambiarTxt(Txt_CodPro, Txt_CanMov);
                        Txt_CanMov.Text = "0";
                        Txt_CanMov.SelectAll();
                        if (Convert.ToInt32(Txt_CodPro.Text) == 1)
                        {
                            Txt_CatMov.Text = FunVAC.Sent_Valor(Convert.ToInt32(Txt_CedPer.Text), now.Date, now.Date);
                        }
                        else
                        {
                            Txt_CatMov.Text = "2";
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("El producto ya fue entregado en esta semana", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Txt_CodPro.SelectAll();
            }
        }

        private void Month_Product()
        {
            DateTime now = Util.GetDate();
            mesual();
            if (FunMOVINV.QuantityProductsMotion(Gift, Convert.ToInt32(Txt_CedPer.Text), Convert.ToInt32(Txt_CodPro.Text), StartMonth.Date, EndMonth.Date))
            {
                Llenar_Lb_DesPro(Convert.ToInt32(Txt_CodPro.Text));
                Llenar_Lb_UndUnm(Convert.ToInt32(Txt_CodPro.Text));
                Util.CambiarTxt(Txt_CodPro, Txt_CanMov);
                Txt_CanMov.Text = "0";
                Txt_CanMov.SelectAll();
                Txt_CatMov.Text = "2";

                if (Convert.ToInt32(Txt_CodPro.Text) == 1 && !isPresent && empleado.isBirthday())
                {
                    DialogResult result;
                    result = MessageBox.Show("¿Desea agregar el beneficio de cumpleaño?", "Seleccione una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        isPresent = false;
                        Lb_DesPro.Text = FunPR.Sent_DesPro(Convert.ToInt32(Txt_CodPro.Text)) + " CUMPLEAÑO";
                        Llenar_Lb_UndUnm(Convert.ToInt32(Txt_CodPro.Text));
                        Util.CambiarTxt(Txt_CodPro, Txt_CanMov);
                        Txt_CanMov.Text = "0";
                        Txt_CanMov.SelectAll();
                        Txt_CatMov.Text = "2";
                    }
                }

                if (FunVAC.ExisteProdTras(Vacation, Convert.ToInt32(Txt_CodPro.Text)) && !isVacation && VAC.codvac != 0)
                {
                    DialogResult result1;
                    result1 = MessageBox.Show("¿Desea agregar el beneficio de vacaciones?", "Seleccione una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result1 == DialogResult.Yes)
                    {
                        isVacation = false;
                        Lb_DesPro.Text = FunPR.Sent_DesPro(Convert.ToInt32(Txt_CodPro.Text)) + " VACACIONES";
                        Llenar_Lb_UndUnm(Convert.ToInt32(Txt_CodPro.Text));
                        Util.CambiarTxt(Txt_CodPro, Txt_CanMov);
                        Txt_CanMov.Text = "0";
                        Txt_CanMov.SelectAll();
                        if (Convert.ToInt32(Txt_CodPro.Text) == 1)
                        {
                            Txt_CatMov.Text = FunVAC.Sent_Valor(Convert.ToInt32(Txt_CedPer.Text), now.Date, now.Date);
                        }
                        else
                        {
                            Txt_CatMov.Text = "2";
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("El producto ya fue entregado en este mes", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Txt_CodPro.SelectAll();
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
                                PER = FunPER.Buscar(Convert.ToInt32(Txt_CedPer.Text));
                                if (PER.retper == 1)
                                {
                                    Weekly_Product();
                                }
                                else
                                {
                                    if (PER.retper == 2)
                                    {
                                        Month_Product();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El producto se encuentra inactivo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                            PER = FunPER.Buscar(Convert.ToInt32(Txt_CedPer.Text));
                            if (PER.retper == 1)
                            {
                                Weekly_Product();
                            }
                            else
                            {
                                if (PER.retper == 2)
                                {
                                    Month_Product();
                                }
                            }
                        }
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_CodPro, Txt_ComDoc);
                    
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
                    if (Txt_CanMov.Text.Trim() != "" && Util.FormatDecimal(Txt_CanMov.Text) > 0)
                    {
                        if (Evento.CompareTo("Nuevo") == 0)
                        {
                            if (FunMOVINV.ExistenciaINV(Convert.ToInt32(Txt_CodPro.Text), Util.FormatDecimal(Txt_CanMov.Text)))
                            {
                                string valor = Lb_DesPro.Text;
                                ListViewItem itmx = listView1.FindItemWithText(valor);
                                if (itmx == null)
                                {
                                    if (Lb_DesPro.Text.Contains("VACACIONES"))
                                    {
                                        string[] Arra = { Txt_CodPro.Text.Trim().PadLeft(8, '0'), Lb_DesPro.Text.Trim(), Lb_UndUnm.Text, Txt_CanMov.Text.Trim(), Txt_CatMov.Text.Trim() };
                                        ListViewItem itm = new ListViewItem(Arra);
                                        listView1.Items.Add(itm);
                                        MenulistViewLimpial();
                                        Util.CambiarTxt(Txt_CanMov, Txt_CodPro);
                                    }
                                    else if (VAC.isVacation())
                                    {
                                        MessageBox.Show("El trabajador actualmente se encuentra de vacaciones y no puede retirar beneficio de obsequio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        Txt_CedPer.Focus();
                                    }
                                    else
                                    {
                                        string[] Arra = { Txt_CodPro.Text.Trim().PadLeft(8, '0'), Lb_DesPro.Text.Trim(), Lb_UndUnm.Text, Txt_CanMov.Text.Trim(), Txt_CatMov.Text.Trim() };
                                        ListViewItem itm = new ListViewItem(Arra);
                                        listView1.Items.Add(itm);
                                        MenulistViewLimpial();
                                        Util.CambiarTxt(Txt_CanMov, Txt_CodPro);
                                    }
                                    
                                }
                                else
                                {
                                    if (Evento2.CompareTo("Modificar") == 0 && SwActivoM == true)
                                    {
                                        listView1.SelectedItems[0].SubItems[3].Text = Txt_CanMov.Text;
                                        Util.CambiarTxt(Txt_CanMov, Txt_CodPro);
                                        MenulistViewLimpial();
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

        }

        private void Txt_CedPer_Enter(object sender, EventArgs e)
        {
            Lb_NomPer.Text = "";
            listView1.Items.Clear();
        }

        private void Txt_CodPro_Enter(object sender, EventArgs e)
        {
            Lb_DesPro.Text = "";
            Lb_UndUnm.Text = "";
            Txt_CanMov.Text = "";
            Txt_CatMov.Text = "";
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


        private void FormOBSEQUIOS_KeyDown(object sender, KeyEventArgs e)
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
                case Keys.PageUp:
                    e.SuppressKeyPress = true;
                    Cmd_UltmEntr.PerformClick();
                    break;
                case Keys.PageDown:
                    e.SuppressKeyPress = true;
                    Cmd_UltmPre.PerformClick();
                    break;
                case Keys.Insert:
                    e.SuppressKeyPress = true;
                    Cmd_UltmVac.PerformClick();
                    break;
            }
        }

        private void PrintTicket()
        {
            VOD = FunVOD.Buscar(Convert.ToInt32(Lb_CodMov.Text));
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
            ticket.AddHeaderLine("   Beneficio al personal según      clausula 25 convención colectiva");
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("RIF: J-29633565-6");
            ticket.AddHeaderLine("DIREC: Carretera panamericana Km.35sector cumbre roja entrada caña ");
            ticket.AddHeaderLine("larga.");
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("OBSEQUIOS          Ticket #" + Lb_CodMov.Text);
            ticket.AddHeaderLine("***********************************");
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("C.I.: " + Txt_CedPer.Text);
            ticket.AddHeaderLine("Nombre: " + Lb_NomPer.Text);
            ticket.AddHeaderLine("Condición: OBSEQUIO (ORIGINAL)");
            ticket.AddSubHeaderLine("Fecha:" + VOD.fecdoc.ToShortDateString() + " Hora:" + VOD.fecdoc.ToShortTimeString());

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ticket.AddItem(Util.FormatDecimal(listView1.Items[i].SubItems[3].Text).ToString("N2") + "" + listView1.Items[i].SubItems[2].Text, "   " + listView1.Items[i].SubItems[1].Text, "");
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

        private void PrintTicketCopy()
        {
            VOD = FunVOD.Buscar(Convert.ToInt32(Lb_CodMov.Text));
            DateTime now = Util.GetDate();
            string cPath;

            Ticket ticket = new Ticket();
            cPath = Application.ExecutablePath.Replace("SISPROIN.exe", "");

            //cPath = cPath.Replace("SGVB.EXE", "");
            //cPath = cPath.Replace("sgvb.exe", "");
            //cPath = cPath.Replace("SGVB.exe", "");
            //cPath = cPath.Replace("sgvb.EXE", "");

            //ticket.HeaderImage = Image.FromFile(cPath);
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("          TODOVITO I, C.A");
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("   Beneficio al personal según      clausula 25 convención colectiva");
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("RIF: J-29633565-6");
            ticket.AddHeaderLine("DIREC: Carretera panamericana Km.35sector cumbre roja entrada caña ");
            ticket.AddHeaderLine("larga.");
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("OBSEQUIOS          Ticket #" + Lb_CodMov.Text);
            ticket.AddHeaderLine("***********************************");
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("C.I.: " + Txt_CedPer.Text);
            ticket.AddHeaderLine("Nombre: " + Lb_NomPer.Text);
            ticket.AddHeaderLine("Condición: OBSEQUIO (COPIA)");
            ticket.AddSubHeaderLine("Fecha:" + VOD.fecdoc.ToShortDateString() + " Hora:" + VOD.fecdoc.ToShortTimeString());

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ticket.AddItem(Util.FormatDecimal(listView1.Items[i].SubItems[3].Text).ToString("N2") + "" + listView1.Items[i].SubItems[2].Text, "   " + listView1.Items[i].SubItems[1].Text, "");
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

        private void Txt_CodPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.SoloNumero(e);
        }

        private void Txt_CanMov_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.SoloNumeroDecimales(sender, e, Txt_CanMov);
        }

        private void FormOBSEQUIOS_Load(object sender, EventArgs e)
        {
            //toolTip1.ToolTipTitle = "Información";
            //toolTip1.UseFading = true;
            //toolTip1.UseAnimation = true;
            //toolTip1.IsBalloon = true;
            //toolTip1.ShowAlways = true;
            //toolTip1.AutoPopDelay = 5000;
            //toolTip1.InitialDelay = 1000;
            //toolTip1.ReshowDelay = 500;
            toolTip1.SetToolTip(Cmd_UltmEntr, "Últimos Productos Entregado.");
            toolTip1.SetToolTip(Cmd_UltmPre, "Últimos Cumpleaño Entregado.");
            toolTip1.SetToolTip(Cmd_UltmVac, "Últimas Vacaciones Entregado.");
        }

        private void Cmd_UltmEntr_Click(object sender, EventArgs e)
        {
            FormVERULTENTR f = new FormVERULTENTR();
            f.Text = "Utima Entrega.";
            VOD = f.VOD;
            f.VOD = FunVOD.Search_UltimoEntrega_OBS(Convert.ToInt32(Txt_CedPer.Text));
            f.Lb_CedPer.Text = Txt_CedPer.Text;
            f.ShowDialog();
        }

        private void Cmd_UltmPre_Click(object sender, EventArgs e)
        {
            FormVERULTENTR f = new FormVERULTENTR();
            f.Text = "Utima Entrega del Beneficio de Cumpleaño.";
            VOD = f.VOD;
            f.VOD = FunVOD.Search_UltimoEntregaPre_OBS(Convert.ToInt32(Txt_CedPer.Text));
            f.Lb_CedPer.Text = Txt_CedPer.Text;
            f.ShowDialog();
        }

        private void Cmd_UltmVac_Click(object sender, EventArgs e)
        {
            FormVERULTENTR f = new FormVERULTENTR();
            f.Text = "Utima Entrega del Beneficio de Vacaciones.";
            VOD = f.VOD;
            f.VOD = FunVOD.Search_UltimoEntregaVac_OBS(Convert.ToInt32(Txt_CedPer.Text));
            f.Lb_CedPer.Text = Txt_CedPer.Text;
            f.ShowDialog();
        }

        private void Cmd_UltmEntr_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_CodPro, Txt_CedPer);
                    MenulistView(false);
                    //Size = new Size(713, 500);
                    Txt_CodPro.Text = "";
                    break;
            }
        }

        private void Cmd_UltmPre_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_CodPro, Txt_CedPer);
                    MenulistView(false);
                    Txt_CodPro.Text = "";
                    break;
            }
        }

        private void PrintTicketNullified()
        {
            VOD = FunVOD.Buscar(Convert.ToInt32(Lb_CodMov.Text));
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
            ticket.AddHeaderLine("   Beneficio al personal según      clausula 25 convención colectiva");
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("RIF: J-29633565-6");
            ticket.AddHeaderLine("DIREC: Carretera panamericana Km.35sector cumbre roja entrada caña ");
            ticket.AddHeaderLine("larga.");
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("OBSEQUIOS          Ticket #" + Lb_CodMov.Text);
            ticket.AddHeaderLine("***********************************");
            ticket.AddHeaderLine("");
            ticket.AddHeaderLine("C.I.: " + Txt_CedPer.Text);
            ticket.AddHeaderLine("Nombre: " + Lb_NomPer.Text);
            ticket.AddHeaderLine("Condición: OBSEQUIO (ANULADO)");
            ticket.AddSubHeaderLine("Fecha:" + VOD.fecdoc.ToShortDateString() + " Hora:" + VOD.fecdoc.ToShortTimeString());

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ticket.AddItem(Util.FormatDecimal(listView1.Items[i].SubItems[3].Text).ToString("N2") + "" + listView1.Items[i].SubItems[2].Text, "   " + listView1.Items[i].SubItems[1].Text, "");
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

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (Evento.CompareTo("Nuevo") == 0)
            {
                AcOpcion();
            }
        }

      

        private void Txt_CedPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.SoloNumero(e);
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
