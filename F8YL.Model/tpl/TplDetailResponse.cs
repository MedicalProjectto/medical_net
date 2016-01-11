using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class TplDetailResponse : APIResponseBase
    {
        public TplDetailInfo data { get; set; }
    }

    //public class TplDetailInfoList
    //{
    //    public List<TplDetailInfo> data { get; set; }

    //    public int total { get; set; }
    //}

    public class TplDetailInfo
    {
        public string _id;
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
        public List<TplDetail_DetailInfo> tpl_detail { get; set; }
        public List<TplDetailPeriodsInfo> periods { get; set; }
        public Dictionary<string, TplDetailSharpInfo> sharp { get; set; }

    }


    public class TplDetail_DetailInfo
    {
        public string id { get; set; }
        public string tplid { get; set; }
        public string sharpid { get; set; }
        public string sharpid2 { get; set; }
        public string termid { get; set; }
        public string editbypat { get; set; }
        public string sorter { get; set; }
        public TplDetail_DetailTermInfo term { get; set; }

    }

    public class TplDetail_DetailTermInfo
    {
        public string id { get; set; }
        public string cateid { get; set; }
        public string hospitalid { get; set; }
        public string userid { get; set; }
        public string name { get; set; }
        public string itype { get; set; }
        public string vtype { get; set; }
        public string unit { get; set; }
        public string editbypat { get; set; }
        public List<TplDetail_DetailTermValInfo> term_val { get; set; }
    }

    public class TplDetail_DetailTermValInfo
    {
        public string id { get; set; }
        public string termid { get; set; }
        public string val { get; set; }
        public string desc { get; set; }
        public string sorter { get; set; }
    }

    public class TplDetailSharpInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string parentid { get; set; }
    }

    public class TplDetailPeriodsInfo
    {
        public string id { get; set; }
        public string tplid { get; set; }
        public string periodname { get; set; }
    }

}
