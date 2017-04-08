using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_Client
{
    class Message
    {
        private List<string> likes;
        public string Username { get; set; }
        public string Content { get; set; }
        public List<string> Likes {
            get {
                if (likes == null)
                    likes = new List<string>();
                return likes;
            }
            set { likes = value; }
        }
    }
}
