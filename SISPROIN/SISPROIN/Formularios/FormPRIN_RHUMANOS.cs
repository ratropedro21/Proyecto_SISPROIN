using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISPROIN.Formularios.RHumanos;

namespace SISPROIN.Formularios
{
    public partial class FormPRIN_RHUMANOS : Form
    {
        Funciones.Fun_Control_Acceso Validar = new Funciones.Fun_Control_Acceso();
        string[] TUsuario = new string[7];
        public FormPRIN_RHUMANOS(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
        }

        private void departamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "1";
            TUsuario[5] = "1";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormDEPARTAMENTO Fmr = new FormDEPARTAMENTO(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void gruposDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "1";
            TUsuario[5] = "2";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormGRUPOPERSONAL Fmr = new FormGRUPOPERSONAL(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "1";
            TUsuario[5] = "3";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
               FormPERSONAL Fmr = new FormPERSONAL(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

    

        private void inasistenciaDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "2";
            TUsuario[5] = "1";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormINASISTENCIADIA Fmr = new FormINASISTENCIADIA(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void vacacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "2";
            TUsuario[5] = "2";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormVACACION Fmr = new FormVACACION(TUsuario);
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
