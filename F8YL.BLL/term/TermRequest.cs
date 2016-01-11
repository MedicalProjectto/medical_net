using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F8YL.Model;

namespace F8YL.BLL.term
{
    public class TermRequest
    {
        /// <summary>
        /// 11、	添加指标
        /// </summary>
        /// <param name="name">指标名称</param>
        /// <param name="itype">输入方式</param>
        /// <param name="vtype">值类型</param>
        /// <param name="editbypat">是否可由病人编辑</param>
        /// <param name="hospitalid">医院id</param>
        /// <param name="cateid">病例分类id</param>
        /// <param name="val">值序列,以数组形式传递,可为空</param>
        /// <returns></returns>
        /// Jack Ding
        public TermAddResponse Add(string name, int itype, int vtype, int editbypat, int hospitalid, int cateid, double[] val)
        {
            string strResponse = string.Empty;
            TermAddResponse response = new TermAddResponse();

            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("name", name);
                sPara.Add("itype", itype.ToString());
                sPara.Add("vtype", vtype.ToString());
                sPara.Add("editbypat", editbypat.ToString());
                sPara.Add("hospitalid", hospitalid.ToString());
                //val参数不知道如何添加

                strResponse = F8YLSubmit.BuildRequest(sPara, "term/add");

                response = JsonHelper.DeserializeJsonToObject<TermAddResponse>(strResponse);

                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 12、	指标列表
        /// </summary>
        /// <param name="hospitalid">医院id</param>
        /// <param name="page">分页id</param>
        /// <param name="name">指标名称(糊糊)</param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// Jack Ding
        public TermListResponse List(int hospitalid, int page, string name, string token)
        {
            string strResponse = string.Empty;
            TermListResponse response = new TermListResponse();

            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("hospitalid", hospitalid.ToString());
                sPara.Add("page", page.ToString());
                sPara.Add("name", name);
                strResponse = F8YLSubmit.BuildGetRequest(sPara, "term/list?token=" + token);

                response = JsonHelper.DeserializeJsonToObject<TermListResponse>(strResponse);

                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 13、	删除指标
        /// </summary>
        /// <param name="id">要删除的指标id</param>
        /// <returns></returns>
        /// Jack Ding
        public TermDropResponse Drop(int id)
        {
            string strResponse = string.Empty;
            TermDropResponse response = new TermDropResponse();

            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("id", id.ToString());

                strResponse = F8YLSubmit.BuildRequest(sPara, "term/drop");

                response = JsonHelper.DeserializeJsonToObject<TermDropResponse>(strResponse);

                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 14、	指标详细设置与获取
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="id">指标id</param>
        /// <returns></returns>
        /// Jerry Shi
        public TermDetailResponse TermDetail (string token, string id)
        {
            try
            {
                string ApiResponse = string.Empty;
                TermDetailResponse termDetailResponse = new TermDetailResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("id", id);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "term/detail?token=" + token);
                termDetailResponse = JsonHelper.DeserializeJsonToObject<TermDetailResponse>(ApiResponse);

                return termDetailResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
