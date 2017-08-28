using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Clases
{
    class _UNIDMEDIA
    {
        public int codunm;
        public string undunm;
        public string desunm;
        public int staunm;

        public _UNIDMEDIA(int vcodunm, string vundunm, string vdesunm, int vstaunm)
        {
            codunm = vcodunm;
            undunm = vundunm;
            desunm = vdesunm;
            staunm = vstaunm;
        }
        public _UNIDMEDIA()
        {
            codunm = 0;
            undunm = "";
            desunm = "";
            staunm = 0;

        }
    }
}
