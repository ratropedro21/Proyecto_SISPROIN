using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Funciones
{
    class Fun_USUARIOS
    {
        Clases.Utilitarios Util = new Clases.Utilitarios();
        public Boolean ValidarLogin(ref Clases._USUARIOS USU)
        {
            Clases.ConectarDB dbSQLConn = new Clases.ConectarDB();
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            NpgsqlCommand cmd;
            string Sql;
            Sql = "SELECT idusu, nomusu, coddpt, stausu FROM usuarios WHERE usuusu = @usuusu AND clausu = @clausu";
            cmd = new NpgsqlCommand(Sql, dbSQLConn.Cnn);
            cmd.Parameters.AddWithValue("@usuusu", USU.usuusu);
            //cmd.Parameters.AddWithValue("@clausu", USU.clausu);
            cmd.Parameters.AddWithValue("@clausu", Util.GetMd5Hash(USU.clausu));
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Read();
                USU.idusu = Dr.GetInt32(0);
                USU.nomusu = Dr.GetString(1);
                USU.coddpt = Dr.GetInt32(2);
                USU.stausu = Dr.GetInt32(3);
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
