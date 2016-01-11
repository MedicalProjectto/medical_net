using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using F8YL.Model;
using F8YL.Models;
using F8YL.BLL;

namespace F8YL.Controllers
{
    public class F8YLManageController : Controller
    {
        HospitalRequest hospitalRequest = new HospitalRequest();
        // GET: F8YLManage       
        public ActionResult ManageIndex()
        {
            try
            {
                var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
                ViewBag.Token = token;
                if (token == "XXXXXXX")//未登录返回首页
                {
                    return RedirectToAction("Index", "F8YLHome");
                }

                UserRequest user = new UserRequest();
                HospitalSearchResponse hsr = new HospitalSearchResponse();
                HospitalSearchResponse hsr80 = new HospitalSearchResponse();
                UserProfileResponse userFile = user.profile(token, "");
                //Session["ManageUserRole"] = userFile.data.role;
                if (Convert.ToInt32(userFile.data.role) < 80)//只有医院管理员(80)和后台管理员(90)账号才能访问管理页面
                {
                    return Content("<script>alert('此用户无权限访问，请使用医院或者后台管理员账号。');window.location.href='/F8YLHome/Index';</script>");
                }


                if (userFile != null)
                {
                    hsr = hospitalRequest.Search(token, 1, "");
                }
                if (userFile.data.role == "80")
                {
                    hsr80.code = hsr.code;
                    hsr.message = hsr.message;
                    hsr80.data = new HospitalSearchEntity();
                    hsr80.data.data = new List<HospitalEntity>();
                    hsr80.data.data.Add(hsr.data.data.Find(x => x.id == userFile.data.hospitalid));
                    hsr = hsr80;
                }
                ViewBag.LoginUserRole = userFile.data.role;
                ViewBag.UserFile = userFile.data;
                ViewBag.HospitalList = hsr;
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("ManageIndex", AppLog.LogMessageType.Error, ex);
            }
            return View();
        }


        // GET: F8YLManage/Create
        /// <summary>
        /// 创建医院并创建一个管理员帐号(后台管理) 
        /// </summary>
        /// <param name="title">医院名称</param>
        /// <param name="contact">联系人</param>
        /// <param name="idcard">18位身份证</param>
        /// <param name="mobile">手机，后6位为管理员的登录密码</param>
        /// <param name="aaddress">地址</param>
        /// <param name="id">医院id，更新的时候需要</param>
        /// <returns></returns>
        [HttpPost]
        public string RegisterHospital(string title, string contact, string idcard, string mobile, string address, string telphone, string deptname)
        {
            string jsonRegister = string.Empty;
            try
            {
                HospitalRequest hr = new HospitalRequest();
                var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
                HospitalRegisterResponse registerHospitalResponse = new HospitalRegisterResponse();
                registerHospitalResponse = hr.Register(token, title, contact, idcard, mobile, address, telphone, deptname);
                jsonRegister = JsonHelper.SerializeObject(registerHospitalResponse);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("RegisterHospital", AppLog.LogMessageType.Error, ex);
            }
            return jsonRegister;
        }

        [HttpPost]
        public string EditHospital(string id, string title, string contact, string mobile, string address, string telphone, string deptname)
        {
            string jsonEditHospital = string.Empty;
            try
            {
                HospitalRequest hr = new HospitalRequest();
                var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();

                HospitalEntity he = new HospitalEntity
                {
                    title = title,
                    contact = contact,
                    mobile = mobile,
                    address = address,
                    telphone = telphone,
                    deptname = deptname
                };

                jsonEditHospital = hr.Edit(token, id, he);

            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("EditHospital", AppLog.LogMessageType.Error, ex);
            }
            return jsonEditHospital;
        }

        [HttpPost]
        public string DisableHospital(string id)
        {
            string jsonEditHospital = string.Empty;
            try
            {
                HospitalRequest hr = new HospitalRequest();
                var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();

                jsonEditHospital = hr.Disable(token, id);

            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("DropHospital", AppLog.LogMessageType.Error, ex);
            }
            return jsonEditHospital;
        }

        [HttpPost]
        public ActionResult HospitalList()
        {
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            HospitalSearchResponse hsr = new HospitalSearchResponse();
            try
            {

                hsr = hospitalRequest.Search(token, 1, "");
            }
            catch (Exception ex)
            {

                AppLog.Instance.Write("HospitalList", AppLog.LogMessageType.Error, ex);
            }


            return View(hsr);
        }

        [HttpPost]
        public ActionResult HospitalDetailById(int id)
        {
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            HospitalDetailResponse hdr = new HospitalDetailResponse();
            try
            {
                hdr = hospitalRequest.Detail(token, id);
                ViewBag.HospitalDetailById = hdr;
            }
            catch (Exception ex)
            {

                AppLog.Instance.Write("HospitalDetailById", AppLog.LogMessageType.Error, ex);
            }

            hdr = hospitalRequest.Detail(token, id);
            ViewBag.HospitalDetailById = hdr;
            return View(hdr);
        }

