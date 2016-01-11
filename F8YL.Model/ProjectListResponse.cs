using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class ProjectListResponse : APIResponseBase
    {
        private entityData _data;
        public entityData data
        {
            get
            {
                if (_data == null)
                {
                    _data = new entityData();
                }
                return _data;
            }
            set
            {
                _data = value;
            }
        }

    }

    public class entityData
    {
        private List<ProjectInfo> _data;
        public List<ProjectInfo> data
        {
            get
            {
                if (_data == null)
                {
                    _data = new List<ProjectInfo>();
                }
                return _data;
            }
            set
            {
                _data = value;
            }
        }
        public int total { get; set; }
    }


    public class ProjectInfo
    {


        public string id { get; set; }

        public string name { get; set; }

        public string fullname { get; set; }

        public string userid { get; set; }

        public string hospitalid { get; set; }

        public string opendate { get; set; }

        public string closedate { get; set; }

        public string num_pi { get; set; }

        public string num_doctor { get; set; }

        public string num_patient { get; set; }

        public string num_goal { get; set; }

        public string status { get; set; }

        public string remark { get; set; }

        public string notice { get; set; }


    }

}
