using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Funciones
{
    class Fun_Control_Acceso
    {
        Clases.ConectarDB dbSQLConn = new Clases.ConectarDB();
        public bool Validar_Nivel_0(string[] TUsuario)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr = null;
            string Sql = "SELECT usuusu FROM modulos WHERE usuusu = @usuusu AND id_nivel0 = @id_nivel0::integer AND permiso < 5 LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@usuusu", TUsuario[0]);
            cmd.Parameters.AddWithValue("@id_nivel0", TUsuario[3]);
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
        public int Validar_Nivel_2(string[] TUsuario)
        {
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader dr2 = null;
            string Sql = "SELECT permiso FROM modulos WHERE usuusu = @usuusu AND id_nivel0 = @id_nivel0::integer AND Id_nivel1 = @id_nivel1::integer AND id_nivel2 = @id_nivel2::integer LIMIT 1";
            NpgsqlCommand cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@usuusu", TUsuario[0]);
            cmd.Parameters.AddWithValue("@id_nivel0", TUsuario[3]);
            cmd.Parameters.AddWithValue("@id_nivel1", TUsuario[4]);
            cmd.Parameters.AddWithValue("@id_nivel2", TUsuario[5]);
            dr2 = cmd.ExecuteReader();
            if (dr2.HasRows)
            {
                dr2.Read();
                int Valor = dr2.GetInt32(0);
                dr2.Close();
                dbSQLConn.ConecDb_Close();
                return Valor;
            }
            else
            {
                dr2.Close();
                dbSQLConn.ConecDb_Close();
                return 5;
            }
        }
    }
}
