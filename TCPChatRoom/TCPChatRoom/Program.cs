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
            Console.WriteLine("Welcome to the Chat!");
            Console.WriteLine("Please provide the IP that you wish to connect to.");
            string ipAddress = Console.ReadLine();

            Console.WriteLine("Please provide the port");
            int port = int.Parse(Console.ReadLine());
            client.CreateClient("",ipAddress,port);
        }
    }
}
