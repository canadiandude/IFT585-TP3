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
            if (args.Length == 2)
                server.Start(args[0], int.Parse(args[1]));
            else
                server.Start("127.0.0.1", 42);
            while (true)
            {
                server.ReceiveFromClients();
            }
        }
    }
}
