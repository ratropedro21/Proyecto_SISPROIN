using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISPROIN.Formularios
{
    public partial class FormBUSQUEDAS : Form
    {
        Clases.ConectarDB Cnn = new Clases.ConectarDB();
        DataTable _DtLocal = new DataTable();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32
            SendMessage(
                            IntPtr hWnd,
                            int msg,
                            int wParam,
                            [MarshalAs(UnmanagedType.LPWStr)]string lParam
                        );
        private const int EM_SETCUEBANNER = 0x1501;
        int Opc = 0;
        public string _CodDpt = "";
        public string _UndUnm = "";
        public string _TipTra = "";
        public string _CodGru = "";
        public string _TipTiv = "";
        public string _CodPro = "";
        public string _CedPer = "";
        public string _TipTid = "";
        public string _CodGco = "";
        public string _TipTmc = "";
        public string _CodInv = "";
        public string _CodObs = "";

        public FormBUSQUEDAS()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            TXT_Text.Focus();
            base.OnShown(e);
        }

        private int GetTamaUltColum()
        {
            int Tam = 0;
            for (int i = 0; i < listView.Columns.Count - 1; i++)
            {
                Tam += listView.Columns[i].Width;
            }
            return listView.Width - Tam;
        }
        private void ResideCol()
        {
            if (((listView.Height - 21.28)) < 21.28 * listView.Items.Count)
            {

                listView.Columns[listView.Columns.Count - 1].Width = GetTamaUltColum() - 20;

            }
            else
            {

                listView.Columns[listView.Columns.Count - 1].Width = GetTamaUltColum();

            }
        }
        //
        //Departamento
        public void ListaDepartamentos()
        {
            Opc = 1;
            Text = "Consulta de Departamentos";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Dpt", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Nombre de Deprtamentos", 364);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Nombre";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarDepartamentos();
        }
        private void CargarDepartamentos()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT coddpt, nomdpt FROM departa WHERE (coddpt)::text  LIKE '" + TXT_Text.Text + "%'  ORDER BY CodDpt";
            }
            else
            {
                Sql = "SELECT coddpt, nomdpt FROM departa WHERE nomdpt LIKE '%" + TXT_Text.Text + "%' ORDER BY CodDpt";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetInt32(0).ToString().PadLeft(8, '0'); ;
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Departamento Activos
        public void ListaDepartamentosAI()
        {
            Opc = 1;
            Text = "Consulta de Departamentos";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Dpt", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Nombre de Deprtamentos", 364);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Nombre";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarDepartamentosAI();
        }
        private void CargarDepartamentosAI()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT coddpt, nomdpt FROM departa WHERE (coddpt)::text  LIKE '" + TXT_Text.Text + "%' AND stadpt = 1 ORDER BY CodDpt";
            }
            else
            {
                Sql = "SELECT coddpt, nomdpt FROM departa WHERE nomdpt LIKE '%" + TXT_Text.Text + "%' AND stadpt = 1 ORDER BY CodDpt";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetInt32(0).ToString().Trim().PadLeft(8, '0'); ;
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Unidad de Medida
        public void ListaUnidadMedida()
        {
            Opc = 2;
            Text = "Consulta de Unidad de Medida";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Unid", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Descripción de la Unidad", 364);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Descripción";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarUnidadMedida();
        }
        private void CargarUnidadMedida()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT undunm, desunm FROM unidmed WHERE undunm LIKE '" + TXT_Text.Text + "%' ORDER BY codunm";
            }
            else
            {
                Sql = "SELECT undunm, desunm FROM unidmed WHERE desunm LIKE '%" + TXT_Text.Text + "%' ORDER BY codunm";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetString(0).Trim();
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Unidad de Medida Activos
        public void ListaUnidadMedidaAI()
        {
            Opc = 2;
            Text = "Consulta de Unidad de Medida";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Unid", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Descripción de la Unidad", 364);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Descripción";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarUnidadMedidaAI();
        }
        private void CargarUnidadMedidaAI()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT undunm, desunm FROM unidmed WHERE undunm LIKE '" + TXT_Text.Text + "%' AND staunm = 1 ORDER BY codunm";
            }
            else
            {
                Sql = "SELECT undunm, desunm FROM unidmed WHERE desunm LIKE '%" + TXT_Text.Text + "%' AND staunm = 1 ORDER BY codunm";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetString(0).Trim();
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Transacciones
        public void ListaTransacciones()
        {
            Opc = 3;
            Text = "Consulta de Unidad de Medida";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Unid", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Descripción de la Unidad", 364);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Descripción";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarTransacciones();
        }
        private void CargarTransacciones()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT tiptra, destra FROM tiptransa WHERE tiptra  LIKE '" + TXT_Text.Text + "%' ORDER BY codtra";
            }
            else
            {
                Sql = "SELECT tiptra, destra FROM tiptransa WHERE destra LIKE '%" + TXT_Text.Text + "%' ORDER BY codtra";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetString(0).Trim();
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Transacciones Activos
        public void ListaTransaccionesAI()
        {
            Opc = 3;
            Text = "Consulta de Unidad de Medida";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Unid", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Descripción de la Unidad", 364);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Descripción";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarTransaccionesAI();
        }
        private void CargarTransaccionesAI()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT tiptra, destra FROM tiptransa WHERE tiptra  LIKE '" + TXT_Text.Text + "%' AND statra = 1 ORDER BY codtra";
            }
            else
            {
                Sql = "SELECT tiptra, destra FROM tiptransa WHERE destra LIKE '%" + TXT_Text.Text + "%' AND statra = 1 ORDER BY codtra";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetString(0).Trim();
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Grupo de Inventario
        public void ListaGrupoInventario()
        {
            Opc = 4;
            Text = "Consulta de Grupo de Inventario";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Grupo", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Descripción del Grupo", 364);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Descripción";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarGrupoInventario();
        }
        private void CargarGrupoInventario()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT codgru, desgru FROM grupinv WHERE (codgru)::text  LIKE '" + TXT_Text.Text + "%' ORDER BY codgru";
            }
            else
            {
                Sql = "SELECT codgru, desgru FROM grupinv WHERE desgru LIKE '%" + TXT_Text.Text + "%' ORDER BY codgru";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetInt32(0).ToString().PadLeft(8, '0'); 
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Grupo de Inventario Activos
        public void ListaGrupoInventarioAI()
        {
            Opc = 4;
            Text = "Consulta de Grupo de Inventario";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Grupo", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Descripción del Grupo", 364);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Descripción";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarGrupoInventarioAI();
        }
        private void CargarGrupoInventarioAI()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT codgru, desgru FROM grupinv WHERE (codgru)::text  LIKE '" + TXT_Text.Text + "%' AND stagru = 1 ORDER BY codgru";
            }
            else
            {
                Sql = "SELECT codgru, desgru FROM grupinv WHERE desgru LIKE '%" + TXT_Text.Text + "%' AND stagru = 1 ORDER BY codgru";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetInt32(0).ToString().PadLeft(8, '0');
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Tipo de IVA Activos
        public void ListaTipoIVA()
        {
            Opc = 5;
            Text = "Consulta de Tipos de IVA";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Unid", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Tipo de Iva", 364);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Tipo de Iva";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarTipoIVA();
        }
        private void CargarTipoIVA()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT tiptiv, destiv FROM tipiva WHERE tiptiv  LIKE '" + TXT_Text.Text + "%' ORDER BY tiptiv";
            }
            else
            {
                Sql = "SELECT tiptiv, destiv FROM tipiva WHERE destra LIKE '%" + TXT_Text.Text + "%' ORDER BY tiptiv";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetString(0).Trim();
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Tipo de IVA Activos
        public void ListaTipoIVAAI()
        {
            Opc = 5;
            Text = "Consulta de Tipos de IVA";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Unid", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Tipo de Iva", 364);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Tipo de Iva";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarTipoIVAAI();
        }
        private void CargarTipoIVAAI()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT tiptiv, destiv FROM tipiva WHERE tiptiv  LIKE '" + TXT_Text.Text + "%' AND stativ = 1 ORDER BY tiptiv";
            }
            else
            {
                Sql = "SELECT tiptiv, destiv FROM tipiva WHERE destra LIKE '%" + TXT_Text.Text + "%' AND stativ = 1 ORDER BY tiptiv";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetString(0).Trim();
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Productos
        public void ListaProductos()
        {
            Opc = 6;
            Text = "Consulta de Grupo de Inventario";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Grupo", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Descripción del Grupo", 364);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Descripción";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarProductos();
        }
        private void CargarProductos()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT codpro, despro FROM productos WHERE (codpro)::text  LIKE '" + TXT_Text.Text + "%' ORDER BY codpro";
            }
            else
            {
                Sql = "SELECT codpro, despro FROM productos WHERE despro LIKE '%" + TXT_Text.Text + "%' ORDER BY codpro";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetInt32(0).ToString().PadLeft(8, '0');
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Productos Activos
        public void ListaProductosAI()
        {
            Opc = 6;
            Text = "Consulta de Grupo de Inventario";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Grupo", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Descripción del Grupo", 364);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Descripción";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarProductosAI();
        }
        private void CargarProductosAI()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT codpro, despro FROM productos WHERE (codpro)::text  LIKE '" + TXT_Text.Text + "%' AND stapro = 1 ORDER BY codpro";
            }
            else
            {
                Sql = "SELECT codpro, despro FROM productos WHERE despro LIKE '%" + TXT_Text.Text + "%' AND stapro = 1 ORDER BY codpro";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetInt32(0).ToString().PadLeft(8, '0');
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Trabajadores  
        public void ListaPersonal()
        {
            Opc = 7;
            this.Text = "Consulta del Personal";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Numero de Cedula", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Nombre y Apellido", 364);
            radioButton1.Text = "No. Cedula";
            radioButton1.Checked = true;
            radioButton2.Text = "Nombre y Apellido";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarPersonal();
        }
        private void CargarPersonal()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT cedper, (nomper || ' ' || apeper) AS nompersonal FROM personal WHERE (cedper)::text LIKE '" + TXT_Text.Text + "%' ORDER BY cedper";
            }
            else
            {
                Sql = "SELECT cedper, (nomper || ' ' || apeper) AS nompersonal FROM personal WHERE nomper LIKE '%" + TXT_Text.Text + "%' OR apeper LIKE '%" + TXT_Text.Text + "%' ORDER BY cedper";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetInt32(0).ToString().Trim();
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Trabajadores Activos
        public void ListaPersonalAI()
        {
            Opc = 7;
            this.Text = "Consulta del Personal";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Numero de Cedula", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Nombre y Apellido", 364);
            radioButton1.Text = "No. Cedula";
            radioButton1.Checked = true;
            radioButton2.Text = "Nombre y Apellido";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarPersonalAI();
        }
        private void CargarPersonalAI()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT cedper, (nomper || ' ' || apeper) AS nompersonal FROM personal WHERE (cedper)::text LIKE '" + TXT_Text.Text + "%' AND staper = 1 ORDER BY cedper";
            }
            else
            {
                Sql = "SELECT cedper, (nomper || ' ' || apeper) AS nompersonal FROM personal WHERE nomper LIKE '%" + TXT_Text.Text + "%' OR apeper LIKE '%" + TXT_Text.Text + "%' AND staper = 1 ORDER BY cedper";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetInt32(0).ToString().Trim();
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Tipo de Documentos  
        public void ListaTipoDocumentos()
        {
            Opc = 8;
            Text = "Consulta de Tipo de Dcumento";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Tipo de Documento", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Descripción", 364);
            radioButton1.Text = "Tipo de Documento";
            radioButton1.Checked = true;
            radioButton2.Text = "Descripción";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarTDocumetnos();
        }
        private void CargarTDocumetnos()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT tiptid, destid FROM tipdoc WHERE tiptid  LIKE '" + TXT_Text.Text + "%' ORDER BY codtid";
            }
            else
            {
                Sql = "SELECT tiptid, destid FROM tipdoc WHERE destid LIKE '%" + TXT_Text.Text + "%' ORDER BY codtid";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetString(0).Trim();
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Tipo de Documentos Activo
        public void ListaTipoDocumentosAI()
        {
            Opc = 8;
            this.Text = "Consulta de Tipo de Dcumento";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Tipo de Documento", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Descripción", 364);
            radioButton1.Text = "Tipo de Documento";
            radioButton1.Checked = true;
            radioButton2.Text = "Descripción";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarTDocumetnosAI();
        }
        private void CargarTDocumetnosAI()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT tiptid, destid FROM tipdoc WHERE tiptid  LIKE '" + TXT_Text.Text + "%' AND statid = 1 ORDER BY codtid";
            }
            else
            {
                Sql = "SELECT tiptid, destid FROM tipdoc WHERE destid LIKE '%" + TXT_Text.Text + "%' AND statid = 1 ORDER BY codtid";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetString(0).Trim();
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Grupo de Personal
        public void ListaGrupoPersonal()
        {
            Opc = 9;
            Text = "Consulta de Grupo de Inventario";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Grupo", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Descripción del Grupo", 364);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Descripción";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarGrupoPersonal();
        }
        private void CargarGrupoPersonal()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT codgco, desgco FROM grupcomobs WHERE (codgco)::text  LIKE '" + TXT_Text.Text + "%' ORDER BY codgco";
            }
            else
            {
                Sql = "SELECT codgco, desgco FROM grupcomobs WHERE desgco LIKE '%" + TXT_Text.Text + "%' ORDER BY codgco";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetInt32(0).ToString().Trim().PadLeft(8, '0');
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Grupo de Personal Activos
        public void ListaGrupoPersonalAI()
        {
            Opc = 9;
            Text = "Consulta de Grupo de Inventario";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Grupo", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Descripción del Grupo", 364);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Descripción";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarGrupoPersonalAI();
        }
        private void CargarGrupoPersonalAI()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT codgco, desgco FROM grupcomobs WHERE (codgco)::text  LIKE '" + TXT_Text.Text + "%' AND stagco = 1 ORDER BY codgco";
            }
            else
            {
                Sql = "SELECT codgco, desgco FROM grupcomobs WHERE desgco LIKE '%" + TXT_Text.Text + "%' AND stagco = 1 ORDER BY codgco";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetInt32(0).ToString().PadLeft(8, '0');
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        // 
        //Tipo de Movimiento de Caja
        public void ListaTMovCaja()
        {
            Opc = 10;
            Text = "Consulta de Tipo de Movimiento de Caja";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("TM Caja", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Descripción", 364);
            radioButton1.Text = "TM Caja";
            radioButton1.Checked = true;
            radioButton2.Text = "Descripción TM Caja";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarTMovCaja();
        }
        private void CargarTMovCaja()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT tiptmc, destmc FROM tipmovcaj WHERE tiptmc  LIKE '" + TXT_Text.Text + "%' ORDER BY codtmc";
            }
            else
            {
                Sql = "SELECT tiptmc, destmc FROM tipmovcaj WHERE destmc LIKE '%" + TXT_Text.Text + "%' ORDER BY codtmc";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetString(0).Trim();
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Tipo de Movimiento de Caja Activo
        public void ListaTMovCajaAI()
        {
            Opc = 10;
            Text = "Consulta de Tipo de Movimiento de Caja";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("TM Caja", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Descripción", 364);
            radioButton1.Text = "TM Caja";
            radioButton1.Checked = true;
            radioButton2.Text = "Descripción TM Caja";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarTMovCajaAI();
        }
        private void CargarTMovCajaAI()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT tiptmc, destmc FROM tipmovcaj WHERE tiptmc  LIKE '" + TXT_Text.Text + "%' AND statmc = 1 ORDER BY codtmc";
            }
            else
            {
                Sql = "SELECT tiptmc, destmc FROM tipmovcaj WHERE destmc LIKE '%" + TXT_Text.Text + "%' AND statmc = 1 ORDER BY codtmc";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetString(0).Trim();
                    arr[2] = Rst1.GetString(1);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Movimiento de Inventario
        public void ListaMovimientos()
        {
            Opc = 11;
            Text = "Consulta de Movimiento de Inventario";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Movimiento", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Tipo de Transacción", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Comentarios", 264);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Tipo de Transacción";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarMovimiento();
        }
        private void CargarMovimiento()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[4];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT codmov, tiptra, commov FROM docmovinv WHERE (codmov)::text  LIKE '" + TXT_Text.Text + "%' ORDER BY codmov";
            }
            else
            {
                Sql = "SELECT codmov, tiptra, commov FROM docmovinv WHERE tiptra LIKE '%" + TXT_Text.Text + "%' ORDER BY codmov";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetInt32(0).ToString().PadLeft(8, '0');
                    arr[2] = Rst1.GetString(1);
                    arr[3] = Rst1.GetString(2);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Movimientos de inventario Activos
        public void ListaMovimientoAI()
        {
            Opc = 11;
            Text = "Consulta de Movimiento de Inventario";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Movimiento", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Tipo de Transacción", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Comentarios", 264);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Tipo de Transacción";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarMovimientoAI();
        }
        private void CargarMovimientoAI()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT codmov, tiptra, commov FROM docmovinv WHERE (codmov)::text  LIKE '" + TXT_Text.Text + "%' AND stamov = 1 ORDER BY codmov";
            }
            else
            {
                Sql = "SELECT codmov, tiptra, commov FROM docmovinv WHERE tiptra LIKE '%" + TXT_Text.Text + "%' AND stamov = 1 ORDER BY codmov";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetInt32(0).ToString().PadLeft(8, '0');
                    arr[2] = Rst1.GetString(1);
                    arr[3] = Rst1.GetString(2);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        // 
        //Consulta de Obsequios
        public void ListaObsequios()
        {
            Opc = 12;
            Text = "Consulta de Movimiento de Inventario";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Movimiento", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Cedula", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Nombre y Apellido", 264);
            listView.Columns.Add("Fecha", 120);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Cedula de Trabajador";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarObsequios();
        }
        private void CargarObsequios()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[5];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT VO.codmov, VO.cedper, (PE.nomper || ' ' || PE.apeper) AS nompersonal, to_char(VO.fecdoc,'DD/MM/YYYY') " +
                    "FROM ventobsdoc AS VO INNER JOIN(SELECT cedper, nomper, apeper FROM PERSONAL) PE " +
                    "ON VO.cedper = PE.cedper WHERE (VO.codmov)::text  LIKE '%" + TXT_Text.Text + "%' AND VO.tiptid = 'OBS' ORDER BY codmov";
            }
            else
            {
                Sql = "SELECT VO.codmov, VO.cedper, (PE.nomper || ' ' || PE.apeper) AS nompersonal, to_char(VO.fecdoc,'DD/MM/YYYY') " +
                    "FROM ventobsdoc AS VO INNER JOIN(SELECT cedper, nomper, apeper FROM PERSONAL) PE " +
                    "ON VO.cedper = PE.cedper WHERE (VO.cedper)::text LIKE '%" + TXT_Text.Text + "%' AND VO.tiptid = 'OBS' ORDER BY codmov";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetInt32(0).ToString().Trim().PadLeft(8, '0');
                    arr[2] = Rst1.GetInt32(1).ToString();
                    arr[3] = Rst1.GetString(2);
                    arr[4] = Rst1.GetString(3);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        //
        //Movimientos de inventario Activos
        public void ListaObsequiosAI()
        {
            Opc = 12;
            Text = "Consulta de Movimiento de Inventario";
            listView.Columns.Add("Nro", 40, HorizontalAlignment.Center);
            listView.Columns.Add("Cod Movimiento", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Tipo de Transacción", 100, HorizontalAlignment.Center);
            listView.Columns.Add("Comentarios", 264);
            radioButton1.Text = "Codigo";
            radioButton1.Checked = true;
            radioButton2.Text = "Tipo de Transacción";
            TXT_Text.Visible = true;
            TXT_Text.Enabled = true;
            TextHp();
            CargarObsequiosAI();
        }
        private void CargarObsequiosAI()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst1 = null;
            string[] arr = new string[3];
            ListViewItem itm;
            int Nr = 0;
            listView.Items.Clear();
            string Sql = "";
            if (radioButton1.Checked)
            {
                Sql = "SELECT VO.codmov, VO.cedper, (PE.nomper || ' ' || PE.apeper) AS nompersonal, to_char(VO.fecdoc,'DD/MM/YYYY') " +
                    "FROM ventobsdoc AS VO INNER JOIN(SELECT cedper, nomper, apeper FROM PERSONAL) PE " +
                    "ON VO.cedper = PE.cedper WHERE (VO.codmov)::text  LIKE '%" + TXT_Text.Text + "%' AND VO.tiptid = 'OBS' ORDER BY codmov";
            }
            else
            {
                Sql = "SELECT VO.codmov, VO.cedper, (PE.nomper || ' ' || PE.apeper) AS nompersonal, to_char(VO.fecdoc,'DD/MM/YYYY') " +
                    "FROM ventobsdoc AS VO INNER JOIN(SELECT cedper, nomper, apeper FROM PERSONAL) PE " +
                    "ON VO.cedper = PE.cedper WHERE (VO.cedper)::text LIKE '" + TXT_Text.Text + "%' AND VO.tiptid = 'OBS' ORDER BY codmov";
            }
            if (Cnn.GetDataReader(ref Rst1, Sql))
            {
                int COLC = 0;
                while (Rst1.Read())
                {
                    Nr++;
                    arr[0] = Nr.ToString();
                    arr[1] = Rst1.GetInt32(0).ToString().Trim().PadLeft(8, '0');
                    arr[2] = Rst1.GetInt32(1).ToString();
                    arr[3] = Rst1.GetString(2);
                    arr[4] = Rst1.GetString(3);
                    itm = new ListViewItem(arr);
                    listView.Items.Add(itm);
                    if (COLC % 2 == 0)
                    {
                        listView.Items[COLC].BackColor = Color.AliceBlue;
                    }
                    COLC++;
                }
                ResideCol();
            }
            Cnn.ConecDb_Close();
        }
        // 

        private void TextHp()
        {
            switch (Opc)
            {
                case 1:
                    if (radioButton1.Checked)
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Cod. Departamento");
                    }
                    else
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Nombre del Departamento");
                    }
                    break;
                case 2:
                    if (radioButton1.Checked)
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Cod. de la Unidad");
                    }
                    else
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Descripcion de la Unidad");
                    }
                    break;
                case 3:
                    if (radioButton1.Checked)
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Cod. de la Transacción");
                    }
                    else
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Descripcion de la Transacción");
                    }
                    break;
                case 4:
                    if (radioButton1.Checked)
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Cod. del Grupo");
                    }
                    else
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Descripcion del Grupo");
                    }
                    break;
                case 5:
                    if (radioButton1.Checked)
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Tipo de IVA");
                    }
                    else
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Descripcion del Tipo de IVA");
                    }
                    break;
                case 6:
                    if (radioButton1.Checked)
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Codigo de Producto");
                    }
                    else
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Descripcion del Producto");
                    }
                    break;
                case 7:
                    if (radioButton1.Checked)
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "No. Cedula");
                    }
                    else
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Nombre y Apellido");
                    }
                    break;
                case 8:
                    if (radioButton1.Checked)
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Tipo de Documentos");
                    }
                    else
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Descripcion del Documento");
                    }
                    break;
                case 9:
                    if (radioButton1.Checked)
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Cod. del Grupo");
                    }
                    else
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Descripcion del Grupo");
                    }
                    break;
                case 10:
                    if (radioButton1.Checked)
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Tipo de Movimiento de Caja");
                    }
                    else
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Descripcion");
                    }
                    break;
                case 11:
                    if (radioButton1.Checked)
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Codigo de Movimiento");
                    }
                    else
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Tipo de Transacción");
                    }
                    break;
                case 12:
                    if (radioButton1.Checked)
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Codigo de Movimiento");
                    }
                    else
                    {
                        SendMessage(TXT_Text.Handle, EM_SETCUEBANNER, 0, "Cedula del Trabajador");
                    }
                    break;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            TextHp();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            TextHp();
        }
        private void Retornar()
        {
            switch (Opc)
            {
                case 1:
                    if (listView.SelectedItems.Count > 0)
                    {
                        _CodDpt = listView.SelectedItems[0].SubItems[1].Text;
                    }
                    break;
                case 2:
                    if (listView.SelectedItems.Count > 0)
                    {
                        _UndUnm = listView.SelectedItems[0].SubItems[1].Text;
                    }
                    break;
                case 3:
                    if (listView.SelectedItems.Count > 0)
                    {
                        _TipTra = listView.SelectedItems[0].SubItems[1].Text;
                    }
                    break;
                case 4:
                    if (listView.SelectedItems.Count > 0)
                    {
                        _CodGru = listView.SelectedItems[0].SubItems[1].Text;
                    }
                    break;
                case 5:
                    if (listView.SelectedItems.Count > 0)
                    {
                        _TipTiv = listView.SelectedItems[0].SubItems[1].Text;
                    }
                    break;
                case 6:
                    if (listView.SelectedItems.Count > 0)
                    {
                        _CodPro = listView.SelectedItems[0].SubItems[1].Text;
                    }
                    break;
                case 7:
                    if (listView.SelectedItems.Count > 0)
                    {
                        _CedPer = listView.SelectedItems[0].SubItems[1].Text;
                    }
                    break;
                case 8:
                    if (listView.SelectedItems.Count > 0)
                    {
                        _TipTid = listView.SelectedItems[0].SubItems[1].Text;
                    }
                    break;
                case 9:
                    if (listView.SelectedItems.Count > 0)
                    {
                        _CodGco = listView.SelectedItems[0].SubItems[1].Text;
                    }
                    break;
                case 10:
                    if (listView.SelectedItems.Count > 0)
                    {
                        _TipTmc = listView.SelectedItems[0].SubItems[1].Text;
                    }
                    break;
                case 11:
                    if (listView.SelectedItems.Count > 0)
                    {
                        _CodInv = listView.SelectedItems[0].SubItems[1].Text;
                    }
                    break;
                case 12:
                    if (listView.SelectedItems.Count > 0)
                    {
                        _CodObs = listView.SelectedItems[0].SubItems[1].Text;
                    }
                    break;
            }
            this.Close();
        }
     
        
        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    Retornar();
                    break;
            }
        }

        private void TXT_Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Encoding.ASCII.GetBytes(e.KeyChar.ToString().ToUpper())[0];
        }

        private void TXT_Text_TextChanged(object sender, EventArgs e)
        {
            switch (Opc)
            {
                case 1:
                    CargarDepartamentos();
                    break;
                case 2:
                    CargarUnidadMedida();
                    break;
                case 3:
                    CargarTransacciones();
                    break;
                case 4:
                    CargarGrupoInventario();
                    break;
                case 5:
                    CargarTipoIVA();
                    break;
                case 6:
                    CargarProductos();
                    break;
                case 7:
                    CargarPersonal();
                    break;
                case 8:
                    CargarTDocumetnos();
                    break;
                case 9:
                    CargarGrupoPersonal();
                    break;
                case 10:
                    CargarTMovCaja();
                        break;
                case 11:
                    CargarMovimiento();
                    break;
                case 12:
                    CargarObsequios();
                    break;
            }
        }

        private void TXT_Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (listView.Items.Count > 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        listView.Items[0].Selected = true;
                        listView.Select();
                        break;
                    case Keys.Down:
                        listView.Items[0].Selected = true;
                        listView.Select();
                        break;
                }
            }
        }

        private void FormBUSQUEDAS_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Retornar();
        }

       
    }
}
