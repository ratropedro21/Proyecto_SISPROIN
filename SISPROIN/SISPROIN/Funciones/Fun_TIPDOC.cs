using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Funciones
{
    class Fun_TIPDOC
    {
        Clases.ConectarDB dbSQLConn = new Clases.ConectarDB();
        string Elementos = " codtid, tiptid, destid, fortid, caltid, mivtid, statid ";
        private Clases._TIPDOC LLenar(NpgsqlDataReader Dr)
        {
            return new Clases._TIPDOC(Dr.GetInt32(0), Dr.GetString(1), Dr.GetString(2), Dr.GetString(3), Dr.GetInt32(4), Dr.GetInt32(5), Dr.GetInt32(6));
        }
        public string Correlativo()
        {
            string R = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT codtid FROM tipdoc ORDER BY codtid DESC LIMIT 1";
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
        public Clases._TIPDOC BuscarUltimo()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPDOC usr = new Clases._TIPDOC();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipdoc ORDER BY codtid DESC LIMIT 1";
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
        public Clases._TIPDOC BuscarPrimero()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPDOC usr = new Clases._TIPDOC();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipdoc ORDER BY codtid ASC LIMIT 1 ";
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
        public Clases._TIPDOC BuscarAnterior(Clases._TIPDOC TID)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPDOC usr = new Clases._TIPDOC();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipdoc WHERE codtid < @codtid ORDER BY codtid DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codtid", TID.codtid);
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
        public Clases._TIPDOC BuscarSiguiente(Clases._TIPDOC TID)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPDOC usr = new Clases._TIPDOC();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipdoc WHERE codtid > @codtid ORDER BY codtid ASC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codtid", TID.codtid);
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
        public Boolean Nuevo(Clases._TIPDOC TID)
        {
            if (!Existe(TID.tiptid))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO tipdoc (codtid, tiptid, destid, fortid, caltid, mivtid, statid) "
                    + "VALUES (@codtid, @tiptid, @destid, @fortid, @caltid, @mivtid, @statid)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codtid", TID.codtid);
                cmd.Parameters.AddWithValue("@tiptid", TID.tiptid);
                cmd.Parameters.AddWithValue("@destid", TID.destid);
                cmd.Parameters.AddWithValue("@fortid", TID.fortid);
                cmd.Parameters.AddWithValue("@caltid", TID.caltid);
                cmd.Parameters.AddWithValue("@mivtid", TID.mivtid);
                cmd.Parameters.AddWithValue("@statid", TID.statid);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Modificar(Clases._TIPDOC TID)
        {
            if (Existe(TID.tiptid))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE tipdoc SET codtid = @codtid, tiptid = @tiptid, destid = @destid, fortid = @fortid, caltid = @caltid, mivtid = @mivtid, statid= @statid WHERE codtid = @codtid";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codtid", TID.codtid);
                cmd.Parameters.AddWithValue("@tiptid", TID.tiptid);
                cmd.Parameters.AddWithValue("@destid", TID.destid);
                cmd.Parameters.AddWithValue("@fortid", TID.fortid);
                cmd.Parameters.AddWithValue("@caltid", TID.caltid);
                cmd.Parameters.AddWithValue("@mivtid", TID.mivtid);
                cmd.Parameters.AddWithValue("@statid", TID.statid);
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
        public Boolean Existe(string vtiptid)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT tiptid FROM tipdoc WHERE tiptid = @tiptid";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptid", vtiptid);
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

        public Clases._TIPDOC BuscarCod(int vcodtid)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPDOC usr = new Clases._TIPDOC();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipdoc WHERE codtid = @codtid LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codtid", vcodtid);
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
        public Clases._TIPDOC BuscarTipo(string vtiptid)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPDOC usr = new Clases._TIPDOC();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipdoc WHERE tiptid = @tiptid LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptid", vtiptid);
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
    }
}
