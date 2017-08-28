using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISPROIN.Formularios.Configuracion
{
    public partial class FormAGREGARUSU : Form
    {
        string[] TUsuario = new string[7];
        Clases.Utilitarios Util = new Clases.Utilitarios();
        string Evento = "";
        Clases._USUARIOS USU = new Clases._USUARIOS();
        Funciones.Fun_AGREGARUSU FunAG = new Funciones.Fun_AGREGARUSU();
        Funciones.Fun_DEPARTA FunDP = new Funciones.Fun_DEPARTA();
        public FormAGREGARUSU(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
            BotonesNormal(true);
            USU = FunAG.BuscarUltimo();
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
           // Cmd_Eliminar.Visible = Mostrar;
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
            Lbl_CodUsu.Visible = Mostrar;
            Lbl_ClaUsu.Visible = Mostrar;
            Lbl_NomUsu.Visible = Mostrar;
            Lbl_CodDpt.Visible = Mostrar;
            Lbl_StaUsu.Visible = Mostrar;
        }
        private void Asignar()
        {
            Txt_UsuUsu.Text = USU.usuusu;
            Txt_ClaUsu.Text = USU.clausu;
            Txt_NomUsu.Text = USU.nomusu;
            Txt_CodDpt.Text = USU.coddpt.ToString();
            if (USU.stausu == 1)
            {

                Che_StaUsu.Checked = true;
                Lbl_StaUsu.Text = "Activo";
                Lbl_StaUsu.ForeColor = Color.Green;
            }
            else
            {
                Che_StaUsu.Checked = false;
                Lbl_StaUsu.Text = "Inactivo";
                Lbl_StaUsu.ForeColor = Color.Red;
            }
            Lbl_CodUsu.Text = USU.usuusu;
            Lbl_ClaUsu.Text = "************";
            Lbl_NomUsu.Text = USU.nomusu;
            Lbl_CodDpt.Text = USU.coddpt.ToString();
            Llenar_Lb_NomDpt(USU.coddpt);
        }

        private void Llenar_Lb_NomDpt(int vCodDpt)
        {
            Lb_NomDpt.Text = FunDP.Sent_NomDpt(vCodDpt);
        }

        public bool ValidarDatos()
        {
            if (Txt_UsuUsu.Text.Trim() == "" || Txt_ClaUsu.Text.Trim() == "" || Txt_NomUsu.Text.Trim() == "" || Txt_CodDpt.Text.Trim() == "")
            {
                MessageBox.Show("DEBE LLENAR TODOS LOS CAMPOS.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
                return true;
        }
        private void Bloqueos()
        {
            BotonesNormal(true);
            BotonesControl(false);
            Lbl(true);
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox IMPUT = ctrl as TextBox;
                    IMPUT.Visible = false;
                    IMPUT.Enabled = false;
                    IMPUT.BackColor = System.Drawing.Color.White;
                }
            }
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is CheckBox)
                {
                    CheckBox IMPUT = ctrl as CheckBox;
                    IMPUT.Visible = false;
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
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        TextBox IMPUT = ctrl as TextBox;
                        IMPUT.Clear();
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
            }
            else
            {
                if (Evento.CompareTo("Modificar") == 0)
                {
                    foreach (Control ctrl in this.Controls)
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
                }
            }
        }

        private void Cmd_Guardar_Click(object sender, EventArgs e)
        {
            int vStaUsu = 0;
            if (Che_StaUsu.Checked)
                vStaUsu = 1;
            else
                vStaUsu = 0;
            if (ValidarDatos())
            {
                if (Evento.CompareTo("Nuevo") == 0)
                {
                    USU = new Clases._USUARIOS(Txt_UsuUsu.Text, Txt_ClaUsu.Text, Txt_NomUsu.Text, Convert.ToInt32(Txt_CodDpt.Text), vStaUsu);
                    if (FunAG.Nuevo(USU))
                    {
                        MessageBox.Show("SE AGREGÓ CORRECTAMENTE.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bloqueos();
                        USU = FunAG.Buscar(USU.usuusu);
                        Asignar();
                    }
                    else
                    {
                        MessageBox.Show("EL USUARIO YA EXISTE.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    USU = new Clases._USUARIOS(Txt_UsuUsu.Text, Txt_ClaUsu.Text, Txt_NomUsu.Text, Convert.ToInt32(Txt_CodDpt.Text), vStaUsu);
                    if (FunAG.Modificar(USU))
                    {
                        MessageBox.Show("SE MODIFICÓ CORRECTAMENTE.", "Atención ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bloqueos();
                        USU = FunAG.Buscar(USU.usuusu);
                        Asignar();
                    }
                    else
                    {
                        MessageBox.Show("EL USUARIO NO EXISTE EN EL SISTEMA.", "Atención ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        private void Cmd_Nuevo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TUsuario[5]) < 5)
            {
                Evento = "Nuevo";
                Desbloqueos();
                Txt_UsuUsu.Enabled = true;
                Txt_UsuUsu.BackColor = Color.Turquoise;
                Txt_UsuUsu.Focus();
                Lb_NomDpt.Text = "";
                Che_StaUsu.Checked = true;
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Modificar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TUsuario[5]) < 4)
            {
                Evento = "Modificar";
                Desbloqueos();
                Txt_ClaUsu.Enabled = true;
                Txt_ClaUsu.BackColor = Color.Turquoise;
                Txt_ClaUsu.Focus();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Primero_Click(object sender, EventArgs e)
        {
            USU = FunAG.BuscarPrimero();
            Asignar();
        }

        private void Cmd_Anterior_Click(object sender, EventArgs e)
        {
            USU = FunAG.BuscarAnterior(USU);
            Asignar();
        }

        private void Cmd_Siguiente_Click(object sender, EventArgs e)
        {
            USU = FunAG.BuscarSiguiente(USU);
            Asignar();
        }

        private void Cmd_Ultimo_Click(object sender, EventArgs e)
        {
            USU = FunAG.BuscarUltimo();
            Asignar();
        }

        private void Cmd_Buscar_Click(object sender, EventArgs e)
        {

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
            USU = FunAG.BuscarUltimo();
            Asignar();
        }

        private void Txt_UsuUsu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_UsuUsu.Text.Trim() != "")
                    {
                        if (!(FunAG.Existe(Txt_UsuUsu.Text)))
                        {
                            Util.CambiarTxt(Txt_UsuUsu, Txt_ClaUsu);
                        }
                        else
                        {
                            MessageBox.Show("El usuario ya existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_UsuUsu.Focus();
                            Txt_UsuUsu.SelectAll();
                        }
                    }
                    else
                        MessageBox.Show("El campo de usuario está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Cmd_Cancelar.PerformClick();
                    break;
            }
        }

        private void Txt_ClaUsu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_ClaUsu.Text.Trim() != "")
                    {
                        Util.CambiarTxt(Txt_ClaUsu, Txt_NomUsu);
                    }
                    else
                    {
                        MessageBox.Show("El campo de clave está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    if (Evento.CompareTo("Nuevo") == 0)
                    {
                        Util.CambiarTxt(Txt_ClaUsu, Txt_UsuUsu);
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

        private void Txt_NomUsu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_NomUsu.Text.Trim() != "")
                    {
                        Util.CambiarTxt(Txt_NomUsu, Txt_CodDpt);
                    }
                    else
                    {
                        MessageBox.Show("El campo de nombre está vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_NomUsu, Txt_ClaUsu);
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
                                Cmd_Guardar.PerformClick();
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
                            Cmd_Guardar.PerformClick();
                        }
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_CodDpt, Txt_NomUsu);
                    break;
            }
        }

        private void Txt_CodDpt_Enter(object sender, EventArgs e)
        {
            Lb_NomDpt.Text = "";
        }

        private void FormAGREGARUSU_KeyDown(object sender, KeyEventArgs e)
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

        private void Txt_CodDpt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.SoloNumero(e);
        }
    }
}
