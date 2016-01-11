using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace F8YL.BLL
{
    /// <summary>
    /// 类名：F8YLSubmit
    /// 功能：请求
    /// 作者：Gerry Ge
    /// 创建日期：2015-12-08
    /// 修改日期：2015-12-08
    public class F8YLSubmit
    {
        #region 字段
        //API网关地址（新）
        private static string GATEWAY_NEW = "http://139.196.192.14/";
        //商户的私钥
        private static string _key = "";
        //编码格式
        private static string _input_charset = "";
        //签名方式
        private static string _sign_type = "";
        #endregion

        static F8YLSubmit()
        {
            _key = F8YLConfig.Key.Trim();
            _input_charset = F8YLConfig.Input_charset.Trim().ToLower();
            _sign_type = F8YLConfig.Sign_type.Trim().ToUpper();
        }

        /// <summary>
        /// 生成要请求给支付宝的参数数组
        /// </summary>
        /// <param name="sParaTemp">请求前的参数数组</param>
        /// <param name="code">字符编码</param>
        /// <returns>要请求的参数数组字符串</returns>
        private static string BuildRequestParaToString(Dictionary<string, string> sPara, Encoding code)
        {
            if (sPara == null) return string.Empty;
            //把参数组中所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串，并对参数值做urlencode
            string strRequestData = F8YLCore.CreateLinkStringUrlencode(sPara, code);

            return strRequestData;
        }

        private static string BuildRequestParaToString(Dictionary<string, string[]> sPara, Encoding code)
        {
            if (sPara == null) return string.Empty;
            //把参数组中所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串，并对参数值做urlencode
            string strRequestData = F8YLCore.CreateLinkStringUrlencode(sPara, code);

            return strRequestData;
        }

        /// <summary>
        /// get提交方法
        /// </summary>
        /// <param name="sPara">请求参数数组</param>
        /// <param name="apiMethod"></param>
        /// <returns></returns>
        public static string BuildGetRequest(Dictionary<string, string> sPara, string apiMethod)
        {

            //string serviceAddress = "http://222.111.999.444:8687/tttr/usercrd/12/b7e50cb45a?userid=9999";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            //request.Method = "GET";
            //request.ContentType = "text/html;charset=UTF-8";
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Stream myResponseStream = response.GetResponseStream();
            //StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            //string retString = myStreamReader.ReadToEnd();
            //myStreamReader.Close();
            //myResponseStream.Close();
            //strResult = retString;



            //string strUrl = GATEWAY_NEW+ "?token=" + token + apiMethod;
            string strUrl = GATEWAY_NEW + apiMethod;

            string strResult = "";

            if (sPara != null)
            {
                foreach (var item in sPara)
                {
                    strUrl += "&" + item.Key + "=" + item.Value;
                }
            }


            Uri uri = new Uri(strUrl);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            try
            {

                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;

                request.Method = "GET";

                request.ContentType = "application/x-www-form-urlencoded";

                request.Proxy = System.Net.WebProxy.GetDefaultProxy();

                //allow auto redirects from redirect headers 
                request.AllowAutoRedirect = true;

                //maximum of 10 auto redirects 
                request.MaximumAutomaticRedirections = 10;

                //30 second timeout for request 
                request.Timeout = (int)new TimeSpan(0, 0, 60).TotalMilliseconds;

                //give the crawler a name. 
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(responseStream, System.Text.Encoding.UTF8);   //System.Text.Encoding.UTF8

                strResult = readStream.ReadToEnd();
            }
            catch (Exception ee)
            {
                strResult = "Fail message : " + ee.Message;
            }
            return strResult;
        }

        public static string BuildGetRequestForFile(Dictionary<string, string> sPara, string apiMethod)
        {
            string strUrl = GATEWAY_NEW + apiMethod;

            string strResult = "";

            if (sPara != null)
            {
                foreach (var item in sPara)
                {
                    strUrl += "&" + item.Key + "=" + item.Value;
                }
            }


            Uri uri = new Uri(strUrl);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            try
            {

                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;

                request.Method = "GET";

                request.ContentType = "application/x-www-form-urlencoded";
               
                request.Proxy = System.Net.WebProxy.GetDefaultProxy();

                //allow auto redirects from redirect headers 
                request.AllowAutoRedirect = true;

                //maximum of 10 auto redirects 
                request.MaximumAutomaticRedirections = 10;

                //30 second timeout for request 
                request.Timeout = (int)new TimeSpan(0, 0, 60).TotalMilliseconds;

                //give the crawler a name. 
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //response.CharacterSet = "gb2312";
                //response.CharacterSet = "utf-8";
                //response.ContentEncoding = System.Text.Encoding.UTF8;
                response.ContentType = "application/ms-excel";
                Stream responseStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(responseStream, System.Text.Encoding.Default);   //System.Text.Encoding.UTF8  Encoding.GetEncoding("gb2312")

                strResult = readStream.ReadToEnd();
            }
            catch (Exception ee)
            {
                strResult = "Fail message : " + ee.Message;
            }
            return strResult;
        }


        /// <summary>
        /// 建立请求，以模拟远程HTTP的POST请求方式构造并获取支付宝的处理结果
        /// </summary>
        /// <param name="sParaTemp">请求参数数组</param>
        /// <returns>支付宝处理结果</returns>
        public static string BuildRequest(Dictionary<string, string> sPara, string apiMethod)
        {
            Encoding code = Encoding.GetEncoding(_input_charset);

            //待请求参数数组字符串
            string strRequestData = BuildRequestParaToString(sPara, code);

            //把数组转换成流中所需字节数组类型
            byte[] bytesRequestData = code.GetBytes(strRequestData);

            //构造请求地址
            //string strUrl = GATEWAY_NEW + "_input_charset=" + _input_charset;
            string strUrl = GATEWAY_NEW + apiMethod;



            //请求远程HTTP
            string strResult = "";
            try
            {
                //设置HttpWebRequest基本信息
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                myReq.Method = "post";
                myReq.ContentType = "application/x-www-form-urlencoded";

                //填充POST数据
                myReq.ContentLength = bytesRequestData.Length;
                Stream requestStream = myReq.GetRequestStream();
                requestStream.Write(bytesRequestData, 0, bytesRequestData.Length);
                requestStream.Close();

                //发送POST数据请求服务器
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = HttpWResp.GetResponseStream();

                //获取服务器返回信息
                StreamReader reader = new StreamReader(myStream, code);
                StringBuilder responseData = new StringBuilder();
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    responseData.Append(line);
                }

                //释放
                myStream.Close();

                strResult = responseData.ToString();
            }
            catch (Exception exp)
            {
                strResult = "报错：" + exp.Message;
            }

            return strResult;
        }

        public static string BuildRequest(Dictionary<string, string[]> sParas, Dictionary<string, string> sPara, string apiMethod)
        {
            Encoding code = Encoding.GetEncoding(_input_charset);

            //待请求参数数组字符串
            string strRequestData = BuildRequestParaToString(sPara, code);
            if (!string.IsNullOrEmpty(strRequestData))
                strRequestData += "&";
            strRequestData += BuildRequestParaToString(sParas, code);

            //把数组转换成流中所需字节数组类型
            byte[] bytesRequestData = code.GetBytes(strRequestData);

            //构造请求地址
            //string strUrl = GATEWAY_NEW + "_input_charset=" + _input_charset;
            string strUrl = GATEWAY_NEW + apiMethod;



            //请求远程HTTP
            string strResult = "";
            try
            {
                //设置HttpWebRequest基本信息
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                myReq.Method = "post";
                myReq.ContentType = "application/x-www-form-urlencoded";

                //填充POST数据
                myReq.ContentLength = bytesRequestData.Length;
                Stream requestStream = myReq.GetRequestStream();
                requestStream.Write(bytesRequestData, 0, bytesRequestData.Length);
                requestStream.Close();

                //发送POST数据请求服务器
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = HttpWResp.GetResponseStream();

                //获取服务器返回信息
                StreamReader reader = new StreamReader(myStream, code);
                StringBuilder responseData = new StringBuilder();
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    responseData.Append(line);
                }

                //释放
                myStream.Close();

                strResult = responseData.ToString();
            }
            catch (Exception exp)
            {
                strResult = "报错：" + exp.Message;
            }

            return strResult;
        }

        /// <summary>
        /// 建立请求，以模拟远程HTTP的POST请求方式构造并获取api的处理结果，带文件上传功能
        /// </summary>
        /// <param name="sParaTemp">请求参数数组</param>
        /// <param name="strMethod">提交方式。两个值可选：post、get</param>
        /// <param name="apiMethod">调用api的路径，例如登录“auth/login”</param>
        /// <param name="fileName">文件绝对路径</param>
        /// <param name="data">文件数据</param>
        /// <param name="contentType">文件内容类型</param>
        /// <param name="lengthFile">文件长度</param>
        /// <returns>支付宝处理结果</returns>
        public static string BuildRequest(Dictionary<string, string> sPara, string strMethod, string apiMethod, string fileName, byte[] data, string contentType, int lengthFile)
        {
            //构造请求地址
            string strUrl = GATEWAY_NEW + apiMethod;

            //设置HttpWebRequest基本信息
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(strUrl);
            //设置请求方式：get、post
            request.Method = strMethod;
            //设置boundaryValue
            string boundaryValue = DateTime.Now.Ticks.ToString("x");
            string boundary = "--" + boundaryValue;
            request.ContentType = "\r\nmultipart/form-data; boundary=" + boundaryValue;
            //设置KeepAlive
            request.KeepAlive = true;
            //设置请求数据，拼接成字符串
            StringBuilder sbHtml = new StringBuilder();
            foreach (KeyValuePair<string, string> key in sPara)
            {
                sbHtml.Append(boundary + "\r\nContent-Disposition: form-data; name=\"" + key.Key + "\"\r\n\r\n" + key.Value + "\r\n");
            }
            sbHtml.Append(boundary + "\r\nContent-Disposition: form-data; name=\"withhold_file\"; filename=\"");
            sbHtml.Append(fileName);
            sbHtml.Append("\"\r\nContent-Type: " + contentType + "\r\n\r\n");
            string postHeader = sbHtml.ToString();
            //将请求数据字符串类型根据编码格式转换成字节流
            Encoding code = Encoding.GetEncoding(_input_charset);
            byte[] postHeaderBytes = code.GetBytes(postHeader);
            byte[] boundayBytes = Encoding.ASCII.GetBytes("\r\n" + boundary + "--\r\n");
            //设置长度
            long length = postHeaderBytes.Length + lengthFile + boundayBytes.Length;
            request.ContentLength = length;

            //请求远程HTTP
            Stream requestStream = request.GetRequestStream();
            Stream myStream;
            try
            {
                //发送数据请求服务器
                requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                requestStream.Write(data, 0, lengthFile);
                requestStream.Write(boundayBytes, 0, boundayBytes.Length);
                HttpWebResponse HttpWResp = (HttpWebResponse)request.GetResponse();
                myStream = HttpWResp.GetResponseStream();
            }
            catch (WebException e)
            {
                return e.ToString();
            }
            finally
            {
                if (requestStream != null)
                {
                    requestStream.Close();
                }
            }

            //读取api返回处理结果
            StreamReader reader = new StreamReader(myStream, code);
            StringBuilder responseData = new StringBuilder();

            String line;
            while ((line = reader.ReadLine()) != null)
            {
                responseData.Append(line);
            }
            myStream.Close();
            return responseData.ToString();
        }

        /// <summary>
        /// 用于防钓鱼，调用接口query_timestamp来获取时间戳的处理函数
        /// 注意：远程解析XML出错，与IIS服务器配置有关
        /// </summary>
        /// <returns>时间戳字符串</returns>
        public static string Query_timestamp()
        {
            string url = GATEWAY_NEW + "service=query_timestamp&partner=" + F8YLConfig.Partner + "&_input_charset=" + F8YLConfig.Input_charset;
            string encrypt_key = "";

            XmlTextReader Reader = new XmlTextReader(url);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Reader);

            encrypt_key = xmlDoc.SelectSingleNode("/alipay/response/timestamp/encrypt_key").InnerText;

            return encrypt_key;
        }
    }
}
