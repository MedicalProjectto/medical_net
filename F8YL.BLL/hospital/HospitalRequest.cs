using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F8YL.Model;

namespace F8YL.BLL
{
    public class HospitalRequest
    {
        /// <summary>
        /// 8、	注册(创建)医院
        /// </summary>
        /// <param name="title">医院名称</param>
        /// <param name="contact">联系人</param>
        /// <param name="idcard">18位身份证</param>
        /// <param name="mobile">手机，后6位为管理员的登录密码</param>
        /// <returns></returns>
        /// Jack Ding
        public HospitalRegisterResponse Register(string token, string title, string contact, string idcard, string mobile, string address, string telphone, string deptname)
        {
            string strResponse = string.Empty;
            HospitalRegisterResponse response = new HospitalRegisterResponse();

            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("title", title);
                sPara.Add("contact", contact);
                sPara.Add("idcard", idcard);
                sPara.Add("mobile", mobile);
                sPara.Add("address", address);
                sPara.Add("tel", telphone);
                sPara.Add("deptname", deptname);

                strResponse = F8YLSubmit.BuildRequest(sPara, "hospital/register?token=" + token);

                response = JsonHelper.DeserializeJsonToObject<HospitalRegisterResponse>(strResponse);

                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 9、	搜索医院
        /// </summary>
        /// <param name="q">关系字</param>
        /// <param name="page">分页id</param>
        /// <param name="name">指标名称(糊糊)</param>
        /// <param name="token">token</param>
        /// <returns></returns>
        /// Jack Ding
        public HospitalSearchResponse Search(string token, int page, string name)
        {
            string strResponse = string.Empty;
            HospitalSearchResponse response = new HospitalSearchResponse();

            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                //sPara.Add("q", q.ToString());
                sPara.Add("page", page.ToString());
                sPara.Add("name", name);
                strResponse = F8YLSubmit.BuildGetRequest(sPara, "hospital/search?token=" + token);

                response = JsonHelper.DeserializeJsonToObject<HospitalSearchResponse>(strResponse);

                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 10、	医院详情
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="id">指标id</param>
        /// <returns></returns>
        /// Jack Ding
        public HospitalDetailResponse Detail(string token, int id)
        {
            string strResponse = string.Empty;
            HospitalDetailResponse response = new HospitalDetailResponse();

            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("id", id.ToString());
                strResponse = F8YLSubmit.BuildGetRequest(sPara, "hospital/detail?token=" + token);

                response = JsonHelper.DeserializeJsonToObject<HospitalDetailResponse>(strResponse);

                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 更新医院信息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="id">医院id</param>
        /// <param name="info">更新信息</param>
        /// <returns></returns>
        public string Edit(string token, string id, HospitalEntity info)
        {
            string strResponse = string.Empty;
            //HospitalDetailResponse response = new HospitalDetailResponse();
            //string id, string title, string contact, string mobile, string address
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("id", id);
                foreach (System.Reflection.PropertyInfo p in info.GetType().GetProperties())
                {
                    if (p.Name == "title")
                    {
                        sPara.Add(p.Name, p.GetValue(info).ToString());
                    }
                    else if (p.Name == "contact")
                    {
                        sPara.Add(p.Name, p.GetValue(info).ToString());
                    }
                    else if (p.Name == "mobile")
                    {
                        sPara.Add(p.Name, p.GetValue(info).ToString());
                    }
                    else if (p.Name == "address")
                    {
                        sPara.Add(p.Name, p.GetValue(info).ToString());
                    }
                    else if (p.Name == "telphone")
                    {
                        sPara.Add(p.Name, p.GetValue(info).ToString());
                    }
                    else if (p.Name == "deptname")
                    {
                        sPara.Add(p.Name, p.GetValue(info).ToString());
                    }
                    //if (p.Name != "id" || p.Name != "adminid")
                    //{
                    //    sPara.Add(p.Name, p.GetValue(info).ToString());
                    //}

                }

                strResponse = F8YLSubmit.BuildRequest(sPara, "hospital/detail?token=" + token);

                //response = JsonHelper.DeserializeJsonToObject<HospitalDetailResponse>(strResponse);

                return strResponse;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 禁用医院
        /// </summary>
        /// <param name="token"></param>
        /// <param name="id">医院id</param>
        /// <returns></returns>
        public string Disable(string token, string id)
        {
            string strResponse = string.Empty;

            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("hospitalid", id);

                strResponse = F8YLSubmit.BuildRequest(sPara, "hospital/status/disable?token=" + token);

                //response = JsonHelper.DeserializeJsonToObject<HospitalDetailResponse>(strResponse);

                return strResponse;
            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("Drop Hospital Error.", AppLog.LogMessageType.Error, ex);
            }
            return strResponse;
        }

    }
}
