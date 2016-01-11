using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F8YL.Model;

namespace F8YL.BLL
{
    /// <summary>
    /// 类名：ProjectRequest
    /// 功能：Project操作
    /// 作者：Gerry Ge
    /// 创建日期：2015-12-10
    /// 修改日期：2015-12-10
    public class ProjectRequest
    {
        /// <summary>
        /// 29、	项目列表
        /// </summary>
        /// <param name="token"></param>
        /// <param name="hospitalid">医院id</param>
        /// <param name="status">状态(0:进行中,1:已归档)</param>
        /// <param name="userid">创建项目的用户id</param>
        /// <returns></returns>
        /// Jerry Shi
        public ProjectListResponse list(string token, string hospitalid, int status, string userid)
        {
            ProjectListResponse projectListResponse = new ProjectListResponse();
            try
            {
                string ApiResponse = string.Empty;
                
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("hospitalid", hospitalid.ToString());
                sPara.Add("status", status.ToString());
                sPara.Add("userid", userid);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "project/list?token=" + token);

                projectListResponse = JsonHelper.DeserializeJsonToObject<ProjectListResponse>(ApiResponse);

                
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("list", AppLog.LogMessageType.Error, ex);
            }
            return projectListResponse;
        }
        /// <summary>
        /// 29、	项目列表
        /// </summary>
        /// <param name="token"></param>
        /// <param name="hospitalid">医院id</param>
        /// <param name="status">状态(0:进行中,1:已归档)</param>
        /// <param name="userid">创建项目的用户id</param>
        /// <returns></returns>
        /// Jerry Shi
        public string getProjectList(string token, string hospitalid, int status, string userid)
        {
            string ApiResponse = string.Empty;
            try
            {
                
                ProjectListResponse projectListResponse = new ProjectListResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("hospitalid", hospitalid.ToString());
                sPara.Add("status", status.ToString());
                sPara.Add("userid", userid);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "project/list?token=" + token);

                
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("getProjectList", AppLog.LogMessageType.Error, ex);
            }
            return ApiResponse;
        }

        /// <summary>
        /// 30、	项目详情
        /// </summary>
        /// <param name="id">项目id</param>
        /// <returns></returns>
        /// Jerry Shi
        public ProjectDetailResponse detail(string token, string id)
        {
            ProjectDetailResponse projectDetailResponse = new ProjectDetailResponse();
            try
            {
                string ApiResponse = string.Empty;
                
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("id", id);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "project/detail?token=" + token);

                if (!ApiResponse.Contains("[]"))
                {
                    projectDetailResponse = JsonHelper.DeserializeJsonToObject<ProjectDetailResponse>(ApiResponse);
                }
                
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("detail", AppLog.LogMessageType.Error, ex);
            }
            return projectDetailResponse;
        }

        /// <summary>
        /// 31、	创建项目(立项)
        /// </summary>
        /// <param name="token"></param>
        /// <param name="name">项目名称</param>
        /// <param name="opendate">立项日期</param>
        /// <param name="closedate">结束日期</param>
        /// <param name="num_goal">项目目标病人数</param>
        /// <param name="remark">简要说明</param>
        /// <returns></returns>
        /// Jerry Shi
        public string create(string token, string name, string opendate, string closedate, string num_goal, string remark)
        {
            string response = string.Empty;
            try
            {
                
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("name", name);
                sPara.Add("opendate", opendate);
                sPara.Add("closedate", closedate);
                sPara.Add("num_goal", num_goal);
                sPara.Add("remark", remark);
                response = F8YLSubmit.BuildRequest(sPara, "project/create?token=" + token);

                
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("create", AppLog.LogMessageType.Error, ex);
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="opendate"></param>
        /// <param name="closedate"></param>
        /// <param name="num_goal"></param>
        /// <param name="remark"></param>
        /// <param name="piid"></param>
        /// <param name="doctorid"></param>
        /// <param name="patientid"></param>
        /// <param name="tplid"></param>
        /// <returns></returns>
        public string create(string token, string name, DateTime opendate, DateTime closedate, int num_goal, string remark, string piid, string doctorid, string patientid, string tplid)
        {
            return string.Empty;
        }

        /// <summary>
        /// 32、	为项目添加PI/医院
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="projectid"项目id</param>
        /// <param name="piid">piid序列,实为PI的userid</param>
        /// <param name="overwrite">是否覆盖之前的PI</param>
        /// <returns></returns>
        /// Jerry Shi
        public string PiAppend(string token, string projectid, string piid, bool overwrite, string num_goal)
        {
            string apiRespone = string.Empty;
            try
            {
                
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("projectid", projectid);

                //List<string> piidList = JsonHelper.DeserializeJsonToObject<List<string>>(piid);
                //foreach (string item in piidList)
                //{
                //    sPara.Add("piid[]", item);
                //}
                sPara.Add("piid[]", piid);
                sPara.Add("overwrite", overwrite == true ? "true" : "false");
                sPara.Add("num_goal", num_goal);
                apiRespone = F8YLSubmit.BuildRequest(sPara, "project/pi/append?token=" + token);
               
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("PiAppend", AppLog.LogMessageType.Error, ex);
            }
            return apiRespone;

        }

        /// <summary>
        /// 33、	为项目添加医生
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="projectid">项目id</param>
        /// <param name="doctorid">doctorid序列,实为医生的userid，它们所对应的PI为当前登录用户</param>
        /// <param name="overwrite">是否覆盖之前的医生</param>
        /// <returns></returns>
        /// Jerry Shi
        public string DoctorAppend(string token, string projectid, string doctorid, bool overwrite, string num_goal)
        {
            string apiRespone = string.Empty;
            try
            {
                
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("projectid", projectid);

                //List<string> doctoridList = JsonHelper.DeserializeJsonToObject<List<string>>(doctorid);
                //foreach (string item in doctoridList)
                //{
                //    sPara.Add("doctorid[]", item);
                //}
                string[] dID = doctorid.Split(',');
                Dictionary<string, string[]> sParas = new Dictionary<string, string[]>();
                sParas.Add("doctorid[]", dID);

                sPara.Add("overwrite", overwrite == true ? "true" : "false");
                sPara.Add("num_goal", num_goal);
                apiRespone = F8YLSubmit.BuildRequest(sParas, sPara, "project/doctor/append?token=" + token);
                
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("DoctorAppend", AppLog.LogMessageType.Error, ex);
            }
            return apiRespone;
        }

        /// <summary>
        /// 34、	为项目添加病人
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="projectid">项目id</param>
        /// <param name="doctorid">不需要传,就是当前登录的用户</param>
        /// <param name="patientid">patientid序列;实为病人的userid，它们所对应的医生为当前登录用户。如果不传此值，那下面的mobile,idcard必填</param>
        /// <param name="username">病人姓名</param>
        /// <param name="mobile">病人手机</param>
        /// <param name="idcard">病人身份证 18位</param>
        /// <param name="overwrite">是否覆盖之前的病人</param>
        /// <param name="height">身高</param>
        /// <param name="weight">体重</param>
        /// <param name="address">地址</param>
        /// <param name="tel">电话</param>
        /// <returns></returns>
        /// Jerry Shi
        public string PatientAppend(string token, string projectid, string doctorid, string patientid, string username, string mobile, string idcard, bool overwrite, string height, string weight, string address, string tel, string num_il, string ethnic, string sex)
        {
            string apiRespone = string.Empty;
            try
            {
               
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("projectid", projectid);
                //sPara.Add("doctorid", doctorid);   //此参数不需要传递，就是当前用户
                if (patientid != "")
                {
                    List<string> patientidList = JsonHelper.DeserializeJsonToObject<List<string>>(patientid);
                    foreach (string item in patientidList)
                    {
                        sPara.Add("patientid[]", item);
                    }
                }
                sPara.Add("username", username);
                sPara.Add("mobile", mobile);
                sPara.Add("idcard", idcard);

                sPara.Add("overwrite", overwrite == true ? "true" : "false");
                sPara.Add("height", height);
                sPara.Add("weight", weight);
                sPara.Add("address", address);
                sPara.Add("tel", tel);
                sPara.Add("num_ill", num_il);
                sPara.Add("ethnic", ethnic);
                sPara.Add("sex", sex);
                sPara.Add("doctorid", doctorid);

                apiRespone = F8YLSubmit.BuildRequest(sPara, "project/patient/append?token=" + token);
                
            }
            catch (Exception ex)
            {
               AppLog.Instance.Write("PatientAppend", AppLog.LogMessageType.Error, ex);
            }
            return apiRespone;
        }

        /// <summary>
        /// 36、	移除医生
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="projectid">项目id</param>
        /// <param name="doctorid">医生id</param>
        /// <returns></returns>
        /// Jerry Shi
        public string removeDoctor(string token, string projectid, string doctorid)
        {
            string apiRespone = string.Empty;
            try
            {
                
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("projectid", projectid);
                sPara.Add("doctorid", doctorid);

                apiRespone = F8YLSubmit.BuildRequest(sPara, "project/doctor/remove?token=" + token);
                
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("removeDoctor", AppLog.LogMessageType.Error, ex);
            }
            return apiRespone;
        }
        /// <summary>
        /// 34、	移除病人
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="projectid">项目id</param>
        /// <param name="patentid">病人id</param>
        /// <returns></returns>
        /// Jerry Shi
        public string removePatent(string token, string projectid, string patentid)
        {
            string apiRespone = string.Empty;
            try
            {
                
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("projectid", projectid);
                sPara.Add("patientid", patentid);

                apiRespone = F8YLSubmit.BuildRequest(sPara, "project/patient/remove?token=" + token);
                
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("removePatent", AppLog.LogMessageType.Error, ex);
            }
            return apiRespone;
        }

        /// <summary>
        /// 38、	为项目添加模板
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="projectid">项目id</param>
        /// <param name="tplid">tplid序列;模板id</param>
        /// <param name="overwrite">是否覆盖之前的模板</param>
        /// <returns></returns>
        /// Jerry Shi
        public string TplAppend(string token, string projectid, string tplid, bool overwrite)
        {
            string apiRespone = string.Empty;
            try
            {
                
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("projectid", projectid);

                List<string> tplidList = JsonHelper.DeserializeJsonToObject<List<string>>(tplid);
                foreach (string item in tplidList)
                {
                    sPara.Add("doctorid[]", item);
                }
                sPara.Add("overwrite", overwrite == true ? "true" : "false");
                apiRespone = F8YLSubmit.BuildRequest(sPara, "project/tpl/append?token=" + token);
                
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("TplAppend", AppLog.LogMessageType.Error, ex);
            }
            return apiRespone;
        }

        ///// 39号接口同 29号，重复

        /// <summary>
        /// 40、	获取项目的PI列表
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="hospitalid">医院id[通常不用]</param>
        /// <param name="projectid">项目id</param>
        /// <param name="username">PI名称(模糊)</param>
        /// <param name="page">分页id</param>
        /// <returns></returns>
        /// Jerry Shi
        public ProjectPiListResponse PiList(string token, string hospitalid, string projectid, string username, string page)
        {
            ProjectPiListResponse projectPiListResponse = new ProjectPiListResponse();
            try
            {
                string ApiResponse = string.Empty;
                
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("hospitalid", hospitalid);
                sPara.Add("projectid", projectid);
                sPara.Add("username", username);
                sPara.Add("page", page.ToString());
                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "project/pi/list?token=" + token);

                projectPiListResponse = JsonHelper.DeserializeJsonToObject<ProjectPiListResponse>(ApiResponse);

                
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("PiList", AppLog.LogMessageType.Error, ex);
            }
            return projectPiListResponse;
        }

        /// <summary>
        /// 41、	获取项目的医生列表
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="hospitalid">医院id[通常不用]</param>
        /// <param name="projectid">项目id</param>
        /// <param name="piid">对应的PI id</param>
        /// <param name="username">医生名字(模糊)</param>
        /// <param name="page">分页id</param>
        /// <returns></returns>
        public ProjectDoctorListResponse DoctorList(string token, string hospitalid, string projectid, string piid, string username, string page)
        {
            ProjectDoctorListResponse projectDoctorListResponse = new ProjectDoctorListResponse();
            try
            {
                string ApiResponse = string.Empty;

                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("hospitalid", hospitalid);
                sPara.Add("projectid", projectid);
                sPara.Add("piid", piid);
                sPara.Add("username", username);
                sPara.Add("page", page.ToString());
                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "project/doctor/list?token=" + token);

                projectDoctorListResponse = JsonHelper.DeserializeJsonToObject<ProjectDoctorListResponse>(ApiResponse);


            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("DoctorList", AppLog.LogMessageType.Error, ex);
            }
            return projectDoctorListResponse;
        }

        /// <summary>
        /// 41、	获取项目的医生列表
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="hospitalid">医院id[通常不用]</param>
        /// <param name="projectid">项目id</param>
        /// <param name="piid">对应的PI id</param>
        /// <param name="username">医生名字(模糊)</param>
        /// <param name="page">分页id</param>
        /// <returns></returns>
        public string getDoctorList(string token, string hospitalid, string projectid, string piid, string username, string page)
        {
            string ApiResponse = string.Empty;
            try
            {

                ProjectDoctorListResponse projectDoctorListResponse = new ProjectDoctorListResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("hospitalid", hospitalid);
                sPara.Add("projectid", projectid);
                sPara.Add("piid", piid);
                sPara.Add("username", username);
                sPara.Add("page", page.ToString());
                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "project/doctor/list?token=" + token);


            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("getDoctorList", AppLog.LogMessageType.Error, ex);
            }
            return ApiResponse;
        }

        /// <summary>
        /// 42、	获取项目的病人列表
        /// </summary>
        /// <param name="hospitalid">医院id[通常不用]</param>
        /// <param name="projectid">项目id</param>
        /// <param name="doctorid">对应的医生id</param>
        /// <param name="username">病人名字(模糊)</param>
        /// <param name="page">分页id</param>
        /// Gerry Ge
        /// 请求方式：GET
        /// <returns></returns>
        public string PatientList(string token, int hospitalid, int projectid, int doctorid, string username, int page = 1)
        {
            string strResponse = string.Empty;
            PatientListResponse apiResponse = new PatientListResponse();
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("hospitalid", hospitalid.ToString());
                sPara.Add("projectid", projectid.ToString());
                sPara.Add("doctorid", doctorid.ToString());
                sPara.Add("username", username.ToString());
                sPara.Add("page", page.ToString());

                strResponse = F8YLSubmit.BuildGetRequest(sPara, "project/patient/list?token=" + token);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("PatientList", AppLog.LogMessageType.Error, ex);

            }
            return strResponse;
        }

        /// <summary>
        /// 43、	获取项目的模板列表
        /// </summary>
        /// <param name="projectid">项目id</param>
        /// <param name="name">模板名称(模糊)</param>
        /// <param name="page">分页id</param>
        /// Gerry Ge
        /// 请求方式：GET
        /// <returns></returns>
        public ProjectTplListResponse ProjectTplList(string token, string projectid, string name, int page = 1)
        {
            string strResponse = string.Empty;
            ProjectTplListResponse apiResponse = new ProjectTplListResponse();
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("projectid", projectid.ToString());
                sPara.Add("name", name.ToString());
                sPara.Add("page", page.ToString());

                strResponse = F8YLSubmit.BuildGetRequest(sPara, "project/tpl/list?token=" + token);

                if (!strResponse.Contains("[]"))
                {
                    apiResponse = JsonHelper.DeserializeJsonToObject<ProjectTplListResponse>(strResponse);
                }
            }
            catch (Exception ex)
            {

                AppLog.Instance.Write("ProjectTplList", AppLog.LogMessageType.Error, ex);
            }
            return apiResponse;

        }

        /// <summary>
        /// 44、	项目变换(修改)
        /// </summary>
        /// <param name="projectid">指标id序列</param>
        /// <param name="piid">id序列</param>
        /// <returns></returns>
        /// Gerry Ge
        ///
        public string Change(string token, string projectid, string piid, string projectname, string num_goal, string opendate, string closedate)
        {
            string strResponse = string.Empty;
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("projectid", projectid);
                sPara.Add("piid[]", piid);
                if (projectname != "")
                {
                    sPara.Add("name", projectname);
                }
                if (num_goal != "")
                {
                    sPara.Add("num_goal", num_goal);
                }
                if (opendate != "")
                {
                    sPara.Add("opendate", opendate);
                }
                if (closedate != "")
                {
                    sPara.Add("closedate", closedate);
                }

                strResponse = F8YLSubmit.BuildRequest(sPara, "project/change?token=" + token);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("Change", AppLog.LogMessageType.Error, ex);

            }
            return strResponse;
        }

        /// <summary>
        /// 45、	删除项目
        /// </summary>
        /// <param name="projectid">要删除的项目id</param>
        /// <returns></returns>
        /// Gerry Ge
        /// 请求方式：POST
        public string Drop(int projectid)
        {
            string strResponse = string.Empty;
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("projectid", projectid.ToString());
                strResponse = F8YLSubmit.BuildRequest(sPara, "project/drop");
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("Drop", AppLog.LogMessageType.Error, ex);

            }
            return strResponse;
        }

        /// <summary>
        /// 46、	项目归档
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="projectid">要归档的项目id</param>
        /// <returns></returns>
        /// Jerry Shi
        public string Archive(string token, string projectid)
        {
            string apiResponse = string.Empty;
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("projectid", projectid);
                apiResponse = F8YLSubmit.BuildRequest(sPara, "project/archive?token=" + token);
            }
            catch (Exception ex)
            {

                AppLog.Instance.Write("Archive", AppLog.LogMessageType.Error, ex);
            }
            return apiResponse;
        }

        /// <summary>
        /// 47、	项目激活
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="projectid">要激活的项目id</param>
        /// <returns></returns>
        public string Active(string token, string projectid)
        {
            string apiResponse = string.Empty;
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("projectid", projectid);
                apiResponse = F8YLSubmit.BuildRequest(sPara, "project/active?token=" + token);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("Active", AppLog.LogMessageType.Error, ex);
            }
            return apiResponse;
        }

        /// <summary>
        /// 56、	56、	获取当前用户所参与的项目
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        public ProjectJoined Joined(string token, string status)
        {
            string apiResponse = string.Empty;
            ProjectJoined projectJoined = new ProjectJoined();
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("status", status);
                apiResponse = F8YLSubmit.BuildGetRequest(sPara, "project/joined?token=" + token);
                projectJoined = JsonHelper.DeserializeJsonToObject<ProjectJoined>(apiResponse);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("Joined", AppLog.LogMessageType.Error, ex);
            }
            return projectJoined;
        }

        /// <summary>
        /// 57、	移动病人到其它医生下
        /// </summary>
        /// <param name="projectid">项目id</param>
        /// <param name="patientid">病人userid</param>
        /// <param name="doctorid_new">新医生userid</param>
        /// <param name="doctorid_old">原医生userid</param>
        /// <returns></returns>
        public string PatientMove(string token, string projectid, string patientid, string doctorid_new, string doctorid_old)
        {
            string apiResponse = string.Empty;
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("projectid", projectid);
                sPara.Add("patientid", patientid);
                sPara.Add("doctorid_new", doctorid_new);
                sPara.Add("doctorid_old", doctorid_old);
                apiResponse = F8YLSubmit.BuildRequest(sPara, "project/patient/move?token=" + token);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("PatientMove", AppLog.LogMessageType.Error, ex);
            }
            return apiResponse;
        }

        public ProjectRelativeUserResponse ProjectRelativeUsers(string token, string hospitalid, string q)
        {
            string apiResponse = string.Empty;
            ProjectRelativeUserResponse projectRelativeUserResponse = new ProjectRelativeUserResponse();
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                if (hospitalid != string.Empty)
                {
                    sPara.Add("hospitalid", hospitalid);
                }
                sPara.Add("q", q);

                apiResponse = F8YLSubmit.BuildGetRequest(sPara, "project/relative/user?token=" + token);
                projectRelativeUserResponse = JsonHelper.DeserializeJsonToObject<ProjectRelativeUserResponse>(apiResponse);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("ProjectRelativeUsers", AppLog.LogMessageType.Error, ex);
            }
            return projectRelativeUserResponse;
        }


        public Dictionary<string, UserDataEntity> GenerageProjectRelativeUsers(string token, string hospitalid, string q)
        {
            ProjectRelativePIResponse projectRelativePIResponse = new ProjectRelativePIResponse();
            ProjectRelativeDoctorResponse projectRelativeDoctorResponse = new ProjectRelativeDoctorResponse();
            ProjectRelativePatientResponse projectRelativePatientResponse = new ProjectRelativePatientResponse();
            string apiPI = ProjectRelativePI(token, hospitalid, q);
            string apiDoctor = ProjectRelativeDoctor(token, hospitalid, q);
            string apiPatient = ProjectRelativePatient(token, hospitalid, q);

            projectRelativePIResponse = JsonHelper.DeserializeJsonToObject<ProjectRelativePIResponse>(apiPI);
            projectRelativeDoctorResponse = JsonHelper.DeserializeJsonToObject<ProjectRelativeDoctorResponse>(apiDoctor);
            if (!apiPatient.Contains("[]"))
            {
                projectRelativePatientResponse = JsonHelper.DeserializeJsonToObject<ProjectRelativePatientResponse>(apiPatient);
            }

            Dictionary<string, UserDataEntity> messageUserList = new Dictionary<string, UserDataEntity>();
            if (projectRelativePIResponse.data != null)
            {
                foreach (ProjectRelativePIInfo pi in projectRelativePIResponse.data)
                {
                    if (messageUserList.ContainsKey(pi.piid) == false)
                    {
                        UserDataEntity userDataEntity = new UserDataEntity();
                        userDataEntity.dataId = pi.piid;
                        userDataEntity.role = pi.role;
                        userDataEntity.username = pi.username;
                        messageUserList.Add(pi.piid, userDataEntity);
                    }
                }
            }

            if (projectRelativeDoctorResponse.data != null)
            {
                foreach (ProjectRelativeDoctorInfo doc in projectRelativeDoctorResponse.data)
                {
                    if (messageUserList.ContainsKey(doc.doctorid) == false)
                    {
                        UserDataEntity userDataEntity = new UserDataEntity();
                        userDataEntity.dataId = doc.doctorid;
                        userDataEntity.role = doc.role;
                        userDataEntity.username = doc.username;
                        messageUserList.Add(doc.doctorid, userDataEntity);
                    }
                }
            }

            if (projectRelativePatientResponse.data != null)
            {
                foreach (ProjectRelativePatientInfo pat in projectRelativePatientResponse.data)
                {
                    if (messageUserList.ContainsKey(pat.patientid) == false)
                    {
                        UserDataEntity userDataEntity = new UserDataEntity();
                        userDataEntity.dataId = pat.patientid;
                        userDataEntity.role = pat.role;
                        userDataEntity.username = pat.username;
                        messageUserList.Add(pat.patientid, userDataEntity);
                    }
                }
            }

            return messageUserList;
        }

        public string ProjectRelativePI(string token, string hospitalid, string q)
        {
            string apiResponse = string.Empty;
            //ProjectRelativeUserResponse projectRelativeUserResponse = new ProjectRelativeUserResponse();
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                if (hospitalid != string.Empty)
                {
                    sPara.Add("hospitalid", hospitalid);
                }
                sPara.Add("q", q);

                apiResponse = F8YLSubmit.BuildGetRequest(sPara, "project/relative/pi?token=" + token);
                //projectRelativeUserResponse = JsonHelper.DeserializeJsonToObject<ProjectRelativeUserResponse>(apiResponse);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("ProjectRelativePI", AppLog.LogMessageType.Error, ex);
            }
            return apiResponse;
        }

        public string ProjectRelativeDoctor(string token, string hospitalid, string q)
        {
            string apiResponse = string.Empty;
            //ProjectRelativeUserResponse projectRelativeUserResponse = new ProjectRelativeUserResponse();
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                if (hospitalid != string.Empty)
                {
                    sPara.Add("hospitalid", hospitalid);
                }
                sPara.Add("q", q);

                apiResponse = F8YLSubmit.BuildGetRequest(sPara, "project/relative/doctor?token=" + token);
                //projectRelativeUserResponse = JsonHelper.DeserializeJsonToObject<ProjectRelativeUserResponse>(apiResponse);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("ProjectRelativeDoctor", AppLog.LogMessageType.Error, ex);
            }
            return apiResponse;
        }

        public string ProjectRelativePatient(string token, string hospitalid, string q)
        {
            string apiResponse = string.Empty;
            //ProjectRelativeUserResponse projectRelativeUserResponse = new ProjectRelativeUserResponse();
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                if (hospitalid != string.Empty)
                {
                    sPara.Add("hospitalid", hospitalid);
                }
                sPara.Add("q", q);

                apiResponse = F8YLSubmit.BuildGetRequest(sPara, "project/relative/patient?token=" + token);
                //projectRelativeUserResponse = JsonHelper.DeserializeJsonToObject<ProjectRelativeUserResponse>(apiResponse);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("ex", AppLog.LogMessageType.Error, ex);
            }
            return apiResponse;
        }


        /// <summary>
        /// 60 获取项目相关用户/PI/医生/病人 列表 
        /// </summary>
        /// <param name="projectid">项目id</param>
        /// <param name="patientid">病人userid</param>
        /// <returns></returns>
        public string relativeDoctor(string token, string projectid, string hospitalid)
        {
            string apiResponse = string.Empty;
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("projectid", projectid);
                sPara.Add("hospitalid", hospitalid);
                apiResponse = F8YLSubmit.BuildGetRequest(sPara, "project/relative/doctor?token=" + token);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("relativeDoctor", AppLog.LogMessageType.Error, ex);
            }
            return apiResponse;
        }
        /// <summary>
        /// 60 获取项目相关用户/PI/医生/病人 列表 
        /// </summary>
        /// <param name="projectid">项目id</param>
        /// <param name="patientid">病人userid</param>
        /// <returns></returns>
        public string relativePatient(string token, string projectid, string hospitalid)
        {
            string apiResponse = string.Empty;
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("projectid", projectid);
                sPara.Add("hospitalid", hospitalid);
                apiResponse = F8YLSubmit.BuildGetRequest(sPara, "project/relative/patient?token=" + token);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("relativePatient", AppLog.LogMessageType.Error, ex);
            }
            return apiResponse;
        }

    }
}
