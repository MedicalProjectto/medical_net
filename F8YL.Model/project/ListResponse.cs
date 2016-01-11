using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    /// <summary>
    /// 类名：ListResponse
    /// 功能：获取项目列表（36）
    /// 作者：Gerry Ge
    /// 创建日期：2015-12-10
    /// 修改日期：2015-12-10
    public class ListResponse : APIResponseBase
    {
        public ListResponseDataEntity data { get; set; }
    }
    public class ListResponseDataEntity
    {
        public List<ListResponseDataDataEntity> data { get; set; }

        public int total { get; set; }
    }
    public class ListResponseDataDataEntity
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
