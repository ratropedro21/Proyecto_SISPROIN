using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Clases
{
    
    class _PERSONAL
    {
        Utilitarios Util = new Utilitarios();
        public int cedper;
        public string nomper;
        public string apeper;
        public string nacper;
        public DateTime fenper;
        public int coddpt;
        public int codgco;
        public DateTime feiper;
        public DateTime feeper;
        public int retper;
        public int staper;

        public _PERSONAL(int vcedper, string vnomper, string vapeper, string vnacper, DateTime vfenper, int vcoddpt, int vcodgco, DateTime vfeiper, DateTime vfeeper, int vretper, int vstaper)
        {
            cedper = vcedper;
            nomper = vnomper;
            apeper = vapeper;
            nacper = vnacper;
            fenper = vfenper;
            coddpt = vcoddpt;
            codgco = vcodgco;
            feiper = vfeiper;
            feeper = vfeeper;
            retper = vretper;
            staper = vstaper;
        }

        public _PERSONAL()
        {
            cedper = 0;
            nomper = "";
            apeper = "";
            nacper = "";
            fenper = new DateTime();
            coddpt = 0;
            codgco = 0;
            feiper = new DateTime();
            feeper = new DateTime();
            retper = 0;
            staper = 0;
        }
        public bool isBirthday()
        {
            if (fenper.ToString("MMdd").CompareTo(Util.GetDate().ToString("MMdd")) <= 0)
                return true;
            return false;
        }

        public static _PERSONAL[] GetAll(string where = "", string order = "cedper")
        {
            List<_PERSONAL> items = new List<_PERSONAL>();
            ConectarDB dbSQLConn = new ConectarDB();
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string strSQL = $"SELECT {Funciones.Fun_PERSONAL.Elementos} FROM personal {(where != "" ? $"WHERE {where}" : "")}{(where != "" ? $"WHERE {where}" : "")} {(order != "" ? $"ORDER BY {order}" : "")}";
            NpgsqlCommand cmd = new NpgsqlCommand(strSQL, dbSQLConn.Cnn);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                while (Dr.Read())
                {
                    items.Add(Funciones.Fun_PERSONAL.LLenar(Dr));
                }
                Dr.Close();
            }
            dbSQLConn.ConecDb_Close();
            return items.ToArray();
        }
    }
}
