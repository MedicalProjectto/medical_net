using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    /// <summary>
    /// 类名：UserAddResponse
    /// 功能：添加用户（6）
    /// 作者：Gerry Ge
    /// 创建日期：2015-12-14
    /// 修改日期：2015-12-14
    class UserAddResponse : APIResponseBase
    {
        public UserAddResponseDataEntity data { get; set; }
    }

    public class UserAddResponseDataEntity
    {
        public string mobile { get; set; }
        public string idcard { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string status { get; set; }
        public string sex { get; set; }
        public string truename { get; set; }
        public string hospitalid { get; set; }
        public string deptid { get; set; }
        public string plain { get; set; }
        public string role { get; set; }
        public string ethnic { get; set; }
        public string duty { get; set; }
        public string education { get; set; }
        public string birthplace { get; set; }
        public string address { get; set; }
        public string enabled { get; set; }
        public string utime { get; set; }
        public string ctime { get; set; }
        public string id { get; set; }


        public string deptname { get; set; }
        public string deptnametel { get; set; }
        public string tel { get; set; }

    }
}
