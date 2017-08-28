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
    public partial class FormTIPTRANSA : Form
    {
        string[] TUsuario = new string[7];
        string Evento = "";
        Clases.Utilitarios Util = new Clases.Utilitarios();
        Clases._TIPTRAN TIPTRA = new Clases._TIPTRAN();
        Funciones.Fun_TIPTRAN FunTIPTRA = new Funciones.Fun_TIPTRAN();

        public FormTIPTRANSA(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
            BotonesNormal(true);
            GenColumnas();
            FunTIPTRA.GetLisPRODUCTOS(ref listView1);
            TIPTRA = FunTIPTRA.BuscarUltimo();
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

        protected void GenColumnas()
        {
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            listView1.HideSelection = false;
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Cod. Producto", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Descripcion del Producto", 442, HorizontalAlignment.Left);
        }
        private void BotonesControl(bool Mostrar)
        {
            Cmd_Guardar.Visible = Mostrar;
            Cmd_Cancelar.Visible = Mostrar;
        }
        private void Lbl(bool Mostrar)
        {
            Lb_TipTra.Visible = Mostrar;
            Lb_DesTra.Visible = Mostrar;
            Lb_StaTra.Visible = Mostrar;
        }
        private void Bloqueos()
        {
            BotonesNormal(true);
            BotonesControl(false);
            Lbl(true);
            listView1.Enabled = false;
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
            listView1.Enabled = true;
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
                foreach (ListViewItem lv in listView1.Items)
                {
                    lv.Checked = false;
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
            AsignarENC();
            AsignarDET();
        }
        private void AsignarENC()
        {
            Txt_TipTra.Text = TIPTRA.tiptra;
            Txt_DesTra.Text = TIPTRA.destra;
            if (TIPTRA.statra == 1)
            {
                Che_StaTra.Checked = true;
                Lb_StaTra.Text = "Activo";
                Lb_StaTra.ForeColor = Color.Green;

            }
            else
            {
                Che_StaTra.Checked = false;
                Lb_StaTra.Text = "Inactivo";
                Lb_StaTra.ForeColor = Color.Red;
            }
            Lb_CodTra.Text = TIPTRA.codtra.ToString().PadLeft(8, '0'); ;
            Lb_TipTra.Text = TIPTRA.tiptra;
            Lb_DesTra.Text = TIPTRA.destra;
        }

        private void AsignarDET()
        {
            int ele;
            foreach (ListViewItem lv in listView1.Items)
            {
                ele = Convert.ToInt32(lv.SubItems[0].Text);
                if (Array.Exists(TIPTRA.codpro, element => element == ele))
                {
                    lv.Checked = true;
                }
                else
                {
                    lv.Checked = false;
                }
            }
        }

        private void Actualizar()
        {
            TIPTRA = FunTIPTRA.BuscarCod(TIPTRA.codtra);
            Asignar();
        }

        private void Cmd_Guardar_Click(object sender, EventArgs e)
        {
            int vStaTra = 0;
            if (Che_StaTra.Checked)
                vStaTra = 1;
            else
                vStaTra = 0;
            List<int> array = new List<int>();

            foreach (ListViewItem lv in listView1.Items)
            {
               if(lv.Checked)
                {
                    array.Add(Convert.ToInt32(lv.SubItems[0].Text));
                }
            }

            if (ValidarDatos())
            {
                if (Evento.CompareTo("Nuevo") == 0)
                {
                    TIPTRA = new Clases._TIPTRAN(Convert.ToInt32(FunTIPTRA.Correlativo()), Txt_TipTra.Text, Txt_DesTra.Text, vStaTra, array.ToArray());
                    if (FunTIPTRA.Nuevo(TIPTRA))
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
                    TIPTRA = new Clases._TIPTRAN(Convert.ToInt32(Lb_CodTra.Text), Txt_TipTra.Text, Txt_DesTra.Text, vStaTra, array.ToArray());
                    if (FunTIPTRA.Modificar(TIPTRA))
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
            if (Txt_TipTra.Text.Trim() == "" || Txt_DesTra.Text.Trim() == "")
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
                Lb_CodTra.Text = FunTIPTRA.Correlativo().PadLeft(8, '0'); ;
                Txt_TipTra.Enabled = true;
                Txt_TipTra.BackColor = Color.Turquoise;
                Txt_TipTra.Focus();
                Che_StaTra.Checked = true;
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
                Txt_DesTra.Enabled = true;
                Txt_DesTra.BackColor = Color.Turquoise;
                Txt_DesTra.Focus();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Primero_Click(object sender, EventArgs e)
        {
            TIPTRA = FunTIPTRA.BuscarPrimero();
            Asignar();
        }

        private void Cmd_Anterior_Click(object sender, EventArgs e)
        {
            TIPTRA = FunTIPTRA.BuscarAnterior(TIPTRA);
            Asignar();
        }

        private void Cmd_Siguiente_Click(object sender, EventArgs e)
        {
            TIPTRA = FunTIPTRA.BuscarSiguiente(TIPTRA);
            Asignar();
        }

        private void Cmd_Ultimo_Click(object sender, EventArgs e)
        {
            TIPTRA = FunTIPTRA.BuscarUltimo();
            Asignar();
        }

        private void Cmd_Buscar_Click(object sender, EventArgs e)
        {
            FormBUSQUEDAS f = new FormBUSQUEDAS();
            f.ListaTransacciones();
            f.ShowDialog();
            if (f._TipTra != "")
            {
                TIPTRA = FunTIPTRA.BuscarTipo(f._TipTra);
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
            TIPTRA = FunTIPTRA.BuscarUltimo();
            Asignar();
        }

        private void Txt_TipTra_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_TipTra.Text.Trim() != "")
                    {
                        if (!(FunTIPTRA.Existe(Txt_TipTra.Text)))
                        {
                            Util.CambiarTxt(Txt_TipTra, Txt_DesTra);
                        }
                        else
                        {
                            MessageBox.Show("El tipo de transacción ya existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_TipTra.Focus();
                            Txt_TipTra.SelectAll();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("El campo de transacción está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Cmd_Cancelar.PerformClick();
                    break;
            }
        }

        private void Txt_DesTra_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_DesTra.Text.Trim() != "")
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
                        Util.CambiarTxt(Txt_DesTra, Txt_TipTra);
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

        private void FormTIPTRANSA_KeyDown(object sender, KeyEventArgs e)
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
