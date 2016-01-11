using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F8YL.Model;
using System.IO;
using System.Web;

namespace F8YL.BLL
{
    /// <summary>
    /// 类名：UserRequest
    /// 功能：Role相关操作
    /// 作者：Gerry Ge
    /// 创建日期：2015-12-10
    /// 修改日期：2015-12-10
    public class UserRequest
    {

        /// <summary>
        /// 4、用户详情设置与获取 get
        /// </summary>
        /// <param name="userid">如果为空返回当前用户</param>
        /// <returns></returns>
        /// Jerry Shi
        public UserProfileResponse profile(string token, string userid)
        {
            UserProfileResponse userProfileResponse = new UserProfileResponse();
            try
            {
                string ApiResponse = string.Empty;

                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("userid", userid.ToString());

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "ucenter/user/profile?token=" + token);

                userProfileResponse = JsonHelper.DeserializeJsonToObject<UserProfileResponse>(ApiResponse);


            }
            catch (Exception ex)
            {
                //AppLog.Instance.Write("UserProfileResponse", AppLog.LogMessageType.Error, ex);
            }
            return userProfileResponse;
        }

        /// <summary>
        /// 4、用户详情设置
        /// </summary>
        /// <param name="token"></param>
        /// <param name="username"></param>
        /// <param name="truename"></param>
        /// <param name="deptid"></param>
        /// <param name="avatar"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        /// Jack Ding
        public string SaveUserProfile(string token, string username, string truename, string deptid, string avatar, string age, string duty, string tel, string email,string userid)
        {
            string strReturn = string.Empty;
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("username", username);
                sPara.Add("truename", truename);
                sPara.Add("deptname", deptid);
                if (avatar != string.Empty)
                {
                    sPara.Add("avatar", avatar);
                }
                sPara.Add("age", age);
                sPara.Add("duty", duty);
                sPara.Add("tel", tel);
                sPara.Add("email", email);
                if (!string.IsNullOrEmpty(userid))
                {
                    sPara.Add("userid", userid);
                }

                strReturn = F8YLSubmit.BuildRequest(sPara, "ucenter/user/profile?token=" + token);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("SaveUserProfile", AppLog.LogMessageType.Error, ex);
            }

