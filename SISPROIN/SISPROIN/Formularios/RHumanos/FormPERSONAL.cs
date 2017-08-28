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
    public partial class FormPERSONAL : Form
    {
        string[] TUsuario = new string[7];
        string Evento = "";
        Clases.Utilitarios Util = new Clases.Utilitarios();
        Clases._PERSONAL PER = new Clases._PERSONAL();
        Funciones.Fun_PERSONAL FunPER = new Funciones.Fun_PERSONAL();
        Funciones.Fun_DEPARTA FunDP = new Funciones.Fun_DEPARTA();
        Funciones.Fun_GRUPCOMOBS FunGCO = new Funciones.Fun_GRUPCOMOBS();

        public FormPERSONAL(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
            BotonesNormal(true);
            PER = FunPER.BuscarUltimo();
            Asignar();
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

        private void Lbl(bool Mostrar)
        {
            Lb_CedPer.Visible = Mostrar;
            Lb_NomPer.Visible = Mostrar;
            Lb_ApePer.Visible = Mostrar;
            Lb_NacPer.Visible = Mostrar;
            Lb_CodDpt.Visible = Mostrar;
            Lb_FenPer.Visible = Mostrar;
            Lb_FeiPer.Visible = Mostrar;
            //Lb_FeePer.Visible = Mostrar;
            Lb_StaPer.Visible = Mostrar;
        }
        private void Bloqueos()
        {
            BotonesNormal(true);
            BotonesControl(false);
            Lbl(true);
            Dat_FenPer.Visible = false;
            Dat_FenPer.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            Dat_FeiPer.Visible = false;
            Dat_FeiPer.Enabled = false;
            Dat_FeePer.Enabled = false;

            foreach (Control ctrl in Controls)
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
                if (ctrl is CheckBox)
                {
                    CheckBox IMPUT = ctrl as CheckBox;
                    IMPUT.Visible = false;
                }
            }
            foreach (Control ctrl in Controls)
            {
                if (ctrl is ComboBox)
                {
                    ComboBox IMPUT = ctrl as ComboBox;
                    IMPUT.Visible = false;
                    IMPUT.Enabled = false;

                }
            }
        }
        private void Desbloqueos()
        {
            BotonesNormal(false);
            BotonesControl(true);
            Lbl(false);
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            if (Evento.CompareTo("Nuevo") == 0)
            {
                Dat_FenPer.Visible = true;
                Dat_FenPer.Value = DateTime.Now;
                Dat_FeiPer.Visible = true;
                Dat_FeiPer.Value = DateTime.Now;
                foreach (Control ctrl in Controls)
                {
                    if (ctrl is TextBox)
                    {
                        TextBox IMPUT = ctrl as TextBox;
                        IMPUT.Clear();
                        IMPUT.Visible = true;
                    }
                }
                foreach (Control ctrl in Controls)
                {
                    if (ctrl is CheckBox)
                    {
                        CheckBox IMPUT = ctrl as CheckBox;
                        IMPUT.Visible = true;
                    }
                }
                foreach (Control ctrl in Controls)
                {
                    if (ctrl is ComboBox)
                    {
                        ComboBox IMPUT = ctrl as ComboBox;
                        IMPUT.SelectedIndex = -1;
                        IMPUT.Text = "";
                        IMPUT.Visible = true;
                    }
                }

                Lb_NomDpt.Text = "";
                Lb_DesGco.Text = "";
            }
            else
            {
                if (Evento.CompareTo("Modificar") == 0)
                {
                    Dat_FeePer.Enabled = true;
                    Dat_FenPer.Visible = true;
                    Dat_FeiPer.Visible = true;
                    foreach (Control ctrl in Controls)
                    {
                        if (ctrl is TextBox)
                        {
                            TextBox IMPUT = ctrl as TextBox;
                            IMPUT.Visible = true;
                        }
                    }
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is CheckBox)
                        {
                            CheckBox IMPUT = ctrl as CheckBox;
                            IMPUT.Visible = true;
                        }
                    }
                    foreach (Control ctrl in Controls)
                    {
                        if (ctrl is ComboBox)
                        {
                            ComboBox IMPUT = ctrl as ComboBox;
                            IMPUT.Visible = true;
                        }
                    }
            
                }
            }
        }
        private void Asignar()
        {
            Txt_CedPer.Text = PER.cedper.ToString();
            Txt_NomPer.Text = PER.nomper;
            Txt_ApePer.Text = PER.apeper;
            
            Txt_CodDpt.Text = PER.coddpt.ToString().PadLeft(8, '0');
            Llenar_Lb_NomDpt(PER.coddpt);
            Dat_FenPer.Text = PER.fenper.ToShortDateString();
            Txt_CodGco.Text = PER.codgco.ToString().PadLeft(8, '0');
            Llenar_Lb_DesGco(PER.codgco);
            
            Dat_FeePer.Text = PER.feeper.ToShortDateString();
            if (PER.staper == 1)
            {
                Che_StaPer.Checked = true;
                Lb_StaPer.Text = "Activo";
                label5.Visible = false;
                Lb_FeePer.Visible = false;
                Dat_FeePer.Visible = false;
                Lb_StaPer.ForeColor = Color.Green;
            }
            else
            {
                Che_StaPer.Checked = false;
                Lb_StaPer.Text = "Egresado";
                label5.Visible = true;
                Lb_FeePer.Visible = true;
                Dat_FeePer.Visible = true;
                Lb_StaPer.ForeColor = Color.Red;
            }

            switch (PER.retper)
            {
                case 1:
                    radioButton1.Checked = true;
                    break;
                case 2:
                    radioButton2.Checked = true;
                    break;
            }

            Lb_CedPer.Text = PER.cedper.ToString();
            Lb_NomPer.Text = PER.nomper;
            Lb_ApePer.Text = PER.apeper;
            if (PER.nacper == "V")
            {
                Com_NacPer.Text = "VENEZOLANO";
                Lb_NacPer.Text = "VENEZOLANO";
            }
            else
            {
                if (PER.nacper == "E")
                {
                    Com_NacPer.Text = "EXTRAJERO";
                    Lb_NacPer.Text = "EXTRAJERO";
                }

            }

            Lb_CodDpt.Text = PER.coddpt.ToString().PadLeft(8, '0');
            Lb_FenPer.Text = PER.fenper.ToShortDateString();
            Lb_FeiPer.Text = PER.feiper.ToShortDateString();
            Lb_CodGru.Text = PER.codgco.ToString().PadLeft(8, '0');
            Lb_FeePer.Text = PER.feeper.ToShortDateString();
            Dat_FeiPer.Text = PER.feiper.ToShortDateString(); 
        }

        private void Llenar_Lb_NomDpt(int vCodigo)
        {
            Lb_NomDpt.Text = FunDP.Sent_NomDpt(vCodigo);
        }

        private void Llenar_Lb_DesGco(int vCodigo)
        {
            Lb_DesGco.Text = FunGCO.Sent_DesGco(vCodigo);
        }

        private void Actualizar()
        {
            PER = FunPER.Buscar(PER.cedper);
            Asignar();
        }

        private void Cmd_Guardar_Click(object sender, EventArgs e)
        {
            int vStaPer = 0;
            if (Che_StaPer.Checked)
                vStaPer = 1;
            else
                vStaPer = 0;

            int sRet = 0;
            if (radioButton1.Checked)
            {
                sRet = 1;
            }
            else
            {
                if (radioButton2.Checked)
                {
                    sRet = 2;
                }
            }
            if (ValidarDatos())
            {
                if (Evento.CompareTo("Nuevo") == 0)
                {
                    PER = new Clases._PERSONAL(Convert.ToInt32(Txt_CedPer.Text), Txt_NomPer.Text, Txt_ApePer.Text, Com_NacPer.Text.Substring(0, 1), Dat_FenPer.Value.Date, Convert.ToInt32(Txt_CodDpt.Text), Convert.ToInt32(Txt_CodGco.Text), Dat_FeiPer.Value, Dat_FeePer.Value, sRet, vStaPer);
                    if (FunPER.Nuevo(PER))
                    {
                        MessageBox.Show("Se agregó correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bloqueos();
                        Actualizar();
                    }
                    else
                    {
                        MessageBox.Show("El trabajador ya existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {

                    PER = new Clases._PERSONAL(Convert.ToInt32(Txt_CedPer.Text), Txt_NomPer.Text, Txt_ApePer.Text, Com_NacPer.Text.Substring(0,1), Dat_FenPer.Value, Convert.ToInt32(Txt_CodDpt.Text), Convert.ToInt32(Txt_CodGco.Text), Dat_FeiPer.Value, Dat_FeePer.Value, sRet, vStaPer);
                    if (FunPER.Modificar(PER))
                    {
                        MessageBox.Show("Se modificó correctamente.", "Atención ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bloqueos();
                        Actualizar();
                    }
                    else
                    {
                        MessageBox.Show("El grupo no existe en el sistema.", "Atención ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        public bool ValidarDatos()
        {
            if (Txt_CedPer.Text.Trim() == "")
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
                Txt_NomPer.Enabled = true;
                Txt_NomPer.BackColor = Color.Turquoise;
                Txt_NomPer.Focus();
                Txt_NomPer.SelectAll();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Primero_Click(object sender, EventArgs e)
        {
            PER = FunPER.BuscarPrimero();
            Asignar();
        }

        private void Cmd_Anterior_Click(object sender, EventArgs e)
        {
            PER = FunPER.BuscarAnterior(PER);
            Asignar();
        }

        private void Cmd_Siguiente_Click(object sender, EventArgs e)
        {
            PER = FunPER.BuscarSiguiente(PER);
            Asignar();
        }

        private void Cmd_Ultimo_Click(object sender, EventArgs e)
        {
            PER = FunPER.BuscarUltimo();
            Asignar();
        }

        private void Cmd_Buscar_Click(object sender, EventArgs e)
        {
            FormBUSQUEDAS f = new FormBUSQUEDAS();
            f.ListaPersonal();
            f.ShowDialog();
            if (f._CedPer != "")
            {
                PER = FunPER.Buscar(Convert.ToInt32(f._CedPer));
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
            PER = FunPER.BuscarUltimo();
            Asignar();
        }

        private void FormPERSONAL_KeyDown(object sender, KeyEventArgs e)
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

        private void Txt_CedPer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_CedPer.Text.Trim() != "")
                    {
                        if (!(FunPER.Existe(Convert.ToInt32(Txt_CedPer.Text))))
                        {
                            Util.CambiarTxt(Txt_CedPer, Txt_NomPer);
                        }
                        else
                        {
                            MessageBox.Show("La cedula del trabajador existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_CedPer.SelectAll();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo de cedula está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Cmd_Cancelar.PerformClick();
                    break;
            }
        }

        private void Txt_NomPer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_NomPer.Text.Trim() != "")
                    {
                        Util.CambiarTxt(Txt_NomPer, Txt_ApePer);
                    }
                    else
                        MessageBox.Show("El campo de nombre está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    if (Evento.CompareTo("Nuevo") == 0)
                    {
                        Util.CambiarTxt(Txt_NomPer, Txt_CedPer);
                    }
                    else
                    {
                        if (Evento.CompareTo("Modificar") == 0)
                        {
                            Cmd_Cancelar.PerformClick();
                        }
                    }
                    break;
            }
        }

        private void Txt_ApePer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_ApePer.Text.Trim() != "")
                    {
                        Util.CambiarTxt(Txt_ApePer, Com_NacPer);
                    }
                    else
                        MessageBox.Show("El campo de apellido está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_ApePer, Txt_NomPer);
                    break;
            }
        }

        private void Com_NacPer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Com_NacPer.Text.Trim() != "")
                    {
                        Util.CambiarTxt(Com_NacPer, Dat_FenPer);
                    }
                    else
                        MessageBox.Show("El campo de nacionalidad está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Com_NacPer, Txt_ApePer);
                    break;
            }
        }

        private void Dat_FenPer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Dat_FenPer.Text.Trim() != "")
                    {
                        Util.CambiarTxt(Dat_FenPer, Txt_CodDpt);
                    }
                    else
                        MessageBox.Show("El campo de fecha de nacimiento está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Dat_FenPer, Com_NacPer);
                    break;
            }
        }

      

        private void Txt_CodDpt_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_CodDpt.Text.Trim() != "")
                    {
                        if (FunDP.Existe(Convert.ToInt32(Txt_CodDpt.Text)))
                        {
                            if (FunDP.StatudAI(Convert.ToInt32(Txt_CodDpt.Text)))
                            {
                                Llenar_Lb_NomDpt(Convert.ToInt32(Txt_CodDpt.Text));
                                Util.CambiarTxt(Txt_CodDpt, Txt_CodGco);

                            }
                            else
                            {
                                MessageBox.Show("El departamento se encuentra inactivo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Txt_CodDpt.Focus();
                            }

                        }
                        else
                        {
                            MessageBox.Show("El departamento no existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_CodDpt.Focus();
                        }
                    }
                    else
                    {
                        FormBUSQUEDAS f = new FormBUSQUEDAS();
                        f.ListaDepartamentosAI();
                        f.ShowDialog();
                        if (f._CodDpt != "")
                        {
                            Txt_CodDpt.Text = f._CodDpt;
                            Llenar_Lb_NomDpt(Convert.ToInt32(f._CodDpt));
                            Util.CambiarTxt(Txt_CodDpt, Txt_CodGco);

                        }
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_CodDpt, Txt_ApePer);
                    break;
            }

        }

        private void Txt_CodGco_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_CodGco.Text.Trim() != "")
                    {
                        if (FunGCO.Existe(Convert.ToInt32(Txt_CodGco.Text)))
                        {
                            if (FunDP.StatudAI(Convert.ToInt32(Txt_CodGco.Text)))
                            {
                                Llenar_Lb_DesGco(Convert.ToInt32(Txt_CodGco.Text));
                                Util.CambiarTxt(Txt_CodGco, Dat_FeiPer);

                            }
                            else
                            {
                                MessageBox.Show("El departamento se encuentra inactivo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Txt_CodGco.Focus();
                            }

                        }
                        else
                        {
                            MessageBox.Show("El departamento no existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_CodGco.Focus();
                        }
                    }
                    else
                    {
                        FormBUSQUEDAS f = new FormBUSQUEDAS();
                        f.ListaGrupoPersonalAI();
                        f.ShowDialog();
                        if (f._CodGco != "")
                        {
                            Txt_CodGco.Text = f._CodGco;
                            Llenar_Lb_NomDpt(Convert.ToInt32(f._CodGco));
                            Util.CambiarTxt(Txt_CodGco, Dat_FeiPer);

                        }
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_CodGco, Txt_CodDpt);
                    break;
            }

        }

        private void Dat_FeiPer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Dat_FeiPer.Text.Trim() != "")
                    {
                        Cmd_Guardar.PerformClick();
                    }
                    else
                        MessageBox.Show("El campo de fecha de ingreso está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Dat_FeiPer, Txt_CodGco);
                    break;
            }
        }

        private void Txt_CedPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.SoloNumero(e);
        }

        private void Com_NacPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Txt_CodDpt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.SoloNumero(e);
        }

        private void Txt_CodGco_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.SoloNumero(e);
        }

        private void Txt_CodGco_Enter(object sender, EventArgs e)
        {
            Lb_DesGco.Text = "";
        }

        private void Txt_CodDpt_Enter(object sender, EventArgs e)
        {
            Lb_NomDpt.Text = "";
        }

        private void Txt_NomPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.SoloLetras(e);
        }

        private void Txt_ApePer_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.SoloLetras(e);
        }

        private void Che_StaPer_CheckedChanged(object sender, EventArgs e)
        {
   
        }

        private void Che_StaPer_CheckStateChanged(object sender, EventArgs e)
        {
            if (Che_StaPer.Checked == true)
            {
                label5.Visible = false;
                Lb_FeePer.Visible = false;
                Dat_FeePer.Visible = false;
            }
            else
            {
                if (Che_StaPer.Checked == false)
                {
                    label5.Visible = true;
                    Lb_FeePer.Visible = true;
                    Dat_FeePer.Visible = true;
                }
            }
        }

        private void FormPERSONAL_Load(object sender, EventArgs e)
        {
            PER = FunPER.BuscarUltimo();
            Asignar();
        }
    }
}
