using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISPROIN.Clases;

namespace SISPROIN.Funciones
{
    class Fun_PERSONAL
    {
        Clases.ConectarDB dbSQLConn = new Clases.ConectarDB();
        public static string Elementos = " cedper, nomper, apeper, nacper, fenper, coddpt, codgco, feiper, feeper, retper, staper ";
        public static Clases._PERSONAL LLenar(NpgsqlDataReader Dr)
        {
            return new Clases._PERSONAL(Dr.GetInt32(0), Dr.GetString(1), Dr.GetString(2), Dr.GetString(3), Dr.GetDateTime(4), Dr.GetInt32(5),Dr.GetInt32(6), Dr.GetDateTime(7), Dr.GetDateTime(8), Dr.GetInt32(9), Dr.GetInt32(10));
        }

        public string Correlativo()
        {
            string R = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT cedper FROM personal ORDER BY cedper DESC LIMIT 1";
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

        public Clases._PERSONAL BuscarUltimo()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._PERSONAL usr = new Clases._PERSONAL();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM personal ORDER BY cedper DESC LIMIT 1";
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
        public Clases._PERSONAL BuscarPrimero()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._PERSONAL usr = new Clases._PERSONAL();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM personal ORDER BY cedper ASC LIMIT 1 ";
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
        public Clases._PERSONAL BuscarAnterior(Clases._PERSONAL PER)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._PERSONAL usr = new Clases._PERSONAL();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM personal WHERE cedper < @cedper ORDER BY cedper DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@cedper", PER.cedper);
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
        public Clases._PERSONAL BuscarSiguiente(Clases._PERSONAL PER)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._PERSONAL usr = new Clases._PERSONAL();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM personal WHERE cedper > @cedper ORDER BY cedper ASC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@cedper", PER.cedper);
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

        public Boolean Nuevo(_PERSONAL clas)
        {
            if (!Existe(clas.cedper))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO personal (cedper, nomper, apeper, nacper, fenper, coddpt, codgco, feiper, feeper, retper, staper) "
                    + "VALUES (@cedper, @nomper, @apeper, @nacper,  @fenper, @coddpt, @codgco, @feiper, @feeper, @retper, @staper)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@cedper", clas.cedper);
                cmd.Parameters.AddWithValue("@nomper", clas.nomper);
                cmd.Parameters.AddWithValue("@apeper", clas.apeper);
                cmd.Parameters.AddWithValue("@nacper", clas.nacper);
                cmd.Parameters.AddWithValue("@fenper", clas.fenper);
                cmd.Parameters.AddWithValue("@coddpt", clas.coddpt);
                cmd.Parameters.AddWithValue("@codgco", clas.codgco);
                cmd.Parameters.AddWithValue("@feiper", clas.feiper);
                cmd.Parameters.AddWithValue("@feeper", clas.feeper);
                cmd.Parameters.AddWithValue("@retper", clas.retper);
                cmd.Parameters.AddWithValue("@staper", clas.staper);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Modificar(_PERSONAL clas)
        {
            if (Existe(clas.cedper))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE personal SET cedper = @cedper, nomper = @nomper, apeper = @apeper, nacper = @nacper, fenper = @fenper, coddpt = @coddpt, codgco = @codgco, feiper = @feiper, feeper = @feeper, retper = @retper, staper = @staper "
                    + "WHERE cedper = @cedper";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@cedper", clas.cedper);
                cmd.Parameters.AddWithValue("@nomper", clas.nomper);
                cmd.Parameters.AddWithValue("@apeper", clas.apeper);
                cmd.Parameters.AddWithValue("@nacper", clas.nacper);
                cmd.Parameters.AddWithValue("@fenper", clas.fenper);
                cmd.Parameters.AddWithValue("@coddpt", clas.coddpt);
                cmd.Parameters.AddWithValue("@codgco", clas.codgco);
                cmd.Parameters.AddWithValue("@feiper", clas.feiper);
                cmd.Parameters.AddWithValue("@feeper", clas.feeper);
                cmd.Parameters.AddWithValue("@retper", clas.retper);
                cmd.Parameters.AddWithValue("@staper", clas.staper);
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
        public Boolean Existe(int vcedper)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT cedper FROM personal WHERE cedper = @cedper";
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

        public Boolean StatudAI(int vcedper)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT cedper FROM personal WHERE cedper = @cedper AND staper = 1";
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


        public _PERSONAL Buscar(int vcedper)
        {
            dbSQLConn.ConecDb_Abrir();
            _PERSONAL usr = new _PERSONAL();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM personal WHERE cedper = @cedper LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@cedper", vcedper);
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

        public string Sent_NomPer(int vcedper)
        {
            string _ValorR = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT (PERSONAL.nomper || ' ' || PERSONAL.apeper) AS nompersonal FROM personal WHERE cedper = @cedper ORDER BY cedper ASC";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@cedper", vcedper);
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

        //public Boolean FechaCumple(int vcedper)
        //{
        //    Utilitarios Util = new Utilitarios();
        //    dbSQLConn.ConecDb_Abrir();
        //    NpgsqlDataReader Dr = null;
        //    string Sql = "SELECT fenper FROM personal WHERE cedper = @cedper ORDER BY cedper ASC";
        //    NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
        //    cmd.Parameters.AddWithValue("@cedper", vcedper);
        //    Dr = cmd.ExecuteReader();
        //    if (Dr.HasRows)
        //    {
        //        Dr.Read();
        //        if (Dr.GetDateTime(0).ToString("MMdd").CompareTo(Util.GetDate().ToString("MMdd")) <= 0)
        //        {
        //            Dr.Close();
        //            dbSQLConn.ConecDb_Close();
        //            return true;
        //        }
        //        else
        //        {
        //            Dr.Close();
        //            dbSQLConn.ConecDb_Close();
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        Dr.Close();
        //        dbSQLConn.ConecDb_Close();
        //        return false;
        //    }
        //}

        public _PERSONAL findById(int cedper)
        {
            dbSQLConn.ConecDb_Abrir();
            _PERSONAL usr = new _PERSONAL();
            NpgsqlDataReader Dr = null;
            string strSQL = $"SELECT {Elementos} FROM personal WHERE cedper = {cedper}";
            NpgsqlCommand cmd = new NpgsqlCommand(strSQL, dbSQLConn.Cnn);
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
            return null;
        }
    }
}
