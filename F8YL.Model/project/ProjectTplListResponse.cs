using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    /// <summary>
    /// 类名：TplListResponse
    /// 功能：获取项目的模板列表（40）
    /// 作者：Gerry Ge
    /// 创建日期：2015-12-10
    /// 修改日期：2015-12-10
    public class ProjectTplListResponse : APIResponseBase
    {
        public TplListResponseDataEntity data { get; set; }
    }
    public class TplListResponseDataEntity
    {
        public List<TplListResponseDataDataEntity> data { get; set; }

        public int total { get; set; }
    }
    public class TplListResponseDataDataEntity
    {
        public string id { get; set; }
        public string tplid { get; set; }
        public string projectid { get; set; }
        public string tplname { get; set; }        
        public string ctime { get; set; }
    }
}
