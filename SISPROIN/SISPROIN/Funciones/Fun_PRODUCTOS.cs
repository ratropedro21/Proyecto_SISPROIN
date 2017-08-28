using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Funciones
{
    class Fun_PRODUCTOS
    {
        Clases.ConectarDB dbSQLConn = new Clases.ConectarDB();
        string Elementos = " codpro, despro, undunm, codgru, tiptiv, prepro, stapro ";
        private Clases._PRODUCTOS LLenar(NpgsqlDataReader Dr)
        {
            return new Clases._PRODUCTOS(Dr.GetInt32(0), Dr.GetString(1), Dr.GetString(2), Dr.GetInt32(3), Dr.GetString(4), Dr.GetDecimal(5), Dr.GetInt32(6));
        }
        public string Correlativo()
        {
            string R = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT codpro FROM productos ORDER BY codpro DESC LIMIT 1";
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
        public Clases._PRODUCTOS BuscarUltimo()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._PRODUCTOS usr = new Clases._PRODUCTOS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM productos ORDER BY codpro DESC LIMIT 1";
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
        public Clases._PRODUCTOS BuscarPrimero()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._PRODUCTOS usr = new Clases._PRODUCTOS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM productos ORDER BY codpro ASC LIMIT 1 ";
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
        public Clases._PRODUCTOS BuscarAnterior(Clases._PRODUCTOS clas)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._PRODUCTOS usr = new Clases._PRODUCTOS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM productos WHERE codpro < @codpro ORDER BY codpro DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codpro", clas.codpro);
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
        public Clases._PRODUCTOS BuscarSiguiente(Clases._PRODUCTOS clas)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._PRODUCTOS usr = new Clases._PRODUCTOS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM productos WHERE codpro > @codpro ORDER BY codpro ASC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codpro", clas.codpro);
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
        public Boolean Nuevo(Clases._PRODUCTOS PRO)
        {
            if (!Existe(PRO.codpro))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO productos (codpro, despro, undunm, codgru, tiptiv, prepro, stapro) "
                    + "VALUES (@codpro, @despro, @undunm, @codgru, @tiptiv, @prepro, @stapro)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codpro", PRO.codpro);
                cmd.Parameters.AddWithValue("@despro", PRO.despro);
                cmd.Parameters.AddWithValue("@undunm", PRO.undunm);
                cmd.Parameters.AddWithValue("@codgru", PRO.codgru);
                cmd.Parameters.AddWithValue("@tiptiv", PRO.tiptiv);
                cmd.Parameters.AddWithValue("@prepro", PRO.prepro);
                cmd.Parameters.AddWithValue("@stapro", PRO.stapro);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Modificar(Clases._PRODUCTOS PRO)
        {
            if (Existe(PRO.codpro))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE productos SET codpro = @codpro, despro = @despro, undunm = @undunm, codgru = @codgru, "
                    + "tiptiv = @tiptiv, prepro = @prepro, stapro = @stapro "
                    + "WHERE codpro = @codpro";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codpro", PRO.codpro);
                cmd.Parameters.AddWithValue("@despro", PRO.despro);
                cmd.Parameters.AddWithValue("@undunm", PRO.undunm);
                cmd.Parameters.AddWithValue("@codgru", PRO.codgru);
                cmd.Parameters.AddWithValue("@tiptiv", PRO.tiptiv);
                cmd.Parameters.AddWithValue("@prepro", PRO.prepro);
                cmd.Parameters.AddWithValue("@stapro", PRO.stapro);
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
        public Boolean Existe(int vcodpro)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT codpro FROM productos WHERE codpro = @codpro";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codpro", vcodpro);
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

        public Boolean StatudAI(int vcodpro)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT codpro FROM productos WHERE codpro = @codpro AND stapro = 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codpro", vcodpro);
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

        public Clases._PRODUCTOS Buscar(int vcodpro)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._PRODUCTOS usr = new Clases._PRODUCTOS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM productos WHERE codpro = @codpro LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codpro", vcodpro);
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

        public string Sent_DesPro(int vcodpro)
        {
            string _ValorR = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT despro FROM productos WHERE codpro = @codpro ORDER BY codpro Desc";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codpro", vcodpro);
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

        public string Sent_UndUnm(int vcodpro)
        {
            string _ValorR = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT undunm FROM productos WHERE codpro = @codpro ORDER BY codpro Desc";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codpro", vcodpro);
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

        public string Sent_PrePro(int vcodpro)
        {
            string _ValorR = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT prepro FROM productos WHERE codpro = @codpro ORDER BY codpro Desc";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codpro", vcodpro);
            Dr = cmd.ExecuteReader();

            if (Dr.HasRows)
            {
                Dr.Read();
                _ValorR = Dr.GetDecimal(0).ToString();
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

        public string Sent_TipIVA(int vcodpro)
        {
            string _ValorR = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT productos.tiptiv, productos.despro FROM productos INNER JOIN tipiva "
                + "ON productos.tiptiv = tipiva.tiptiv WHERE productos.codpro = @codpro";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codpro", vcodpro);
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
