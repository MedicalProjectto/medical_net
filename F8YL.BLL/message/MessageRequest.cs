using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using F8YL.Model;

namespace F8YL.BLL
{
    /// <summary>
    /// 类名：MessageRequest
    /// 功能：Message操作（drop，chat...）
    /// 作者：Gerry Ge
    /// 创建日期：2015-12-10
    /// 修改日期：2015-12-10
    public class MessageRequest
    {
        /// <summary>
        /// 48、	消息发送
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="type">10为公告; 0为消息 type=10,targetid=项目id --表示项目公告；2,type=0,targetid=0--表示广播消息；3,type=0,targetid=用户id--表示发送好友消息;</param>
        /// <param name="targetid">当type为10时,targerid可以为项目id或userid，如果它为空且type为0就表示广播</param>
        /// <param name="content">消息内容</param>
        /// <param name="url">完整的url信息，表示该消息要链接到目标地址</param>
        /// <param name="label">要显示的文本</param>
        /// <returns></returns>
        public string send(string token, string type, string targetid, string content, string url, string label)
        {
            try
            {
                string ApiResponse = string.Empty;
                //RecvResponse recvResponse = new RecvResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("type", type);
                //string targetParam = "&";
                //string[] tID = targetid.Split(',');
                //for (int i = 0; i < tID.Length; i++)
                //{
                //    targetParam = targetParam + "targetid[]=" + tID[i] + "&";
                //}
                //targetParam = targetParam.Substring(0, targetParam.Length - 1);
                string[] tID = targetid.Split(',');
                Dictionary<string, string[]> sParas = new Dictionary<string, string[]>();
                sParas.Add("targetid[]", tID);

                sPara.Add("content", content);
                sPara.Add("url", url);
                sPara.Add("label", label);
                ApiResponse = F8YLSubmit.BuildRequest(sParas, sPara, "message/send?token=" + token);  //+ targetParam
                //recvResponse = JsonHelper.DeserializeJsonToObject<RecvResponse>(ApiResponse);

                return ApiResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 49、	接收消息  获取别人发给当前用户的所有消息 用于获取别人发给自己的消息
        /// </summary>
        /// <param name="type">消息类型</param>
        /// <param name="date">查询起始时间;默认值：上月一号</param>
        /// <returns></returns>
        /// Jerry Shi
        public RecvResponse Recv(string token, string type, string date, string targetid)
        {
            try
            {
                string ApiResponse = string.Empty;
                RecvResponse recvResponse = new RecvResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("type", type);
                sPara.Add("date", date);
                if (targetid != string.Empty)
                {
                    sPara.Add("targetid", targetid);
                }
                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "message/recv?token=" + token);
                recvResponse = JsonHelper.DeserializeJsonToObject<RecvResponse>(ApiResponse);

                return recvResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 50、	获取与某人(好友)之间的消息记录
        /// </summary>
        /// <param name="id">好友userid，如果为空表示获取当前用户的消息 [ id不传是获取好友发给自己的消息; 传就是我发给这个人的]</param>
        /// <param name="page">分页id</param>
        /// <returns></returns>
        /// Jerry Shi
        public ChatResponse Chat(string token, string id)
        {
            try
            {
                string ApiResponse = string.Empty;
                ChatResponse chatResponse = new ChatResponse();
                Dictionary<string, string> sPara = new Dictionary<string, string>();
                if (id != string.Empty)
                {
                    sPara.Add("id", id);
                }
                ApiResponse = F8YLSubmit.BuildGetRequest(sPara, "message/chat?token=" + token);
                if (!ApiResponse.Contains("[]"))
                {
                    chatResponse = JsonHelper.DeserializeJsonToObject<ChatResponse>(ApiResponse);
                }
                return chatResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 51、	删除消息
        /// </summary>
        /// <param name="id">要删除的消息id</param>
        /// <returns></returns>
        /// Jerry Shi
        public string Drop(string token, string id)
        {
            try
            {
                string ApiResponse = string.Empty;
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("id", id);
                ApiResponse = F8YLSubmit.BuildRequest(sPara, "message/drop?token=" + token);

                return ApiResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 53、	上传接口
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="Filedata">web端上传:它是一个FILES值</param>
        /// <returns></returns>
        /// Jerry Shi
        public string UploadWeb(string token, string Filedata)
        {
            try
            {
                string ApiResponse = string.Empty;
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("Filedata", Filedata);
                ApiResponse = F8YLSubmit.BuildRequest(sPara, "upload/web?token=" + token);

                return ApiResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 54、	下载接口
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="Filedata">手机商上传:它是一普通的post参数，它的值为file文件的base64编码</param>
        /// <returns></returns>
        /// Jerry Shi
        public string UploadMobile(string token, string Filedata)
        {
            try
            {
                string ApiResponse = string.Empty;
                Dictionary<string, string> sPara = new Dictionary<string, string>();

                sPara.Add("Filedata", Filedata);
                ApiResponse = F8YLSubmit.BuildRequest(sPara, "upload/mobile?token=" + token);

                return ApiResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
