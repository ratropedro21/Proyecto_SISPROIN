using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Clases
{
    class _VACACION
    {
        Utilitarios Util = new Utilitarios();
       
        public int codvac;
        public int cedper;
        public DateTime feavac;
        public DateTime feivac;
        public DateTime fefvac;
        public string obsvac;
        public int catmov;
        public int stavac;

        public _VACACION(int vcodvac, int vcedper, DateTime vfeavac, DateTime vfeivac, DateTime vfefvac, string vobsvac, int vcatmov, int vstavac)
        {
            codvac= vcodvac;
            cedper= vcedper;
            feavac= vfeavac;
            feivac= vfeivac;
            fefvac= vfefvac;
            obsvac= vobsvac;
            catmov = vcatmov;
            stavac= vstavac;
        }

        public _VACACION(int vcodvac, int vcedper, DateTime vfeavac, DateTime vfeivac, DateTime vfefvac, string vobsvac, int vcatmov)
        {
            codvac = vcodvac;
            cedper = vcedper;
            feavac = vfeavac;
            feivac = vfeivac;
            fefvac = vfefvac;
            obsvac = vobsvac;
            catmov = vcatmov;
        }

        public _VACACION(int vcodvac,  int vstavac)
        {
            codvac = vcodvac;
            stavac = vstavac;
        }

        public _VACACION()
        {
            codvac = 0;
            cedper = 0;
            feavac = new DateTime();
            feivac = new DateTime();
            fefvac = new DateTime();
            obsvac = "";
            catmov = 0;
            stavac = 0;
        }

        public bool isVacation()
        {
            DateTime now = Util.GetDate();
            if (feivac.ToString("MMddyyyy").CompareTo(now.ToString("MMddyyyy")) <= 0 && fefvac.ToString("MMddyyyy").CompareTo(now.ToString("MMddyyyy")) >= 0 && stavac ==1)
                return true;
            return false;
        }
    }
}
