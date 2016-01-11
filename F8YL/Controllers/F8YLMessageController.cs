using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using F8YL.Model;
using F8YL.BLL;

namespace F8YL.Controllers
{
    public class F8YLMessageController : Controller
    {
        UserRequest userRequest = new UserRequest();
        MessageRequest messageRequest = new MessageRequest();
        ProjectRequest projectRequest = new ProjectRequest();
        TplRequest tplRequest = new TplRequest();
        // GET: F8YLMessage
        public ActionResult MessageIndex(string pageType, string projectId, string hospitalId, string patientId)
        {
            //patientId = "93";
            //ViewBag.patientId = patientId;
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();  // Session["role"]
            ViewBag.Token = token;
            var currentUserId = Session["CurrentUserID"] == null ? "-1" : Session["CurrentUserID"].ToString();
            var currentUserHospitalID = Session["CurrentUserHospitalID"] == null ? "-1" : Session["CurrentUserHospitalID"].ToString();
            var currentUserRole = Session["role"] == null ? "XXXXXXX" : Session["role"].ToString();
            string dateParam = Convert.ToString(DateTime.Today.AddMonths(-1).ToString("yyyy-MM-01"));

            ViewBag.currentUserId = currentUserId;
            ViewBag.pageType = pageType;
            ViewBag.projectId = projectId == null ? "-1" : projectId;
            ViewBag.hospitalId = hospitalId == null ? "-1" : hospitalId;
            ViewBag.patientId = string.IsNullOrEmpty(patientId) ? currentUserId : patientId;
            ViewBag.currentUserRole = currentUserRole;

            List<JoinedProjectEntity> projectList = new List<JoinedProjectEntity>();
            //if (currentUserRole != "90")
            //{
            //    // 生成项目列表，传递到页面;
            //    ProjectJoined projectJoined = projectRequest.Joined(token);
            //    if (projectJoined.data != null)
            //    {
            //        projectList = projectJoined.data;
            //    }
            //}
            // 生成项目列表，传递到页面;
            ProjectJoined projectJoined = projectRequest.Joined(token, "0");
            if (projectJoined.data != null)
            {
                projectList = projectJoined.data;
            }

            ViewBag.ProjectList = projectList;

            // 生成用户列表，传递到页面;
            //HospitalUserProfileResponse hospitalUsers = new HospitalUserProfileResponse();
            //hospitalUsers = userRequest.SearchUsers(token, currentUserHospitalID, "");

            //ProjectRelativeUserResponse projectRelativeUserResponse = new ProjectRelativeUserResponse();
            //projectRelativeUserResponse = projectRequest.ProjectRelativeUsers(token, "", "");
            List<UserDataEntity> userList = new List<UserDataEntity>();
            string userHospitalID = currentUserHospitalID;

            if (currentUserRole == "90" || currentUserRole == "80")
            {
                if (currentUserRole == "90")
                {
                    userHospitalID = "";
                }
                HospitalUserProfileResponse hospitalUsers = new HospitalUserProfileResponse();
                hospitalUsers = userRequest.SearchUsers(token, userHospitalID, "");
                if (hospitalUsers.data != null && hospitalUsers.data.data != null)
                {
                    foreach (HospitalUserProfileInfo u in hospitalUsers.data.data)
                    {
                        UserDataEntity user = new UserDataEntity();
                        user.dataId = u.id;
                        user.role = u.role;
                        user.username = u.username;
                        userList.Add(user);
                    }
                }
            }
            else
            {
                Dictionary<string, UserDataEntity> messageUserList = projectRequest.GenerageProjectRelativeUsers(token, "", "");
                userList = FilterBusersByCurrentUserRole(messageUserList, currentUserRole, currentUserId);

            }
            ViewBag.ProjectUsers = userList;

            // 调用接口，获取发送给自己的消息列表和公告列表
            //RecvResponse recvResponseMessage = messageRequest.Recv(token, "0", dateParam, "");
            ChatResponse recvResponseMessage = messageRequest.Chat(token, "0");

            // 生成消息列表，传递到页面;
            List<PageMessageEntity> pageMessageList = new List<PageMessageEntity>();

            if (recvResponseMessage.data != null)
            {
                Dictionary<string, string> usersInfo = new Dictionary<string, string>();
                foreach (ChatResponseDataChatEntity item in recvResponseMessage.data.data)
                {
                    PageMessageEntity pageMessageEntity = new PageMessageEntity();

                    pageMessageEntity.id = item.id;
                    pageMessageEntity.userid = item.userid;
                    pageMessageEntity.ctime = item.ctime;
                    pageMessageEntity.msg = item.msg;
                    pageMessageEntity.label = "";
                    pageMessageEntity.username = item.user.username;
                    //if (usersInfo.ContainsKey(item.userid) == true)
                    //{
                    //    pageMessageEntity.username = usersInfo[item.userid];
                    //}
                    //else
                    //{
                    //    UserProfileResponse user = userRequest.profile(token, item.userid);
                    //    if (user.data != null)
                    //    {
                    //        pageMessageEntity.username = user.data.username;
                    //    }
                    //    else
                    //    {
                    //        pageMessageEntity.username = "OOO";
                    //    }

                    //    usersInfo.Add(item.userid, pageMessageEntity.username);
                    //}

                    //bool isExists = false;
                    // foreach (PageMessageEntity msg in pageMessageList)
                    //{
                    //    if (msg.userid == pageMessageEntity.userid)
                    //    {
                    //        if (Convert.ToDateTime(pageMessageEntity.ctime) > Convert.ToDateTime(msg.ctime))
                    //        {
                    //            pageMessageList.Remove(msg);
                    //            pageMessageList.Add(pageMessageEntity);
                    //        }
                    //        isExists = true;
                    //    }
                    //}
                    //if (isExists == false)
                    //{
                    pageMessageList.Add(pageMessageEntity);
                    //}
                }
            }

            //foreach (PageMessageEntity msg in pageMessageList)
            //{
            //    ChatResponse chatResponse = messageRequest.Chat(token, msg.userid);
            //    if (chatResponse.data != null)
            //    {
            //        msg.msg = chatResponse.data.data.First<ChatResponseDataChatEntity>().msg;
            //        msg.ctime = chatResponse.data.data.First<ChatResponseDataChatEntity>().ctime;
            //    }
            //}

            ViewBag.MessageList = pageMessageList;

            // 生成公告列表，传递到页面；
            List<PageMessageEntity> pageBroadcastList = new List<PageMessageEntity>();
            if (currentUserRole == "90"|| currentUserRole == "80")
            {
                RecvResponse recvResponseBroadcast = messageRequest.Recv(token, "10", dateParam, "");
                if (recvResponseBroadcast.data != null)
                {
                    foreach (RecvResponseDataMessageEntity item in recvResponseBroadcast.data.data)
                    {
                        PageMessageEntity pageBroadcastEntity = new PageMessageEntity();
                        pageBroadcastEntity.id = item.id;
                        pageBroadcastEntity.userid = item.userid;
                        pageBroadcastEntity.ctime = item.ctime;
                        pageBroadcastEntity.msg = item.content;
                        pageBroadcastEntity.url = item.url;  //add by jack
                        if (item.label == string.Empty)
                        {
                            pageBroadcastEntity.label = "公告标题";
                        }
                        else
                        {
                            pageBroadcastEntity.label = item.label;
                        }
                        UserProfileResponse user = userRequest.profile(token, item.userid);
                        pageBroadcastEntity.username = user.data == null ? "OOO" : user.data.username;
                        pageBroadcastList.Add(pageBroadcastEntity);
                    }
                }
            }
            else
            {
                foreach (JoinedProjectEntity projectItem in projectList)
                {
                    RecvResponse recvResponseBroadcast = messageRequest.Recv(token, "10", dateParam, projectItem.id);
                    if (recvResponseBroadcast.data != null)
                    {
                        foreach (RecvResponseDataMessageEntity item in recvResponseBroadcast.data.data)
                        {
                            PageMessageEntity pageBroadcastEntity = new PageMessageEntity();
                            pageBroadcastEntity.id = item.id;
                            pageBroadcastEntity.userid = item.userid;
                            pageBroadcastEntity.ctime = item.ctime;
                            pageBroadcastEntity.msg = item.content;
                            pageBroadcastEntity.url = item.url;  //add by jack
                            if (item.label == string.Empty)
                            {
                                pageBroadcastEntity.label = "公告标题";
                            }
                            else
                            {
                                pageBroadcastEntity.label = item.label;
                            }
                            UserProfileResponse user = userRequest.profile(token, item.userid);
                            pageBroadcastEntity.username = user.data == null ? "OOO" : user.data.username;
                            pageBroadcastList.Add(pageBroadcastEntity);
                        }
                    }
                }
            }

            ViewBag.BroadcastList = pageBroadcastList;

            //取模板类型列表
            TplKindListResponse tplkindList = tplRequest.TplKindList(token, "1");
            ViewBag.tplkindList = tplkindList;

            //取第一个分类下的所有模板
            TplListResponse tpllistDefault = tplRequest.TplList(token, tplkindList.data[0].id, "");
            ViewBag.tpllistDefault = tpllistDefault;



            return View();
        }

