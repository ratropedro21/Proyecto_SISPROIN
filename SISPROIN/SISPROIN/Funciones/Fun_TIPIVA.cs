using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Funciones
{
    class Fun_TIPIVA
    {
        Clases.ConectarDB dbSQLConn = new Clases.ConectarDB();
        string Elementos = " codtiv, tiptiv, destiv, stativ ";
        private Clases._TIPIVA LLenar(NpgsqlDataReader Dr)
        {
            return new Clases._TIPIVA(Dr.GetInt32(0), Dr.GetString(1), Dr.GetString(2), Dr.GetInt32(3));
        }
        public string Correlativo()
        {
            string R = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT codtiv FROM tipiva ORDER BY codtiv DESC LIMIT 1";
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
        public Clases._TIPIVA BuscarUltimo()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPIVA usr = new Clases._TIPIVA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipiva ORDER BY codtiv DESC LIMIT 1";
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
        public Clases._TIPIVA BuscarPrimero()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPIVA usr = new Clases._TIPIVA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipiva ORDER BY codtiv ASC LIMIT 1 ";
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
        public Clases._TIPIVA BuscarAnterior(Clases._TIPIVA TIV)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPIVA usr = new Clases._TIPIVA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipiva WHERE codtiv < @codtiv ORDER BY codtiv DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codtiv", TIV.codtiv);
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
        public Clases._TIPIVA BuscarSiguiente(Clases._TIPIVA TIV)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPIVA usr = new Clases._TIPIVA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipiva WHERE codtiv > @codtiv ORDER BY codtiv ASC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codtiv", TIV.codtiv);
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
        public Boolean Nuevo(Clases._TIPIVA TIV)
        {
            if (!Existe(TIV.tiptiv))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO tipiva (codtiv, tiptiv, destiv, stativ) VALUES (@codtiv, @tiptiv, @destiv, @stativ)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codtiv", TIV.codtiv);
                cmd.Parameters.AddWithValue("@tiptiv", TIV.tiptiv);
                cmd.Parameters.AddWithValue("@destiv", TIV.destiv);
                cmd.Parameters.AddWithValue("@stativ", TIV.stativ);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Modificar(Clases._TIPIVA TIV)
        {
            if (Existe(TIV.tiptiv))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE tipiva SET codtiv = @codtiv, tiptiv = @tiptiv, destiv = @destiv, stativ = @stativ WHERE codtiv = @codtiv";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codtiv", TIV.codtiv);
                cmd.Parameters.AddWithValue("@tiptiv", TIV.tiptiv);
                cmd.Parameters.AddWithValue("@destiv", TIV.destiv);
                cmd.Parameters.AddWithValue("@stativ", TIV.stativ);
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
        public Boolean Existe(string vtiptiv)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT tiptiv FROM tipiva WHERE tiptiv = @tiptiv";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptiv", vtiptiv);
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

        public Boolean StatudAI(string vtiptiv)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT tiptiv FROM tipiva WHERE tiptiv = @tiptiv AND stativ = 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptiv", vtiptiv);
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

        public Clases._TIPIVA BuscarCod(int vcodtiv)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPIVA usr = new Clases._TIPIVA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipiva WHERE codtiv = @codtiv LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codtiv", vcodtiv);
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

        public Clases._TIPIVA BuscarTip(string vtiptiv)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPIVA usr = new Clases._TIPIVA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipiva WHERE tiptiv = @tiptiv LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptiv", vtiptiv);
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

        public string Sent_DesTiv(string vtiptiv)
        {
            string _ValorR = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT destiv FROM tipiva WHERE tiptiv = @tiptiv ORDER BY codtiv Desc";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptiv", vtiptiv);
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
    }
}
