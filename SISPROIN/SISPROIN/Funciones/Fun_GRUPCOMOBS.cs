using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Funciones
{
    class Fun_GRUPCOMOBS
    {
        Clases.ConectarDB dbSQLConn = new Clases.ConectarDB();
        string Elementos = " codgco, desgco, comgco, obsgco, stagco ";
        private Clases._GRUPCOMOBS LLenar(NpgsqlDataReader Dr)
        {
            return new Clases._GRUPCOMOBS(Dr.GetInt32(0), Dr.GetString(1), Dr.GetInt32(2), Dr.GetInt32(3), Dr.GetInt32(4));
        }

        public string Correlativo()
        {
            string R = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT codgco FROM grupcomobs ORDER BY codgco DESC LIMIT 1";
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

        public Clases._GRUPCOMOBS BuscarUltimo()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._GRUPCOMOBS usr = new Clases._GRUPCOMOBS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM grupcomobs ORDER BY codgco DESC LIMIT 1";
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
        public Clases._GRUPCOMOBS BuscarPrimero()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._GRUPCOMOBS usr = new Clases._GRUPCOMOBS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM grupcomobs ORDER BY codgco ASC LIMIT 1 ";
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
        public Clases._GRUPCOMOBS BuscarAnterior(Clases._GRUPCOMOBS clas)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._GRUPCOMOBS usr = new Clases._GRUPCOMOBS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM grupcomobs WHERE codgco < @codgco ORDER BY codgco DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codgco", clas.codgco);
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
        public Clases._GRUPCOMOBS BuscarSiguiente(Clases._GRUPCOMOBS clas)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._GRUPCOMOBS usr = new Clases._GRUPCOMOBS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM grupcomobs WHERE codgco > @codgco ORDER BY codgco ASC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codgco", clas.codgco);
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
        public Boolean Nuevo(Clases._GRUPCOMOBS clas)
        {
            if (!Existe(clas.codgco))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO grupcomobs (codgco, desgco, comgco, obsgco, stagco) VALUES (@codgco, @desgco, @comgco, @obsgco, @stagco)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codgco", clas.codgco);
                cmd.Parameters.AddWithValue("@desgco", clas.desgco);
                cmd.Parameters.AddWithValue("@comgco", clas.comgco);
                cmd.Parameters.AddWithValue("@obsgco", clas.obsgco);
                cmd.Parameters.AddWithValue("@stagco", clas.stagco);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Modificar(Clases._GRUPCOMOBS clas)
        {
            if (Existe(clas.codgco))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE grupcomobs SET codgco = @codgco, desgco = @desgco, comgco = @comgco, obsgco = @obsgco, stagco = @stagco WHERE codgco = @codgco";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codgco", clas.codgco);
                cmd.Parameters.AddWithValue("@desgco", clas.desgco);
                cmd.Parameters.AddWithValue("@comgco", clas.comgco);
                cmd.Parameters.AddWithValue("@obsgco", clas.obsgco);
                cmd.Parameters.AddWithValue("@stagco", clas.stagco);
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
        public Boolean Existe(int vcodgco)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT codgco FROM grupcomobs WHERE codgco = @codgco";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codgco", vcodgco);
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

        public Boolean StatusAI(int vcodgco)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT codgco FROM grupcomobs WHERE codgco = @codgco AND stagco = 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codgco", vcodgco);
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

        public Clases._GRUPCOMOBS Buscar(int vcodgco)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._GRUPCOMOBS usr = new Clases._GRUPCOMOBS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM grupcomobs WHERE codgco = @codgco LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codgco", vcodgco);
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

        public string Sent_DesGco(int vcodgco)
        {
            string _ValorR = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT desgco FROM grupcomobs WHERE codgco = @codgco ORDER BY codgco Desc";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codgco", vcodgco);
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

        public Boolean GrupoOBSEQUIO(int vcedper)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT PERSONAL.cedper " +
                "FROM PERSONAL INNER JOIN GRUPCOMOBS ON PERSONAL.codgco = GRUPCOMOBS.codgco " +
                "WHERE PERSONAL.cedper = @cedper AND GRUPCOMOBS.obsgco = 1 ";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@cedper", vcedper);
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
    }
}
