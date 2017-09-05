using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISPROIN.Clases;
using NpgsqlTypes;

namespace SISPROIN.Funciones
{
    class Fun_TIPTRAN
    {
        ConectarDB dbSQLConn = new ConectarDB();
        string Elementos = " codtra, tiptra, destra, statra, codpro ";
        private _TIPTRAN LLenar(NpgsqlDataReader Dr)
        {
            return new _TIPTRAN(Dr.GetInt32(0), Dr.GetString(1), Dr.GetString(2), Dr.GetInt32(3), Dr.GetValue(4) as int[]);
        }
        public string Correlativo()
        {
            string R = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT codtra FROM tiptransa ORDER BY codtra DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            dr2 = cmd.ExecuteReader();
            if (dr2.HasRows)
            {
                dr2.Read();
                R = dr2.GetInt32(0).ToString();
                dr2.Close();
                dbSQLConn.ConecDb_Close();
                R = (Convert.ToInt32(R) + 1).ToString();
                return R;
            }
            else
            {
                dr2.Close();
                dbSQLConn.ConecDb_Close();
                return "1";
            }
        }
        public _TIPTRAN BuscarUltimo()
        {
            dbSQLConn.ConecDb_Abrir();
            _TIPTRAN usr = new _TIPTRAN();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tiptransa ORDER BY codtra DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar(Dr);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
        }
        public _TIPTRAN BuscarPrimero()
        {
            dbSQLConn.ConecDb_Abrir();
            _TIPTRAN usr = new _TIPTRAN();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tiptransa ORDER BY codtra ASC LIMIT 1 ";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);

            Dr = cmd.ExecuteReader();

            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar(Dr);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
        }
        public _TIPTRAN BuscarAnterior(_TIPTRAN TTR)
        {
            dbSQLConn.ConecDb_Abrir();
            _TIPTRAN usr = new _TIPTRAN();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tiptransa WHERE codtra < @codtra ORDER BY codtra DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codtra", TTR.codtra);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar(Dr);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return BuscarPrimero();
            }
        }
        public _TIPTRAN BuscarSiguiente(_TIPTRAN TTR)
        {
            dbSQLConn.ConecDb_Abrir();
            _TIPTRAN usr = new _TIPTRAN();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tiptransa WHERE codtra > @codtra ORDER BY codtra ASC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codtra", TTR.codtra);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar(Dr);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return BuscarUltimo();
            }
        }
        public Boolean Nuevo(_TIPTRAN TTR)
        {
            if (!Existe(TTR.tiptra))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO tiptransa (codtra, tiptra, destra, statra, codpro) VALUES (@codtra, @tiptra, @destra, @statra, @codpro)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codtra", TTR.codtra);
                cmd.Parameters.AddWithValue("@tiptra", TTR.tiptra);
                cmd.Parameters.AddWithValue("@destra", TTR.destra);
                cmd.Parameters.AddWithValue("@statra", TTR.statra);
                cmd.Parameters.AddWithValue("@codpro", NpgsqlDbType.Array | NpgsqlDbType.Integer, TTR.codpro);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Modificar( _TIPTRAN TTR)
        {
            if (Existe(TTR.tiptra))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE tiptransa SET codtra = @codtra, tiptra = @tiptra, destra = @destra, statra = @statra, codpro = @codpro WHERE codtra = @codtra";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codtra", TTR.codtra);
                cmd.Parameters.AddWithValue("@tiptra", TTR.tiptra);
                cmd.Parameters.AddWithValue("@destra", TTR.destra);
                cmd.Parameters.AddWithValue("@statra", TTR.statra);
                cmd.Parameters.AddWithValue("@codpro",  NpgsqlDbType.Array | NpgsqlDbType.Integer, TTR.codpro);
                int retVal = cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                if (retVal == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        public Boolean Existe(string vtiptra)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT tiptra FROM tiptransa WHERE tiptra = @tiptra";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptra", vtiptra);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return false;
            }
        }

        public Boolean StatusAI(string vtiptra)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT tiptra FROM tiptransa WHERE tiptra = @tiptra AND statra = 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptra", vtiptra);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return false;
            }
        }

        public string Search_TipTra(string vcodigo)
        {
            string _ValorR = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT destra FROM tiptransa WHERE tiptra = @tiptra ORDER BY tiptra Desc";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptra", vcodigo);
            dr2 = cmd.ExecuteReader();

            if (dr2.HasRows)
            {
                dr2.Read();
                _ValorR = dr2.GetString(0);
                dr2.Close();
                dbSQLConn.ConecDb_Close();
                return _ValorR;
            }
            else
            {
                dr2.Close();
                dbSQLConn.ConecDb_Close();
                return "";
            }
        }

        public _TIPTRAN BuscarCod(int vcodtra)
        {
            dbSQLConn.ConecDb_Abrir();
            _TIPTRAN usr = new _TIPTRAN();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tiptransa WHERE codtra = @codtra LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codtra", vcodtra);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar(Dr);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return BuscarPrimero();
            }
        }
        public _TIPTRAN BuscarTipo(string vtiptra)
        {
            dbSQLConn.ConecDb_Abrir();
            _TIPTRAN usr = new _TIPTRAN();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tiptransa WHERE tiptra = @tiptra LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptra", vtiptra);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar(Dr);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return BuscarPrimero();
            }
        }

        public void GetLisPRODUCTOS(ref ListView Lista)
        {
            int COLC = 0;
            foreach (_PRODUCTOS pro in _PRODUCTOS.getAll())
            {
                Lista.Items.Add(new ListViewItem(new string[] { pro.codpro.ToString(), pro.despro }));
                if (COLC % 2 == 0)
                {
                    Lista.Items[COLC].BackColor = Color.AliceBlue;
                }
                COLC++;

            }
        }

        public int ProductOfTheTransaction(string TipTra)
        {
            Int32 R = 0;
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = $"SELECT SUM(array_length(codpro,1))::integer AS R FROM public.tiptransa " +
                $"WHERE tiptra = @tiptra AND statra = 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptra", TipTra);
            dr2 = cmd.ExecuteReader();
            if (dr2.HasRows)
            {
                dr2.Read();
                //if (dr2.GetInt32(0) = null)
                //{
                //    return 0;
                //    dr2.Close();
                //    dbSQLConn.ConecDb_Close();
                //}
                //else
                //{
                    R = dr2.GetInt32(0);
                    dr2.Close();
                    dbSQLConn.ConecDb_Close();
                    return R;
                //}
               
            }
            else
            {
                dr2.Close();
                dbSQLConn.ConecDb_Close();
                return 0;
            }
        }
    }
}
