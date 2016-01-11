using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.BLL
{
    /// <summary>
    /// 类名：Auth
    /// 功能：授权操作（登录，登出）
    /// 作者：Gerry Ge
    /// 创建日期：2015-12-08
    /// 修改日期：2015-12-08
    public class AuthRequest
    {

        /// <summary>
        /// 1、	登录
        /// </summary>
        /// <param name="loginname">登录名(手机号或身分证)</param>
        /// <param name="password">密码的md5值</param>
        /// <returns></returns>
        /// Jerry Shi
        public string Login(string loginname, string password)
        {
            string apiResponse = string.Empty;
            //LoginResponse response = new LoginResponse();
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                password = F8YLMD5.Sign(password);
                sPara.Add("loginname", loginname);
                sPara.Add("password", password);
                apiResponse = F8YLSubmit.BuildRequest(sPara, "auth/login");
                //response = JsonHelper.DeserializeJsonToObject<LoginResponse>(strResponse);

                //string token = response.data.token;

                //F8YLConfig.Token = "f04ea436bc0ff295ac6631647ccb05e4";
                //response = Logout();
            }
            catch (Exception)
            {

                throw;
            }

            return apiResponse;
        }

        /// <summary>
        /// 2、	登出(下线)
        /// </summary>
        /// <param name="token">token</param>
        /// <returns></returns>
        /// Jerry Shi
        public string Logout(string token)
        {
            string strResponse = string.Empty;
            try
            {
                //if (!string.IsNullOrEmpty(F8YLConfig.Token))
                //{
                    Dictionary<string, string> sPara = new Dictionary<string, string>();
                    //sPara.Add("token", token);
                    //strResponse = F8YLSubmit.BuildRequest(sPara, "get", "auth/logout", "", new Byte[] { }, "", 0);
                    strResponse = F8YLSubmit.BuildGetRequest(sPara, "auth/logout?token=" + token);
                //}

            }
            catch (Exception)
            {

                throw;
            }

            return strResponse;
        }
    }
}
