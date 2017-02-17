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
    public class Client 
    {
        public Client()
        {
          
        }
        public void CreateClient(string message)
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 8080);
                byte[] data = Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();
                string responseData = string.Empty;
                while (!responseData.Equals("Exit"))
                {
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("You: {0}", message);
                    data = new byte[256];
                    int bytes = stream.Read(data, 0, data.Length);
                    Console.WriteLine("Received: {0}", responseData);
                    
                }
                stream.Close();
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}" , e);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
        }
    }
    //StreamReader reader = new StreamReader(client.GetStream());
    //StreamWriter writer = new StreamWriter(client.GetStream());
    //string emptyString = string.Empty;
    //while (!emptyString.Equals("Exit")) ;
    //{
    //    Console.WriteLine("Type a message to send to the chat!");
    //    emptyString = Console.ReadLine();
    //    writer.WriteLine(emptyString);
    //    writer.Flush();
    //    string server_string = reader.ReadLine();
    //    Console.WriteLine(server_string);
    //}
    //reader.Close();
    //writer.Close();
    //client.Close();
}
