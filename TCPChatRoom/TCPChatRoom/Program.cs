using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPChatRoom;

namespace ClientSide
{
     class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.CreateClient(Console.ReadLine());
            
        }
    }
}
