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
    public partial class FormTIPCAJ : Form
    {
        string[] TUsuario = new string[7];
        string Evento = "";
        Clases.Utilitarios Util = new Clases.Utilitarios();
        Clases._TIPMOVCAJA TMC = new Clases._TIPMOVCAJA();
        Funciones.Fun_TIPMOVCAJA FunTMC = new Funciones.Fun_TIPMOVCAJA();

        public FormTIPCAJ(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
            BotonesNormal(true);
            TMC = FunTMC.BuscarUltimo();
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
            Lb_TipTmc.Visible = Mostrar;
            Lb_DesTmc.Visible = Mostrar;
            Lb_ForTmc.Visible = Mostrar;
            Lb_StaTmc.Visible = Mostrar;
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
                    IMPUT.BackColor = Color.White;
                }
            }
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is CheckBox)
                {
                    CheckBox IMPUT = ctrl as CheckBox;
                    IMPUT.Visible = false;
                    IMPUT.Enabled = false;

                }
            }
            foreach (Control ctrl in this.Controls)
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
                        IMPUT.Enabled = true;
                        IMPUT.Checked = false;
                    }
                }
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is ComboBox)
                    {
                        ComboBox IMPUT = ctrl as ComboBox;
                        IMPUT.SelectedIndex = -1;
                        IMPUT.Text = "";
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
                            IMPUT.Enabled = true;
                        }
                    }
                    foreach (Control ctrl in this.Controls)
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
            Txt_TipTmc.Text = TMC.tiptmc;
            Txt_DesTmc.Text = TMC.destmc;
            Com_ForTmc.Text = TMC.fortmc;
            if (TMC.statmc == 1)
            {
                Che_StaTmc.Checked = true;
                Lb_StaTmc.Text = "Activo";
                Lb_StaTmc.ForeColor = Color.Green;
            }
            else
            {
                Che_StaTmc.Checked = false;
                Lb_StaTmc.Text = "Inactivo";
                Lb_StaTmc.ForeColor = Color.Red;
            }
            Lb_CodTmc.Text = TMC.codtmc.ToString().PadLeft(8, '0'); ;
            Lb_TipTmc.Text = TMC.tiptmc;
            Lb_DesTmc.Text = TMC.destmc;
            Lb_ForTmc.Text = TMC.fortmc;
        }

        private void Actualizar()
        {
            TMC = FunTMC.BuscarCod(TMC.codtmc);
            Asignar();
        }

        private void Cmd_Guardar_Click(object sender, EventArgs e)
        {
            int vStaTid = 0;
            if (Che_StaTmc.Checked)
                vStaTid = 1;
            else
                vStaTid = 0;

            if (ValidarDatos())
            {
                if (Evento.CompareTo("Nuevo") == 0)
                {
                    TMC = new Clases._TIPMOVCAJA(Convert.ToInt32(FunTMC.Correlativo()), Txt_TipTmc.Text, Txt_DesTmc.Text, Com_ForTmc.Text, vStaTid);
                    if (FunTMC.Nuevo(TMC))
                    {
                        MessageBox.Show("Se agregó correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bloqueos();
                        Actualizar();
                    }
                    else
                    {
                        MessageBox.Show("La transacción ya existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    TMC = new Clases._TIPMOVCAJA(Convert.ToInt32(Lb_CodTmc.Text), Txt_TipTmc.Text, Txt_DesTmc.Text, Com_ForTmc.Text, vStaTid);
                    if (FunTMC.Modificar(TMC))
                    {
                        MessageBox.Show("Se modificó correctamente.", "Atención ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bloqueos();
                        Actualizar();
                    }
                    else
                    {
                        MessageBox.Show("La transacción no existe en el sistema.", "Atención ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        public bool ValidarDatos()
        {
            if (Txt_TipTmc.Text.Trim() == "" || Txt_DesTmc.Text.Trim() == "" || Com_ForTmc.SelectedIndex == -1)
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
                Lb_CodTmc.Text = FunTMC.Correlativo().PadLeft(8, '0'); ;
                Txt_TipTmc.Enabled = true;
                Txt_TipTmc.BackColor = Color.Turquoise;
                Txt_TipTmc.Focus();
                Che_StaTmc.Checked = true;
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
                Txt_DesTmc.Enabled = true;
                Txt_DesTmc.BackColor = Color.Turquoise;
                Txt_DesTmc.Focus();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Primero_Click(object sender, EventArgs e)
        {
            TMC = FunTMC.BuscarPrimero();
            Asignar();
        }

        private void Cmd_Anterior_Click(object sender, EventArgs e)
        {
            TMC = FunTMC.BuscarAnterior(TMC);
            Asignar();
        }

        private void Cmd_Siguiente_Click(object sender, EventArgs e)
        {
            TMC = FunTMC.BuscarSiguiente(TMC);
            Asignar();
        }

        private void Cmd_Ultimo_Click(object sender, EventArgs e)
        {
            TMC = FunTMC.BuscarUltimo();
            Asignar();
        }

        private void Cmd_Buscar_Click(object sender, EventArgs e)
        {
            FormBUSQUEDAS f = new FormBUSQUEDAS();
            f.ListaTMovCaja();
            f.ShowDialog();
            if (f._TipTmc != "")
            {
                TMC = FunTMC.BuscarTipo(f._TipTmc);
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
            TMC = FunTMC.BuscarUltimo();
            Asignar();
            Lb_CodTmc.Focus();
        }

        private void Txt_TipTmc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_TipTmc.Text.Trim() != "")
                    {
                        if (!(FunTMC.Existe(Txt_TipTmc.Text)))
                        {
                            Util.CambiarTxt(Txt_TipTmc, Txt_DesTmc);
                        }
                        else
                        {
                            MessageBox.Show("El tipo de documento ya existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_TipTmc.Focus();
                            Txt_TipTmc.SelectAll();
                        }

                    }
                    else
                    {
                        MessageBox.Show("El campo de tipo de documeto está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Cmd_Cancelar.PerformClick();
                    break;
            }
        }

        private void Txt_DesTmc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_DesTmc.Text.Trim() != "")
                    {

                        Util.CambiarTxt(Txt_DesTmc, Com_ForTmc);
                    }
                    else
                    {
                        MessageBox.Show("El campo de descripción está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_DesTmc, Txt_TipTmc);
                    break;
            }
        }

        private void Com_ForTmc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Com_ForTmc.Text.Trim() != "")
                    {

                        Cmd_Guardar.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Debe de seleccionar un registro está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    if (Evento.CompareTo("Nuevo") == 0)
                    {
                        Util.CambiarTxt(Com_ForTmc, Txt_DesTmc);
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

        private void Com_ForTmc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FormTIPCAJ_KeyDown(object sender, KeyEventArgs e)
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
