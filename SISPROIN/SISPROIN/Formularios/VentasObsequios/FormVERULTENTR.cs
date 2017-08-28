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

namespace SISPROIN.Formularios.VentasObsequios
{
    public partial class FormVERULTENTR : Form
    {
        public _VENOBSDOC VOD = new _VENOBSDOC();
        Fun_PERSONAL FunPER = new Fun_PERSONAL();
        Fun_MOVINV FunMOVINV = new Fun_MOVINV();
        Fun_VENOBSDOC FunVOD = new Fun_VENOBSDOC();
        public bool Proceso = false;
        bool SwActive = true;
        public FormVERULTENTR()
        {
            InitializeComponent();
            GenColumnas();
        }

        private void Asignar()
        {
            AsignarENC();
            AsignarDET();
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
        }

        private void AsignarENC()
        {
            Lb_FecDoc.Text = VOD.fecdoc.ToShortDateString();
            Llenar_Lb_NomPer(Convert.ToInt32(Lb_CedPer.Text));
        }

        private void AsignarDET()
        {
            FunMOVINV.GetLisOBSEQUIO(Convert.ToInt32(VOD.codmov), listView1);
        }

        private void Llenar_Lb_NomPer(int vcedper)
        {
            Lb_NomPer.Text = FunPER.Sent_NomPer(vcedper);
        }

        private void FormVERULTENTR_Activated(object sender, EventArgs e)
        {
            if (SwActive)
            {
                SwActive = false;
                Asignar();
            }
        }

        private void FormVERULTENTR_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}
