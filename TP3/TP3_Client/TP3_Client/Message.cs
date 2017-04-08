using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_Client
{
    class Message
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public DateTime Date { get; set; }
    }
}
