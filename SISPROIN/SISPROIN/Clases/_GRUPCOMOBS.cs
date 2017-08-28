using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Clases
{
    class _GRUPCOMOBS
    {
        public int codgco;
        public string desgco;
        public int comgco;
        public int obsgco;
        public int stagco;

        public _GRUPCOMOBS(int vcodgco, string vdesgco, int vcomgco, int vobsgco, int vstagco)
        {
            codgco = vcodgco;
            desgco = vdesgco;
            comgco = vcomgco;
            obsgco = vobsgco;
            stagco = vstagco;
        }
        public _GRUPCOMOBS()
        {
            codgco = 0;
            desgco = "";
            comgco = 0;
            obsgco = 0;
            stagco = 0;
        }
    }
}
