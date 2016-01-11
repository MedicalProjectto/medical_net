using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    /// <summary>
    /// 类名：LoginResponse
    /// 功能：登录（1）
    /// 作者：Gerry Ge
    /// 创建日期：2015-12-08
    /// 修改日期：2015-12-08
    public class LoginResponse : APIResponseBase
    {
        public DataEntity data { get; set; }
    }

    public class DataEntity
    {
        public string token { get; set; }

        public int role { get; set; }
    }
}
