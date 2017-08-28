    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Clases
{
    class _DEPARTA
    {
        public int coddpt;
        public string nomdpt;
        public int stadpt;

        public _DEPARTA(int vcoddpt, string vnomdpt, int vstadpt)
        {
            coddpt = vcoddpt;
            nomdpt = vnomdpt;
            stadpt = vstadpt;
        }
        public _DEPARTA()
        {
            coddpt = 0;
            nomdpt = "";
            stadpt = 0;
        }
    }
}
