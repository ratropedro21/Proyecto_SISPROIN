using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Clases
{
    class _TIPMOVCAJA
    {
        public int codtmc;
        public string tiptmc;
        public string destmc;
        public string fortmc;
        public int statmc;

        public _TIPMOVCAJA(int vcodtmc, string vtiptmc, string vdestmc, string vfortmc, int vstatmc)
        {
            codtmc = vcodtmc;
            tiptmc = vtiptmc;
            destmc = vdestmc;
            fortmc = vfortmc;
            statmc = vstatmc;
        }
        public _TIPMOVCAJA()
        {
            codtmc = 0;
            tiptmc = "";
            destmc = "";
            fortmc = "";
            statmc = 0;
        }
    }
}
