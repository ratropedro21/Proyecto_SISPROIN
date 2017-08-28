using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SISPROIN.Clases;
using Npgsql;

namespace SISPROIN.Funciones
{
    class Fun_CONFPRINT
    {
        ConectarDB dbSQLConn = new ConectarDB();
        

        public bool LoadPC(string pc_pri)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr = null;
            string Sql = "SELECT pc_pri FROM confprint WHERE pc_pri = @pc_pri";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@pc_pri", pc_pri);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Close();
                dbSQLConn.ConecDb_Close();
                return true;
            }
            else
            {
                dr.Close();
                dbSQLConn.ConecDb_Close();
                return false;
            }

        }

        public string LoadPRINT(string pc_pri, string ip_pri)
        {
            string _ValorR = "";
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr = null;
            string Sql = "SELECT nompri FROM confprint WHERE pc_pri = @pc_pri AND ip_pri = @ip_pri";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@pc_pri", pc_pri);
            cmd.Parameters.AddWithValue("@ip_pri", ip_pri);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                _ValorR = dr.GetString(0);
                dr.Close();
                dbSQLConn.ConecDb_Close();
                return _ValorR;
            }
            else
            {
                dr.Close();
                dbSQLConn.ConecDb_Close();
                return "";
            }

        }
        public Boolean Nuevo(_CONFPRINT clas)
        {
                dbSQLConn.ConecDb_Abrir();
                string Sql = "INSERT INTO confprint (pc_pri, ip_pri, nompri) VALUES (@pc_pri, @ip_pri, @nompri)";
                NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
                cmd.Parameters.AddWithValue("@pc_pri", clas.pc_pri);
                cmd.Parameters.AddWithValue("@ip_pri", clas.ip_pri);
                cmd.Parameters.AddWithValue("@nompri", clas.nompri);
                cmd.ExecuteNonQuery();
                dbSQLConn.ConecDb_Close();
                return true;
        }

        public bool Eliminar(string pc_pri)
        {
            dbSQLConn.ConecDb_Abrir();
            string strSQL = "DELETE FROM confprint WHERE pc_pri = @pc_pri";
            NpgsqlCommand cmd = new NpgsqlCommand(strSQL, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@pc_pri", pc_pri);
            cmd.ExecuteNonQuery();
            dbSQLConn.ConecDb_Close();
            return true;
        }

       
        
    }
}
