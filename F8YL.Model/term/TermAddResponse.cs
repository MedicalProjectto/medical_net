using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class TermAddResponse : APIResponseBase
    {
        public TermEntity data { get; set; }
    }

    public class TermEntity
    {
        public string id { get; set; }
        public string cateid { get; set; }
        public string hospitalid { get; set; }
        public string userid { get; set; }
        public string name { get; set; }
        public string itype { get; set; }
        public string vtype { get; set; }
        public string editbypat { get; set; }
        public string ctime { get; set; }
        public string utime { get; set; }
    }
}
