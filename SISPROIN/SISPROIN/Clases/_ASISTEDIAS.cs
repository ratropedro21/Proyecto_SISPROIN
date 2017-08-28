using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Clases
{
    class _ASISTEDIAS
    {

        public int codasd;
        public DateTime fecasd;
        public int staasd;
       
        public int cedper;
        public string comasd;

        public _ASISTEDIAS(int vcodasd, DateTime vfecasd, int vstaasd)
        {
            codasd = vcodasd;
            fecasd = vfecasd;
            staasd = vstaasd;
        }

        public _ASISTEDIAS(int vcodasd, int vstaasd)
        {
            codasd = vcodasd;
            staasd = vstaasd;
        }

        public _ASISTEDIAS(int vcodasd, int vcedper, string vcomasd, DateTime vfecasd)
        {
            codasd = vcodasd;
            cedper = vcedper;
            comasd = vcomasd;
            fecasd = vfecasd;
        }

        public _ASISTEDIAS(int vcodasd, int vcedper, string vcomasd)
        {
            codasd = vcodasd;
            cedper = vcedper;
            comasd = vcomasd;
           
        }


        public _ASISTEDIAS()
        {
            codasd = 0;
            fecasd = new DateTime();
            staasd = 0;

           
            cedper = 0;
            comasd = "";
           
        }


    }
}
