using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class TplReportDetailResponse : APIResponseBase
    {
        private TplReportDetaiInfo _data;
        public TplReportDetaiInfo data
        {
            get
            {
                if (_data == null)
                {
                    _data = new TplReportDetaiInfo();
                }
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }

    public class TplReportDetaiInfo
    {
        private TplReportDetail_ReportInfo _report;
        public TplReportDetail_ReportInfo report
        {
            get
            {
                if (_report == null)
                {
                    _report = new TplReportDetail_ReportInfo();
                }
                return _report;
            }
            set
            {
                _report = value;
            }
        }

        private TplDetailInfo _tpl;
        public TplDetailInfo tpl
        {
            get
            {
                if (_tpl == null)
                {
                    _tpl = new TplDetailInfo();
                }
                return _tpl;
            }
            set
            {
                _tpl = value;
            }
        }
    }

    public class TplReportDetail_ReportInfo
    {
        public string id { get; set; }
        public string hospitalid { get; set; }
        public string userid { get; set; }
        public string tplid { get; set; }
        public string remark { get; set; }
        public string ctime { get; set; }
        public string utime { get; set; }

        private Dictionary<string, TplReportDetail_ReportDetail> _tpl_report_detail;
        public Dictionary<string, TplReportDetail_ReportDetail> tpl_report_detail
        {
            get
            {
                if (_tpl_report_detail == null)
                {
                    _tpl_report_detail = new Dictionary<string, TplReportDetail_ReportDetail>();
                }
                return _tpl_report_detail;
            }
            set
            {
                _tpl_report_detail = value;
            }
        }
    }

    public class TplReportDetail_ReportDetail
    {
        public string id { get; set; }
        public string reportid { get; set; }
        public string tplid { get; set; }
        public string detailid { get; set; }
        public string termid { get; set; }
        public string itype { get; set; }
        public string answer { get; set; }
        public string utime { get; set; }
    }

}
