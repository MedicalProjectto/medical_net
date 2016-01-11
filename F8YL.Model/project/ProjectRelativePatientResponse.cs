using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
  public  class ProjectRelativePatientResponse : APIResponseBase
    {
        private List<ProjectRelativePatientInfo> _data;
        public List<ProjectRelativePatientInfo> data
        {
            get
            {
                if (_data == null)
                {
                    _data = new List<ProjectRelativePatientInfo>();
                }
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }

    public class ProjectRelativePatientInfo
    {
        public string id { get; set; }
        public string patientid { get; set; }
        public string doctorid { get; set; }
        public string projectid { get; set; }
        public string username { get; set; }
        public string role { get; set; }
        public string uid { get; set; }
        public ProjectRelativeUser_ProjectInfo project { get; set; }

        private ProjectRelativeUser_UserInfo _user;
        public ProjectRelativeUser_UserInfo user
        {
            get
            {
                if (_user == null)
                {
                    _user = new ProjectRelativeUser_UserInfo();
                }
                return _user;
            }
           set
            {
                _user = value;
            }
        }
    }


}
