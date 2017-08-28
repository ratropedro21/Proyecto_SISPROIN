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
    public partial class FormFILLINVPRO : Form
    {
        string[] TUsuario = new string[7];
        public FormFILLINVPRO(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
        }

        private void Cmd_Aceptar_Click(object sender, EventArgs e)
        {
            FormVISORRPT Vs = new FormVISORRPT();
            Vs.Reporte_MOVINVPRO(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            Vs.ShowDialog();
        }

        private void Cmd_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
