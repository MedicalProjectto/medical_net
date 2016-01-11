using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class RecvResponse : APIResponseBase
    {
        private RecvResponseDataEntity _data;
        public RecvResponseDataEntity data
        {
            get
            {
                if (_data ==null)
                {
                    _data = new RecvResponseDataEntity();
                }
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }

    public class RecvResponseDataEntity
    {
        private List<RecvResponseDataMessageEntity> _data;
        public List<RecvResponseDataMessageEntity> data
        {
            get
            {
                if (_data == null)
                {
                    _data = new List<RecvResponseDataMessageEntity>();
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
    public class RecvResponseDataMessageEntity
    {
        public string id { get; set; }
        public string userid { get; set; }
        public string type { get; set; }
        public string targetid { get; set; }
        public string label { get; set; }
        public string url { get; set; }
        public string content { get; set; }
        public string status { get; set; }
        public string ctime { get; set; }
    }
}
