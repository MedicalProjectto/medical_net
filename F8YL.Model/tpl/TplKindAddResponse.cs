using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class TplKindAddResponse : APIResponseBase
    {
        public TplKindAdd_KindInfo data { get; set; }
    }

    public class TplKindAdd_KindInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string parentid { get; set; }
    }
}
