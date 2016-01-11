using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class TplReportListResponse : APIResponseBase
    {
        private TplReportListDataInfo _data;
        public TplReportListDataInfo data
        {
            get
            {
                if (_data == null)
                {
                    _data = new TplReportListDataInfo();
                }
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }

    public class TplReportListDataInfo
    {
        private List<TplReportListData_DataInfo> _data;
        public List<TplReportListData_DataInfo> data
        {
            get
            {
                if (_data == null)
                {
                    _data = new List<TplReportListData_DataInfo>();
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

    public class TplReportListData_DataInfo
    {
        public string id { get; set; }
        public string hospitalid { get; set; }
        public string userid { get; set; }
        public string tplid { get; set; }
        public string remark { get; set; }
    }
}
