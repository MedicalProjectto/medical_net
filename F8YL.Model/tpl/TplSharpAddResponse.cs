using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class TplSharpAddResponse : APIResponseBase
    {
        public TplSharpAdd_SharpInfo data { get; set; }
    }

    public class TplSharpAdd_SharpInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string parentid { get; set; }
        public string tplid { get; set; }
    }
}
