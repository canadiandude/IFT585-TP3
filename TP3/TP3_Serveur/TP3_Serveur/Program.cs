﻿using System;
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
            Server server = new Server("192.168.2.21", 42);
            while (true)
            {
                server.ReceiveFromClients();
            }
        }
    }
}
