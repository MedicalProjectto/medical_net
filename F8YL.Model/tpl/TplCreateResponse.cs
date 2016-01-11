using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class TplCreateResponse : APIResponseBase
    {
        public TplBasicInfo data { get; set; }
    }

    public class TplBasicInfo
    {
        public string id { get; set; }
        public string userid { get; set; }
        public string hospitalid { get; set; }
        public string name { get; set; }
        public string period { get; set; }
        public string freqs { get; set; }
        public string kindid { get; set; }
        public string editbypat { get; set; }
        public string remark { get; set; }
        public string ctime { get; set; }
        public string utime { get; set; }
    }
}
