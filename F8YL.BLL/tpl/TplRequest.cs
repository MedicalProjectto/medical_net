using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using F8YL.Model;

namespace F8YL.BLL
{
    public class TplRequest
    {
        /// <summary>
        /// 15、	创建模板
        /// </summary>
        /// <param name="name">模板名称</param>
        /// <param name="period">周期(应大于0)</param>
        /// <param name="freqs">一个周其内的次研究次数</param>
        /// <param name="editbypat">是否可由病人编辑</param>
        /// <param name="kindid">模板种类id(如:10:术前,20:访问等)</param>
        /// <param name="remark">简要说明</param>
        /// <param name="sharpid">它的作用是为了将一个模板中的指标人为地分若干个片</param>
        /// <param name="termid"></param>
        /// <returns></returns>
        /// Jack Ding
        public TplCreateResponse TplCreate(string name, int period, int freqs, int editbypat, int kindid, string remark, int[] sharpid, int[] termid, string token)
        {
            string strResponse = string.Empty;
            TplCreateResponse response = new TplCreateResponse();

            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("name", name);
                sPara.Add("period", period.ToString());
                sPara.Add("freqs", freqs.ToString());
                sPara.Add("editbypat", editbypat.ToString());
                sPara.Add("kindid", kindid.ToString());
                sPara.Add("remark", remark);

                Dictionary<string, string[]> sParas = new Dictionary<string, string[]>();
                sParas.Add("sharpid[]", Array.ConvertAll(sharpid, new Converter<int, string>(F8YLCore.IntToStr)));
                sParas.Add("termid[]", Array.ConvertAll(termid, new Converter<int, string>(F8YLCore.IntToStr)));

                strResponse = F8YLSubmit.BuildRequest(sParas, sPara, "tpl/create?token=" + token);

                response = JsonHelper.DeserializeJsonToObject<TplCreateResponse>(strResponse);

                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 16、	模板列表
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="kindid">模板分类id</param>
        /// <param name="page">分页id</param>
        /// <returns></returns>
        /// Jerry Shi
        public TplListResponse TplList(string token, string kindid, string page)
        {
            try
            {
                string ApiResponse = string.Empty;
                TplListResponse tplListResponse = new TplListResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                //不需要传，不可以为空
                if (!string.IsNullOrEmpty(kindid))
                {
                    sPara.Add("kindid", kindid);
                }

                //sPara.Add("page", page);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "tpl/list?token=" + token);
                tplListResponse = JsonHelper.DeserializeJsonToObject<TplListResponse>(ApiResponse);

                return tplListResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 17、	删除模板
        /// </summary>
        /// <param name="id">要删除的模板id</param>
        /// <returns></returns>
        /// Jack Ding
        public TplDropResponse TplDrop(int id, string token)
        {
            string strResponse = string.Empty;
            TplDropResponse response = new TplDropResponse();

            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("id", id.ToString());

                strResponse = F8YLSubmit.BuildRequest(sPara, "tpl/drop?token=" + token);

                response = JsonHelper.DeserializeJsonToObject<TplDropResponse>(strResponse);

                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 18、	获取模板详情
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="id">要查询的模板id</param>
        /// <returns></returns>
        public TplDetailResponse TplDetail(string token, string id)
        {
            try
            {
                string ApiResponse = string.Empty;
                TplDetailResponse tplDetailResponse = new TplDetailResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("id", id);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "tpl/detail?token=" + token);

                tplDetailResponse = JsonHelper.DeserializeJsonToObject<TplDetailResponse>(ApiResponse);
                //tplDetailResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TplDetailResponse>(ApiResponse);

                return tplDetailResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 18、	get方式获取模板详情
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="id">要查询的模板id</param>
        /// <returns></returns>
        public string getTplDetail(string token, string id)
        {
            try
            {
                string ApiResponse = string.Empty;
                TplDetailResponse tplDetailResponse = new TplDetailResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("id", id);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "tpl/detail?token=" + token);


                //ApiResponse = "{\"code\": \"0\", \"message\": null, \"data\": {\"id\": \"11\", \"userid\": \"12\", \"hospitalid\": \"9951480\", \"name\": \"检查\", \"period\": \"0\", \"freqs\": \"1\", \"kindid\": \"20\", \"editbypat\": \"0\", \"remark\": \"随访模板\", \"ctime\": \"2015-11-17 17:11:44\", \"utime\": \"2015-11-18 10:45:18\", \"tpl_detail\": [{\"id\": \"32\", \"tplid\": \"11\", \"sharpid\": \"7\", \"sharpid2\": \"9\", \"termid\": \"20\", \"sorter\": \"0\", \"term\": {\"id\": \"20\", \"cateid\": \"0\", \"hospitalid\": \"0\", \"userid\": \"0\", \"name\": \"癌胚抗原\", \"itype\": \"10\", \"vtype\": \"2\", \"unit\": \"\", \"editbypat\": \"0\", \"term_val\": [{\"id\": \"52\", \"termid\": \"20\", \"val\": \"1000000\", \"desc\": \"\", \"sorter\": \"126\"}, {\"id\": \"51\", \"termid\": \"20\", \"val\": \"0\", \"desc\": \"\", \"sorter\": \"127\"}]}}, {\"id\": \"35\", \"tplid\": \"11\", \"sharpid\": \"7\", \"sharpid2\": \"10\", \"termid\": \"20\", \"sorter\": \"0\", \"term\": {\"id\": \"20\", \"cateid\": \"0\", \"hospitalid\": \"0\", \"userid\": \"0\", \"name\": \"癌胚抗原\", \"itype\": \"10\", \"vtype\": \"2\", \"unit\": \"\", \"editbypat\": \"0\", \"term_val\": [{\"id\": \"52\", \"termid\": \"20\", \"val\": \"1000000\", \"desc\": \"\", \"sorter\": \"126\"}, {\"id\": \"51\", \"termid\": \"20\", \"val\": \"0\", \"desc\": \"\", \"sorter\": \"127\"}]}}, {\"id\": \"36\", \"tplid\": \"11\", \"sharpid\": \"7\", \"sharpid2\": \"10\", \"termid\": \"15\", \"sorter\": \"127\", \"term\": {\"id\": \"15\", \"cateid\": \"0\", \"hospitalid\": \"0\", \"userid\": \"0\", \"name\": \"CA125\", \"itype\": \"10\", \"vtype\": \"2\", \"unit\": \"U/ml\", \"editbypat\": \"0\", \"term_val\": [{\"id\": \"31\", \"termid\": \"15\", \"val\": \"0\", \"desc\": \"\", \"sorter\": \"127\"}, {\"id\": \"32\", \"termid\": \"15\", \"val\": \"1000000\", \"desc\": \"\", \"sorter\": \"126\"}]}}, {\"id\": \"43\", \"tplid\": \"11\", \"sharpid\": \"8\", \"sharpid2\": \"12\", \"termid\": \"16\", \"sorter\": \"127\", \"term\": {\"id\": \"16\", \"cateid\": \"0\", \"hospitalid\": \"0\", \"userid\": \"0\", \"name\": \"白细胞计数\", \"itype\": \"10\", \"vtype\": \"2\", \"unit\": \"109/L\", \"editbypat\": \"0\", \"term_val\": [{\"id\": \"33\", \"termid\": \"16\", \"val\": \"0\", \"desc\": \"\", \"sorter\": \"127\"}, {\"id\": \"34\", \"termid\": \"16\", \"val\": \"1000000\", \"desc\": \"\", \"sorter\": \"126\"}]}}, {\"id\": \"44\", \"tplid\": \"11\", \"sharpid\": \"8\", \"sharpid2\": \"12\", \"termid\": \"24\", \"sorter\": \"125\", \"term\": {\"id\": \"24\", \"cateid\": \"0\", \"hospitalid\": \"0\", \"userid\": \"0\", \"name\": \"淋巴细胞绝对值\", \"itype\": \"10\", \"vtype\": \"2\", \"unit\": \"109/L\", \"editbypat\": \"0\", \"term_val\": [{\"id\": \"59\", \"termid\": \"24\", \"val\": \"0\", \"desc\": \"\", \"sorter\": \"127\"}, {\"id\": \"60\", \"termid\": \"24\", \"val\": \"100000\", \"desc\": \"\", \"sorter\": \"126\"}]}}], \"sharp\": {\"7\": {\"id\": \"7\", \"name\": \"肿瘤标记物\", \"parentid\": \"0\"}, \"8\": {\"id\": \"8\", \"name\": \"血生化\", \"parentid\": \"0\"}, \"9\": {\"id\": \"9\", \"name\": \"术前肿瘤标志物\", \"parentid\": \"7\"}, \"10\": {\"id\": \"10\", \"name\": \"术后、随访肿瘤标志物\", \"parentid\": \"7\"}, \"11\": {\"id\": \"11\", \"name\": \"入院时、术前一天血生化\", \"parentid\": \"8\"}, \"12\": {\"id\": \"12\", \"name\": \"术后一天、术后七天血生化\", \"parentid\": \"8\"}}}}";

                //ApiResponse = "1234";
                return ApiResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 19、	模板变换(修改)
        /// </summary>
        /// <param name="period">data中的period周期</param>
        /// <param name="freqs">data中的freqs频次</param>
        /// <param name="termids">tpl_detail中的termid数组</param>
        /// <param name="ids">tpl_detail中的id数组</param>
        /// <param name="editbypats">tpl_detail中的editbypat数组</param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// Gerry Ge
        public string TplChange(string id, string period, string freqs, string termids, string ids, string editbypats, string token)
        {
            string strResponse = string.Empty;
            TplChangeResponse response = new TplChangeResponse();

            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("period", period);
                sPara.Add("freqs", freqs);

                Dictionary<string, string[]> sParas = new Dictionary<string, string[]>();
                string[] Tpltermids = termids.Split(',');
                string[] Tplids = ids.Split(',');
                string[] Tpleditbypats = editbypats.Split(',');
                sParas.Add("id[]", Tplids);
                sParas.Add("termid[]", Tpltermids);
                sParas.Add("editbypat[]", Tpleditbypats);

                strResponse = F8YLSubmit.BuildRequest(sParas, sPara, "tpl/change?token=" + token + "&id=" + id);

                //response = JsonHelper.DeserializeJsonToObject<TplChangeResponse>(strResponse);

                return strResponse;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 20、	模板报告－列表
        /// </summary>
        /// <param name="token"></param>
        /// <param name="tplid">模板id</param>
        /// <param name="page">分页id</param>
        /// <returns></returns>
        /// Jack Ding
        public TplReportListResponse TplReportList(string token, string tplid, string patientid)
        {
            try
            {
                string ApiResponse = string.Empty;
                TplReportListResponse response = new TplReportListResponse();

                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("tplid", tplid);
                sPara.Add("patientid", patientid);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "tpl/report/list?token=" + token);
                response = JsonHelper.DeserializeJsonToObject<TplReportListResponse>(ApiResponse);

                return response;
            }
            catch
            {
                throw;
            }
        }

        public string TplReportListString(string token, string tplid, string patientid)
        {
            try
            {
                string ApiResponse = string.Empty;
                TplReportListResponse response = new TplReportListResponse();

                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("tplid", tplid);
                sPara.Add("patientid", patientid);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "tpl/report/list?token=" + token);

                return ApiResponse;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 21、	模板报告－详情
        /// </summary>
        /// <param name="token"></param>
        /// <param name="id">报告id</param>
        /// <returns></returns>
        /// Jack Ding
        public string TplReportDetail(string token, string tplId, string periodId)
        {
            try
            {
                string ApiResponse = string.Empty;
                //TplReportDetailResponse response = new TplReportDetailResponse();

                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("tplid", tplId);
                sPara.Add("periodid", periodId);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "tpl/report/detail?token=" + token);
                //response = JsonHelper.DeserializeJsonToObject<TplReportDetailResponse>(ApiResponse);

                return ApiResponse;
            }
            catch
            {
                throw;
            }
        }

        public TplReportDetailResponse TplReportDetailObject(string token, string tplId, string periodId)
        {

            try
            {
                string ApiResponse = string.Empty;
                TplReportDetailResponse response = new TplReportDetailResponse();

                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("tplid", tplId);
                sPara.Add("periodid", periodId);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "tpl/report/detail?token=" + token);
                response = JsonHelper.DeserializeJsonToObject<TplReportDetailResponse>(ApiResponse);

                return response;
            }
            catch
            {
                throw;
            }
        }

        public TplReportDetailResponse TplReportDetailByIdObject(string token, string id)
        {

            try
            {
                string ApiResponse = string.Empty;
                TplReportDetailResponse response = new TplReportDetailResponse();

                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("id", id);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "tpl/report/detail?token=" + token);
                response = JsonHelper.DeserializeJsonToObject<TplReportDetailResponse>(ApiResponse);

                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 22、	提交报告(保存调研报告)
        /// </summary>
        /// <param name="tplid">模板id</param>
        /// <param name="name">报告的title</param>
        /// <param name="remark">报告简要说明</param>
        /// <param name="id">如果存在表示修改</param>
        /// <param name="detailid">特别注意:这个id来自于”模板”与”指标”之间的那个关系id</param>
        /// <param name="answer">答案值</param>
        /// <returns></returns>
        /// Jack Ding
        public string TplReportCommit(string token, string tplid, string periodid, string detailids, string answers, string patientid)
        {
            string apiResponse = string.Empty;
            //TplReportCommitResponse response = new TplReportCommitResponse();
            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                sPara.Add("tplid", tplid);
                sPara.Add("periodid", periodid);
                sPara.Add("patientid", patientid);

                Dictionary<string, string[]> sParas = new Dictionary<string, string[]>();

                string[] reportDetailIds = detailids.Substring(0, detailids.Length - 1).Split('$');
                string[] reportAnswers = reportAnswers = answers.Substring(0, answers.Length - 1).Split('$');

                sParas.Add("detailid[]", reportDetailIds);
                sParas.Add("answer[]", reportAnswers);

                apiResponse = F8YLSubmit.BuildRequest(sParas, sPara, "tpl/report/commit?token=" + token);

                //apiResponse = JsonHelper.DeserializeJsonToObject<TplReportCommitResponse>(strResponse);

                return apiResponse;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 23、	模板分类列表
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="page">分页id(未启用)</param>
        /// <returns></returns>
        /// Jerry Shi
        public TplKindListResponse TplKindList(string token, string page)
        {
            try
            {
                string ApiResponse = string.Empty;
                TplKindListResponse tplKindListResponse = new TplKindListResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("page", page);

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "tpl/kind/list?token=" + token);
                tplKindListResponse = JsonHelper.DeserializeJsonToObject<TplKindListResponse>(ApiResponse);

                return tplKindListResponse;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 24、	添加一个模板分类
        /// </summary>
        /// <param name="name">分类的名称</param>
        /// <returns></returns>
        /// Jack Ding
        public TplKindAddResponse TplKindAdd(string name, string token)
        {
            string strResponse = string.Empty;
            TplKindAddResponse response = new TplKindAddResponse();

            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("name", name);

                strResponse = F8YLSubmit.BuildRequest(sPara, "tpl/kind/add?token=" + token);

                response = JsonHelper.DeserializeJsonToObject<TplKindAddResponse>(strResponse);

                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 25、	删除一个模板分类
        /// </summary>
        /// <param name="id">分类id</param>
        /// <returns></returns>
        /// Jack Ding
        public TplKindDropResponse TplKindDrop(int id, string token)
        {
            string strResponse = string.Empty;
            TplKindDropResponse response = new TplKindDropResponse();

            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("id", id.ToString());

                strResponse = F8YLSubmit.BuildRequest(sPara, "tpl/kind/drop?token=" + token);

                response = JsonHelper.DeserializeJsonToObject<TplKindDropResponse>(strResponse);

                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 26、	模板的指标的分片列表
        /// </summary>
        /// <param name="token"></param>
        /// <param name="tplid">模板id</param>
        /// <returns></returns>
        public TplSharpListResponse TplSharpList(string token, int tplid)
        {
            try
            {
                string ApiResponse = string.Empty;
                TplSharpListResponse response = new TplSharpListResponse();

                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("tplid", tplid.ToString());

                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "tpl/sharp/list?token=" + token);
                response = JsonHelper.DeserializeJsonToObject<TplSharpListResponse>(ApiResponse);

                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 27、	添加一个模板的指标分片
        /// </summary>
        /// <param name="tplid">模板id</param>
        /// <param name="name">分类的名称</param>
        /// <returns></returns>
        /// Jack Ding
        public TplSharpAddResponse TplSharpAdd(int tplid, string name, string token)
        {
            string strResponse = string.Empty;
            TplSharpAddResponse response = new TplSharpAddResponse();

            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("tplid", tplid.ToString());
                sPara.Add("name", name);

                strResponse = F8YLSubmit.BuildRequest(sPara, "tpl/sharp/add?token=" + token);

                response = JsonHelper.DeserializeJsonToObject<TplSharpAddResponse>(strResponse);

                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 28、	删除一个模板的指标分片
        /// </summary>
        /// <param name="id">分类id</param>
        /// <returns></returns>
        /// Jack Ding
        public TplSharpDropResponse TplSharpDrop(int id, string token)
        {
            string strResponse = string.Empty;
            TplSharpDropResponse response = new TplSharpDropResponse();

            try
            {
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("id", id.ToString());

                strResponse = F8YLSubmit.BuildRequest(sPara, "tpl/sharp/drop?token=" + token);

                response = JsonHelper.DeserializeJsonToObject<TplSharpDropResponse>(strResponse);

                return response;
            }
            catch
            {
                throw;
            }
        }

    }
}
