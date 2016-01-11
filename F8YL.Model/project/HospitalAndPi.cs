using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class HospitalAndPi
    {
        public List<HospitalSearchResponse> hospitalsearch { get; set; }

        public  List<HospitalUserProfileResponse> pi { get; set; }
    }
}
