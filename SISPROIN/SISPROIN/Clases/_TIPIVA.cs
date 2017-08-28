using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Clases
{
    class _TIPIVA
    {
        public int codtiv;
        public string tiptiv;
        public string destiv;
        public int stativ;

        public _TIPIVA(int vcodtiv, string vtiptiv, string vdestiv, int vstativ)
        {
            codtiv = vcodtiv;
            tiptiv = vtiptiv;
            destiv = vdestiv;
            stativ = vstativ;
        }
        public _TIPIVA()
        {
            codtiv = 0;
            tiptiv = "";
            destiv = "";
            stativ = 0;
        }
    }
}
