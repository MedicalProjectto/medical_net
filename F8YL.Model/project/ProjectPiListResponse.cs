using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class ProjectPiListResponse : APIResponseBase
    {
        public ProjectPiListData data { get; set; }
    }

    public class ProjectPiListData
    {

        public List<ProjectPiInfo> data { get; set; }
        public int total { get; set; }
    }


    public class ProjectPiInfo
    {
        public string id { get; set; }

        public string piid { get; set; }

        public string projectid { get; set; }

        public string hospitalid { get; set; }

        public string username { get; set; }

        public string ctime { get; set; }

    }
}