        [HttpPost]
        public string GetUserProfileByHospitalId(string hospitalId)
        {
            string jsonUser = string.Empty;

            try
            {
                var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
                HospitalUserProfileResponse hupr = new HospitalUserProfileResponse();

                UserRequest ur = new UserRequest();
                hupr = ur.SearchUsers(token, hospitalId, "");
                if (hupr.data != null)
                {
                    hupr.data.data.Sort((left, right) => Convert.ToInt32(right.role) - Convert.ToInt32(left.role));//按角色由大到小排序

                    jsonUser = JsonHelper.SerializeObject(hupr);
                }
                else if (hupr.code == 0 && hupr.data == null)
                {
                    APIResponseBaseExtend res = new APIResponseBaseExtend
                    {
                        code = 0,
                        message = "无用户。",
                        data = null

                    };
                    jsonUser = JsonHelper.SerializeObject(res);
                }

            }
            catch (Exception ex)
            {

                AppLog.Instance.Write("GetUserProfileByHospitalId", AppLog.LogMessageType.Error, ex);
            }
            return jsonUser;
        }

        public string AddUser(string id, string idcard, string role, string username, string mobile, string email, string deptname, string duty, string tel)
        {
            string jsonAddUser = string.Empty;
            try
            {
                UserRequest ur = new UserRequest();
                var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();

                UserAddResponseDataEntity ua = new UserAddResponseDataEntity
                {
                    idcard = idcard,
                    username = username,
                    role = role,
                    mobile = mobile,
                    hospitalid = id,
                    email = email,

                    deptname = deptname,
                    duty = duty,
                    tel = tel,

                };

                jsonAddUser = ur.AddUser(token, ua);

            }
            catch (Exception ex)
            {

                AppLog.Instance.Write("AddUser", AppLog.LogMessageType.Error, ex);
            }
            return jsonAddUser;
        }

        [HttpPost]
        public string DropUser(string id)
        {
            string jsonDropUser = string.Empty;
            try
            {
                UserRequest ur = new UserRequest();
                var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();

                jsonDropUser = ur.DropUser(token, id);

            }
            catch (Exception ex)
            {

                AppLog.Instance.Write("DropUser", AppLog.LogMessageType.Error, ex);
            }
            return jsonDropUser;
        }

        public string UpdateUser(string userid, string username, string deptname, string duty, string tel, string email)
        {
            string strJson = string.Empty;
            try
            {
                UserRequest ur = new UserRequest();
                var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();

                strJson = ur.UpdateUser(token, userid, username, deptname, duty, tel, email);

            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("UpdateUser", AppLog.LogMessageType.Error, ex);
            }
            return strJson;
        }

        public string UserStatusDisable(string id)
        {
            string jsonDropUser = string.Empty;
            try
            {
                UserRequest ur = new UserRequest();
                var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();

                jsonDropUser = ur.UserStatusDisable(token, id);

            }
            catch (Exception ex)
            {

                AppLog.Instance.Write("UserStatusDisable", AppLog.LogMessageType.Error, ex);
            }
            return jsonDropUser;
        }

