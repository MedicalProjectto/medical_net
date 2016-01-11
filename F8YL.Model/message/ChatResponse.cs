using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F8YL.Model
{
    public class ChatResponse : APIResponseBase
    {
        public ChatResponseDataEntity data { get; set; }
    }

    public class ChatResponseDataEntity
    {
        public List<ChatResponseDataChatEntity> data { get; set; }
        public int total { get; set; }
    }

    public class ChatResponseDataChatEntity
    {
        public string id { get; set; }
        public string userid { get; set; }
        public string friendid { get; set; }
        public string msg { get; set; }
        public string ctime { get; set; }
        public UserEntity user { get; set; }
    }

    public class UserEntity
    {
        public string id { get; set; }
        public string username { get; set; }
        public string idcard { get; set; }
        public string mobile { get; set; }
    }
}
