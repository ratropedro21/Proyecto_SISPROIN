using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Clases
{
    class _TIPTRAN
    {
        public int codtra;
        public string tiptra;
        public string destra;
        public int statra;
        public int [] codpro;

        public _TIPTRAN(int vcodtra, string vtiptra, string vdestra, int vstatra, int[] vcodpro)
        {
            codtra = vcodtra;
            tiptra = vtiptra;
            destra = vdestra;
            statra = vstatra;
            codpro = vcodpro;
        }
        public _TIPTRAN()
        {
            codtra = 0;
            tiptra = "";
            destra = "";
            statra = 0;
            codpro= new  int[] {};                
            
        }

    }
}
