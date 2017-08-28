using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISPROIN.Formularios.Configuracion
{
    public partial class FormNIVELESMENU : Form
    {
        int Boton = 0;
        Clases.Utilitarios Util = new Clases.Utilitarios();
        Clases.ConectarDB dbSQLConn = new Clases.ConectarDB();
        string[] TUsuario = new string[7];
        public FormNIVELESMENU(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
            listView0.Columns.Add("Cod.", 50);
            listView0.Columns.Add("Nombre", 140);
            listView1.Columns.Add("Cod", 50);
            listView1.Columns.Add("Nombre", 140);
            listView2.Columns.Add("Cod", 50);
            listView2.Columns.Add("Nombre", 140);
            LlenarNivel0();
            if (listView0.Items.Count > 0)
            {
                listView0.Items[0].Selected = true;
                listView0.Select();
            }
        }
        private void LlenarNivel0()
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Rst = null;
            string[] arr = new string[2];
            ListViewItem itm;
            listView0.Items.Clear();
            if (dbSQLConn.GetDataReader(ref Rst, "SELECT * FROM nivel0 ORDER BY id_nivel0"))
            {
                while (Rst.Read())
                {
                    arr[0] = Rst.GetInt32(0).ToString();
                    arr[1] = Rst.GetString(1).Trim();
                    itm = new ListViewItem(arr);
                    listView0.Items.Add(itm);

                }
                Rst.Close();
            }
            dbSQLConn.ConecDb_Close();
        }
        private void limpiar()
        {
            Txt_Nivel.Clear();
            Txt_Nombre.Clear();
            Txt_Nivel.Focus();
        }
        private void LlenarNivel1(int CodNivel0)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Rst = null;
            string[] arr = new string[2];
            ListViewItem itm;
            listView1.Items.Clear();
            if (dbSQLConn.GetDataReader(ref Rst, "SELECT id_nivel1, nom_nivel1 FROM nivel1 WHERE id_nivel0 = " + CodNivel0.ToString() + " ORDER BY id_nivel1"))
            {
                while (Rst.Read())
                {
                    arr[0] = Rst.GetInt32(0).ToString();
                    arr[1] = Rst.GetString(1).Trim();
                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);
                }
                Rst.Close();
            }
            dbSQLConn.ConecDb_Close();
        }
        private void LlenarNivel2(int CodNivel0, int CodNivel1)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Rst = null;
            string[] arr = new string[2];
            ListViewItem itm;
            listView2.Items.Clear();
            if (dbSQLConn.GetDataReader(ref Rst, "SELECT id_nivel2, nom_nivel2 FROM nivel2 WHERE id_nivel0 = " + CodNivel0.ToString() + " AND id_nivel1=" + CodNivel1.ToString() + " ORDER BY id_nivel2"))
            {
                while (Rst.Read())
                {
                    arr[0] = Rst.GetInt32(0).ToString();
                    arr[1] = Rst.GetString(1).Trim();
                    itm = new ListViewItem(arr);
                    listView2.Items.Add(itm);
                }
                Rst.Close();
            }
            dbSQLConn.ConecDb_Close();
        }
        private void AgregarNivel0()
        {
            dbSQLConn.ConecDb_Abrir();
            try
            {
                dbSQLConn.Inset("INSERT INTO nivel0 (id_nivel0, nom_nivel0) VALUES (" + Txt_Nivel.Text + ",'" + Txt_Nombre.Text + "')");
                LlenarNivel0();
                foreach (Control ctrl in this.panel1.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        TextBox TXT = ctrl as TextBox;
                        TXT.Clear();
                        TXT.BackColor = System.Drawing.Color.White;
                    }
                }
                panel1.Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ya el nivel existe.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            dbSQLConn.ConecDb_Close();
        }
        private void AgregarNivel1()
        {
            int CodNivel0 = 0;
            CodNivel0 = Convert.ToInt32(listView0.SelectedItems[0].Text);
            dbSQLConn.ConecDb_Abrir();
            try
            {
                dbSQLConn.Inset("INSERT INTO nivel1 (id_nivel0, id_nivel1, nom_nivel1) VALUES (" + CodNivel0.ToString() + "," + Txt_Nivel.Text + ",'" + Txt_Nombre.Text + "')");
                LlenarNivel1(Convert.ToInt32(listView0.SelectedItems[0].Text));
                foreach (Control ctrl in this.panel1.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        TextBox TXT = ctrl as TextBox;
                        TXT.Clear();
                        TXT.BackColor = System.Drawing.Color.White;
                    }
                }
                panel1.Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ya el nivel existe.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            dbSQLConn.ConecDb_Close();
        }
        private void AgregarNivel2()
        {
            int CodNivel0 = 0;
            int CodNivel1 = 1;
            CodNivel0 = Convert.ToInt32(listView0.SelectedItems[0].Text);
            CodNivel1 = Convert.ToInt32(listView1.SelectedItems[0].Text);
            dbSQLConn.ConecDb_Abrir();
            try
            {
                dbSQLConn.Inset("INSERT INTO nivel2 (id_Nivel0, id_nivel1, id_nivel2, nom_nivel2) VALUES (" + CodNivel0.ToString() + "," + CodNivel1.ToString() + "," + Txt_Nivel.Text + ",'" + Txt_Nombre.Text + "')");
                LlenarNivel2(CodNivel0, CodNivel1);
                foreach (Control ctrl in this.panel1.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        TextBox TXT = ctrl as TextBox;
                        TXT.Clear();
                        TXT.BackColor = Color.White;
                    }
                }
                panel1.Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Ya el nivel existe.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            dbSQLConn.ConecDb_Close();
        }

        private void Cmd_AgrNivel0_Click(object sender, EventArgs e)
        {
            Boton = 0;
            panel1.Visible = true;
            Txt_Nivel.Enabled = true;
            Txt_Nivel.BackColor = Color.Turquoise;
            Txt_Nivel.Focus();
            limpiar();
        }

        private void Cmd_AgrNivel1_Click(object sender, EventArgs e)
        {
            Boton = 1;
            panel1.Visible = true;
            Txt_Nivel.Enabled = true;
            Txt_Nivel.BackColor = Color.Turquoise;
            limpiar();
        }

        private void Cmd_AgrNivel2_Click(object sender, EventArgs e)
        {
            Boton = 2;
            panel1.Visible = true;
            Txt_Nivel.Enabled = true;
            Txt_Nivel.BackColor = Color.Turquoise;
            limpiar();
        }

        private void Cmd_Aceptar_Click(object sender, EventArgs e)
        {
            switch (Boton)
            {
                case 0:
                    AgregarNivel0();
                    break;
                case 1:
                    AgregarNivel1();
                    break;
                case 2:
                    AgregarNivel2();
                    break;
            }
        }

        private void Cmd_Cancelar_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            foreach (Control ctrl in this.panel1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox TXT = ctrl as TextBox;
                    TXT.Clear();
                    TXT.BackColor = Color.White;
                }
            }
        }

        private void Cmd_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView0_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView0.SelectedItems.Count > 0)
            {
                LlenarNivel1(Convert.ToInt32(listView0.SelectedItems[0].Text));
                listView2.Items.Clear();
                Cmd_AgrNivel0.Visible = true;
                Cmd_AgrNivel1.Visible = true;
                Cmd_AgrNivel2.Visible = false;
                Cmd_Cancelar.PerformClick();
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                LlenarNivel2(Convert.ToInt32(listView0.SelectedItems[0].Text), Convert.ToInt32(listView1.SelectedItems[0].Text));
                Cmd_AgrNivel0.Visible = false;
                Cmd_AgrNivel1.Visible = true;
                Cmd_AgrNivel2.Visible = true;
                Cmd_Cancelar.PerformClick();
            }
        }

        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                Cmd_Cancelar.PerformClick();
            }
        }

        private void Txt_Nivel_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_Nivel, Txt_Nombre);
                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Cmd_Cancelar.PerformClick();
                    break;
            }
        }

        private void Txt_Nombre_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    Cmd_Aceptar.PerformClick();
                    break;
            }
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    Util.CambiarTxt(Txt_Nombre, Txt_Nivel);
                    break;
            }
        }
    }
}
