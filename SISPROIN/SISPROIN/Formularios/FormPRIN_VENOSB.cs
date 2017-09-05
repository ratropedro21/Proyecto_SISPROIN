using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISPROIN.Formularios.VentasObsequios;

namespace SISPROIN.Formularios
{
    public partial class FormPRIN_VENOSB : Form
    {
        Funciones.Fun_Control_Acceso Validar = new Funciones.Fun_Control_Acceso();
        string[] TUsuario = new string[7];
        public FormPRIN_VENOSB(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
        }

        private void unidadDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "1";
            TUsuario[5] = "1";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormUNIDADMED Fmr = new FormUNIDADMED(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void tipoDeTransaccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "1";
            TUsuario[5] = "2";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormTIPTRANSA Fmr = new FormTIPTRANSA(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void gruposDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "1";
            TUsuario[5] = "3";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
               FormGRUPOINV Fmr = new FormGRUPOINV(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "1";
            TUsuario[5] = "4";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormPRODUCTOS Fmr = new FormPRODUCTOS(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void tipoDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "1";
            TUsuario[5] = "5";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormTIPDOC Fmr = new FormTIPDOC(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void tipoDeMovDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "1";
            TUsuario[5] = "6";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormTIPCAJ Fmr = new FormTIPCAJ(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void tiposDeIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "1";
            TUsuario[5] = "7";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {

                FormTIPIVA Fmr = new FormTIPIVA(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void alicuotasDeIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "1";
            TUsuario[5] = "8";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                //VentasObsequios.FormTIPIVA Fmr = new VentasObsequios.FormTIPIVA(TUsuario);
                //Fmr.MdiParent = this;
                //Fmr.Show();
                //Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void configuraciónDeImprDeTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "1";
            TUsuario[5] = "9";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormCONIMPR Fmr = new FormCONIMPR(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void movimientosDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "2";
            TUsuario[5] = "1";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormMOVINVETARIO Fmr = new FormMOVINVETARIO(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "3";
            TUsuario[5] = "1";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormFACTURA Fmr = new FormFACTURA(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void cobranzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "4";
            TUsuario[5] = "1";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormCOBRANZA Fmr = new FormCOBRANZA(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void entregaDeObsequiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "5";
            TUsuario[5] = "1";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormOBSEQUIOS Fmr = new FormOBSEQUIOS(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void movimientoInventarioPorProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "6";
            TUsuario[5] = "1";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormFILLINVPRO Fmr = new FormFILLINVPRO(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void movimientoDeInventarioPorProductosYCedulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "6";
            TUsuario[5] = "2";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormFILLINVPROCED Fmr = new FormFILLINVPROCED(TUsuario);
                Fmr.MdiParent = this;
                Fmr.Show();
                Fmr.Activate();
            }
            else
            {
                MessageBox.Show("No tiene el permiso para acceder.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void resumenDeMovimientoDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TUsuario[4] = "6";
            TUsuario[5] = "3";
            int Permiso = Validar.Validar_Nivel_2(TUsuario);
            TUsuario[6] = Permiso.ToString();
            if (Permiso < 5)
            {
                FormFILLRESMOINV Fmr = new FormFILLRESMOINV(TUsuario);
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
