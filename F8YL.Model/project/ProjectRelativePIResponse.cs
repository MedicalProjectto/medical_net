using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class ProjectRelativePIResponse : APIResponseBase
    {
        private List<ProjectRelativePIInfo> _data;
        public List<ProjectRelativePIInfo> data
        {
            get
            {
                if (_data == null)
                {
                    _data = new List<ProjectRelativePIInfo>();
                }
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }

    public class ProjectRelativePIInfo
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

}
