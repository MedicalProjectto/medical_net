using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class UserProfileResponse : APIResponseBase
    {
        public UserProfileInfo data { get; set; }
    }

    public class UserProfileInfo
    {
        public string id { get; set; }

        public string idcard { get; set; }

        public string mobile { get; set; }

        public string email { get; set; }

        public string hospitalid { get; set; }

        public string deptid { get; set; }

        public string username { get; set; }

        public string truename { get; set; }
        public string avatar { get; set; }//头像路径
        public string sex { get; set; }
        public string age { get; set; }
        public string role { get; set; }

        public string ethnic { get; set; }

        public string birthplace { get; set; }

        public string address { get; set; }

        public string tel { get; set; }
        public string validated { get; set; }

        public string code { get; set; }

        public string enabled { get; set; }

        public string height { get; set; }

        public string weight { get; set; }
        public string ctime { get; set; }

        public string lastime { get; set; }        

        public string num_ill { get; set; }
        public string date_in { get; set; }
        public string date_out { get; set; }

        public string deptname { get; set; }

        public string duty { get; set; }

        public UserHospitalInfo hospital { get; set; }
    }

    public class UserHospitalInfo
    {
        public string id { get; set; }

        public string title { get; set; }

        public string adminid { get; set; }
        public string mobile { get; set; }
        public string contact { get; set; }
    }

}
