using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace ServerSide
{
    public class Server
    {
        List<Room> room;
        
        public Server()
        {
            room = new List<Room>();
        }

        public void StartServer()
        {
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);

                byte[] bytes = new byte[256];
                string data = null;
                listener.Start();
                Console.WriteLine("MultiThread Started");

                while (true)
                {
                    Console.WriteLine("Waiting for client connections.");
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Accepted new client connection.");
                    NetworkStream stream = client.GetStream();
                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);
                        data = data;
                        byte[] msg = Encoding.ASCII.GetBytes(data);


                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }
                    client.Close();
                    Console.WriteLine("Closing connection with client");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                if (listener != null)
                {
                    listener.Stop();
                }
            }
        }
        public void NotifyClientMessage()
        {
            //take in message from client and store it in queue 
            //write what client wrote/notify all clients of what was taken in
        }
        public void NotifyClientArrive()
        {

        }
        public void NotifyClientLeave()
        {

        }
    }
    //StreamReader reader = new StreamReader(client.GetStream());
    //StreamWriter writer = new StreamWriter(client.GetStream());
    //string emptyString = string.Empty;
    //while (!(emptyString = reader.ReadLine()).Equals("Exit") || (emptyString == null))
    //{
    //    Console.WriteLine("From client" + emptyString);
    //    writer.WriteLine("From server" + emptyString);
    //    writer.Flush();
    //}
    //reader.Close();
    //writer.Close();
    //client.Close();
}
