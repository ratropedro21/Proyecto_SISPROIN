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
    public partial class FormPRODUCTOS : Form
    {
        string[] TUsuario = new string[7];
        string Evento = "";
        Clases.Utilitarios Util = new Clases.Utilitarios();
        Clases._PRODUCTOS PRO = new Clases._PRODUCTOS();
        Funciones.Fun_PRODUCTOS FunPRO = new Funciones.Fun_PRODUCTOS();
        Funciones.Fun_UNIDMEDIA FunUND = new Funciones.Fun_UNIDMEDIA();
        Funciones.Fun_GRUPOINV FunGRU = new Funciones.Fun_GRUPOINV();
        Funciones.Fun_TIPIVA FunTIP = new Funciones.Fun_TIPIVA();
        public FormPRODUCTOS(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
            BotonesNormal(true);
            PRO = FunPRO.BuscarUltimo();
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
            Lb_DesPro.Visible = Mostrar;
            Lb_UndUnm.Visible = Mostrar;
            Lb_CodGru.Visible = Mostrar;
            Lb_TipTiv.Visible = Mostrar;
            Lb_PrePro.Visible = Mostrar;
            Lb_StaPro.Visible = Mostrar;
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
            Txt_DesPro.Text = PRO.despro;
            Txt_UndUnm.Text = PRO.undunm;
            Txt_CodGru.Text = PRO.codgru.ToString().PadLeft(8, '0');
            Txt_TipTiv.Text = PRO.tiptiv;
            if (PRO.stapro == 1)
            {
                Che_StaPro.Checked = true;
                Lb_StaPro.Text = "Activo";
                Lb_StaPro.ForeColor = Color.Green;
            }
            else
            {
                Che_StaPro.Checked = false;
                Lb_StaPro.Text = "Inactivo";
                Lb_StaPro.ForeColor = Color.Red;
            }
            Txt_PrePro.Text = string.Format("{0:0.00}", PRO.prepro);
            //
            Lb_CodPro.Text = PRO.codpro.ToString().PadLeft(8, '0'); 
            Lb_DesPro.Text = PRO.despro;
            Lb_UndUnm.Text = PRO.undunm;
            Lb_CodGru.Text = PRO.codgru.ToString().PadLeft(8, '0'); 
            Lb_TipTiv.Text = PRO.tiptiv;
            Lb_PrePro.Text = string.Format("{0:0.00}", PRO.prepro);
            Llenar_Lb_DesUnm(PRO.undunm);
            Llenar_Lb_DesGru(PRO.codgru);
            Llenar_Lb_DesTiv(PRO.tiptiv);
        }

        private void Llenar_Lb_DesUnm(string vundunm)
        {
            Lb_DesUnm.Text = FunUND.Sent_DesUnm(vundunm);
        }

        private void Llenar_Lb_DesGru(int vcodgru)
        {
            Lb_DesGru.Text = FunGRU.Sent_DesGru(vcodgru);
        }

        private void Llenar_Lb_DesTiv(string vtiptiv)
        {
            Lb_DesTiv.Text = FunTIP.Sent_DesTiv(vtiptiv);
        }

        private void Actualizar()
        {
            PRO = FunPRO.Buscar(PRO.codpro);
            Asignar();
        }

        private void Cmd_Guardar_Click(object sender, EventArgs e)
        {
            int vStaPro = 0;
            if (Che_StaPro.Checked)
                vStaPro = 1;
            else
                vStaPro = 0;
            if (ValidarDatos())
            {
                if (Evento.CompareTo("Nuevo") == 0)
                {
                    PRO = new Clases._PRODUCTOS(Convert.ToInt32(FunPRO.Correlativo()), Txt_DesPro.Text, Txt_UndUnm.Text, Convert.ToInt32(Txt_CodGru.Text), Txt_TipTiv.Text, Util.FormatDecimal(Txt_PrePro.Text), vStaPro);
                    if (FunPRO.Nuevo(PRO))
                    {
                        MessageBox.Show("Se agregó correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bloqueos();
                        Actualizar();
                    }
                    else
                    {
                        MessageBox.Show("El producto ya existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    PRO = new Clases._PRODUCTOS(Convert.ToInt32(Lb_CodPro.Text), Txt_DesPro.Text, Txt_UndUnm.Text, Convert.ToInt32(Txt_CodGru.Text), Txt_TipTiv.Text, Util.FormatDecimal(Txt_PrePro.Text), vStaPro);
                    if (FunPRO.Modificar(PRO))
                    {
                        MessageBox.Show("Se modificó correctamente.", "Atención ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bloqueos();
                        Actualizar();
                    }
                    else
                    {
                        MessageBox.Show("El producto no existe en el sistema.", "Atención ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        public bool ValidarDatos()
        {
            if (Txt_DesPro.Text.Trim() == "" || Txt_UndUnm.Text.Trim() == "" || Txt_CodGru.Text.Trim() == "" || Txt_TipTiv.Text.Trim() == "" || Txt_PrePro.Text.Trim() == "")
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
                Lb_CodPro.Text = FunPRO.Correlativo().PadLeft(8, '0');
                Lb_DesUnm.Text = "";
                Lb_DesGru.Text = "";
                Lb_DesTiv.Text = "";
                Txt_DesPro.Enabled = true;
                Txt_DesPro.BackColor = Color.Turquoise;
                Txt_DesPro.Focus();
                Che_StaPro.Checked = true;
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
                Txt_DesPro.Enabled = true;
                Txt_DesPro.BackColor = Color.Turquoise;
                Txt_DesPro.Focus();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Primero_Click(object sender, EventArgs e)
        {
            PRO = FunPRO.BuscarPrimero();
            Asignar();
        }

        private void Cmd_Anterior_Click(object sender, EventArgs e)
        {
            PRO = FunPRO.BuscarAnterior(PRO);
            Asignar();
        }

        private void Cmd_Siguiente_Click(object sender, EventArgs e)
        {
            PRO = FunPRO.BuscarSiguiente(PRO);
            Asignar();
        }

        private void Cmd_Ultimo_Click(object sender, EventArgs e)
        {
            PRO = FunPRO.BuscarUltimo();
            Asignar();
        }

        private void Cmd_Buscar_Click(object sender, EventArgs e)
        {
            FormBUSQUEDAS f = new FormBUSQUEDAS();
            f.ListaProductos();
            f.ShowDialog();
            if (f._CodPro != "")
            {
                PRO = FunPRO.Buscar(Convert.ToInt32(f._CodPro));
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
            PRO = FunPRO.BuscarUltimo();
            Asignar();
        }

        private void Txt_DesPro_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_DesPro.Text.Trim() != "")
                    {
                        Util.CambiarTxt(Txt_DesPro, Txt_UndUnm);
                    }
                    else
                        MessageBox.Show("El campo de descripción está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Cmd_Cancelar.PerformClick();
                    break;
            }
        }

        private void Txt_UndUnm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_UndUnm.Text.Trim() != "")
                    {
                        if (FunUND.Existe(Txt_UndUnm.Text))
                        {
                            if (FunUND.StatudAI(Txt_UndUnm.Text))
                            {
                                Llenar_Lb_DesUnm(Txt_UndUnm.Text);
                                Util.CambiarTxt(Txt_UndUnm, Txt_CodGru);
                            }
                            else
                            {
                                MessageBox.Show("La unidad se encuentra inactivo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Txt_UndUnm.SelectAll();
                            }
                        }
                        else
                        {
                            MessageBox.Show("La unidad no existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_UndUnm.SelectAll();
                        }
                    }
                    else
                    {
                        FormBUSQUEDAS f = new FormBUSQUEDAS();
                        f.ListaUnidadMedidaAI();
                        f.ShowDialog();
                        if (f._UndUnm != "")
                        {
                            Txt_UndUnm.Text = f._UndUnm;
                            Llenar_Lb_DesUnm(f._UndUnm);
                            Util.CambiarTxt(Txt_UndUnm, Txt_CodGru);
                        }
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_UndUnm, Txt_DesPro);
                    break;
            }
        }

        private void Txt_CodGru_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_CodGru.Text.Trim() != "")
                    {
                        if (FunGRU.Existe(Convert.ToInt32(Txt_CodGru.Text)))
                        {
                            if (FunGRU.StatudAI(Convert.ToInt32(Txt_CodGru.Text)))
                            {
                                Llenar_Lb_DesGru(Convert.ToInt32(Txt_CodGru.Text));
                                Util.CambiarTxt(Txt_CodGru, Txt_TipTiv);
                            }
                            else
                            {
                                MessageBox.Show("El grupo se encuentra inactivo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Txt_CodGru.SelectAll();
                            }
                             
                        }
                        else
                        {
                            MessageBox.Show("El grupo no existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_CodGru.SelectAll();
                        }
                    }
                    else
                    {
                        FormBUSQUEDAS f = new FormBUSQUEDAS();
                        f.ListaGrupoInventarioAI();
                        f.ShowDialog();
                        if (f._CodGru != "")
                        {
                            Txt_CodGru.Text = f._CodGru;
                            Llenar_Lb_DesGru(Convert.ToInt32(f._CodGru));
                            Util.CambiarTxt(Txt_CodGru, Txt_TipTiv);
                        }
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_CodGru, Txt_UndUnm);
                    break;
            }
        }

        private void Txt_TipTiv_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_TipTiv.Text.Trim() != "")
                    {
                        if (FunTIP.Existe(Txt_TipTiv.Text))
                        {
                            if (FunTIP.StatudAI(Txt_TipTiv.Text))
                            {
                                Llenar_Lb_DesTiv(Txt_TipTiv.Text);
                                Util.CambiarTxt(Txt_TipTiv, Txt_PrePro);
                            }
                            else
                            {
                                MessageBox.Show("El tipo de IVA se encuentra inactivo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Txt_TipTiv.SelectAll();
                            }
                        }
                        else
                        {
                            MessageBox.Show("El tipo de IVA no existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_TipTiv.SelectAll();
                        }
                    }
                    else
                    {
                        FormBUSQUEDAS f = new FormBUSQUEDAS();
                        f.ListaTipoIVAAI();
                        f.ShowDialog();
                        if (f._TipTiv != "")
                        {
                            Txt_TipTiv.Text = f._TipTiv;
                            Llenar_Lb_DesTiv(f._TipTiv);
                            Util.CambiarTxt(Txt_TipTiv, Txt_PrePro);
                        }
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_TipTiv, Txt_CodGru);
                    break;
            }
        }

        private void Txt_PrePro_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_PrePro.Text.Trim().CompareTo("") != 0)
                    {
                        Cmd_Guardar.PerformClick();
                    }
                    else
                    {
                        Txt_PrePro.Text = "0,00";
                        Cmd_Guardar.PerformClick();
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_PrePro, Txt_TipTiv);
                    break;
            }
        }

        private void Txt_UndUnm_Enter(object sender, EventArgs e)
        {
            Lb_DesUnm.Text = "";
        }

        private void Txt_CodGru_Enter(object sender, EventArgs e)
        {
            Lb_DesGru.Text = "";
        }

        private void Txt_TipTiv_Enter(object sender, EventArgs e)
        {
            Lb_DesTiv.Text = "";
        }

        private void Txt_PrePro_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.SoloNumeroDecimales(sender, e, Txt_PrePro);
        }

        private void FormPRODUCTOS_KeyDown(object sender, KeyEventArgs e)
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
