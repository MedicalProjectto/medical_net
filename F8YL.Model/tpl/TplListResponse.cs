using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class TplListResponse : APIResponseBase
    {
        public TplInfo data { get; set; }
    }

    public class TplInfo
    {
        public List<TplListInfo> data { get; set; }
        public int total { get; set; }
    }

    public class TplListInfo
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
        public List<TplListDetailInfo> tpl_detail { get; set; }
    }

    public class TplListDetailInfo
    {
        public string id { get; set; }
        public string tplid { get; set; }
        public string sharpid { get; set; }
        public string termid { get; set; }
        public string sorter { get; set; }
    }

}
