using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F8YL.BLL;
using F8YL.Model;
using System.Text;

namespace F8YL.Controllers
{
    public class F8YLProjectController : Controller
    {

        ProjectRequest projectRequest = new ProjectRequest();
        TplRequest tplrequest = new TplRequest();
        AuthRequest authrequest = new AuthRequest();

        #region //qiyong
        // GET: F8YLProject
        //public ActionResult ProjectList()
        //{
        //    var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
        //    var currentUserId = Session["CurrentUserID"] == null ? "-1" : Session["CurrentUserID"].ToString();
        //    UserRequest user = new UserRequest();

        //    UserProfileResponse userFile = user.profile(token, currentUserId);

        //    ProjectListResponse entData = new ProjectListResponse();
        //    if (userFile.data != null)
        //    {
        //        entData = projectRequest.list(token, userFile.data.hospitalid, 0, currentUserId);
        //    }

        //    ViewBag.UserFile = userFile.data;
        //    ViewBag.ProjectList = entData.data.data;
        //    return View();
        //}
        #endregion

        public ActionResult ProjectList()
        {
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            ViewBag.Token = token;
            var currentUserId = Session["CurrentUserID"] == null ? "-1" : Session["CurrentUserID"].ToString();

            ViewBag.UserID = currentUserId;
            ViewBag.HospitalID = Session["hospitalid"] == null ? "-1" : Session["hospitalid"].ToString();

            UserRequest user = new UserRequest();

            UserProfileResponse userFile = user.profile(token, currentUserId);
            if (userFile.data.role == "90")
            {
                return RedirectToAction("ManageIndex", "F8YLManage");
            }


            ProjectJoined entData = new ProjectJoined();
            if (userFile.data != null)
            {
                entData = projectRequest.Joined(token,"0");
            }

            ViewBag.UserFile = userFile.data;
            ViewBag.ProjectList = entData.data;
            return View();
        }


        [HttpPost]
        public string CreateProject(string projectName)
        {
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            string apiResponse = string.Empty;
            try
            {
                apiResponse = projectRequest.create(token, projectName, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.MaxValue.ToString("yyyy-MM-dd"), "0", "");
            }
            catch (Exception ex)
            {
                throw;
            }
            return apiResponse;
        }