        public string MessageDetails(string id)
        {
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            ChatResponse chatResponse = messageRequest.Chat(token, id);

            //ChatResponse chatResponse = new ChatResponse();
            if (chatResponse.data != null)
            {
                //chatResponse = JsonHelper.DeserializeJsonToObject<ChatResponse>(apiResponse);
                chatResponse.data.data.Sort((left, right) =>
                {
                    if (int.Parse(left.id) > int.Parse(right.id))
                        return 1;
                    else if (int.Parse(left.id) == int.Parse(right.id))
                        return 0;
                    else
                        return -1;
                });
            }
            //UserProfileResponse currentUser = userRequest.profile(token, "");
            //ViewBag.currrentUserid = currentUser.data.id;
            //chatResponse.data.data
            string jsonResponse = JsonHelper.SerializeObject(chatResponse);
            return jsonResponse;
        }

        public string SearchHospitalUsers(string searchContext)

        {
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            var currentUserId = Session["CurrentUserID"] == null ? "-1" : Session["CurrentUserID"].ToString();
            var currentUserHospitalID = Session["CurrentUserHospitalID"] == null ? "-1" : Session["CurrentUserHospitalID"].ToString();
            var currentUserRole = Session["role"] == null ? "XXXXXXX" : Session["role"].ToString();
            //UserProfileResponse user = userRequest.profile(token, "");

            //获取所有用户
            //HospitalUserProfileResponse hospitalUsers = new HospitalUserProfileResponse();
            //hospitalUsers = userRequest.SearchUsers(token, currentUserHospitalID, searchContext);
            //ProjectRelativeUserResponse projectRelativeUserResponse = new ProjectRelativeUserResponse();
            ProjectRelativeUserResponse projectRelativeUserResponse = new ProjectRelativeUserResponse();

            projectRelativeUserResponse = projectRequest.ProjectRelativeUsers(token, "", searchContext);
            //FilterBusersByCurrentUserRole(projectRelativeUserResponse, currentUserRole, currentUserId);
            string jsonResponse = JsonHelper.SerializeObject(projectRelativeUserResponse);
            return jsonResponse;
        }

