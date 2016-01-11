using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    /// <summary>
    /// 类名：PatientListResponse
    /// 功能：获取项目的病人列表（39）
    /// 作者：Gerry Ge
    /// 创建日期：2015-12-10
    /// 修改日期：2015-12-10
    public class PatientListResponse
    {
        public PatientListResponseDataEntity data { get; set; }
    }

    public class PatientListResponseDataEntity
    {
        public List<PatientListResponseDataDataEntity> data { get; set; }

        public int total { get; set; }
    }
    public class PatientListResponseDataDataEntity
    {
        public string id { get; set; }
        public string patientid { get; set; }
        public string doctorid { get; set; }
        public string projectid { get; set; }
        public string hospitalid { get; set; }
        public string username { get; set; }
        public string ctime { get; set; }
    }
}
