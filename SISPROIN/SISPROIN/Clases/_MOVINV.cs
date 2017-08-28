using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Clases
{
    class _MOVINV
    {
        
        public static string attr = "codmov, cedper, codpro, fecmov, tiptra, canmov, catmov, cosmov, predoc, totmov, tiptid, undunm, tiptiv, stamov, usuusu";
        public static _MOVINV ByDr(NpgsqlDataReader Dr)
        {
            return new _MOVINV(Dr.GetInt32(0), Dr.GetInt32(1), Dr.GetInt32(2), Dr.GetDateTime(3), Dr.GetString(4), Dr.GetDecimal(5), Dr.GetInt32(6), Dr.GetDecimal(7), Dr.GetDecimal(8), Dr.GetDecimal(9), Dr.GetString(10), Dr.GetString(11), Dr.GetString(12), Dr.GetInt32(13), Dr.GetString(14));
        }
        public int codmov;
        public DateTime fecmov;
        public string tiptra;
        public string commov;
        public string dotmov;
        public int stamov;

        public int cedper;
        public int codpro;
        public decimal canmov;
        public int catmov;
        public decimal cosmov;
        public decimal predoc;
        public decimal totmov;
        public string tiptid;
        public string undunm;
        public string tiptiv;
        public string usuusu;
       

        public _MOVINV(int vcodmov, DateTime vfecmov, string vtiptra, string vcommov, string vdotmov, int vstamov)
        {
            codmov = vcodmov;
            fecmov = vfecmov;
            tiptra = vtiptra;
            commov = vcommov;
            dotmov = vdotmov;
            stamov = vstamov;
        }

        public _MOVINV(int vcodmov, int vcedper, int vcodpro, DateTime vfecmov, string vtiptra, decimal vcanmov, int vcatmov,
            decimal vcosmov, decimal vpredoc, decimal vtotmov, string vtiptid, string vundunm, string vtiptiv, int vstamov, string vusuusu)
        {
            codmov = vcodmov;
            cedper = vcedper;
            codpro = vcodpro;
            fecmov = vfecmov;
            tiptra = vtiptra;
            canmov = vcanmov;
            catmov = vcatmov;
            cosmov = vcosmov;
            predoc = vpredoc;
            totmov = vtotmov;
            tiptid = vtiptid;
            undunm = vundunm;
            tiptiv = vtiptiv;
            stamov = vstamov;
            usuusu = vusuusu;
        }

        //Anular Movimiento
        public _MOVINV(int vcodmov, int vstamov)
        {
            codmov = vcodmov;
            stamov = vstamov;
        }

        public _MOVINV(int vcodmov, int vstamov, string vusuusu)
        {
            codmov = vcodmov;
            stamov = vstamov;
            usuusu = vusuusu;
        }
        //

        public _MOVINV()
        {
            codmov = 0;
            fecmov = new DateTime();
            tiptra = "";
            commov = "";
            dotmov = "";
            stamov = 0;

            cedper = 0;
            codpro = 0;
            canmov = Convert.ToDecimal("0,00");
            catmov = 0;
            cosmov = Convert.ToDecimal("0,00");
            predoc = Convert.ToDecimal("0,00");
            totmov = Convert.ToDecimal("0,00");
            tiptid = "";
            undunm = "";
            tiptiv = "";
        }
        //public bool isBirthday()
        //{
        //    if (fecmov.ToString("MM").CompareTo(Util.GetDate().ToString("MM")) <= 0)
        //        return true;
        //    return false;
        //}
    }
}
