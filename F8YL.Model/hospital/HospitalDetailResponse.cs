using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class HospitalDetailResponse : APIResponseBase
    {
        public HospitalEntity data { get; set; }
    }
}
