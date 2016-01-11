using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
   public class ProjectRelativeUserResponse : APIResponseBase
    {
        private List<ProjectRelativeUserInfo> _data;
        public List<ProjectRelativeUserInfo> data
        {
            get
            {
                if (_data == null)
                {
                    _data = new List<ProjectRelativeUserInfo>();
                }
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }


    public class ProjectRelativeUserInfo
    {
        public string id { get; set; }
        public string piid { get; set; }
        public string projectid { get; set; }
        public string username { get; set; }
        public string num_doctor { get; set; }
        public string num_patient { get; set; }
        public string num_goal { get; set; }
        public string role { get; set; }
        public string uid { get; set; }
        public ProjectRelativeUser_ProjectInfo project { get; set; }
        public ProjectRelativeUser_UserInfo user { get; set; }
    }

    public class ProjectRelativeUser_ProjectInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string userid { get; set; }
        public string num_pi { get; set; }
        public string num_doctor { get; set; }
        public string num_patient { get; set; }
        public string num_goal { get; set; }
        public string ctime { get; set; }

    }

    public class ProjectRelativeUser_UserInfo
    {
        public string id { get; set; }
        public string idcard { get; set; }
        public string mobile { get; set; }
        public string tel { get; set; }
        public string age { get; set; }
        public string email { get; set; }
        public string hospitalid { get; set; }
        public string deptid { get; set; }
        public string doctorid { get; set; }
        public string deptname { get; set; }
        public string duty { get; set; }
        public string username { get; set; }
        public string truename { get; set; }
        public string avatar { get; set; }
        public string sex { get; set; }
        
        public string role { get; set; }
        public string ethnic { get; set; }
        public string birthplace { get; set; }
        public string address { get; set; }
        
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


    }


}
