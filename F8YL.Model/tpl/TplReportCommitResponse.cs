using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class TplReportCommitResponse : APIResponseBase
    {
        public TplReportCommit_DataInfo data { get; set; }
    }

    public class TplReportCommit_DataInfo
    {
        public string id { get; set; }
        public string hospitalid { get; set; }
        public string userid { get; set; }
        public string tplid { get; set; }
        public string remark { get; set; }
        public string ctime { get; set; }
        public string utime { get; set; }
    }
}