        /// <summary>
        /// 获取模板详细信息
        /// </summary>
        /// <param name="id">目前id为10(病史)和11(检查)</param>
        /// <returns></returns>
        [HttpPost]
        public string GetTplDetai()
        {
            string jsonDetailTpl = string.Empty;
            try
            {
                var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
                TplRequest tr = new TplRequest();
                //TplDetailResponse tpl10 = new TplDetailResponse();
                //TplDetailResponse tpl11 = new TplDetailResponse();
                TplDetailResponse tpldetail = new TplDetailResponse();
                List<TplDetailResponse> listTplDetail = new List<TplDetailResponse>();
                TplListResponse tpllist = tr.TplList(token, "", "");
                foreach (var tpl in tpllist.data.data)
                {
                    tpldetail = tr.TplDetail(token, tpl.id);
                    if (tpldetail.code == 0)
                    {
                        //if (tpldetail.data.id == "10" || tpldetail.data.id == "11" || tpldetail.data.id == "12")
                        //{
                        //tpldetail.data.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.sharpid) - Convert.ToInt32(right.sharpid)));
                        //tpldetail.data.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.sharpid2) - Convert.ToInt32(right.sharpid2)));
                        ////tpldetail.data.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.termid) - Convert.ToInt32(right.termid)));



                        tpldetail.data.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.termid) - Convert.ToInt32(right.termid)));
                        tpldetail.data.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.sharpid2) - Convert.ToInt32(right.sharpid2)));
                        tpldetail.data.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.sharpid) - Convert.ToInt32(right.sharpid)));

                        listTplDetail.Add(tpldetail);
                        //}


                    }
                }


                //tpl10 = tr.TplDetail(token, "10");
                //tpl11 = tr.TplDetail(token, "11");
                //if (tpl10.code == 0)
                //{
                //    tpl10.data.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.sharpid) + Convert.ToInt32(left.sharpid2)) - (Convert.ToInt32(right.sharpid) + Convert.ToInt32(right.sharpid2)));
                //    listTplDetail.Add(tpl10);
                //}
                //if (tpl11.code == 0)
                //{
                //    tpl11.data.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.sharpid) + Convert.ToInt32(left.sharpid2)) - (Convert.ToInt32(right.sharpid) + Convert.ToInt32(right.sharpid2)));
                //    listTplDetail.Add(tpl11);
                //}

                jsonDetailTpl = JsonHelper.SerializeObject(listTplDetail);
                ViewBag.listTplDetail = jsonDetailTpl;

            }
            catch (Exception ex)
            {

                AppLog.Instance.Write("GetTplDetai", AppLog.LogMessageType.Error, ex);
            }

            return jsonDetailTpl;
        }

        //public string TplChange(string period, string freqs, string termids, string ids, string editbypats)
        //{
        //    string strJson = string.Empty;
        //    try
        //    {
        //        var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
        //        TplRequest tplRequest = new TplRequest();
        //        strJson = tplRequest.TplChange(period, freqs, termids, ids, editbypats, token);
        //    }
        //    catch (Exception ex)
        //    {

        //        AppLog.Instance.Write("TplChange", AppLog.LogMessageType.Error, ex);
        //    }
        //    return strJson;
        //}

        [HttpPost]
        public string TplChange(string strListTplDetail)
        {

            List<TplDetailResponse> listTplDetail = JsonHelper.DeserializeJsonToObject<List<TplDetailResponse>>(strListTplDetail);
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            TplRequest tplRequest = new TplRequest();
            string strJson = string.Empty;
            APIResponseBase ai = new APIResponseBase { code = 0, message = "" };
            strJson = JsonHelper.SerializeObject(ai);
            foreach (TplDetailResponse tpl in listTplDetail)
            {
                string termids = string.Empty;
                string ids = string.Empty;
                string editbypats = string.Empty;

                foreach (TplDetail_DetailInfo tpldetail in tpl.data.tpl_detail)
                {
                    termids += tpldetail.termid + ",";
                    ids += tpldetail.id + ",";
                    editbypats += tpldetail.editbypat + ",";
                }

                string reponse = tplRequest.TplChange(tpl.data.id, tpl.data.period, tpl.data.freqs, termids.Trim(','), ids.Trim(','), editbypats.Trim(','), token);
                TplChangeResponse tcr = JsonHelper.DeserializeJsonToObject<TplChangeResponse>(reponse);
                if (tcr.code != 0)
                {
                    return reponse;
                }

            }

            return strJson;

        }

        /// <summary>
        /// 传个对象对json的长度有限制(8000)
        /// </summary>
        /// <param name="listTplDetail"></param>
        //[HttpPost]
        //public void TplChange(List<TplDetailResponse> listTplDetail)
        //{
        //    var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
        //    TplRequest tplRequest = new TplRequest();


        //    foreach (TplDetailResponse tpl in listTplDetail)
        //    {
        //        string termids = string.Empty;
        //        string ids = string.Empty;
        //        string editbypats = string.Empty;

        //        foreach (TplDetail_DetailInfo tpldetail in tpl.data.tpl_detail)
        //        {
        //            termids += tpldetail.termid + ",";
        //            ids += tpldetail.id + ",";
        //            editbypats += tpldetail.editbypat + ",";
        //        }

        //        string reponse = tplRequest.TplChange(tpl.data.id, tpl.data.period, tpl.data.freqs, termids.Trim(','), ids.Trim(','), editbypats.Trim(','), token);
        //    }

        //}

        [HttpGet]
        public void DownloadTemplate(string templateName)
        {
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();


            string fileData = FileOperation.Download(templateName, token);
        }

        [HttpPost]
        public string ImportUser(string filexls)
        {
            string jsonDropUser = string.Empty;
            try
            {
                UserRequest ur = new UserRequest();
                var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();

                jsonDropUser = ur.ImportUser(token, filexls);

            }
            catch (Exception ex)
            {

                AppLog.Instance.Write("ImportUser", AppLog.LogMessageType.Error, ex);
            }
            return jsonDropUser;
        }

        public string HostpitalSearch()
        {
            string strJson = string.Empty;
            try
            {
                var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
                UserRequest user = new UserRequest();
                HospitalSearchResponse hsr = new HospitalSearchResponse();
                HospitalSearchResponse hsr80 = new HospitalSearchResponse();
                UserProfileResponse userFile = user.profile(token, "");
                if (userFile != null)
                {
                    hsr = hospitalRequest.Search(token, 1, "");
                }
                if (userFile.data.role == "80")
                {
                    hsr80.code = hsr.code;
                    hsr.message = hsr.message;
                    hsr80.data = new HospitalSearchEntity();
                    hsr80.data.data = new List<HospitalEntity>();
                    hsr80.data.data.Add(hsr.data.data.Find(x => x.id == userFile.data.hospitalid));
                    hsr = hsr80;

                }
                if (hsr != null)
                {
                    strJson = JsonHelper.SerializeObject(hsr);
                }

            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("HostpitalSearch", AppLog.LogMessageType.Error, ex);
            }
            return strJson;
        }
    }
}
