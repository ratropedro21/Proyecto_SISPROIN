using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Funciones
{
    class Fun_AGREGARUSU
    {
        Clases.Utilitarios Util = new Clases.Utilitarios();
        Clases.ConectarDB dbSQLConn = new Clases.ConectarDB();
        string Elementos = " idusu, usuusu, clausu, nomusu, coddpt, stausu ";
        private Clases._USUARIOS LLenarUsuario(NpgsqlDataReader Dr)
        {
            return new Clases._USUARIOS(Dr.GetString(1), Dr.GetString(2), Dr.GetString(3), Dr.GetInt32(4), Dr.GetInt32(5));
        }
        public Clases._USUARIOS BuscarUltimo()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._USUARIOS usr = new Clases._USUARIOS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM usuarios ORDER BY usuusu DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenarUsuario(Dr);
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
        public Clases._USUARIOS BuscarPrimero()
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._USUARIOS usr = new Clases._USUARIOS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM usuarios ORDER BY usuusu ASC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);

            Dr = cmd.ExecuteReader();

            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenarUsuario(Dr);
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
        public Clases._USUARIOS BuscarAnterior(Clases._USUARIOS USU)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._USUARIOS usr = new Clases._USUARIOS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM usuarios WHERE usuusu < @usuusu ORDER BY usuusu DESC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@usuusu", USU.usuusu);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenarUsuario(Dr);
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
        public Clases._USUARIOS BuscarSiguiente(Clases._USUARIOS USU)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._USUARIOS usr = new Clases._USUARIOS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM usuarios WHERE usuusu > @usuusu ORDER BY usuusu ASC LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@usuusu", USU.usuusu);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenarUsuario(Dr);
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
        public Boolean Nuevo(Clases._USUARIOS USU)
        {
            if (!Existe(USU.usuusu))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO usuarios (usuusu, clausu, nomusu, coddpt, stausu) VALUES (@usuusu, @clausu, @nomusu, @coddpt, @stausu)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@usuusu", USU.usuusu);
                cmd.Parameters.AddWithValue("@clausu", Util.GetMd5Hash(USU.clausu));
                cmd.Parameters.AddWithValue("@nomusu", USU.nomusu);
                cmd.Parameters.AddWithValue("@coddpt", USU.coddpt);
                cmd.Parameters.AddWithValue("@StaUsu", USU.stausu);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean Modificar(Clases._USUARIOS USU)
        {
            if (Existe(USU.usuusu))
            {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "UPDATE usuarios SET usuusu = @usuusu, clausu = @clausu, nomusu = @nomusu, coddpt = @coddpt, stausu = @stausu WHERE usuusu = @usuusu";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@usuusu", USU.usuusu);
                cmd.Parameters.AddWithValue("@clausu", Util.GetMd5Hash(USU.clausu));
                cmd.Parameters.AddWithValue("@NomUsu", USU.nomusu);
                cmd.Parameters.AddWithValue("@coddpt", USU.coddpt);
                cmd.Parameters.AddWithValue("@stausu", USU.stausu);
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
        public Boolean Existe(string vusuusu)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT usuusu FROM usuarios WHERE usuusu = @usuusu";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@usuusu", vusuusu);
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

        public Clases._USUARIOS Buscar(string vusuusu)
        {
            dbSQLConn.ConecDb_Abrir();
            Clases._USUARIOS usr = new Clases._USUARIOS();
            NpgsqlDataReader Dr = null;
            string Sql = "SELECT " + Elementos + " FROM usuarios WHERE usuusu = @usuusu LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@usuusu", vusuusu);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                usr = LLenarUsuario(Dr);
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
        public string Sent_NomUsu(string vusuusu)
        {
            string _ValorR = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT nomusu FROM usuarios WHERE usuusu = @usuusu ORDER BY usuusu Desc";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@usuusu", vusuusu);
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
