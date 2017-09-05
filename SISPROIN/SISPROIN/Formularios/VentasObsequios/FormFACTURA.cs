using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISPROIN.Funciones;

namespace SISPROIN.Formularios.VentasObsequios
{
    public partial class FormFACTURA : Form
    {
        string[] TUsuario = new string[7];
        string Evento = "";
        string Evento2 = "";
        Fun_VENOBSDOC FunVOD = new Fun_VENOBSDOC();

        public FormFACTURA(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
            BotonesNormal(true);
            GenColumnas();
        }

        protected void GenColumnas()
        {
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            listView1.HideSelection = false;
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Cod. Producto", 84, HorizontalAlignment.Left);
            listView1.Columns.Add("Descripcion del Producto", 338, HorizontalAlignment.Center);
            listView1.Columns.Add("Unid.", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("Cant. KLG", 96, HorizontalAlignment.Center);
            listView1.Columns.Add("Cant. UND", 96, HorizontalAlignment.Center);
            listView1.Columns.Add("Precio", 110, HorizontalAlignment.Center);
            listView1.Columns.Add("Total", 110, HorizontalAlignment.Center);
        }

        private void BotonesNormal(bool Mostrar)
        {
            Cmd_Nuevo.Visible = Mostrar;
            //Cmd_Modificar.Visible = Mostrar;
            Cmd_Primero.Visible = Mostrar;
            Cmd_Anterior.Visible = Mostrar;
            Cmd_Siguiente.Visible = Mostrar;
            Cmd_Ultimo.Visible = Mostrar;
            Cmd_Eliminar.Visible = Mostrar;
            Cmd_Imprimir.Visible = Mostrar;
            Cmd_Buscar.Visible = Mostrar;
            //Cmd_UltmEntr.Visible = Mostrar;
            //Cmd_UltmPre.Visible = Mostrar;
        }

        private void Bloqueos()
        {
            BotonesNormal(true);
            BotonesControl(false);
            Lbl(true);
            MenulistView(false);
            listView1.Items.Clear();
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox IMPUT = ctrl as TextBox;
                    IMPUT.Visible = false;
                    IMPUT.Enabled = false;
                    IMPUT.BackColor = Color.White;
                }
            }
            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox IMPUT = ctrl as TextBox;
                    IMPUT.Clear();
                    IMPUT.Enabled = false;
                    IMPUT.BackColor = Color.White;
                }
            }
            foreach (Control ctrl in Controls)
            {
                if (ctrl is Label)
                {
                    Label IMPUT = ctrl as Label;
                    IMPUT.Text = "";
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
                listView1.Items.Clear();
                foreach (Control ctrl in panel1.Controls)
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
                    foreach (Control ctrl in panel1.Controls)
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

        private void BotonesControl(bool Mostrar)
        {
            Cmd_Guardar.Visible = Mostrar;
            Cmd_Cancelar.Visible = Mostrar;
        }
        
        private void Lbl(bool Mostrar)
        {
            Lb_CedPer.Visible = Mostrar;
            Lb_FecDoc.Visible = Mostrar;
            Lb_StaDoc.Visible = Mostrar;
        }

        private void MenulistView(bool Mostrar)
        {
            Txt_CodPro.Visible = Mostrar;
            Lb_DesPro.Visible = Mostrar;
            Lb_UndUnm.Visible = Mostrar;
            Txt_CanMov.Visible = Mostrar;
            Txt_CatMov.Visible = Mostrar;
            //Cmd_UltmEntr.Visible = Mostrar;
            //Cmd_UltmPre.Visible = Mostrar;
            //Cmd_UltmVac.Visible = Mostrar;
        }

        private void MenulistViewReset()
        {
            Txt_CodPro.Clear();
            Txt_CodPro.Enabled = false;
            Txt_CodPro.BackColor = Color.White;

            Txt_CanMov.Clear();
            Txt_CanMov.Enabled = false;
            Txt_CanMov.BackColor = Color.White;

            Txt_CatMov.Clear();
            Txt_CatMov.Enabled = false;
            Txt_CatMov.BackColor = Color.White;
        }

        private void Cmd_Guardar_Click(object sender, EventArgs e)
        {

        }

        private void Cmd_Nuevo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TUsuario[6]) < 5)
            {
                Evento = "Nuevo";
                //isPresent = false;
                Desbloqueos();
                Lb_CodMov.Text = FunVOD.Correlativo().PadLeft(8, '0');
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

        }

        private void Cmd_Primero_Click(object sender, EventArgs e)
        {

        }

        private void Cmd_Anterior_Click(object sender, EventArgs e)
        {

        }

        private void Cmd_Siguiente_Click(object sender, EventArgs e)
        {

        }

        private void Cmd_Ultimo_Click(object sender, EventArgs e)
        {

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

        }
    }
}
