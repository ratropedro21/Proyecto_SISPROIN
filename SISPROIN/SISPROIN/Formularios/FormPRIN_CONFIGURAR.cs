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
    public partial class FormPRIN_CONFIGURAR : Form
    {
        Funciones.Fun_Control_Acceso Validar = new Funciones.Fun_Control_Acceso();
        string[] TUsuario = new string[7];
        public FormPRIN_CONFIGURAR(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
        }

        private void agregarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "1";
            TUsuario[5] = "1";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                Configuracion.FormAGREGARUSU Fmr = new Configuracion.FormAGREGARUSU(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void nivelesDeMenúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "1";
            TUsuario[5] = "2";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                Configuracion.FormNIVELESMENU Fmr = new Configuracion.FormNIVELESMENU(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void permisosDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "2";
            TUsuario[5] = "1";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                Configuracion.FormPERMISOS Fmr = new Configuracion.FormPERMISOS(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();

            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
