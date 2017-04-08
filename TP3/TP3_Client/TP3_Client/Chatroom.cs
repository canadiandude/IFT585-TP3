using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_Client
{
    class Chatroom
    {
        private List<Message> msgList;
        public int Id { get; set; }
        public string Desc { get; set; }
        public string Titre { get; set; }
        public List<Message> MessageList {
            get {
                if(msgList == null)
                    msgList = new List<Message>();
                return msgList;
            }
            set {
                msgList = value;
            }
        }
    }
}
