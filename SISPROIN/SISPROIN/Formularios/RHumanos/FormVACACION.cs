using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISPROIN.Clases;
using SISPROIN.Funciones;

namespace SISPROIN.Formularios.RHumanos
{
    public partial class FormVACACION : Form
    {
        string[] TUsuario = new string[7];
        string Evento = "";
        _VACACION VAC = new _VACACION();
        _PERSONAL PER = new _PERSONAL();
        Fun_VACACION FunVAC = new Fun_VACACION();
        Fun_PERSONAL FunPER = new Fun_PERSONAL();
        Fun_DEPARTA FunDP = new Fun_DEPARTA();
        Fun_GRUPCOMOBS FunGCO = new Fun_GRUPCOMOBS();
        Utilitarios Util = new Utilitarios();

        public FormVACACION(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
            BotonesNormal(true);
            VAC = FunVAC.BuscarUltimo();
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
            Cmd_Anular.Visible = Mostrar;
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
            Lb_FeiVac.Visible = Mostrar;
            Lb_FefVac.Visible = Mostrar;
            Lb_ObsVac.Visible = Mostrar;
            Lb_CatMov.Visible = Mostrar;
            Lb_StaVac.Visible = Mostrar;
        }

        private void Bloqueos()
        {
            BotonesNormal(true);
            BotonesControl(false);
            Lbl(true);
            Dat_FeiVac.Visible = false;
            Dat_FeiVac.Enabled = false;
            Dat_FefVac.Visible = false;
            Dat_FefVac.Enabled = false;

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
        }
        private void Desbloqueos()
        {
            BotonesNormal(false);
            BotonesControl(true);
            Lbl(false);
            if (Evento.CompareTo("Nuevo") == 0)
            {
                Dat_FeiVac.Visible = true;
                Dat_FeiVac.Value = DateTime.Now;
                Dat_FefVac.Visible = true;
                Dat_FefVac.Value = DateTime.Now;
                foreach (Control ctrl in Controls)
                {
                    if (ctrl is TextBox)
                    {
                        TextBox IMPUT = ctrl as TextBox;
                        IMPUT.Clear();
                        IMPUT.Visible = true;
                    }
                }
            }
            else
            {
                if (Evento.CompareTo("Modificar") == 0)
                {
                    Dat_FeiVac.Enabled = true;
                    Dat_FeiVac.Visible = true;
                    Dat_FefVac.Visible = true;
                    foreach (Control ctrl in Controls)
                    {
                        if (ctrl is TextBox)
                        {
                            TextBox IMPUT = ctrl as TextBox;
                            IMPUT.Visible = true;
                        }
                    }
                }
            }
        }
        private void Asignar()
        {
            DateTime now = Util.GetDate();
            Lb_CodVac.Text = VAC.codvac.ToString().PadLeft(8, '0');
            Txt_CedPer.Text = VAC.cedper.ToString();
            if (VAC.feivac == new DateTime())
            {
                Dat_FeiVac.Value = now;
            }
            else
            {
                Dat_FeiVac.Text = VAC.feivac.ToShortDateString();
            }

            if (VAC.fefvac == new DateTime())
            {
                Dat_FefVac.Value = now;
            }
            else
            {
                Dat_FefVac.Text = VAC.fefvac.ToShortDateString();
            }

            
            Txt_ObsVac.Text = VAC.obsvac;
            Txt_CatMov.Text = VAC.catmov.ToString();

            if (VAC.stavac == 1)
            {
                Lb_StaVac.Text = "Activo";
                Lb_StaVac.ForeColor = Color.Green;
            }
            else
            {
                Lb_StaVac.Text = "Anulado";
                Lb_StaVac.ForeColor = Color.Red;
            }

            Lb_CedPer.Text = VAC.cedper.ToString();
            Lb_FeiVac.Text = VAC.feivac.ToShortDateString();
            Lb_FefVac.Text = VAC.fefvac.ToShortDateString();
            Lb_ObsVac.Text = VAC.obsvac;
            Lb_CatMov.Text = VAC.catmov.ToString();
            if (VAC.cedper == 0)
            {
                Lb_NomPer.Text = "";
                Lb_ApePer.Text = ""; 
                Lb_CodDpt.Text = ""; 
                Lb_NomDpt.Text = ""; 
                Lb_CodGru.Text = ""; 
                Lb_DesGco.Text = ""; 
                Lb_FeiPer.Text = "";
            }
            else
            {
                Llenar_Lb(VAC.cedper);
            }
        }

        private void Llenar_Lb(int vCodigo)
        {
            PER = FunPER.Buscar(vCodigo);
            Lb_NomPer.Text = PER.nomper;
            Lb_ApePer.Text = PER.apeper;
            Lb_CodDpt.Text = PER.coddpt.ToString().PadLeft(8, '0'); ;
            Lb_NomDpt.Text = FunDP.Sent_NomDpt(PER.coddpt);
            Lb_CodGru.Text = PER.codgco.ToString().PadLeft(8, '0');
            Lb_DesGco.Text = FunGCO.Sent_DesGco(PER.codgco);
            Lb_FeiPer.Text = PER.feiper.ToShortDateString();
        }

        private void Actualizar()
        {
            VAC = FunVAC.Buscar(VAC.codvac);
            Asignar();
        }

