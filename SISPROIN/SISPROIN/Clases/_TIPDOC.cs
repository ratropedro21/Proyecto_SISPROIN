using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPROIN.Clases
{
    class _TIPDOC
    {
        public int codtid;
        public string tiptid;
        public string destid;
        public string fortid;
        public int caltid;
        public int mivtid;
        public int statid;

        public _TIPDOC(int vcodtid, string vtiptid, string vdestid, string vfortid, int vcaltid, int vmivtid, int vstatid)
        {
            codtid = vcodtid;
            tiptid = vtiptid;
            destid = vdestid;
            fortid = vfortid;
            caltid = vcaltid;
            mivtid = vmivtid;
            statid = vstatid;
        }
        public _TIPDOC()
        {
            codtid = 0;
            tiptid = "";
            destid = "";
            fortid = "";
            caltid = 0;
            mivtid = 0;
            statid = 0;
        }
    }
}