        //ProjectDetail
        public ActionResult ProjectDetail(string id)
        {
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();

            ViewBag.role = Session["role"] == null ? "XXXXXXX" : Session["role"].ToString();
            ViewBag.username = Session["username"] == null ? "XXXXXXX" : Session["username"].ToString();

            ViewBag.sessionHospitalid= Session["hospitalid"] == null ? "XXXXXXX" : Session["hospitalid"].ToString();


            //实体
            ProjectDetailResponse projectDetailResponse = new ProjectDetailResponse();

            HospitalRequest hospitalrequest = new HospitalRequest();

            HospitalSearchResponse response = new HospitalSearchResponse();//医院列表

            HospitalUserProfileResponse hospitalprofile = new HospitalUserProfileResponse();//医院pi

            ProjectTplListResponse tplListResponse = new ProjectTplListResponse();//模板列表

            TplDetailResponse tpldetailresponse = new TplDetailResponse();//模板详情

            //方法
            UserRequest userrequest = new UserRequest();
            ViewBag.UserFile = userrequest.profile(token, "").data;

            ProjectRequest projecttplrequest = new ProjectRequest();

            //TplRequest tplrequest = new TplRequest();

            List<HospitalUserProfileResponse> listhospitalfrofile = new List<HospitalUserProfileResponse>();

            string apiResponse = string.Empty;
            try
            {
                projectDetailResponse = projectRequest.detail(token, id);

                if (projectDetailResponse.data != null)
                {
                    if (projectDetailResponse.data.tpl == null)
                    {
                        projectDetailResponse.data.tpl = new List<ProjectDetailTplInfo>();
                    }

                    //模板列表
                    tplListResponse = projecttplrequest.ProjectTplList(token, projectDetailResponse.data.id, "", 1);

                    if (tplListResponse.data != null)
                    {
                        //列表detail
                        tpldetailresponse = tplrequest.TplDetail(token, tplListResponse.data.data[0].tplid);
                    }

                    //医院列表
                    response = hospitalrequest.Search(token, 1, "");

                    //医院pi
                    if (response.data != null)
                    {
                        foreach (HospitalEntity hs in response.data.data)
                        {
                            hospitalprofile = userrequest.SearchHospitalPi(token, hs.id, "");
                            if (hospitalprofile.data != null)
                            {
                                listhospitalfrofile.Add(hospitalprofile);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            ViewBag.TplList = tplListResponse;//tpllist
            ViewBag.hospitalSearch = response;//hospitallist
            ViewBag.hopital = listhospitalfrofile;//pi
            ViewBag.TplDetail = tpldetailresponse;//tpldetail
            ViewBag.Token = token;
            return View(projectDetailResponse);
        }


        //PiAppend
        public string getPiAppend(string piId, string projectId, bool overwrite, string num_goal)
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = projectRequest.PiAppend(token, projectId, piId, overwrite, num_goal);
            }
            catch (Exception ex)
            {
                throw;
            }


            return apiResponse;
        }

        //gettpldetail
        public string getTplDetail(string tplId)
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = tplrequest.getTplDetail(token, tplId);

                //string sssss= JsonHelper.ToJson(apiResponse);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }

        //get项目的医生列表
        public string getDoctorlist(string projectId, string hospitalId, string piId)
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = projectRequest.getDoctorList(token, hospitalId, projectId, piId, "", "1");

                apiResponse = "{\"code\": 0,\"message\": null,\"data\": {\"data\": [{\"id\": \"5\",\"doctorid\": \"16\",\"piid\": \"12\",\"projectid\": \"20\",\"hospitalid\": \"120\",\"username\": \"扁鹊\",\"ctime\": \"2015-11-16 16:52:00\"}],\"total\": 1}}";
                //string sssss= JsonHelper.ToJson(apiResponse);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }

        //为项目添加医生
        public string addDoctorAppend(string projectId, string doctorId, bool overwrite,string num_goal)
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = projectRequest.DoctorAppend(token, projectId, doctorId, overwrite, num_goal);

            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }

        [HttpGet]
        //获取所有医生列表
        public string getdoctorlisttest(string hospitalId)
        {
            UserRequest user = new UserRequest();
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = user.getSearchHospitalDoctor(token, hospitalId, null);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }

        //查看医生患者资料
        public string getuserinformation(string userId)
        {
            UserRequest user = new UserRequest();
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = user.getProfile(token, userId);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }

        [HttpGet]
        public void DownloadTemplate(string templateName)
        {
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();

            UserRequest user = new UserRequest();
            string fileData = user.Download(templateName, token);
        }

        [HttpPost]
        public void UploadFile()
        {
            string[] upfiles = Request.Files.AllKeys;

            UserRequest user = new UserRequest();
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                var x = Request.Files[upfiles[0]];
                // BufferedReader reader = new BufferedReader(Request.Files[upfiles[0]].InputStream);
                byte[] bt = new byte[x.ContentLength];
                int test = x.InputStream.ReadByte();

                StringBuilder strB = new StringBuilder();
                //System.Text.Encoding.ASCII.GetString(bt);
                foreach (byte b in bt)
                {
                    strB.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
                    //strB.Append(System.Text.Encoding.ASCII.GetString(b));
                }
                //}

                var lala = user.UploadWeb(upfiles[0], token);

            }
            catch (Exception ex)
            {
                throw;
            }

            // return apiResponse;
        }


        //项目归档
        public string getprojectfiling(string projectId)
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = projectRequest.Archive(token, projectId);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }
        //修改项目名称
        public string updateProjectName(string projectId, string projectName)
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = projectRequest.Change(token, projectId, "", projectName, "", "", "");
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }
        //修改项目入组人数
        public string updateProjectnum_goal(string projectId, string projectName, string num_goal)
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = projectRequest.Change(token, projectId, "", "", num_goal, "", "");
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }
        //修改项目日期
        public string updateProjectcycle(string projectId, string opendate, string closedate)
        {
            string apiResponse = string.Empty;

            if (closedate.Equals(""))
            {
                closedate = DateTime.Parse(opendate).AddYears(1).ToString("yyyy-MM-dd");
            }

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = projectRequest.Change(token, projectId, "", "", "", opendate, closedate);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }
        //移除医生
        public string removeDoctor(string projectId, string doctorId)
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = projectRequest.removeDoctor(token, projectId, doctorId);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }
        //searchPi
        public string searchPi(string hospitalId)
        {
            UserRequest user = new UserRequest();
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = user.getSearchHospitalPi(token, hospitalId, "");
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }

        //添加病人
        public string addpatient(string projectId, string doctorId, string hospitalId, string patientId, string userName, string mobile, string idCard, bool overwrite,string height,string weight,string address,string tel,string num_il,string ethnic,string sex)
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = projectRequest.PatientAppend(token, projectId, doctorId, patientId, userName, mobile, idCard, overwrite,height, weight,address,tel, num_il, ethnic, sex);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }
        //移除病人
        public string removePatent(string projectId, string patentId)
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = projectRequest.removePatent(token, projectId, patentId);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }

        //修改密码
        public string updatePassword(string pass_old, string pass_new1, string pass_new2)
        {
            string apiResponse = string.Empty;
            UserRequest user = new UserRequest();

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = user.getUCenterUserPasswd(pass_old, pass_new1, pass_new2, token);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }

        //获取待归档项目列表
        public string getprojectList(string projectId, string hospitalId, string userId)
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = projectRequest.getProjectList(token, hospitalId, 1, userId);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }

        //项目激活
        public string projectInvoke(string projectId)
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = projectRequest.Active(token, projectId);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }
        //登出
        public string loginout()
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = authrequest.Logout(token);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }
        //保存资料
        public string saveInforamtion(string username,  string email,  string avatar,  string sex, string ethnic,string height,string weight,string address,string doctorid,string userid,string mobile,string telphone,string num_il)
        {
            UserRequest user = new UserRequest();
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = user.getProfiles(token, username, email, "", avatar, sex, ethnic,height,weight,address,doctorid, userid, mobile, telphone, num_il);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }

        //获取病人列表getSearchHospitalPatient
        public string getPatientlisttest(string hospitalId)
        {
            UserRequest user = new UserRequest();
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = user.getSearchHospitalPatient(token, hospitalId, null);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }

        //PatientMove将病人移到某医生下
        public string patientmove(string hospitalId, string patientId, string doctorid_new, string doctorid_old)
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = projectRequest.PatientMove(token, hospitalId, patientId, doctorid_new, doctorid_old);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }

        //获取项目下的医院下的医生列表
        public string relativeDoctor(string hospitalId, string projectid)
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = projectRequest.relativeDoctor(token, projectid, hospitalId);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }

        [HttpGet]
        //获取项目下的医院下的病人列表
        public string relativePatient(string hospitalId, string projectid)
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = projectRequest.relativePatient(token, projectid, hospitalId);
            }
            catch (Exception ex)
            {
                throw;
            }

            return apiResponse;
        }



    }
}