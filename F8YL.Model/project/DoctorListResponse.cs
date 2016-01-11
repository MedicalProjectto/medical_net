using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    /// <summary>
    /// 类名：DoctorListResponse
    /// 功能：获取项目的医生列表（38）
    /// 作者：Gerry Ge
    /// 创建日期：2015-12-10
    /// 修改日期：2015-12-10
    public class DoctorListResponse : APIResponseBase
    {
        public DoctorListResponseDataEntity data { get; set; }
    }

    public class DoctorListResponseDataEntity
    {
        public List<DoctorListResponseDataDataEntity> data { get; set; }

        public int total { get; set; }
    }
    public class DoctorListResponseDataDataEntity
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
