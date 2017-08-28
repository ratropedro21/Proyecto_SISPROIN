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
    public partial class FormPERMISOS : Form
    {
        Clases.ConectarDB Cnn = new Clases.ConectarDB();
        string[] TUsuario = new string[7];
        int _Nivel = 0;
        bool sW = false;
        public FormPERMISOS(string[] _TUsuario)
        {
            InitializeComponent();
            TUsuario = _TUsuario;
            LlenarUsuarios();
            Com_UsuUsu.SelectedIndex = 0;
            LlenearNivel0();
            Com_Nivel0.SelectedIndex = 0;
        }
        private void LlenarUsuarios()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst = null;
            Com_UsuUsu.Items.Clear();
            if (Cnn.GetDataReader(ref Rst, "SELECT usuusu FROM usuarios ORDER BY idusu"))
            {
                while (Rst.Read())
                {
                    Com_UsuUsu.Items.Add(Rst.GetString(0).Trim());
                }
                Rst.Close();
            }
            Cnn.ConecDb_Close();
        }
        private void LlenearNivel0()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst = null;
            Com_Nivel0.Items.Clear();
            if (Cnn.GetDataReader(ref Rst, "SELECT * FROM nivel0 ORDER BY id_nivel0"))
            {
                while (Rst.Read())
                {
                    Com_Nivel0.Items.Add(Rst.GetInt32(0).ToString().PadLeft(3, '0') + " - " + Rst.GetString(1).Trim());
                }
                Rst.Close();
            }
            Cnn.ConecDb_Close();

        }
        private void LlenarNivel1(int CodNivel0)
        {
            string _IdNivel0 = Com_Nivel0.Items[CodNivel0].ToString().Substring(0, 3);
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst = null;
            Com_Nivel1.Items.Clear();
            if (Cnn.GetDataReader(ref Rst, "SELECT id_nivel1, nom_nivel1 FROM nivel1 WHERE id_nivel0 = " + _IdNivel0 + " ORDER BY id_nivel1"))
            {
                while (Rst.Read())
                {
                    Com_Nivel1.Items.Add(Rst.GetInt32(0).ToString().PadLeft(3, '0') + " - " + Rst.GetString(1).Trim());
                }
                Rst.Close();
            }
            Cnn.ConecDb_Close();
        }
        private void LlenarNivel2(int CodNivel0, int CodNivel1)
        {
            Cnn.ConecDb_Abrir();
            int _IdNivel0 = Convert.ToInt32(Com_Nivel0.Items[CodNivel0].ToString().Substring(0, 3));
            int _IdNivel1 = Convert.ToInt32(Com_Nivel1.Items[CodNivel1].ToString().Substring(0, 3));
            NpgsqlDataReader Rst = null;
            Com_Nivel2.Items.Clear();
            if (Cnn.GetDataReader(ref Rst, "SELECT id_nivel2, nom_nivel2 FROM nivel2 WHERE id_nivel0 = " + _IdNivel0.ToString() + " AND id_nivel1=" + _IdNivel1.ToString() + " ORDER BY id_nivel2"))
            {
                while (Rst.Read())
                {
                    Com_Nivel2.Items.Add(Rst.GetInt32(0).ToString().PadLeft(3, '0') + " - " + Rst.GetString(1).Trim());
                }
                Rst.Close();
            }
            Cnn.ConecDb_Close();
        }

        private void CargarPermiso()
        {
            Cnn.ConecDb_Abrir();
            NpgsqlDataReader Rst = null;
            string _CodUsu = Com_UsuUsu.Items[Com_UsuUsu.SelectedIndex].ToString();
            int _IdNivel0 = Convert.ToInt32(Com_Nivel0.Items[Com_Nivel0.SelectedIndex].ToString().Substring(0, 3));
            int _IdNivel1 = Convert.ToInt32(Com_Nivel1.Items[Com_Nivel1.SelectedIndex].ToString().Substring(0, 3));
            int _IdNivel2 = Convert.ToInt32(Com_Nivel2.Items[Com_Nivel2.SelectedIndex].ToString().Substring(0, 3));
            if (Cnn.GetDataReader(ref Rst, "SELECT permiso FROM modulos WHERE usuusu='" + _CodUsu + "' AND id_nivel0 = " + _IdNivel0.ToString() + " AND id_nivel1=" + _IdNivel1.ToString() + " AND id_nivel2=" + _IdNivel2.ToString() + ""))
            {
                Rst.Read();
                _Nivel = Rst.GetInt32(0);
                Rst.Close();
            }
            else
            {
                _Nivel = 5;
            }
            AsignarNivel();
            Cnn.ConecDb_Close();
        }

        private void AsignarNivel()
        {
            sW = false;
            switch (_Nivel)
            {
                case 1:
                    radioButton1.Checked = true;
                    break;
                case 2:
                    radioButton2.Checked = true;
                    break;
                case 3:
                    radioButton3.Checked = true;
                    break;
                case 4:
                    radioButton4.Checked = true;
                    break;
                case 5:
                    radioButton5.Checked = true;
                    break;
            }
            sW = true;
        }
        private void ActualizarPermiso(int _Permiso)
        {
            string _UsuUsu = Com_UsuUsu.Items[Com_UsuUsu.SelectedIndex].ToString();
            int _IdNivel0 = Convert.ToInt32(Com_Nivel0.Items[Com_Nivel0.SelectedIndex].ToString().Substring(0, 3));
            int _IdNivel1 = Convert.ToInt32(Com_Nivel1.Items[Com_Nivel1.SelectedIndex].ToString().Substring(0, 3));
            int _IdNivel2 = Convert.ToInt32(Com_Nivel2.Items[Com_Nivel2.SelectedIndex].ToString().Substring(0, 3));
            Cnn.ConecDb_Abrir();
            string Sql = "UPDATE modulos SET permiso=" + _Permiso.ToString() + " WHERE usuusu ='" + _UsuUsu + "' AND id_nivel0 = " + _IdNivel0.ToString() + " AND id_nivel1=" + _IdNivel1.ToString() + " AND id_nivel2=" + _IdNivel2.ToString() + "";

            if (Cnn.Update(Sql) == 0)
            {
                Sql = "INSERT INTO modulos (usuusu, id_nivel0, id_nivel1, id_nivel2, permiso) VALUES ('" + _UsuUsu + "'," + _IdNivel0.ToString() + "," + _IdNivel1.ToString() + "," + _IdNivel2.ToString() + "," + _Permiso.ToString() + ")";
                Cnn.Inset(Sql);
            }
            Cnn.ConecDb_Close();
        }

        private void Com_UsuUsu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Com_Nivel2.Items.Count > 0)
            {
                CargarPermiso();
            }
        }

        private void Com_Nivel0_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarNivel1(Com_Nivel0.SelectedIndex);
            if (Com_Nivel1.Items.Count > 0)
            {
                Com_Nivel1.SelectedIndex = 0;
            }
        }

        private void Com_Nivel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarNivel2(Com_Nivel0.SelectedIndex, Com_Nivel1.SelectedIndex);
            if (Com_Nivel2.Items.Count > 0)
            {
                Com_Nivel2.SelectedIndex = 0;
            }
        }

        private void Com_Nivel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPermiso();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked && sW)
                ActualizarPermiso(1);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked && sW)
                ActualizarPermiso(2);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked && sW)
                ActualizarPermiso(3);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked && sW)
                ActualizarPermiso(4);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked && sW)
                ActualizarPermiso(5);
        }

        private void Cmd_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
