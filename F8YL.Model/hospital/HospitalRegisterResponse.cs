using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class HospitalRegisterResponse : APIResponseBase
    {
        public HospitalRegisterEntity data { get; set; }
    }

    public class HospitalRegisterEntity
    {
        public HospitalEntity hospital { get; set; }
        public UserProfileInfo user { get; set; }
    }

}
