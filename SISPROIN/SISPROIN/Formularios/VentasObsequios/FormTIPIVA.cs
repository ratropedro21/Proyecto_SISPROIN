using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISPROIN.Formularios.VentasObsequios
{
    public partial class FormTIPIVA : Form
    {
        string[] TUsuario = new string[7];
        string Evento = "";
        Clases.Utilitarios Util = new Clases.Utilitarios();
        Clases._TIPIVA TIV = new Clases._TIPIVA();
        Funciones.Fun_TIPIVA FunTIV = new Funciones.Fun_TIPIVA();
        public FormTIPIVA(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
            BotonesNormal(true);
            TIV = FunTIV.BuscarUltimo();
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
            Lb_TipTiv.Visible = Mostrar;
            Lb_DesTiv.Visible = Mostrar;
            Lb_StaTiv.Visible = Mostrar;
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
            Txt_TipTiv.Text = TIV.tiptiv;
            Txt_DesTiv.Text = TIV.destiv;
            if (TIV.stativ == 1)
            {
                Che_StaTiv.Checked = true;
                Lb_StaTiv.Text = "Activo";
                Lb_StaTiv.ForeColor = Color.Green;
            }
            else
            {
                Che_StaTiv.Checked = false;
                Lb_StaTiv.Text = "Inactivo";
                Lb_StaTiv.ForeColor = Color.Red;
            }
            Lb_CodTiv.Text = TIV.codtiv.ToString().PadLeft(8, '0'); ;
            Lb_TipTiv.Text = TIV.tiptiv;
            Lb_DesTiv.Text = TIV.destiv;
        }

        private void Actualizar()
        {
            TIV = FunTIV.BuscarCod(TIV.codtiv);
            Asignar();
        }

        private void Cmd_Guardar_Click(object sender, EventArgs e)
        {
            int vStaTiv = 0;
            if (Che_StaTiv.Checked)
                vStaTiv = 1;
            else
                vStaTiv = 0;
            if (ValidarDatos())
            {
                if (Evento.CompareTo("Nuevo") == 0)
                {
                    TIV = new Clases._TIPIVA(Convert.ToInt32(FunTIV.Correlativo()), Txt_TipTiv.Text, Txt_DesTiv.Text, vStaTiv);
                    if (FunTIV.Nuevo(TIV))
                    {
                        MessageBox.Show("Se agregó correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bloqueos();
                        Actualizar();
                    }
                    else
                    {
                        MessageBox.Show("El tipo de IVA ya existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    if (Evento.CompareTo("Modificar") == 0)
                    {
                        TIV = new Clases._TIPIVA(Convert.ToInt32(Lb_CodTiv.Text), Txt_TipTiv.Text, Txt_DesTiv.Text, vStaTiv);
                        if (FunTIV.Modificar(TIV))
                        {
                            MessageBox.Show("Se modificó correctamente.", "Atención ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Bloqueos();
                            Actualizar();
                        }
                        else
                        {
                            MessageBox.Show("El tipo de IVA no existe en el sistema.", "Atención ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
        }

        public bool ValidarDatos()
        {
            if (Txt_TipTiv.Text.Trim() == "" || Txt_DesTiv.Text.Trim() == "")
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
                Lb_CodTiv.Text = FunTIV.Correlativo().PadLeft(8, '0'); ;
                Txt_TipTiv.Enabled = true;
                Txt_TipTiv.BackColor = Color.Turquoise;
                Txt_TipTiv.Focus();
                Che_StaTiv.Checked = true;
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
                Txt_DesTiv.Enabled = true;
                Txt_DesTiv.BackColor = Color.Turquoise;
                Txt_DesTiv.Focus();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Primero_Click(object sender, EventArgs e)
        {
            TIV = FunTIV.BuscarPrimero();
            Asignar();
        }

        private void Cmd_Anterior_Click(object sender, EventArgs e)
        {
            TIV = FunTIV.BuscarAnterior(TIV);
            Asignar();
        }

        private void Cmd_Siguiente_Click(object sender, EventArgs e)
        {
            TIV = FunTIV.BuscarSiguiente(TIV);
            Asignar();
        }

        private void Cmd_Ultimo_Click(object sender, EventArgs e)
        {
            TIV = FunTIV.BuscarUltimo();
            Asignar();
        }

        private void Cmd_Buscar_Click(object sender, EventArgs e)
        {
            FormBUSQUEDAS f = new FormBUSQUEDAS();
            f.ListaTipoIVA();
            f.ShowDialog();
            if (f._TipTiv != "")
            {
                TIV = FunTIV.BuscarTip(f._TipTiv);
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
            TIV = FunTIV.BuscarUltimo();
            Asignar();
        }

        private void Txt_TipTiv_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_TipTiv.Text.Trim() != "")
                    {
                        if (!(FunTIV.Existe(Txt_TipTiv.Text)))
                        {
                            Util.CambiarTxt(Txt_TipTiv, Txt_DesTiv);
                        }
                        else
                        {
                            MessageBox.Show("El tipo de IVA ya existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_TipTiv.Focus();
                            Txt_TipTiv.SelectAll();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo de Tipo de IVA está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Cmd_Cancelar.PerformClick();
                    break;
            }
        }

        private void Txt_DesTiv_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_DesTiv.Text.Trim() != "")
                    {

                        Cmd_Guardar.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("El campo de descripción está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    if (Evento.CompareTo("Nuevo") == 0)
                    {
                        Util.CambiarTxt(Txt_DesTiv, Txt_TipTiv);
                    }
                    else
                    {
                        if (Evento.CompareTo("Nuevo") == 0)
                        {
                            e.SuppressKeyPress = true;
                            Cmd_Cancelar.PerformClick();
                        }


                    }
                    break;
            }
        }

        private void FormTIPIVA_KeyDown(object sender, KeyEventArgs e)
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
