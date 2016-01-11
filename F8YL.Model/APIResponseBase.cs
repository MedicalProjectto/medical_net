using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    /// <summary>
    /// API 返回消息的基础类
    /// 作者：Gerry Ge
    /// 创建日期：2015-12-09
    /// 修改日期：2015-12-09
    /// </summary>
    public class APIResponseBase
    {
        public int code { get; set; }
        public string message { get; set; }
    }
}
