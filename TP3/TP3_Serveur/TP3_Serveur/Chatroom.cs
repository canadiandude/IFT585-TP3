using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_Serveur
{
    class Chatroom
    {
        public int Id;
        public String Title;
        public String Description;
        public List<String> Messages;

        public Chatroom(int id, String title, String description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public override string ToString()
        {
            String str = Title + " - " + Description + "\n";
            foreach (String m in Messages)
            {
                str += m + "\n";
            }
            return str;
        }
    }
}
