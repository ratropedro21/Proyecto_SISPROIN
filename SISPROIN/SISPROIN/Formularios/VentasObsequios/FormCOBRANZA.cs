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
    public partial class FormCOBRANZA : Form
    {
        string[] TUsuario = new string[7];
        public FormCOBRANZA(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
        }
    }
}
