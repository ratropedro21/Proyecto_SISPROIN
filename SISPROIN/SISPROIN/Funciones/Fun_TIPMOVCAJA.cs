using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Funciones
{
    class Fun_TIPMOVCAJA
    {
        Clases.ConectarDB dbSQLConn = new Clases.ConectarDB();
        string Elementos = " codtmc, tiptmc, destmc, fortmc, statmc ";
        private Clases._TIPMOVCAJA LLenar(NpgsqlDataReader Dr)
        {
            return new Clases._TIPMOVCAJA(Dr.GetInt32(0), Dr.GetString(1), Dr.GetString(2), Dr.GetString(3), Dr.GetInt32(4));
        }
        public string Correlativo()
        {
            string R = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT codtmc FROM tipmovcaj ORDER BY codtmc DESC LIMIT 1";
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
        public Clases._TIPMOVCAJA BuscarUltimo()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPMOVCAJA usr = new Clases._TIPMOVCAJA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipmovcaj ORDER BY codtmc DESC LIMIT 1";
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
        public Clases._TIPMOVCAJA BuscarPrimero()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPMOVCAJA usr = new Clases._TIPMOVCAJA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipmovcaj ORDER BY codtmc ASC LIMIT 1 ";
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
        public Clases._TIPMOVCAJA BuscarAnterior(Clases._TIPMOVCAJA TMC)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPMOVCAJA usr = new Clases._TIPMOVCAJA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipmovcaj WHERE codtmc < @codtmc ORDER BY codtmc DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codtmc", TMC.codtmc);
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
        public Clases._TIPMOVCAJA BuscarSiguiente(Clases._TIPMOVCAJA TMC)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPMOVCAJA usr = new Clases._TIPMOVCAJA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipmovcaj WHERE codtmc > @codtmc ORDER BY codtmc ASC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codtmc", TMC.codtmc);
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
        public Boolean Nuevo(Clases._TIPMOVCAJA TMC)
        {
            if (!Existe(TMC.tiptmc))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO tipmovcaj (codtmc, tiptmc, destmc, fortmc, statmc) "
                    + "VALUES (@codtmc, @tiptmc, @destmc, @fortmc, @statmc)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codtmc", TMC.codtmc);
                cmd.Parameters.AddWithValue("@tiptmc", TMC.tiptmc);
                cmd.Parameters.AddWithValue("@destmc", TMC.destmc);
                cmd.Parameters.AddWithValue("@fortmc", TMC.fortmc);
                cmd.Parameters.AddWithValue("@statmc", TMC.statmc);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Modificar(Clases._TIPMOVCAJA TMC)
        {
            if (Existe(TMC.tiptmc))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE tipmovcaj SET codtmc = @codtmc, tiptmc = @tiptmc, destmc = @destmc, fortmc = @fortmc, statmc = @statmc WHERE codtmc = @codtmc";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codtmc", TMC.codtmc);
                cmd.Parameters.AddWithValue("@tiptmc", TMC.tiptmc);
                cmd.Parameters.AddWithValue("@destmc", TMC.destmc);
                cmd.Parameters.AddWithValue("@fortmc", TMC.fortmc);
                cmd.Parameters.AddWithValue("@statmc", TMC.statmc);
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
        public Boolean Existe(string vtiptmc)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT tiptmc FROM tipmovcaj WHERE tiptmc = @tiptmc";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptmc", vtiptmc);
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

        public Clases._TIPMOVCAJA BuscarCod(int vcodtmc)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPMOVCAJA usr = new Clases._TIPMOVCAJA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipmovcaj WHERE codtmc = @codtmc LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codtmc", vcodtmc);
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
        public Clases._TIPMOVCAJA BuscarTipo(string vtiptmc)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._TIPMOVCAJA usr = new Clases._TIPMOVCAJA();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM tipmovcaj WHERE tiptmc = @tiptmc LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptmc", vtiptmc);
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
