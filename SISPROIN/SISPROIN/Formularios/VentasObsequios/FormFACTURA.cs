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
    public partial class FormFACTURA : Form
    {
        string[] TUsuario = new string[7];
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

        private void BotonesControl(bool Mostrar)
        {
            Cmd_Guardar.Visible = Mostrar;
            Cmd_Cancelar.Visible = Mostrar;
        }
    }
}
