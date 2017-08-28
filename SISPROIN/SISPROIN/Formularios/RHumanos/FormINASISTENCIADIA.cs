using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISPROIN.Formularios.RHumanos
{
    public partial class FormINASISTENCIADIA : Form
    {
        string[] TUsuario = new string[7];
        Clases.Utilitarios Util = new Clases.Utilitarios();
        Clases._ASISTEDIAS ASID = new Clases._ASISTEDIAS();
        Funciones.Fun_ASISTEDIA FunASID = new Funciones.Fun_ASISTEDIA();
        Funciones.Fun_PERSONAL FunPER = new Funciones.Fun_PERSONAL();
        string Evento = "";
        string Evento2 = "";

        public FormINASISTENCIADIA(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
            BotonesNormal(true);
            GenColumnas();
            ASID = FunASID.BuscarUltimo();
            Asignar();
        }

        protected void GenColumnas()
        {
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            listView1.HideSelection = false;
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Cedula", 134, HorizontalAlignment.Left);
            listView1.Columns.Add("Trabajadores", 275, HorizontalAlignment.Center);
            listView1.Columns.Add("Comentario", 272, HorizontalAlignment.Center);
        }

        private void BotonesNormal(bool Mostrar)
        {
            Cmd_Nuevo.Visible = Mostrar;
            Cmd_Modificar.Visible = Mostrar;
            Cmd_Primero.Visible = Mostrar;
            Cmd_Anterior.Visible = Mostrar;
            Cmd_Siguiente.Visible = Mostrar;
            Cmd_Ultimo.Visible = Mostrar;
            //Cmd_Eliminar.Visible = Mostrar;
            Cmd_Imprimir.Visible = Mostrar;
            Cmd_Buscar.Visible = Mostrar;
        }

        private void BotonesControl(bool Mostrar)
        {
            Cmd_Guardar.Visible = Mostrar;
            Cmd_Cancelar.Visible = Mostrar;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecAsd.Text = Util.GetDate().ToString();
        }

        private void Bloqueos()
        {
            BotonesNormal(true);
            BotonesControl(false);
            Lbl(true);
            lblFecAsd.Visible = false;
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
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is CheckBox)
                {
                    CheckBox IMPUT = ctrl as CheckBox;
                    IMPUT.Visible = false;
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
            Lb_FecAsd.Visible = Mostrar;
            Lb_StaAsd.Visible = Mostrar;
            
        }

        private void MenulistView(bool Mostrar)
        {
            Txt_CedPer.Visible = Mostrar;
            Lb_NomPer.Visible = Mostrar;
            Txt_ComAsd.Visible = Mostrar;
        }

        private void MenulistViewReset()
        {
            Txt_CedPer.Clear();
            Txt_CedPer.Enabled = false;
            Txt_CedPer.BackColor = Color.White;

            Txt_ComAsd.Clear();
            Txt_ComAsd.Enabled = false;
            Txt_ComAsd.BackColor = Color.White;
        }

        private void MenulistViewLimpial()
        {
            Txt_CedPer.Text = "";
            Lb_NomPer.Text = "";
            Txt_ComAsd.Text = "";
   
        }

        private void Desbloqueos()
        {
            BotonesNormal(false);
            BotonesControl(true);
            Lbl(false);
            lblFecAsd.Visible = true;
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
                foreach (Control ctrl in panel1.Controls)
                {
                    if (ctrl is CheckBox)
                    {
                        CheckBox IMPUT = ctrl as CheckBox;
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
                    foreach (Control ctrl in panel1.Controls)
                    {
                        if (ctrl is CheckBox)
                        {
                            CheckBox IMPUT = ctrl as CheckBox;
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
            Lb_CodAsd.Text = ASID.codasd.ToString().PadLeft(8, '0');
            Lb_FecAsd.Text = ASID.fecasd.ToShortDateString();
            Llenar_Lb_NomPer(ASID.cedper);

            if (ASID.staasd == 1)
            {
                Che_StaAsd.Checked = true;
                Lb_StaAsd.Text = "Activo";
                Lb_StaAsd.ForeColor = Color.Green;
            }
            else
            {
                Che_StaAsd.Checked = false;
                Lb_StaAsd.Text = "Inactivo";
                Lb_StaAsd.ForeColor = Color.Red;
            }
        }

        private void AsignarDET()
        {
            FunASID.GetLisInasisente(Convert.ToInt32(Lb_CodAsd.Text), ref listView1);
        }

        private void Actualizar()
        {
            ASID = FunASID.Buscar(ASID.codasd);
            Asignar();
        }

        private void Llenar_Lb_NomPer(int vcedper)
        {
            Lb_NomPer.Text = FunPER.Sent_NomPer(vcedper);
        }

        private void Cmd_Guardar_Click(object sender, EventArgs e)
        {

            DateTime now =Util.GetDate();
            int vStaAsd = 0;
            if (Che_StaAsd.Checked)
                vStaAsd = 1;
            else
                vStaAsd = 0;

            if (Evento.CompareTo("Nuevo") == 0)
            {
                DialogResult result;
                result = MessageBox.Show("¿Desea guardar la inasistencia?", "Seleccione una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ASID = new Clases._ASISTEDIAS(Convert.ToInt32(FunASID.Correlativo()), Util.GetDate(), vStaAsd);
                    if (FunASID.Nuevo(ASID))
                    {
                        for (int i = 0; i < listView1.Items.Count; i++)
                        {
                            ASID = new Clases._ASISTEDIAS(Convert.ToInt32(Lb_CodAsd.Text), Convert.ToInt32(listView1.Items[i].SubItems[0].Text), listView1.Items[i].SubItems[2].Text, now.Date);
                            FunASID.GuardarDET(ASID);
                        }
                        MessageBox.Show("Se agregó correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bloqueos();
                        Actualizar();
                        // Cmd_Nuevo.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("El correlativo ya existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            else
            {
                if (Evento.CompareTo("Modificar") == 0)
                {
                    DialogResult result;
                    result = MessageBox.Show("¿Desea modificar la inasistencia?", "Seleccione una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        ASID = new Clases._ASISTEDIAS(Convert.ToInt32(Lb_CodAsd.Text), vStaAsd);
                        if (FunASID.Modificar(ASID))
                        {
                            FunASID.EliminarDET(ASID);
                            for (int i = 0; i < listView1.Items.Count; i++)
                            {
                                Clases._ASISTEDIAS usr1 = new Clases._ASISTEDIAS(Convert.ToInt32(Lb_CodAsd.Text), Convert.ToInt32(listView1.Items[i].SubItems[0].Text), listView1.Items[i].SubItems[2].Text, now.Date);
                                FunASID.GuardarDET(usr1);
                            }
                            MessageBox.Show("Se modificó correctamente.", "Atención ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Bloqueos();
                            Actualizar();
                        }
                        else
                        {
                            MessageBox.Show("El trabajador no existe en el sistema.", "Atención ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
        }

        private void Cmd_Nuevo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TUsuario[6]) < 5)
            {
                DateTime now = Util.GetDate();
                if (!(FunASID.RealizarNuevo(Util.GetDate().Date)))
                {
                    Evento = "Nuevo";
                    Desbloqueos();
                    Lb_CodAsd.Text = FunASID.Correlativo().PadLeft(8, '0');
                    MenulistView(true);
                    Txt_CedPer.Enabled = true;
                    Txt_CedPer.BackColor = Color.Turquoise;
                    Txt_CedPer.Focus();
                    Che_StaAsd.Checked = true;
                }
                else
                {
                    MessageBox.Show("Ya realizo un documento de inasistencia con fecha " + now.ToShortDateString() + " tendrá que modificarlo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
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
                DateTime now = Util.GetDate();
                ASID = FunASID.Buscar(ASID.codasd);
                if(ASID.fecasd.Date == now.Date)
                {
                    Evento = "Modificar";
                    Desbloqueos();
                    MenulistView(true);
                    Txt_CedPer.Enabled = true;
                    Txt_CedPer.BackColor = Color.Turquoise;
                    Txt_CedPer.Focus();
                }
                else
                {
                    MessageBox.Show("Debe de realizar una inasistencia el día de hoy.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
              
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Primero_Click(object sender, EventArgs e)
        {
            ASID = FunASID.BuscarPrimero();
            Asignar();
        }

        private void Cmd_Anterior_Click(object sender, EventArgs e)
        {
            ASID = FunASID.BuscarAnterior(ASID);
            Asignar();
        }

        private void Cmd_Siguiente_Click(object sender, EventArgs e)
        {
            ASID = FunASID.BuscarSiguiente(ASID);
            Asignar();
        }

        private void Cmd_Ultimo_Click(object sender, EventArgs e)
        {
            ASID = FunASID.BuscarUltimo();
            Asignar();
        }

        private void Cmd_Buscar_Click(object sender, EventArgs e)
        {
            FormBUSQUEDAS f = new FormBUSQUEDAS();
            f.ListaGrupoInventario();
            f.ShowDialog();
            if (f._CodGru != "")
            {
                ASID = FunASID.Buscar(Convert.ToInt32(f._CodGru));
                Actualizar();
            }
        }

        private void Cmd_Eliminar_Click(object sender, EventArgs e)
        {

        }

        private void Cmd_Imprimir_Click(object sender, EventArgs e)
        {

        }

        private void Cmd_Aceptar_Click(object sender, EventArgs e)
        {

        }

        private void Cmd_Cancelar_Click(object sender, EventArgs e)
        {

            Bloqueos();
            ASID = FunASID.BuscarUltimo();
            Asignar();
        }

        private void Txt_CedPer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_CedPer.Text.Trim() != "")
                    {
                        if (FunPER.Existe(Convert.ToInt32(Txt_CedPer.Text)))
                        {
                            if (FunPER.StatudAI(Convert.ToInt32(Txt_CedPer.Text)))
                            {
                                    Llenar_Lb_NomPer(Convert.ToInt32(Txt_CedPer.Text));
                                    Util.CambiarTxt(Txt_CedPer, Txt_ComAsd);
                            }
                            else
                            {
                                MessageBox.Show("El trabajador se encuentra egresado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Txt_CedPer.SelectAll();
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
                            Txt_CedPer.Text = f._CedPer;
                            Llenar_Lb_NomPer(Convert.ToInt32(Txt_CedPer.Text));
                            Util.CambiarTxt(Txt_CedPer, Txt_ComAsd);
                        }
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Cmd_Cancelar.PerformClick();
                    Txt_ComAsd.Text = "";
                    break;
            }
        }

        private void Txt_ComAsd_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
                    if (Evento.CompareTo("Nuevo") == 0)
                    {
                        ListViewItem itmx = listView1.FindItemWithText(Txt_CedPer.Text);
                        if (itmx == null)
                        {
                            string[] Arra = { Txt_CedPer.Text.Trim(), Lb_NomPer.Text.Trim(), Txt_ComAsd.Text.Trim() };
                            ListViewItem itm = new ListViewItem(Arra);
                            listView1.Items.Add(itm);
                            MenulistViewLimpial();
                            Util.CambiarTxt(Txt_ComAsd, Txt_CedPer);

                        }
                        else
                        {
                            if (Evento2.CompareTo("Modificar") == 0)
                            {
                                listView1.SelectedItems[0].SubItems[2].Text = Txt_ComAsd.Text;
                                MenulistViewLimpial();
                                Util.CambiarTxt(Txt_ComAsd, Txt_CedPer);
                            }
                            else
                            {
                                MessageBox.Show("El trabajador ya existe en la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                //itmx.Remove();
                            }
                        }
                    }
                    else
                    {
                        if (Evento.CompareTo("Modificar") == 0)
                        {
                            if (Evento2.CompareTo("Modificar")==0)
                            {
                                MenulistViewLimpial();
                                MenulistViewReset();
                                listView1.SelectedItems[0].SubItems[2].Text = Txt_ComAsd.Text;
                                Util.CambiarTxt(Txt_ComAsd, Txt_CedPer);
                            }
                            else
                            {
                                if (Evento2.CompareTo("Nuevo") == 0)
                                {
                                    ListViewItem itmx = listView1.FindItemWithText(Txt_CedPer.Text);
                                    if (itmx == null)
                                    {
                                        string[] Arra = { Txt_CedPer.Text.Trim(), Lb_NomPer.Text.Trim(), Txt_ComAsd.Text.Trim() };
                                        ListViewItem itm = new ListViewItem(Arra);
                                        listView1.Items.Add(itm);
                                        MenulistViewLimpial();
                                        Util.CambiarTxt(Txt_ComAsd, Txt_CedPer);
                                    }
                                    else
                                    {
                                        MessageBox.Show("El trabajador ya existe en la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    }
                                }
                                else
                                {
                                    ListViewItem itmx = listView1.FindItemWithText(Txt_CedPer.Text);
                                    if (itmx == null)
                                    {
                                        string[] Arra = { Txt_CedPer.Text.Trim(), Lb_NomPer.Text.Trim(), Txt_ComAsd.Text.Trim() };
                                        ListViewItem itm = new ListViewItem(Arra);
                                        listView1.Items.Add(itm);
                                        MenulistViewLimpial();
                                        Util.CambiarTxt(Txt_ComAsd, Txt_CedPer);

                                    }
                                    else
                                    {
                                        MessageBox.Show("El trabajador ya existe en la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        //itmx.Remove();
                                    }
                                }
                            }
                        }
                    }
                    break;

                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_ComAsd, Txt_CedPer);
                    Txt_CedPer.Clear();
                    break;

            }
        }

        private void Txt_CedPer_Enter(object sender, EventArgs e)
        {
            Lb_NomPer.Text = "";
            Txt_ComAsd.Text = "";
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

                    Txt_CedPer.Clear();
                    Txt_CedPer.Enabled = true;
                    Txt_CedPer.Focus();
                    Txt_CedPer.SelectAll();
                    Txt_CedPer.BackColor = Color.Turquoise;
                    break;
                case "2":
                    if (listView1.SelectedItems.Count > 0)
                    {
                        Evento2 = "Modificar";
                        MenulistView(true);
                        MenulistViewReset();

                        Txt_CedPer.Text = listView1.SelectedItems[0].SubItems[0].Text;
                        Lb_NomPer.Text = listView1.SelectedItems[0].SubItems[1].Text;
                        Txt_ComAsd.Text = listView1.SelectedItems[0].SubItems[2].Text;

                        Txt_ComAsd.Enabled = true;
                        Txt_ComAsd.Focus();
                        Txt_ComAsd.SelectAll();
                        Txt_ComAsd.BackColor = Color.Turquoise;
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

                        Txt_CedPer.Clear();
                        Txt_CedPer.Enabled = true;
                        Txt_CedPer.Focus();
                        Txt_CedPer.SelectAll();
                        Txt_CedPer.BackColor = Color.Turquoise;
                    }
                    break;
                default:
                    //MessageBox.Show("ESCAPE");
                    break;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (Evento.CompareTo("Nuevo") == 0)
            {
                AcOpcion();
            }
            else
            {
                if (Evento.CompareTo("Modificar") == 0)
                {
                    AcOpcion();

                }
            }
               
        }

        private void FormINASISTENCIADIA_KeyDown(object sender, KeyEventArgs e)
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
    }
}
