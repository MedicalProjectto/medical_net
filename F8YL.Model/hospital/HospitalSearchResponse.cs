using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class HospitalSearchResponse : APIResponseBase
    {        
        public HospitalSearchEntity data { get; set; }
    }

    public class HospitalSearchEntity
    {
        public List<HospitalEntity> data { get; set; }
        public int total { get; set; }
    }

    public class HospitalEntity
    {
        public string id { get; set; }
        public string adminid { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string logo { get; set; }
        public string lisence { get; set; }
        public string provid { get; set; }
        public string cityid { get; set; }
        public string areaid { get; set; }
        public string address { get; set; }

        public string deptname { get; set; }
        public string enabled { get; set; }
        public string level { get; set; }
        public string ll { get; set; }
        public string keywords { get; set; }
        public string features { get; set; }
        public string tags { get; set; }
        public string services { get; set; }
        public string contact { get; set; }
        public string telphone { get; set; }
        public string mobile { get; set; }
        public string im { get; set; }
        public string status { get; set; }
        public string ctime { get; set; }
        public string utime { get; set; }
        public string atime { get; set; }
    }

}
