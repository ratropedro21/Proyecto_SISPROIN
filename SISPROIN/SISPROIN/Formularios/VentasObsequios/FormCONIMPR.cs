using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISPROIN.Funciones;
using SISPROIN.Clases;
using System.Drawing.Printing;

namespace SISPROIN.Formularios.VentasObsequios
{
    public partial class FormCONIMPR : Form
    {
        Fun_CONFPRINT FunCONFPRINT = new Fun_CONFPRINT();
        _CONFPRINT CONFPRINT = new _CONFPRINT();
        public static string cNomPc, cIp, cNomImp;
        public static IPAddress[] aIP;
        string[] TUsuario = new string[7];

        private void FormCONIMPR_Load(object sender, EventArgs e)
        {
            Com_NomPri.Items.Clear();
            foreach (string impre in PrinterSettings.InstalledPrinters)
            {
                Com_NomPri.Items.Add(impre);
            }
            Lb_Pc_Pri.Text = cNomPc;
            Lb_Ip_Pri.Text = cIp;
            Com_NomPri.Text = cNomImp;
            Com_NomPri.Text = FunCONFPRINT.LoadPRINT(cNomPc, cIp);
        }

        private void Cmd_Aceptar_Click(object sender, EventArgs e)
        {
            if (Com_NomPri.Text != "")
            {
                DialogResult result;
                result = MessageBox.Show("¿Desea guardar la configuración.?", "Seleccione una opción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    FunCONFPRINT.Eliminar(cNomPc);
                    CONFPRINT = new _CONFPRINT(cNomPc, cIp, Com_NomPri.Text);
                    FunCONFPRINT.Nuevo(CONFPRINT);
                    MessageBox.Show("Se guardar correctamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar una impresora.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void Cmd_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Com_NomPri_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public FormCONIMPR(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
            cargaimppos();
        }
        private void cargaimppos()
        {
            string server_ip = "";
            int i;
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress a in localIPs)
            {
                if (a.ToString().Length <= 15 & a.ToString().Substring(0, 3) == "192")
                {
                    server_ip = server_ip + a.ToString();
                }
            }
            cIp = server_ip;
            cNomPc = Dns.GetHostName();

            if (cIp == "" || cIp == null)
            {
                aIP = Dns.GetHostAddresses(cNomPc);

                for (i = 0; i < aIP.Length; i++)
                {
                    cIp = aIP[i].ToString();
                }
            }

            if (cIp == null)
            {
                cIp = "";
            }
            cNomImp = "";
            FunCONFPRINT.LoadPC(cNomImp);
        }
    }
}