        public List<UserDataEntity> FilterBusersByCurrentUserRole(Dictionary<string, UserDataEntity> messageUserList, string currentUserRole, string currentUserId)
        {
            List<UserDataEntity> userList = new List<UserDataEntity>();
            foreach (UserDataEntity val in messageUserList.Values)
            {
                userList.Add(val);
            }

            List<UserDataEntity> removedItems = new List<UserDataEntity>();
            switch (currentUserRole)
            {
                case "90":
                case "80":
                case "20":
                case "10":
                    foreach (UserDataEntity item in userList)
                    {
                        if (item.dataId == currentUserId)
                        {
                            removedItems.Add(item);
                        }
                    }
                    break;
                case "-10":
                    foreach (UserDataEntity item in userList)
                    {
                        if (item.dataId == currentUserId || item.role == "-10" || item.role == "20" || item.role == "80" || item.role == "90")
                        {
                            removedItems.Add(item);
                        }
                    }
                    break;
            }

            foreach (UserDataEntity remove in removedItems)
            {
                userList.Remove(remove);
            }
            return userList;
        }


        [HttpPost]
        public string SendMessage(string userids, string messageContext)
        {
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            string apiResponse = string.Empty;
            try
            {
                apiResponse = messageRequest.send(token, "0", userids, messageContext, "", "");
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("SendMessage", AppLog.LogMessageType.Error, ex);
            }
            return apiResponse;
        }

        [HttpPost]
        public string UpdateBroadcast(string broadcastContext)
        {
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            string apiResponse = string.Empty;
            try
            {
                apiResponse = messageRequest.send(token, "0", "", broadcastContext, "", "");
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("UpdateBroadcast", AppLog.LogMessageType.Error, ex);
            }
            return apiResponse;
        }

        public string NewBroadcast(string newBroadcastLabel, string newBroadcastContext, string newBroadcastProjectList, string attachmentUrl)
        {
            var currentUserRole = Session["role"] == null ? "XXXXXXX" : Session["role"].ToString();
            //if (currentUserRole == "90" && newBroadcastProjectList == "")
            //{
            //    newBroadcastProjectList = "0";
            //}
            if (newBroadcastProjectList.Contains("0") == true)
            {
                newBroadcastProjectList = "0";
            }
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            string apiResponse = string.Empty;
            try
            {
                apiResponse = messageRequest.send(token, "10", newBroadcastProjectList, newBroadcastContext, attachmentUrl, newBroadcastLabel);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("NewBroadcast", AppLog.LogMessageType.Error, ex);
            }
            return apiResponse;
        }

