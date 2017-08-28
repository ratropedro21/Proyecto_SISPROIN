using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Funciones
{
    class Fun_UNIDMEDIA
    {
        Clases.ConectarDB dbSQLConn = new Clases.ConectarDB();
        string Elementos = " codunm, undunm, desunm, staunm ";
        private Clases._UNIDMEDIA LLenar(NpgsqlDataReader Dr)
        {
            return new Clases._UNIDMEDIA(Dr.GetInt32(0), Dr.GetString(1), Dr.GetString(2), Dr.GetInt32(3));
        }
        public string Correlativo()
        {
            string R = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT codunm FROM unidmed ORDER BY codunm DESC LIMIT 1";
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
        public Clases._UNIDMEDIA BuscarUltimo()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._UNIDMEDIA usr = new Clases._UNIDMEDIA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM unidmed ORDER BY codunm DESC LIMIT 1";
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
        public Clases._UNIDMEDIA BuscarPrimero()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._UNIDMEDIA usr = new Clases._UNIDMEDIA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM unidmed ORDER BY codunm ASC LIMIT 1 ";
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
        public Clases._UNIDMEDIA BuscarAnterior(Clases._UNIDMEDIA UND)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._UNIDMEDIA usr = new Clases._UNIDMEDIA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM unidmed WHERE codunm < @codunm ORDER BY codunm DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codunm", UND.codunm);
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
        public Clases._UNIDMEDIA BuscarSiguiente(Clases._UNIDMEDIA UND)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._UNIDMEDIA usr = new Clases._UNIDMEDIA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM unidmed WHERE codunm > @codunm ORDER BY codunm ASC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codunm", UND.codunm);
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
        public Boolean Nuevo(Clases._UNIDMEDIA UND)
        {
            if (!Existe(UND.undunm))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO unidmed (codunm, undunm, desunm, staunm) VALUES (@codunm, @undunm, @desunm, @staunm)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codunm", UND.codunm);
                cmd.Parameters.AddWithValue("@undunm", UND.undunm);
                cmd.Parameters.AddWithValue("@desunm", UND.desunm);
                cmd.Parameters.AddWithValue("@staunm", UND.staunm);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Modificar(Clases._UNIDMEDIA UND)
        {
            if (Existe(UND.undunm))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE unidmed SET codunm = @codunm, undunm = @undunm, desunm = @desunm, staunm = @staunm WHERE codunm = @codunm";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codunm", UND.codunm);
                cmd.Parameters.AddWithValue("@undunm", UND.undunm);
                cmd.Parameters.AddWithValue("@desunm", UND.desunm);
                cmd.Parameters.AddWithValue("@staunm", UND.staunm);
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

        public Boolean Existe(string vundunm)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT undunm FROM unidmed WHERE undunm = @undunm";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@undunm", vundunm);
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

        public Boolean StatudAI(string vundunm)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT undunm FROM unidmed WHERE undunm = @undunm AND staunm = 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@undunm", vundunm);
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

        public Clases._UNIDMEDIA BuscarCod(int vcodunm)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._UNIDMEDIA usr = new Clases._UNIDMEDIA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM unidmed WHERE codunm = @codunm LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codunm", vcodunm);
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
        public Clases._UNIDMEDIA BuscarUnd(string vundunm)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._UNIDMEDIA usr = new Clases._UNIDMEDIA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM unidmed WHERE undunm = @undunm LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@undunm", vundunm);
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

        public string Sent_DesUnm(string vundunm)
        {
            string _ValorR = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT desunm FROM unidmed WHERE undunm = @undunm ORDER BY codunm Desc";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@undunm", vundunm);
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
