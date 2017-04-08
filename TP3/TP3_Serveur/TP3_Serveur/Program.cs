using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_Serveur
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start(args[0], int.Parse(args[1]));
            while (true)
            {
                server.ReceiveFromClients();
            }
        }
    }
}
