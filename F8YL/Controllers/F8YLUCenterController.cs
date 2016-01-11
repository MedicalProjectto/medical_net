using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using F8YL.BLL;
using F8YL.Model;

namespace F8YL.Controllers
{
    public class F8YLUCenterController : Controller
    {
        UserRequest user = new UserRequest();

        // GET: F8YLUCenter
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string SaveUser(string username, string truename, string deptid, string avatar, string age,string duty,string tel,string email, string userid = "")
        {
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            return user.SaveUserProfile(token, username, truename, deptid, HttpUtility.UrlDecode(avatar), age, duty, tel,email,userid);
        }

        [HttpPost]
        public string ModifyUserPassword(string pass_old, string pass_new1, string pass_new2)
        {    
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            return user.ModifyUserPassword(pass_old, pass_new1, pass_new2, token);                           
        }

        [HttpGet]
        public ActionResult Logout()
        {
            //AuthRequest authRequest = new AuthRequest();
            //return authRequest.Logout(Session["token"].ToString());
            Session.Abandon();
            Session.Clear();

            return RedirectToAction("Index", "F8YLHome");
        }

        [HttpPost]
        public ActionResult UploadAvatar(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return Content("没有文件！", "text/plain");
            }

            var fileName = Path.Combine(Request.MapPath("~/UploadFiles"), Path.GetFileName(file.FileName));

            try
            {
                file.SaveAs(fileName);

                //调用上传接口
                UploadWebResponse response = user.UploadWeb(fileName, Session["token"].ToString());   

                if (response.code != 0)
                    return Content("上传失败!", "text/plain");

                return Content("上传成功！", "text/plain");
            }
            catch
            {
                return Content("上传异常 ！", "text/plain");
            }
        }

        [HttpGet]
        public string DownloadTemplateFile()
        {
            //string fileData = user.Download();
            return string.Empty;

        }

        [HttpGet]
        public string GetUserInfo(string userid)
        {
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            UserRequest user = new UserRequest();

            return user.getProfile(token, userid);
        }
    }
}

