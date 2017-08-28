using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Clases
{
    public class _VENOBSDOC
    {
        public int codmov;
        public int cedper;
        public DateTime fecdoc;
        public decimal netdoc;
        public decimal brudoc; 
        public decimal mtidoc;
        public int codrec;
        public string tiptid;
        public int cxcdoc;
        public string estdoc;
        public string condoc;
        public int stadoc;
        public string comdoc;

        public _VENOBSDOC(int vcodmov, int vcedper, DateTime vfecdoc, decimal vnetdoc, decimal vbrudoc, decimal vmtidoc, 
            int vcodrec, string vtiptid, int vcxcdoc, string vestdoc, string vcondoc, int vstadoc, string vcomdoc)
        {
            codmov = vcodmov;
            cedper = vcedper;
            fecdoc = vfecdoc;
            netdoc = vnetdoc;
            brudoc = vbrudoc;
            mtidoc = vmtidoc;
            codrec = vcodrec;
            tiptid = vtiptid;
            cxcdoc = vcxcdoc;
            estdoc = vestdoc;
            condoc = vcondoc;
            stadoc = vstadoc;
            comdoc = vcomdoc;
        }

        //Anular OBSEQUIO
        public _VENOBSDOC(int vcodmov, int vcedper, int vcodrec, string vtiptid, int vstadoc)
        {
            codmov = vcodmov;
            cedper = vcedper;
            codrec = vcodrec;
            tiptid = vtiptid;
            stadoc = vstadoc;
        }
        //

        public _VENOBSDOC()
        {
            codmov = 0;
            cedper = 0;
            fecdoc = new DateTime(); 
            netdoc = Convert.ToDecimal("0,00"); 
            brudoc = Convert.ToDecimal("0,00");
            mtidoc = Convert.ToDecimal("0,00");
            codrec = 0;
            tiptid = "";
            cxcdoc = 0;
            estdoc = "";
            condoc = "";
            stadoc = 0;
            comdoc = "";
        }
    }
}
