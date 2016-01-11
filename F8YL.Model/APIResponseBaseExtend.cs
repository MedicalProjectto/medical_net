using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    /// <summary>
    /// 类名：APIResponseBaseExtend
    /// 功能：针对多返回一个字符型的data的通用Response
    /// 作者：Gerry Ge
    /// 创建日期：2015-12-10
    /// 修改日期：2015-12-10
    public class APIResponseBaseExtend : APIResponseBase
    {
        public string data { get; set; }
    }
}
