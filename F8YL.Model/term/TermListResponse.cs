using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class TermListResponse : APIResponseBase
    {
        public TermListEntity data { get; set; }
    }

    public class TermListEntity
    {
        public List<TermReportEntity> data { get; set; }
        public int total { get; set; }
    }

    public class TermReportEntity
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
        public List<TermValEntity> term_val { get; set; }
        public CateEntity cate { get; set; }
    }

    public class TermValEntity
    {
        public string id { get; set; }
        public string termid { get; set; }
        public string val { get; set; }
        public string sorter { get; set; }
    }

    public class CateEntity
    {
        public string id { get; set; }
        public string name { get; set; }
    }

}
