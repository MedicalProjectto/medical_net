using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.BLL
{
    public class FileOperation
    {
        public static string Download(string fileName, string token)
        {
            string strResponse = string.Empty;
            try
            {
                strResponse = F8YLSubmit.BuildGetRequestForFile(null, "download?file=dHBsLXVzZXItaW1wb3J0Lnhscw%3D%3D");

            }
            catch (Exception ex)
            {
                AppLog.Instance.Write("Download", AppLog.LogMessageType.Error, ex);
            }
            return strResponse;

        }
    }
}