        private void Cmd_Guardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (Evento.CompareTo("Nuevo") == 0)
                {
                    DialogResult result1;
                    result1 = MessageBox.Show("¿Desea guardar la vacacion?", "Seleccione una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result1 == DialogResult.Yes)
                    {
                        DateTime FeaVac = Dat_FeiVac.Value.AddDays(-7);
                        int vStaVac = 1;
                        VAC = new _VACACION(Convert.ToInt32(FunVAC.Correlativo()), Convert.ToInt32(Txt_CedPer.Text), FeaVac, Dat_FeiVac.Value, Dat_FefVac.Value, Txt_ObsVac.Text, Convert.ToInt32(Txt_CatMov.Text), vStaVac);
                        if (FunVAC.Nuevo(VAC))
                        {
                            MessageBox.Show("Se agregó correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Bloqueos();
                            Actualizar();
                        }
                        else
                        {
                            MessageBox.Show("Las vacaciones ya existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
                else
                {
                    DialogResult result1;
                    result1 = MessageBox.Show("¿Desea modificar la vacacion?", "Seleccione una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result1 == DialogResult.Yes)
                    {
                        DateTime FeaVac = Dat_FeiVac.Value.AddDays(-7);
                        VAC = new _VACACION(Convert.ToInt32(Lb_CodVac.Text), Convert.ToInt32(Txt_CedPer.Text), FeaVac, Dat_FeiVac.Value, Dat_FefVac.Value, Txt_ObsVac.Text, Convert.ToInt32(Txt_CatMov.Text));
                        if (FunVAC.Modificar(VAC))
                        {
                            MessageBox.Show("Se modificó correctamente.", "Atención ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Bloqueos();
                            Actualizar();
                        }
                        else
                        {
                            MessageBox.Show("la vacaciones no existe en el sistema.", "Atención ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
        }

        public bool ValidarDatos()
        {
            if (Txt_CedPer.Text.Trim() == "" || Txt_CatMov.Text.Trim() == "")
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
                Lb_CodVac.Text = FunVAC.Correlativo().PadLeft(8, '0');
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
                Dat_FeiVac.Enabled = true;
                Dat_FeiVac.BackColor = Color.Turquoise;
                Dat_FeiVac.Focus();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Primero_Click(object sender, EventArgs e)
        {
            VAC = FunVAC.BuscarPrimero();
            Asignar();
        }

        private void Cmd_Anterior_Click(object sender, EventArgs e)
        {
            VAC = FunVAC.BuscarAnterior(VAC);
            Asignar();
        }

        private void Cmd_Siguiente_Click(object sender, EventArgs e)
        {
            VAC = FunVAC.BuscarSiguiente(VAC);
            Asignar();
        }

        private void Cmd_Ultimo_Click(object sender, EventArgs e)
        {
            VAC = FunVAC.BuscarUltimo();
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

        private void Cmd_Anular_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TUsuario[6]) < 3)
            {
                VAC = FunVAC.Buscar(Convert.ToInt32(Lb_CodVac.Text));
                if (VAC.stavac == 1)
                {
                    DialogResult result;
                    result = MessageBox.Show("¿Esta seguro que desea anular las vacaciones.?", "Seleccione una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int vStaMov = 0;
                        VAC = new _VACACION(Convert.ToInt32(Lb_CodVac.Text), vStaMov);
                        if (FunVAC.Anular(VAC))
                        {
                            MessageBox.Show("El documento se anuló correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Actualizar();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El documento se encuentra anulado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Actualizar();
                }
            }
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

        private void FormVACACION_KeyDown(object sender, KeyEventArgs e)
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
                    Cmd_Anular.PerformClick();
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
                        if (FunPER.Existe(Convert.ToInt32(Txt_CedPer.Text)))
                        {
                            if (FunPER.StatudAI(Convert.ToInt32(Txt_CedPer.Text)))
                            {
                                Llenar_Lb(Convert.ToInt32(Txt_CedPer.Text));
                                Util.CambiarTxt(Txt_CedPer, Dat_FeiVac);
                            }
                            else
                            {
                                MessageBox.Show("El trabajador se encuentra egresado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Txt_CedPer.SelectAll();
                            }

                        }
                        else
                        {
                            MessageBox.Show("El trabajador no extiste.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Txt_CedPer.SelectAll();
                        }
                    }
                    else
                    {
                        FormBUSQUEDAS f = new FormBUSQUEDAS();
                        f.ListaPersonalAI();
                        f.ShowDialog();
                        if (f._CedPer != "")
                        {
                            Txt_CedPer.Text = f._CedPer;
                            Llenar_Lb(Convert.ToInt32(Txt_CedPer.Text));
                            Util.CambiarTxt(Txt_CedPer, Dat_FeiVac);
                        }
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Cmd_Cancelar.PerformClick();
                    break;
            }
        }

        private void Dat_FeiVac_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Dat_FeiVac.Text.Trim() != "")
                    {
                        Util.CambiarTxt(Dat_FeiVac, Dat_FefVac);
                    }
                    else
                        MessageBox.Show("El campo de fecha de inicio de vacaciones está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Dat_FeiVac, Txt_CedPer);
                    break;
            }
        }

        private void Dat_FefVac_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Dat_FefVac.Text.Trim() != "")
                    {
                        Util.CambiarTxt(Dat_FefVac, Txt_ObsVac);
                    }
                    else
                        MessageBox.Show("El campo de fecha de final de vacaciones está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Dat_FefVac, Dat_FeiVac);
                    break;
            }
        }

        private void Txt_ObsVac_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_ObsVac, Txt_CatMov);
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_ObsVac, Dat_FefVac);
                    break;
            }
        }

        private void Txt_CatMov_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (Txt_CatMov.Text.Trim() != "" && Util.FormatDecimal(Txt_CatMov.Text) > 0)
                    {
                        Cmd_Guardar.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("El campo de cantidad debe ser mayor a 0 ó esta vaio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Txt_CatMov.SelectAll();
                    }
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_CatMov, Txt_ObsVac);
                    break;
            }
        }
    }
}
