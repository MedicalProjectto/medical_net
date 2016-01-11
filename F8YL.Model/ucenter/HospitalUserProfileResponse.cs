using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class HospitalUserProfileResponse : APIResponseBase
    {
        public HospitalUserProfileinfoList data { get; set; }
        
    }

    public class HospitalUserProfileinfoList
    {
        public List<HospitalUserProfileInfo> data { get; set; }

        public string total { get; set; }
    }

    public class HospitalUserProfileInfo
    {
        public string id { get; set; }

        public string idcard { get; set; }

        public string mobile { get; set; }

        public string email { get; set; }

        public string hospitalid { get; set; }

        public string deptid { get; set; }

        public string username { get; set; }

        public string truename { get; set; }

        public string sex { get; set; }

        public string role { get; set; }

        public string ethnic { get; set; }

        public string birthplace { get; set; }

        public string address { get; set; }

        public string validated { get; set; }

        public string code { get; set; }

        public string enabled { get; set; }

        public string ctime { get; set; }

        public string lastime { get; set; }

        public HospitalInfo hospital { get; set; }
    }

    public class HospitalInfo
    {
        public string id { get; set; }

        public string title { get; set; }

        public string adminid { get; set; }

        public string mobile { get; set; }

        public string contact { get; set; }
    }

}
