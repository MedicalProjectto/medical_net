using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class ProjectDetailResponse : APIResponseBase
    {
        private ProjectDetailInfo _data;
        public ProjectDetailInfo data
        {
            get
            {
                if (_data == null)
                {
                    _data = new ProjectDetailInfo();
                }
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }

    public class ProjectDetailInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string fullname { get; set; }
        public string userid { get; set; }
        public string hospitalid { get; set; }
        public string opendate { get; set; }
        public string closedate { get; set; }
        public string num_pi { get; set; }
        public string num_doctor { get; set; }
        public string num_patient { get; set; }
        public string num_goal { get; set; }
        public string status { get; set; }
        public string remark { get; set; }
        public string notice { get; set; }

        private CreatorInfo _creator;
        public CreatorInfo creator
        {
            get
            {
                if (_creator == null)
                {
                    _creator = new CreatorInfo();
                }
                return _creator;
            }
            set
            {
                _creator = value;
            }
        }

        private List<ProjectDetailTplInfo> _project_tpl;
        public List<ProjectDetailTplInfo> project_tpl
        {
            get
            {
                if (_project_tpl == null)
                {
                    _project_tpl = new List<ProjectDetailTplInfo>();
                }
                return _project_tpl;
            }
            set
            {
                _project_tpl = value;
            }
        }

        private List<ProjectDetailTplInfo> _tpl;
        public List<ProjectDetailTplInfo> tpl
        {
            get
            {
                if (_tpl == null)
                {
                    _tpl = new List<ProjectDetailTplInfo>();
                }
                return _tpl;
            }
            set
            {
                _tpl = value;
            }
        }

        private List<ProjectDetailPIListInfo> _project_pi;
        public List<ProjectDetailPIListInfo> project_pi
        {
            get
            {
                if (_project_pi == null)
                {
                    _project_pi = new List<ProjectDetailPIListInfo>();
                }
                return _project_pi;
            }
            set
            {
                _project_pi = value;
            }

        }

        private List<ProjectDetailDoctorListInfo> _project_doctor;
        public List<ProjectDetailDoctorListInfo> project_doctor
        {
            get
            {
                if (_project_doctor == null)
                {
                    _project_doctor = new List<ProjectDetailDoctorListInfo>();
                }
                return _project_doctor;
            }
            set
            {
                _project_doctor = value;
            }
        }

        private List<ProjectDetailPatientListInfo> _project_patient;
        public List<ProjectDetailPatientListInfo> project_patient
        {
            get
            {
                if (_project_patient == null)
                {
                    _project_patient = new List<ProjectDetailPatientListInfo>();
                }
                return _project_patient;
            }
            set
            {
                _project_patient = value;
            }
        }

        private List<ProjectDetailPIInfo> _pi;
        public List<ProjectDetailPIInfo> pi
        {
            get
            {
                if (_pi == null)
                {
                    _pi = new List<ProjectDetailPIInfo>();
                }
                return _pi;
            }
            set
            {
                _pi = value;
            }
        }

        private List<ProjectDetailDoctorInfo> _doctor;
        public List<ProjectDetailDoctorInfo> doctor
        {
            get
            {
                if (_doctor == null)
                {
                    _doctor = new List<ProjectDetailDoctorInfo>();
                }
                return _doctor;
            }
            set
            {
                _doctor = value;
            }
        }

        private List<ProjectDetailPatientInfo> _patient;
        public List<ProjectDetailPatientInfo> patient
        {
            get
            {
                if (_patient == null)
                {
                    _patient = new List<ProjectDetailPatientInfo>();
                }
                return _patient;
            }
            set
            {
                _patient = value;
            }
        }

        private List<ProjectDetailHospitalInfo> _hospital;
        public List<ProjectDetailHospitalInfo> hospital
        {
            get
            {
                if (_hospital == null)
                {
                    _hospital = new List<ProjectDetailHospitalInfo>();
                }
                return _hospital;
            }
            set
            {
                _hospital = value;
            }
        }
    }

    public class CreatorInfo
    {
        public string id { get; set; }
        public string idcard { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string hospitalid { get; set; }
        public string deptid { get; set; }
        public string username { get; set; }
        public string truename { get; set; }
        public string sex { get; set; }
        public string role { get; set; }
        public string ethnic { get; set; }
        public string birthplace { get; set; }
        public string address { get; set; }
        public string enabled { get; set; }
    }
    public class ProjectDetailPIListInfo
    {
        public string id { get; set; }
        public string piid { get; set; }
        public string projectid { get; set; }
        public string hospitalid { get; set; }
        public string username { get; set; }
        public string ctime { get; set; }
        public string num_patient { get; set; }

        public string num_goal { get; set; }

    }
    public class ProjectDetailDoctorListInfo
    {
        public string id { get; set; }
        public string doctorid { get; set; }
        public string piid { get; set; }
        public string projectid { get; set; }
        public string hospitalid { get; set; }
        public string username { get; set; }
        public string ctime { get; set; }
        public string num_patient { get; set; }

        public string num_goal { get; set; }

    }
    public class ProjectDetailPatientListInfo
    {
        public string id { get; set; }
        public string patientid { get; set; }
        public string doctorid { get; set; }
        public string projectid { get; set; }
        public string hospitalid { get; set; }
        public string username { get; set; }
        public string ctime { get; set; }
    }
    public class ProjectDetailTplInfo
    {
        public string id { get; set; }
        public string userid { get; set; }
        public string hospitalid { get; set; }
        public string name { get; set; }
        public string period { get; set; }
        public string freqs { get; set; }
        public string kindid { get; set; }
        public string editbypat { get; set; }
        public string remark { get; set; }
        public string ctime { get; set; }
        public string utime { get; set; }
    }
    public class ProjectDetailPIInfo
    {
        public string id { get; set; }
        public string username { get; set; }
        public string idcard { get; set; }
        public string mobile { get; set; }
    }
    public class ProjectDetailDoctorInfo
    {
        public string id { get; set; }
        public string username { get; set; }
        public string idcard { get; set; }
        public string mobile { get; set; }
    }
    public class ProjectDetailPatientInfo
    {
        public string id { get; set; }
        public string username { get; set; }
        public string idcard { get; set; }
        public string mobile { get; set; }
        public string age { get; set; }
    }
    public class ProjectDetailHospitalInfo
    {
        public string id { get; set; }
        public string title { get; set; }
        public string adminid { get; set; }
        public string contact { get; set; }
        public string telphone { get; set; }
        public string mobile { get; set; }
    }

}