            return strReturn;
        }

        /// <summary>
        /// 4、用户详情设置与获取 get
        /// </summary>
        /// <param name="token"></param>
        /// <param name="username"></param>
        /// <param name="truename"></param>
        /// <param name="deptid"></param>
        /// <param name="avatar"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        /// Jack Ding
        public string getProfile(string token, string userid)
        {
            try
            {
                string ApiResponse = string.Empty;
                UserProfileResponse userProfileResponse = new UserProfileResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("userid", userid);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "ucenter/user/profile?token=" + token);

                return ApiResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 4、用户详情设置与获取 get
        /// </summary>
        /// <param name="token"></param>
        /// <param name="username"></param>
        /// <param name="truename"></param>
        /// <param name="deptid"></param>
        /// <param name="avatar"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        /// Jack Ding
        public string getProfile(string token, string username, string email, string deptid, string avatar, string sex, string ethnic, string height, string weight, string address, string doctorid)
        {
            try
            {
                string ApiResponse = string.Empty;
                UserProfileResponse userProfileResponse = new UserProfileResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("username", username);
                sPara.Add("mobile", username);
                sPara.Add("email", email);
                //sPara.Add("deptid", deptid);
                if (avatar != string.Empty)
                {
                    sPara.Add("avatar", avatar);
                }
                if (sex != string.Empty)
                {
                    sPara.Add("sex", sex);
                }
                if (ethnic != string.Empty)
                {
                    sPara.Add("ethnic", sex);
                }

                sPara.Add("height", height);
                sPara.Add("weight", weight);
                sPara.Add("address", address);
                sPara.Add("doctorid", doctorid);



                ApiResponse = F8YLSubmit.BuildRequest(sPara, "ucenter/user/profile?token=" + token);

                return ApiResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 4、用户详情设置与获取 get
        /// </summary>
        /// <param name="token"></param>
        /// <param name="username"></param>
        /// <param name="truename"></param>
        /// <param name="deptid"></param>
        /// <param name="avatar"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        /// Jack Ding
        public string getProfiles(string token, string username, string email, string deptid, string avatar, string sex, string ethnic, string height, string weight, string address, string doctorid, string userid, string mobile, string telphone, string num_il)
        {
            try
            {
                string ApiResponse = string.Empty;
                UserProfileResponse userProfileResponse = new UserProfileResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("username", username);
                sPara.Add("mobile", mobile);
                sPara.Add("email", email);
                sPara.Add("tel", telphone);
                //sPara.Add("deptid", deptid);
                if (avatar != string.Empty)
                {
                    sPara.Add("avatar", avatar);
                }
                if (sex != string.Empty)
                {
                    sPara.Add("sex", sex);
                }
                if (ethnic != string.Empty)
                {
                    sPara.Add("ethnic", ethnic);
                }
                if (userid != string.Empty)
                {
                    sPara.Add("userid", userid);
                }

                sPara.Add("height", height);
                sPara.Add("weight", weight);
                sPara.Add("address", address);
                sPara.Add("doctorid", doctorid);
                sPara.Add("num_ill", num_il);



                ApiResponse = F8YLSubmit.BuildRequest(sPara, "ucenter/user/profile?token=" + token);

                return ApiResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 3-All 获取用户信息
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="hospitalid">医院id</param>
        /// <param name="page"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public HospitalUserProfileResponse SearchUsers(string token, string hospitalid, string q)
        {
            try
            {
                string ApiResponse = string.Empty;
                HospitalUserProfileResponse hospitalUserProfileResponse = new HospitalUserProfileResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("hospitalid", hospitalid);
                sPara.Add("q", q);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "ucenter/user/search/?token=" + token);

                if (!ApiResponse.Contains("[]"))
                {
                    hospitalUserProfileResponse = JsonHelper.DeserializeJsonToObject<HospitalUserProfileResponse>(ApiResponse);
                }

                return hospitalUserProfileResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 3、	用户－PI/医生/病人/列表  之 获取医院PI列表
        /// </summary>
        /// <param name="token"></param>
        /// <param name="hospitalid"></param>
        /// <param name="page"></param>
        /// <param name="q"></param>
        public HospitalUserProfileResponse SearchHospitalPi(string token, string hospitalid, string q)
        {
            try
            {
                string ApiResponse = string.Empty;
                HospitalUserProfileResponse hospitalUserProfileResponse = new HospitalUserProfileResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("hospitalid", hospitalid);
                sPara.Add("q", q);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "ucenter/user/search/pi?token=" + token);

                if (!ApiResponse.Contains("[]"))
                {
                    hospitalUserProfileResponse = JsonHelper.DeserializeJsonToObject<HospitalUserProfileResponse>(ApiResponse);
                }

                return hospitalUserProfileResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 3、	用户－PI/医生/病人/列表  之 获取医院PI列表
        /// </summary>
        /// <param name="token"></param>
        /// <param name="hospitalid"></param>
        /// <param name="page"></param>
        /// <param name="q"></param>
        public string getSearchHospitalPi(string token, string hospitalid, string q)
        {
            try
            {
                string ApiResponse = string.Empty;
                HospitalUserProfileResponse hospitalUserProfileResponse = new HospitalUserProfileResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("hospitalid", hospitalid);
                sPara.Add("q", q);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "ucenter/user/search/pi?token=" + token);

                return ApiResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 3、	用户－PI/医生/病人/列表  之 获取医院医生列表
        /// </summary>
        /// <param name="token"></param>
        /// <param name="hospitalid"></param>
        /// <param name="page"></param>
        /// <param name="q"></param>
        public HospitalUserProfileResponse SearchHospitalDoctor(string token, string hospitalid, string q)
        {
            try
            {
                string ApiResponse = string.Empty;
                HospitalUserProfileResponse hospitalUserProfileResponse = new HospitalUserProfileResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("hospitalid", hospitalid);
                sPara.Add("q", q);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "ucenter/user/search/doctor?token=" + token);
                if (!ApiResponse.Contains("[]"))
                {
                    hospitalUserProfileResponse = JsonHelper.DeserializeJsonToObject<HospitalUserProfileResponse>(ApiResponse);
                }
                return hospitalUserProfileResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 3、	用户－PI/医生/病人/列表  之 获取医院医生列表
        /// </summary>
        /// <param name="token"></param>
        /// <param name="hospitalid"></param>
        /// <param name="page"></param>
        /// <param name="q"></param>
        public string getSearchHospitalDoctor(string token, string hospitalid, string q)
        {
            try
            {
                string ApiResponse = string.Empty;
                HospitalUserProfileResponse hospitalUserProfileResponse = new HospitalUserProfileResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("hospitalid", hospitalid);
                sPara.Add("q", q);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "ucenter/user/search/doctor?token=" + token);

                return ApiResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 3、	用户－PI/医生/病人/列表  之 获取医院病人列表
        /// </summary>
        /// <param name="token"></param>
        /// <param name="hospitalid"></param>
        /// <param name="page"></param>
        /// <param name="q"></param>
        public HospitalUserProfileResponse SearchHospitalPatient(string token, string hospitalid, string q)
        {
            try
            {
                string ApiResponse = string.Empty;
                HospitalUserProfileResponse hospitalUserProfileResponse = new HospitalUserProfileResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("hospitalid", hospitalid);
                sPara.Add("q", q);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "ucenter/user/search/patient?token=" + token);
                if (!ApiResponse.Contains("[]"))
                {
                    hospitalUserProfileResponse = JsonHelper.DeserializeJsonToObject<HospitalUserProfileResponse>(ApiResponse);
                }
                return hospitalUserProfileResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 3、	用户－PI/医生/病人/列表  之 获取医院病人列表
        /// </summary>
        /// <param name="token"></param>
        /// <param name="hospitalid"></param>
        /// <param name="page"></param>
        /// <param name="q"></param>
        public string getSearchHospitalPatient(string token, string hospitalid, string q)
        {
            try
            {
                string ApiResponse = string.Empty;
                HospitalUserProfileResponse hospitalUserProfileResponse = new HospitalUserProfileResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("hospitalid", hospitalid);
                sPara.Add("q", q);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "ucenter/user/search/patient?token=" + token);
                return ApiResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 5、	修改密码
        /// </summary>
        /// <param name="pass_old">原始密码(明文)</param>
        /// <param name="pass_new1">新密码(明文)</param>
        /// <param name="pass_new2">新密码(明文)</param>
        /// <returns></returns>
        /// Jack Ding
        public string ModifyUserPassword(string pass_old, string pass_new1, string pass_new2, string token)
        {
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("pass_old", pass_old);
                sPara.Add("pass_new1", pass_new1);
                sPara.Add("pass_new2", pass_new2);

                return F8YLSubmit.BuildRequest(sPara, "ucenter/user/passwd?token=" + token);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 5、	修改密码
        /// </summary>
        /// <param name="pass_old">原始密码(明文)</param>
        /// <param name="pass_new1">新密码(明文)</param>
        /// <param name="pass_new2">新密码(明文)</param>
        /// <returns></returns>
        /// Jack Ding
        public string getUCenterUserPasswd(string pass_old, string pass_new1, string pass_new2, string token)
        {
            string strResponse = string.Empty;

            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("pass_old", pass_old);
                sPara.Add("pass_new1", pass_new1);
                sPara.Add("pass_new2", pass_new2);

                strResponse = F8YLSubmit.BuildRequest(sPara, "ucenter/user/passwd?token=" + token);

                return strResponse;
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 49、	获取病人加入的项目
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// Gerry Ge
        /// 请求方式：GET
        public string Joined(string token, int page = 1)
        {

            string strResponse = string.Empty;
            UserJoinedResponse apiResponse = new UserJoinedResponse();
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("page", page.ToString());

                strResponse = F8YLSubmit.BuildGetRequest(sPara, "ucenter/user/joined?token=" + token);
            }
            catch (Exception)
            {

            }
            return strResponse;
        }

        /// <summary>
        /// 53、	上传接口
        /// </summary>
        /// <param name="filedata"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// Jack Ding
        public UploadWebResponse UploadWeb(string filedata, string token)
        {
            string strResponse = string.Empty;

            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("Filedata", filedata);

                strResponse = F8YLSubmit.BuildRequest(sPara, "upload/web?token=" + token);

                return JsonHelper.DeserializeJsonToObject<UploadWebResponse>(strResponse);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 54.文件下载(静态)
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="token">token</param>
        /// <returns></returns>
        public string Download(string fileName, string token)
        {
            string strResponse = string.Empty;
            try
            {
                strResponse = F8YLSubmit.BuildGetRequestForFile(null, "download?file=dHBsLXVzZXItaW1wb3J0Lnhscw%3D%3D");
                return strResponse;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 55、	用户导入
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="filexls">来自上传所返回的文件名</param>
        /// <returns></returns>
        public string UserImport(string token, string filexls)
        {
            string apiResponse = string.Empty;
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("filexls", filexls);
                apiResponse = F8YLSubmit.BuildRequest(sPara, "ucenter/user/import?token=" + token);
                return apiResponse;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Files the content.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        private byte[] FileContent(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            try
            {
                byte[] buffur = new byte[fs.Length];
                fs.Read(buffur, 0, (int)fs.Length);

                return buffur;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (fs != null)
                {

                    //关闭资源
                    fs.Close();
                }
            }
        }


        /// <summary>
        ///  6、	添加用户
        /// </summary>
        /// <param name="token"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        /// Gerry Ge
        /// 请求方式：POST
        public string AddUser(string token, UserAddResponseDataEntity user)
        {

            string strResponse = string.Empty;
            UserJoinedResponse apiResponse = new UserJoinedResponse();
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                foreach (System.Reflection.PropertyInfo p in user.GetType().GetProperties())
                {
                    if (p.Name == "hospitalid")
                    {
                        sPara.Add(p.Name, p.GetValue(user).ToString());
                    }
                    else if (p.Name == "role")
                    {
                        sPara.Add(p.Name, p.GetValue(user).ToString());
                    }
                    else if (p.Name == "idcard")
                    {
                        sPara.Add(p.Name, p.GetValue(user).ToString());
                    }
                    else if (p.Name == "username")
                    {
                        sPara.Add(p.Name, p.GetValue(user).ToString());
                    }
                    else if (p.Name == "mobile")
                    {
                        sPara.Add(p.Name, p.GetValue(user).ToString());
                    }
                    else if (p.Name == "email")
                    {
                        sPara.Add(p.Name, p.GetValue(user).ToString());
                    }
                    else if (p.Name == "deptname")
                    {
                        sPara.Add(p.Name, p.GetValue(user).ToString());
                    }
                    else if (p.Name == "duty")
                    {
                        sPara.Add(p.Name, p.GetValue(user).ToString());
                    }
                    else if (p.Name == "tel")
                    {
                        sPara.Add(p.Name, p.GetValue(user).ToString());
                    }
                }

                strResponse = F8YLSubmit.BuildRequest(sPara, "ucenter/user/add?token=" + token);
            }
            catch (Exception)
            {

            }
            return strResponse;
        }

        /// <summary>
        /// 7、	删除用户
        /// </summary>
        /// <param name="token"></param>
        /// <param name="id">要删除的用户id</param>
        /// <returns></returns>
        public string DropUser(string token, string id)
        {

            string strResponse = string.Empty;
            APIResponseBase apiResponse = new APIResponseBase();
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("userid", id);

                strResponse = F8YLSubmit.BuildRequest(sPara, "ucenter/user/drop?token=" + token);
            }
            catch (Exception)
            {

            }
            return strResponse;
        }

        public string UpdateUser(string token, string userid, string username, string deptname, string duty, string tel, string email)
        {

            string strResponse = string.Empty;
            APIResponseBase apiResponse = new APIResponseBase();
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("userid", userid);
                sPara.Add("username", username);
                sPara.Add("deptname", deptname);
                sPara.Add("duty", duty);
                sPara.Add("tel", tel);
                sPara.Add("email", email);

                strResponse = F8YLSubmit.BuildRequest(sPara, "ucenter/user/profile?token=" + token);
            }
            catch (Exception)
            {

            }
            return strResponse;
        }


        public string UserStatusDisable(string token, string id)
        {

            string strResponse = string.Empty;
            APIResponseBase apiResponse = new APIResponseBase();
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("userid", id);

                strResponse = F8YLSubmit.BuildRequest(sPara, "ucenter/user/status/disable?token=" + token);
            }
            catch (Exception)
            {

            }
            return strResponse;
        }

        public string ImportUser(string token, string filexls)
        {

            string strResponse = string.Empty;
            APIResponseBase apiResponse = new APIResponseBase();
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("filexls", filexls);

                strResponse = F8YLSubmit.BuildRequest(sPara, "ucenter/user/import?token=" + token);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("ImportUser", AppLog.LogMessageType.Error, ex);
            }
            return strResponse;
        }
    }
}
