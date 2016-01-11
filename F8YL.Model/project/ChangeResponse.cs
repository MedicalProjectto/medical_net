using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    /// <summary>
    /// 类名：ChangeResponse
    /// 功能：项目变换(修改)（41）
    /// 作者：Gerry Ge
    /// 创建日期：2015-12-10
    /// 修改日期：2015-12-10
    public class ChangeResponse : APIResponseBase
    {
        public ChangeResponseDataEntity data { get; set; }
    }

    public class ChangeResponseDataEntity
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
        public string ctime { get; set; }
        public string utime { get; set; }
    }
}
