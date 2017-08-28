using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Clases
{
    public class _USUARIOS
    {
        public int idusu;
        public String usuusu;
        public String clausu;
        public String nomusu;
        public int coddpt;
        public int stausu;

        public _USUARIOS(string vusuusu, string vclausu, string vnomusu, int vcoddpt, int vstausu)
        {
            usuusu = vusuusu;
            clausu = vclausu;
            nomusu = vnomusu;
            coddpt = vcoddpt;
            stausu = vstausu;
        }
        public _USUARIOS(string vusuusu, string vclausu)
        {
            usuusu = vusuusu;
            clausu = vclausu;
            idusu = 0;
        }
        public _USUARIOS()
        {
            idusu = 0;
        }
    }
}
