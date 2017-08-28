using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Clases
{
    class _CONFPRINT
    {
        public string pc_pri;
        public String ip_pri;
        public String nompri;

        public _CONFPRINT(string vpc_pri, string vip_pri, string vnompri)
        {
            pc_pri = vpc_pri;
            ip_pri = vip_pri;
            nompri = vnompri;
        }
        public _CONFPRINT()
        {
            pc_pri="";
            ip_pri="";
            nompri="";
        }
    }
}
