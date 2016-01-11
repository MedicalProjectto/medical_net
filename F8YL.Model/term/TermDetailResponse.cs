using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class TermDetailResponse : APIResponseBase
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
        public List<TermDetail_TermValInfo> term_val { get; set; }
        public TermDetail_CateInfo cate { get; set; }
    }


    public class TermDetail_TermValInfo
    {
        public string id { get; set; }
        public string termid { get; set; }
        public string val { get; set; }
        public string sorter { get; set; }
    }

    public class TermDetail_CateInfo
    {
        public string id { get; set; }
        public string name { get; set; }

    }

}
