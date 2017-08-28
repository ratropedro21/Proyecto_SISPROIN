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
    public partial class FormDEPARTAMENTO : Form
    {
        string[] TUsuario = new string[7];
        string Evento = "";
        Clases.Utilitarios Util = new Clases.Utilitarios();
        Clases._DEPARTA DP = new Clases._DEPARTA();
        Funciones.Fun_DEPARTA FunDP = new Funciones.Fun_DEPARTA();
        public FormDEPARTAMENTO(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
            BotonesNormal(true);
            DP = FunDP.BuscarUltimo();
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
            Lb_NomDpt.Visible = Mostrar;
            Lb_StaDpt.Visible = Mostrar;
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
        private void Asignar()
        {
            Txt_NomDpt.Text = DP.nomdpt;
            if (DP.stadpt == 1)
            {
                Che_StaDpt.Checked = true;
                Lb_StaDpt.Text = "Activo";
                Lb_StaDpt.ForeColor = Color.Green;
            }
            else
            {
                Che_StaDpt.Checked = false;
                Lb_StaDpt.Text = "Inactivo";
                Lb_StaDpt.ForeColor = Color.Red;
            }
            Lb_CodDpt.Text = DP.coddpt.ToString().PadLeft(8, '0'); ;
            Lb_NomDpt.Text = DP.nomdpt;
        }

        private void Actualizar()
        {
            DP = FunDP.Buscar(DP.coddpt);
            Asignar();
        }

        private void Cmd_Guardar_Click(object sender, EventArgs e)
        {
            int vStaDpt = 0;
            if (Che_StaDpt.Checked)
                vStaDpt = 1;
            else
                vStaDpt = 0;
            if (ValidarDatos())
            {
                if (Evento.CompareTo("Nuevo") == 0)
                {
                    DP = new Clases._DEPARTA(Convert.ToInt32(FunDP.Correlativo()), Txt_NomDpt.Text, vStaDpt);
                    if (FunDP.Nuevo(DP))
                    {
                        MessageBox.Show("Se agregó correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bloqueos();
                        Actualizar();
                    }
                    else
                    {
                        MessageBox.Show("El departamento ya existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    DP = new Clases._DEPARTA(Convert.ToInt32(Lb_CodDpt.Text), Txt_NomDpt.Text, vStaDpt);
                    if (FunDP.Modificar(DP))
                    {
                        MessageBox.Show("Se modificó correctamente.", "Atención ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bloqueos();
                        Actualizar();
                    }
                    else
                    {
                        MessageBox.Show("El departamento no existe en el sistema.", "Atención ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        public bool ValidarDatos()
        {
            if (Txt_NomDpt.Text.Trim() == "")
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
                Lb_CodDpt.Text = FunDP.Correlativo().PadLeft(8, '0'); ;
                Txt_NomDpt.Enabled = true;
                Txt_NomDpt.BackColor = Color.Turquoise;
                Txt_NomDpt.Focus();
                Che_StaDpt.Checked = true;
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
                Txt_NomDpt.Enabled = true;
                Txt_NomDpt.BackColor = Color.Turquoise;
                Txt_NomDpt.Focus();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Primero_Click(object sender, EventArgs e)
        {
            DP = FunDP.BuscarPrimero();
            Asignar();
        }

        private void Cmd_Anterior_Click(object sender, EventArgs e)
        {
            DP = FunDP.BuscarAnterior(DP);
            Asignar();
        }

        private void Cmd_Siguiente_Click(object sender, EventArgs e)
        {
            DP = FunDP.BuscarSiguiente(DP);
            Asignar();
        }

        private void Cmd_Ultimo_Click(object sender, EventArgs e)
        {
            DP = FunDP.BuscarUltimo();
            Asignar();
        }

        private void Cmd_Buscar_Click(object sender, EventArgs e)
        {
            FormBUSQUEDAS f = new FormBUSQUEDAS();
            f.ListaDepartamentos();
            f.ShowDialog();
            if (f._CodDpt != "")
            {
                DP = FunDP.Buscar(Convert.ToInt32(f._CodDpt));
                Actualizar();
            }
        }

        private void Cmd_Eliminar_Click(object sender, EventArgs e)
        {

        }

        private void Cmd_Cancelar_Click(object sender, EventArgs e)
        {
            Bloqueos();
            DP = FunDP.BuscarUltimo();
            Asignar();
        }

        private void Txt_NomDpt_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_NomDpt.Text.Trim() != "")
                    {
                        Cmd_Guardar.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("El campo de nombre está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Cmd_Cancelar.PerformClick();
                    break;
            }
        }

        private void FormDEPARTAMENTO_KeyDown(object sender, KeyEventArgs e)
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
