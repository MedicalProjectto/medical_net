using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using F8YL.BLL;
using F8YL.Model;

namespace F8YL.Controllers
{
    public class F8YLHomeController : Controller
    {
        // GET: F8YLHome
        public ActionResult Index()
        {
            return View();
        }

        public string Login(string mobile, string password)
        {
            string bllRsponse = string.Empty;
            AuthRequest auth = new AuthRequest();
            UserRequest userRequest = new UserRequest();

            bllRsponse = auth.Login(mobile, password);
            //bllRsponse = auth.Login("13012345676", "654321");

            // 将接口返回的信息记录在服务端Sesson
            LoginResponse bllRsponseModel = new LoginResponse();
            bllRsponseModel = JsonHelper.DeserializeJsonToObject<LoginResponse>(bllRsponse);

            if (bllRsponseModel.code == 0)
            {
                Session["Phone"] = mobile;
                Session["token"] = bllRsponseModel.data.token;
                Session["role"] = bllRsponseModel.data.role;
                
                UserProfileResponse userProfileResponse = userRequest.profile(bllRsponseModel.data.token, "");
                Session["username"] = userProfileResponse.data.username;
                Session["hospitalid"] = userProfileResponse.data.hospitalid;
                Session["CurrentUserID"] = userProfileResponse.data.id;
                Session["CurrentUserHospitalID"] = userProfileResponse.data.hospitalid;
                Session["password"] = password;
            }

            ////返回接口对象
            return bllRsponse;
        }

    }
}