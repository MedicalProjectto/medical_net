using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class TplSharpListResponse : APIResponseBase
    {
        public List<TplSharpList_SharpInfo> data { get; set; }
    }

    public class TplSharpList_SharpInfo
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
