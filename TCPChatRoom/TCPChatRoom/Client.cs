using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TCPChatRoom
{
    class Client
    {
        public Client()
        {
          
        }
        public void CreateClient()
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 8080);
                StreamReader reader = new StreamReader(client.GetStream());
                StreamWriter writer = new StreamWriter(client.GetStream());
                string emptyString = string.Empty;
                while (!emptyString.Equals("Exit")) ;
                {
                    Console.WriteLine("Type a message to send to the chat!");
                    emptyString = Console.ReadLine();
                    writer.WriteLine(emptyString);
                    writer.Flush();
                    string server_string = reader.ReadLine();
                    Console.WriteLine(server_string);
                }
                reader.Close();
                writer.Close();
                client.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Error connecting to server");
            }
            //TCPClient client = new TCP client (IP,Port)
            //new string reader 
            //new string writer
            //create variable to hold what user inputs
            //tell user to type something in
            //take what user inputs and store it in variable
        }
    }
}
