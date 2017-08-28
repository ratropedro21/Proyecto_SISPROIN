using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Clases
{
    public class _PRODUCTOS
    {
        public int codpro;
        public string despro;
        public string undunm;
        public int codgru;
        public string tiptiv;
        public decimal prepro;
        public int stapro;

        public _PRODUCTOS(int vcodpro, string vdespro, string vundunm, int vcodgru, string vtiptiv, decimal vprepro, int vstapro)
        {
            codpro = vcodpro;
            despro = vdespro;
            undunm = vundunm;
            codgru = vcodgru;
            tiptiv = vtiptiv;
            prepro = vprepro;
            stapro = vstapro;
        }
        public _PRODUCTOS()
        {
            codpro = 0;
            despro = "";
            undunm = "";
            codgru = 0;
            tiptiv = "";
            prepro = Convert.ToDecimal("0,00");
            stapro = 0;
        }
        public static _PRODUCTOS[] getAll(string where = "",string  order = "codpro")
        {
            List<_PRODUCTOS> producto = new List<_PRODUCTOS>();
            ConectarDB dbSQLConn = new Clases.ConectarDB();            
            dbSQLConn.ConecDb_Abrir();
            NpgsqlDataReader Dr = null;
            string strSQL = $"SELECT codpro,despro,undunm,codgru,tiptiv,prepro,stapro FROM productos {(where!=""?$"WHERE {where}":"")}{(where != "" ? $"WHERE {where}" : "")} {(order != "" ? $"ORDER BY {order}" : "")}";
            NpgsqlCommand cmd = new NpgsqlCommand(strSQL, dbSQLConn.Cnn);
            Dr = cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                while (Dr.Read())
                {
                    producto.Add(new _PRODUCTOS(Dr.GetInt32(0), Dr.GetString(1), Dr.GetString(2), Dr.GetInt32(3), Dr.GetString(4), Dr.GetDecimal(5), Dr.GetInt32(6)));
                }
            }          
            return producto.ToArray();
        }
    }
}
