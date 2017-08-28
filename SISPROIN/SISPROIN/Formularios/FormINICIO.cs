using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISPROIN.Formularios
{
    public partial class FormINICIO : Form
    {
        Clases.Utilitarios Util = new Clases.Utilitarios();
        Funciones.Fun_Control_Acceso Validar = new Funciones.Fun_Control_Acceso();
        string[] TUsuario = new string[7];
        public FormINICIO(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
        }

        private void Cmd_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormINICIO_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Cmd_Salir.PerformClick();
                    break;
            }
        }

        private void Cmd_Configuracion_Click(object sender, EventArgs e)
        {
            TUsuario[3] = "1";
            if (Validar.Validar_Nivel_0(TUsuario))
            {
                FormPRIN_CONFIGURAR Fmr = new FormPRIN_CONFIGURAR(TUsuario);
                this.Hide();
                Fmr.Text = Fmr.Text + " - Bienvenido Sr.(a): " + TUsuario[1];
                Fmr.ShowDialog();
                this.Show();

            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_VentasOsq_Click(object sender, EventArgs e)
        {
            TUsuario[3] = "2";
            if (Validar.Validar_Nivel_0(TUsuario))
            {
                FormPRIN_VENOSB Fmr = new FormPRIN_VENOSB(TUsuario);
                this.Hide();
                Fmr.Text = Fmr.Text + " - Bienvenido Sr.(a): " + TUsuario[1];
                Fmr.ShowDialog();
                this.Show();

            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Cmd_Cestas_Click(object sender, EventArgs e)
        {

        }

        private void Cmd_RHumanos_Click(object sender, EventArgs e)
        {
            TUsuario[3] = "4";
            if (Validar.Validar_Nivel_0(TUsuario))
            {
                FormPRIN_RHUMANOS Fmr = new FormPRIN_RHUMANOS(TUsuario);
                this.Hide();
                Fmr.Text = Fmr.Text + " - Bienvenido Sr.(a): " + TUsuario[1];
                Fmr.ShowDialog();
                this.Show();

            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

     
    }
}
