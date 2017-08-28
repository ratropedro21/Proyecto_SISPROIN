using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Clases
{
    class _GRUPOINV
    {
        public int codgru;
        public string desgru;
        public int stagru;

        public _GRUPOINV(int vcodgru, string vdesgru, int vstagru)
        {
            codgru = vcodgru;
            desgru = vdesgru;
            stagru = vstagru;
        }
        public _GRUPOINV()
        {
            codgru = 0;
            desgru = "";
            stagru = 0;
        }
    }
}
