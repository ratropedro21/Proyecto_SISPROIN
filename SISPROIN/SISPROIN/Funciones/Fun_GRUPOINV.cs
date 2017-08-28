using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Funciones
{
    class Fun_GRUPOINV
    {
        Clases.ConectarDB dbSQLConn = new Clases.ConectarDB();
        string Elementos = " codgru, desgru, stagru ";
        private Clases._GRUPOINV LLenar(NpgsqlDataReader Dr)
        {
            return new Clases._GRUPOINV(Dr.GetInt32(0), Dr.GetString(1), Dr.GetInt32(2));
        }

        public string Correlativo()
        {
            string R = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT codgru FROM grupinv ORDER BY codgru DESC LIMIT 1";
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

        public Clases._GRUPOINV BuscarUltimo()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._GRUPOINV usr = new Clases._GRUPOINV();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM grupinv ORDER BY codgru DESC LIMIT 1";
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
        public Clases._GRUPOINV BuscarPrimero()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._GRUPOINV usr = new Clases._GRUPOINV();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM grupinv ORDER BY codgru ASC LIMIT 1 ";
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
        public Clases._GRUPOINV BuscarAnterior(Clases._GRUPOINV GRU)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._GRUPOINV usr = new Clases._GRUPOINV();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM grupinv WHERE codgru < @codgru ORDER BY codgru DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codgru", GRU.codgru);
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
        public Clases._GRUPOINV BuscarSiguiente(Clases._GRUPOINV GRU)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._GRUPOINV usr = new Clases._GRUPOINV();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM grupinv WHERE codgru > @codgru ORDER BY codgru ASC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codgru", GRU.codgru);
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
        public Boolean Nuevo(Clases._GRUPOINV GRU)
        {
            if (!Existe(GRU.codgru))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO grupinv (codgru, desgru, stagru) VALUES (@codgru, @desgru, @stagru)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codgru", GRU.codgru);
                cmd.Parameters.AddWithValue("@desgru", GRU.desgru);
                cmd.Parameters.AddWithValue("@stagru", GRU.stagru);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Modificar(Clases._GRUPOINV GRU)
        {
            if (Existe(GRU.codgru))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE grupinv SET codgru = @codgru, desgru = @desgru, stagru = @stagru WHERE codgru = @codgru";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codgru", GRU.codgru);
                cmd.Parameters.AddWithValue("@desgru", GRU.desgru);
                cmd.Parameters.AddWithValue("@stagru", GRU.stagru);
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
        public Boolean Existe(int vcodgru)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT codgru FROM grupinv WHERE codgru = @codgru";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codgru", vcodgru);
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

        public Boolean StatudAI(int vcodgru)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT codgru FROM grupinv WHERE codgru = @codgru AND stagru = 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codgru", vcodgru);
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

        public Clases._GRUPOINV Buscar(int vcodgru)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._GRUPOINV usr = new Clases._GRUPOINV();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM grupinv WHERE codgru = @codgru LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codgru", vcodgru);
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

        public string Sent_DesGru(int vcodgru)
        {
            string _ValorR = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT desgru FROM grupinv WHERE codgru = @codgru ORDER BY codgru Desc";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codgru", vcodgru);
            Dr = cmd.ExecuteReader();

            if (Dr.HasRows)
            {
                Dr.Read();
                _ValorR = Dr.GetString(0);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return _ValorR;
            }
            else
            {
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return "";
            }
        }
    }
}
