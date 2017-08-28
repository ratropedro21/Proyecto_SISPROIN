using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISPROIN.Formularios
{
    public partial class FormPASSWORD : Form
    {
        Funciones.Fun_USUARIOS FunUSU = new Funciones.Fun_USUARIOS();
        Funciones.Fun_AGREGARUSU FunAUSU = new Funciones.Fun_AGREGARUSU();
        Clases.Utilitarios Util = new Clases.Utilitarios();
        bool band;
        public FormPASSWORD()
        {
            InitializeComponent();
            this.Txt_UsuUsu.Enabled = true;
            this.Txt_UsuUsu.Focus();
            Txt_UsuUsu.BackColor = Color.Turquoise;
        }

        private void Cmd_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Cmd_Aceptar_Click(object sender, EventArgs e)
        {
            VarLogin();
        }

        private void VarLogin()
        {
            Clases._USUARIOS USU = new Clases._USUARIOS(Txt_UsuUsu.Text.Trim(), Txt_ClaUsu.Text.Trim());
            if (FunUSU.ValidarLogin(ref USU))
            {
                if (USU.stausu == 1)
                {
                    string[] TUsuario = new string[7];
                    TUsuario[0] = USU.usuusu;
                    TUsuario[1] = USU.nomusu;
                    TUsuario[2] = USU.coddpt.ToString();
                    FormINICIO Fmr = new FormINICIO(TUsuario);

                   //MessageBox.Show("Bienvenido al Sistema... Sr(a).: " + TUsuario[1], "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                    //Fmr.Text = Fmr.Text + " - Bienvenido Sr.(a): " + TUsuario[1];
                    Fmr.ShowDialog();
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Usuario Inactivo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Util.CambiarTxt(Txt_ClaUsu, Txt_UsuUsu);
                    this.Txt_UsuUsu.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Usuario o clave incorrecta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Util.CambiarTxt(Txt_ClaUsu, Txt_UsuUsu);
                this.Txt_UsuUsu.SelectAll();
            }
        }

        private void Txt_UsuUsu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_UsuUsu.Text.Trim() != "")
                    {
                        //if (FunAUSU.Existe(Txt_UsuUsu.Text))
                        //{

                        Util.CambiarTxt(Txt_UsuUsu, Txt_ClaUsu);
                        Txt_UsuUsu.SelectAll();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("El usuario no existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //    Txt_UsuUsu.SelectAll();
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Debe de colocar un usuario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Txt_UsuUsu.Focus();
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Cmd_Salir.PerformClick();
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
                        VarLogin();
                    }
                    else
                    {
                        MessageBox.Show("Debe de colocar un password.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Txt_ClaUsu.SelectAll();
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_ClaUsu, Txt_UsuUsu);
                    break;
            }
        }

    

        private void FormPASSWORD_Load(object sender, EventArgs e)
        {

        }
    }
}
