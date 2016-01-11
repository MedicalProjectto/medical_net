using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.BLL
{
    /// <summary>
    /// 类名：F8YLMD5
    /// 功能：MD5加密
    /// 作者：Gerry Ge
    /// 创建日期：2015-12-08
    /// 修改日期：2015-12-08
    /// </summary>
    public sealed class F8YLMD5
    {
        public F8YLMD5()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 签名字符串
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <returns>签名结果</returns>
        public static string Sign(string prestr)
        {
            string _input_charset = "utf-8";//"_input_charset"编码格式
            StringBuilder sb = new StringBuilder(32);

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            //Sign("654321")="c33367701511b4f6020ec61ded352059"
            return sb.ToString();
        }

    }
}
