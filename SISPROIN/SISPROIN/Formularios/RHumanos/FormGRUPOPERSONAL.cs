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
    public partial class FormGRUPOPERSONAL : Form
    {
        string[] TUsuario = new string[7];
        string Evento = "";
        Clases.Utilitarios Util = new Clases.Utilitarios();
        Clases._GRUPCOMOBS GCO = new Clases._GRUPCOMOBS();
        Funciones.Fun_GRUPCOMOBS FunGCO = new Funciones.Fun_GRUPCOMOBS();
        public FormGRUPOPERSONAL(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
            BotonesNormal(true);
            GCO = FunGCO.BuscarUltimo();
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
            Lb_DesGco.Visible = Mostrar;
            Lb_StaGco.Visible = Mostrar;
            Lb_ComGco.Visible = Mostrar;
            Lb_ObsGco.Visible = Mostrar;

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
            Txt_DesGco.Text = GCO.desgco;
            if (GCO.stagco == 1)
            {
                Che_StaGco.Checked = true;
                Lb_StaGco.Text = "Activo";
                Lb_StaGco.ForeColor = Color.Green;

            }
            else
            {
                Che_StaGco.Checked = false;
                Lb_StaGco.Text = "Inactivo";
                Lb_StaGco.ForeColor = Color.Red;

            }

            if (GCO.comgco == 1)
            {
                Che_ComGco.Checked = true;
                Lb_ComGco.Text = "Activo";
                Lb_ComGco.ForeColor = Color.Green;

            }
            else
            {
                Che_ComGco.Checked = false;
                Lb_ComGco.Text = "Inactivo";
                Lb_ComGco.ForeColor = Color.Red;

            }

            if (GCO.obsgco == 1)
            {
                Che_ObsGco.Checked = true;
                Lb_ObsGco.Text = "Activo";
                Lb_ObsGco.ForeColor = Color.Green;

            }
            else
            {
                Che_ObsGco.Checked = false;
                Lb_ObsGco.Text = "Inactivo";
                Lb_ObsGco.ForeColor = Color.Red;

            }
            Lb_CodGco.Text = GCO.codgco.ToString().PadLeft(8, '0');
            Lb_DesGco.Text = GCO.desgco;
        }

        private void Actualizar()
        {
            GCO = FunGCO.Buscar(GCO.codgco);
            Asignar();
        }

        private void Cmd_Guardar_Click(object sender, EventArgs e)
        {
            int vStaGco = 0;
            if (Che_StaGco.Checked)
                vStaGco = 1;
            else
                vStaGco = 0;

            int vComGco = 0;
            if (Che_ComGco.Checked)
                vComGco = 1;
            else
                vComGco = 0;

            int vObsGco = 0;
            if (Che_ObsGco.Checked)
                vObsGco = 1;
            else
                vObsGco = 0;

            if (ValidarDatos())
            {
                if (Evento.CompareTo("Nuevo") == 0)
                {
                    GCO = new Clases._GRUPCOMOBS(Convert.ToInt32(FunGCO.Correlativo()), Txt_DesGco.Text, vComGco, vObsGco, vStaGco);
                    if (FunGCO.Nuevo(GCO))
                    {
                        MessageBox.Show("Se agregó correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bloqueos();
                        Actualizar();
                    }
                    else
                    {
                        MessageBox.Show("El grupo ya existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    GCO = new Clases._GRUPCOMOBS(Convert.ToInt32(Lb_CodGco.Text), Txt_DesGco.Text, vComGco, vObsGco, vStaGco);
                    if (FunGCO.Modificar(GCO))
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
            if (Txt_DesGco.Text.Trim() == "")
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
                Lb_CodGco.Text = FunGCO.Correlativo().PadLeft(8, '0'); ;
                Txt_DesGco.Enabled = true;
                Txt_DesGco.BackColor = Color.Turquoise;
                Txt_DesGco.Focus();
                Che_StaGco.Checked = true;
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
                Txt_DesGco.Enabled = true;
                Txt_DesGco.BackColor = Color.Turquoise;
                Txt_DesGco.Focus();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Primero_Click(object sender, EventArgs e)
        {
            GCO = FunGCO.BuscarPrimero();
            Asignar();
        }

        private void Cmd_Anterior_Click(object sender, EventArgs e)
        {
            GCO = FunGCO.BuscarAnterior(GCO);
            Asignar();
        }

        private void Cmd_Siguiente_Click(object sender, EventArgs e)
        {
            GCO = FunGCO.BuscarSiguiente(GCO);
            Asignar();
        }

        private void Cmd_Ultimo_Click(object sender, EventArgs e)
        {
            GCO = FunGCO.BuscarUltimo();
            Asignar();
        }

        private void Cmd_Buscar_Click(object sender, EventArgs e)
        {
            FormBUSQUEDAS f = new FormBUSQUEDAS();
            f.ListaGrupoPersonal();
            f.ShowDialog();
            if (f._CodGco != "")
            {
                GCO = FunGCO.Buscar(Convert.ToInt32(f._CodGco));
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
            GCO = FunGCO.BuscarUltimo();
            Asignar();
        }

        private void Txt_DesGco_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_DesGco.Text.Trim() != "")
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
                    Cmd_Cancelar.PerformClick();
                    break;
            }
        }

        private void FormGRUPOPERSONAL_KeyDown(object sender, KeyEventArgs e)
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
