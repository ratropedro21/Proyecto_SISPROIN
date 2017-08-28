using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISPROIN.Clases;

namespace SISPROIN.Funciones
{
    class Fun_VACACION
    {
        ConectarDB dbSQLConn = new ConectarDB();
        string Elementos = " codvac, cedper, feavac, feivac, fefvac, obsvac, catmov, stavac ";
        private _VACACION LLenar(NpgsqlDataReader Dr)
        {
            return new _VACACION(Dr.GetInt32(0), Dr.GetInt32(1),  Dr.GetDateTime(2), Dr.GetDateTime(3), Dr.GetDateTime(4), Dr.GetString(5), Dr.GetInt32(6), Dr.GetInt32(7));
        }
        public string Correlativo()
        {
            string R = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT codvac FROM vacacion ORDER BY codvac DESC LIMIT 1";
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

        public _VACACION BuscarUltimo()
        {
            dbSQLConn.ConecDb_Abrir();
            _VACACION usr = new _VACACION();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM vacacion ORDER BY codvac DESC LIMIT 1";
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

        public _VACACION BuscarPrimero()
        {
            dbSQLConn.ConecDb_Abrir();
            _VACACION usr = new _VACACION();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM vacacion ORDER BY codvac ASC LIMIT 1 ";
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
        public _VACACION BuscarAnterior(_VACACION clas)
        {
            dbSQLConn.ConecDb_Abrir();
            _VACACION usr = new _VACACION();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM vacacion WHERE codvac < @codvac ORDER BY codvac DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codvac", clas.codvac);
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
        public _VACACION BuscarSiguiente(_VACACION clas)
        {
            dbSQLConn.ConecDb_Abrir();
            _VACACION usr = new _VACACION();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM vacacion WHERE codvac > @codvac ORDER BY codvac ASC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codvac", clas.codvac);
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

        public Boolean Nuevo(_VACACION clas)
        {
            if (!Existe(clas.codvac))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO vacacion (codvac, cedper, feavac, feivac, fefvac, obsvac, catmov, stavac) "
                    + "VALUES (@codvac, @cedper, @feavac, @feivac, @fefvac, @obsvac, @catmov, @stavac)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codvac", clas.codvac);
                cmd.Parameters.AddWithValue("@cedper", clas.cedper);
                cmd.Parameters.AddWithValue("@feavac", clas.feavac);
                cmd.Parameters.AddWithValue("@feivac", clas.feivac);
                cmd.Parameters.AddWithValue("@fefvac", clas.fefvac);
                cmd.Parameters.AddWithValue("@obsvac", clas.obsvac);
                cmd.Parameters.AddWithValue("@catmov", clas.catmov);
                cmd.Parameters.AddWithValue("@stavac", clas.stavac);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Modificar(_VACACION clas)
        {
            if (Existe(clas.codvac))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE vacacion SET codvac = @codvac, cedper = @cedper, feavac = @feavac, feivac = @feivac, fefvac = @fefvac, obsvac = @obsvac, catmov = @catmov "
                    + "WHERE codvac = @codvac";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codvac", clas.codvac);
                cmd.Parameters.AddWithValue("@cedper", clas.cedper);
                cmd.Parameters.AddWithValue("@feavac", clas.feavac);
                cmd.Parameters.AddWithValue("@feivac", clas.feivac);
                cmd.Parameters.AddWithValue("@fefvac", clas.fefvac);
                cmd.Parameters.AddWithValue("@obsvac", clas.obsvac);
                cmd.Parameters.AddWithValue("@catmov", clas.catmov);
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

        public Boolean Anular(_VACACION clas)
        {
            if (Existe(clas.codvac))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE vacacion SET codvac = @codvac, stavac = @stavac  WHERE codvac = @codvac ";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@codvac", clas.codvac);
                cmd.Parameters.AddWithValue("@stavac", clas.stavac);
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

        public Boolean Existe(int vcodigo)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT codvac FROM vacacion WHERE codvac = @codvac";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codvac", vcodigo);
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

        public _VACACION Buscar(int vcodvac)
        {
            dbSQLConn.ConecDb_Abrir();
            _VACACION usr = new _VACACION();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM vacacion WHERE codvac = @codvac LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@codvac", vcodvac);
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

        public _VACACION IsVacationAct(int vcodigo, DateTime From, DateTime To)
        {
            dbSQLConn.ConecDb_Abrir();
            _VACACION usr = new _VACACION();
            NpgsqlDataReader Dr = null;
            string Sql = $"SELECT { Elementos } FROM vacacion " +
                $"WHERE cedper = @cedper AND feavac::DATE <= @From::DATE AND fefvac::DATE >= @To::DATE AND stavac = 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@cedper", vcodigo);
            cmd.Parameters.AddWithValue("@From", From);
            cmd.Parameters.AddWithValue("@To", To);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenar(Dr);
                Dr.Close();
                dbSQLConn.ConecDb_Close();
                return usr;
            }
            Dr.Close();
            dbSQLConn.ConecDb_Close();
            return usr;
        }

        public Boolean ExisteProdTras(string tiptra, int vcodigo)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT tiptra FROM public.tiptransa WHERE tiptra = @tiptra AND codpro @> ARRAY[@vcodigo] AND statra = 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@tiptra", tiptra);
            cmd.Parameters.AddWithValue("@vcodigo", vcodigo);
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

        public string Sent_Valor(int vcodigo, DateTime From, DateTime To)
        {
            string _ValorR = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT  catmov FROM vacacion " +
                "WHERE cedper = @cedper AND feavac::DATE <= @From::DATE AND fefvac::DATE >= @To::DATE AND stavac = 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@cedper", vcodigo);
            cmd.Parameters.AddWithValue("@From", From);
            cmd.Parameters.AddWithValue("@To", To);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                _ValorR = Dr.GetInt32(0).ToString();
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
