using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class TplKindListResponse : APIResponseBase
    {
        public List<TplKindList_KindInfo> data { get; set; }
    }

    public class TplKindList_KindInfo
    {
        public string id { get; set; }
        public string name { get; set; }
    }

}
