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
    public partial class FormTIPDOC : Form
    {
        string[] TUsuario = new string[7];
        string Evento = "";
        Clases.Utilitarios Util = new Clases.Utilitarios();
        Clases._TIPDOC TID = new Clases._TIPDOC();
        Funciones.Fun_TIPDOC FunTID = new Funciones.Fun_TIPDOC();

        public FormTIPDOC(string[] _TUsuario)
        {
            InitializeComponent();
           
            TUsuario = _TUsuario;
            BotonesNormal(true);
            TID = FunTID.BuscarUltimo();
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
            Lb_TipTid.Visible = Mostrar;
            Lb_DesTid.Visible = Mostrar;
            Lb_ForTid.Visible = Mostrar;
            Lb_StaTid.Visible = Mostrar;
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

            Com_ForTid.Visible = false;
            Com_ForTid.Enabled = false;

            Che_StaTid.Enabled = false;
            Che_CalTid.Enabled = false;
            Che_MivTid.Enabled = false;

            Che_StaTid.Visible = false;
            Che_CalTid.Visible = true;
            Che_MivTid.Visible = true;
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
                        //IMPUT.SelectedIndex = -1;
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
            Txt_TipTid.Text = TID.tiptid;
            Txt_DesTid.Text = TID.destid;
            Com_ForTid.Text = TID.fortid;
            if (TID.caltid == 1)
            {
                Che_CalTid.Checked = true;
            }
            else
            {
                Che_CalTid.Checked = false;
            }
            if (TID.mivtid == 1)
            {
                Che_MivTid.Checked = true;
            }
            else
            {
                Che_MivTid.Checked = false;
            }
            if (TID.statid == 1)
            {
                Che_StaTid.Checked = true;
                Lb_StaTid.Text = "Activo";
                Lb_StaTid.ForeColor = Color.Green;

            }
            else
            {
                Che_StaTid.Checked = false;
                Lb_StaTid.Text = "Inactivo";
                Lb_StaTid.ForeColor = Color.Red;

            }
            Lb_CodTid.Text = TID.codtid.ToString().PadLeft(8, '0'); ;
            Lb_TipTid.Text = TID.tiptid;
            Lb_DesTid.Text = TID.destid;
            Lb_ForTid.Text = TID.fortid;
        }

        private void Actualizar()
        {
            TID = FunTID.BuscarCod(TID.codtid);
            Asignar();
        }
        private void Cmd_Guardar_Click(object sender, EventArgs e)
        {
            int vCalTid = 0;
            if (Che_CalTid.Checked)
                vCalTid = 1;
            else
                vCalTid = 0;
            int vMivTid = 0;
            if (Che_MivTid.Checked)
                vMivTid = 1;
            else
                vMivTid = 0;
            int vStaTid = 0;
            if (Che_StaTid.Checked)
                vStaTid = 1;
            else
                vStaTid = 0;

            if (ValidarDatos())
            {
                if (Evento.CompareTo("Nuevo") == 0)
                {
                    TID = new Clases._TIPDOC(Convert.ToInt32(FunTID.Correlativo()), Txt_TipTid.Text, Txt_DesTid.Text, Com_ForTid.Text, vCalTid, vMivTid, vStaTid);
                    if (FunTID.Nuevo(TID))
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
                    TID = new Clases._TIPDOC(Convert.ToInt32(Lb_CodTid.Text), Txt_TipTid.Text, Txt_DesTid.Text, Com_ForTid.Text, vCalTid, vMivTid, vStaTid);
                    if (FunTID.Modificar(TID))
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
            if (Txt_TipTid.Text.Trim() == "" || Txt_DesTid.Text.Trim() == "" || Com_ForTid.SelectedIndex == -1)
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
                Lb_CodTid.Text = FunTID.Correlativo().PadLeft(8, '0'); ;
                Txt_TipTid.Enabled = true;
                Txt_TipTid.BackColor = Color.Turquoise;
                Txt_TipTid.Focus();
                Che_StaTid.Checked = true;
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
                Txt_DesTid.Enabled = true;
                Txt_DesTid.BackColor = Color.Turquoise;
                Txt_DesTid.Focus();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Primero_Click(object sender, EventArgs e)
        {
            TID = FunTID.BuscarPrimero();
            Asignar();
        }

        private void Cmd_Anterior_Click(object sender, EventArgs e)
        {
            TID = FunTID.BuscarAnterior(TID);
            Asignar();
        }

        private void Cmd_Siguiente_Click(object sender, EventArgs e)
        {
            TID = FunTID.BuscarSiguiente(TID);
            Asignar();
        }

        private void Cmd_Ultimo_Click(object sender, EventArgs e)
        {
            TID = FunTID.BuscarUltimo();
            Asignar();
        }

        private void Cmd_Buscar_Click(object sender, EventArgs e)
        {
            FormBUSQUEDAS f = new FormBUSQUEDAS();
            f.ListaTipoDocumentos();
            f.ShowDialog();
            if (f._TipTra != "")
            {
                TID = FunTID.BuscarTipo(f._TipTra);
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
            TID = FunTID.BuscarUltimo();
            Asignar();
            Lb_CodTid.Focus();
        }

        private void Txt_TipTid_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_TipTid.Text.Trim() != "")
                    {
                        if (!(FunTID.Existe(Txt_TipTid.Text)))
                        {
                            Util.CambiarTxt(Txt_TipTid, Txt_DesTid);
                        }
                        else
                        {
                            MessageBox.Show("El tipo de documento ya existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_TipTid.Focus();
                            Txt_TipTid.SelectAll();
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

        private void Txt_DesTid_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_DesTid.Text.Trim() != "")
                    {

                        Util.CambiarTxt(Txt_DesTid, Com_ForTid);
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
                        Util.CambiarTxt(Txt_DesTid, Txt_TipTid);
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

        private void Com_ForTid_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Com_ForTid.Text.Trim() != "")
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
                    Util.CambiarTxt(Com_ForTid, Txt_DesTid);
                    break;
            }
        }

        private void Com_ForTid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FormTIPDOC_KeyDown(object sender, KeyEventArgs e)
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
