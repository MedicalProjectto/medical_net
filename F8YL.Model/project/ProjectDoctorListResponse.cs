using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class ProjectDoctorListResponse : APIResponseBase
    {
        public ProjectDoctorListData data { get; set; }
    }

    public class ProjectDoctorListData
    {

        public List<ProjectDoctorInfo> data { get; set; }
        public int total { get; set; }
    }


    public class ProjectDoctorInfo
    {
        public string id { get; set; }

        public string doctorid { get; set; }

        public string piid { get; set; }

        public string projectid { get; set; }

        public string hospitalid { get; set; }

        public string username { get; set; }

        public string ctime { get; set; }

    }
}