        public string GetTplDetail(string id)
        {
            string strJson = string.Empty;
            try
            {
                var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
                TplDetailResponse tpldetail = new TplDetailResponse();
                tpldetail = tplRequest.TplDetail(token, id);
                if (tpldetail.code == 0)
                {
                    tpldetail.data.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.termid) - Convert.ToInt32(right.termid)));
                    tpldetail.data.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.sharpid2) - Convert.ToInt32(right.sharpid2)));
                    tpldetail.data.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.sharpid) - Convert.ToInt32(right.sharpid)));

                    strJson = JsonHelper.SerializeObject(tpldetail);
                }
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("GetTplDetail", AppLog.LogMessageType.Error, ex);
            }
            return strJson;
        }

        [HttpPost]
        public string CommitTplReport(string tplId, string periodid, string detailids, string answers, string patientid)
        {
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            string apiResponse = string.Empty;
            try
            {
                string reportName = "模板报告" + DateTime.Now.ToShortDateString();
                string reportRemark = "模板报告" + DateTime.Now.ToShortDateString();
                apiResponse = tplRequest.TplReportCommit(token, tplId, periodid, detailids, answers, patientid);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("CommitTplReport", AppLog.LogMessageType.Error, ex);
            }
            return apiResponse;
        }

        public string GetTplReportDetail(string tplId, string periodId)
        {
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            string apiResponse = string.Empty;
            TplReportDetailResponse trdr = new TplReportDetailResponse();
            try
            {
                trdr = tplRequest.TplReportDetailObject(token, tplId, periodId);
                if (trdr.code == 0)
                {
                    trdr.data.tpl.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.termid) - Convert.ToInt32(right.termid)));
                    trdr.data.tpl.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.sharpid2) - Convert.ToInt32(right.sharpid2)));
                    trdr.data.tpl.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.sharpid) - Convert.ToInt32(right.sharpid)));
                    apiResponse = JsonHelper.SerializeObject(trdr);
                }
                else
                {
                    APIResponseBase ar = new APIResponseBase { code = 404, message = "报告不存在" };
                    apiResponse = JsonHelper.SerializeObject(ar);
                }


            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("GetTplReportDetail", AppLog.LogMessageType.Error, ex);
            }
            return apiResponse;
        }

        public string GetTplReportDetailById(string id)
        {
            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            string apiResponse = string.Empty;
            TplReportDetailResponse trdr = new TplReportDetailResponse();
            try
            {
                trdr = tplRequest.TplReportDetailByIdObject(token, id);
                trdr.data.tpl.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.termid) - Convert.ToInt32(right.termid)));
                trdr.data.tpl.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.sharpid2) - Convert.ToInt32(right.sharpid2)));
                trdr.data.tpl.tpl_detail.Sort((left, right) => (Convert.ToInt32(left.sharpid) - Convert.ToInt32(right.sharpid)));

                apiResponse = JsonHelper.SerializeObject(trdr);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("GetTplReportDetailById", AppLog.LogMessageType.Error, ex);
            }
            return apiResponse;
        }

        //添加病人
        public string addpatient(string projectId, string doctorId, string hospitalId, string patientId, string userName, string mobile, string idCard, bool overwrite, string height, string weight, string address, string tel, string num_il, string ethnic, string sex)
        {
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = projectRequest.PatientAppend(token, projectId, doctorId, patientId, userName, mobile, idCard, overwrite, height, weight, address, tel, num_il, ethnic, sex);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("addpatient", AppLog.LogMessageType.Error, ex);
            }

            return apiResponse;
        }
        //保存资料
        public string saveInforamtion(string username, string mobile, string email, string idcard, string avatar, string userId, string sex, string ethnic, string height, string weight, string address, string doctorid)
        {
            UserRequest user = new UserRequest();
            string apiResponse = string.Empty;

            var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
            try
            {
                apiResponse = user.getProfile(token, username, email, "", avatar, sex, ethnic, height, weight, address, doctorid);
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("saveInforamtion", AppLog.LogMessageType.Error, ex);
            }

            return apiResponse;
        }

        public string GetTplListByKindId(string kindid)
        {
            string strJson = string.Empty;
            try
            {
                var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
                TplRequest tr = new TplRequest();
                TplListResponse tpllist = tr.TplList(token, kindid, "");
                strJson = JsonHelper.SerializeObject(tpllist);
            }
            catch (Exception ex)
            {

                AppLog.Instance.Write("GetTplListByKindId", AppLog.LogMessageType.Error, ex);
            }
            return strJson;
        }

        public string TplReportList(string tplid, string patientid)
        {
            string strJson = string.Empty;
            try
            {
                var token = Session["token"] == null ? "XXXXXXX" : Session["token"].ToString();
                strJson = tplRequest.TplReportListString(token, tplid, patientid);
            }
            catch (Exception ex)
            {

                AppLog.Instance.Write("TplReportList", AppLog.LogMessageType.Error, ex);
            }
            return strJson;
        }
    }
}