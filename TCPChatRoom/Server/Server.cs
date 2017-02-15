using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ServerSide
{
    public class Server
    {
        List<Room> room;
        
        public Server()
        {
            room = new List<Room>();
        }
        public void ProcessClient(object argument)
        {
            TcpClient client = new TcpClient(argument);
            try
            {
                StreamReader reader = new StreamReader(client.GetStream());
                StreamWriter writer = new StreamWriter(client.GetStream());
                string emptyString = string.Empty;
                while (!(emptyString = reader.ReadLine()).Equals("Exit") || (emptyString == null))
                {
                    Console.WriteLine("From client" + emptyString);
                    writer.WriteLine("From server" + emptyString);
                    writer.Flush();
                }
                reader.Close();
                writer.Close();
                client.Close();
                Console.WriteLine("Closing connection with client");
            }
            catch(Exception)
            {
                Console.WriteLine("Error with communicating with client.");
            }
            finally
            {
                if(client != null)
                {
                    client.Close();
                }
            }
        }
        public void StartServer()
        {
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
                listener.Start();
                Console.WriteLine("MultiThread Started");
                while(true)
                {
                    Console.WriteLine("Waiting for client connections.");
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Accepted new client connection.");
                    Thread t = new Thread(ProcessClient);
                    t.Start(client);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error processing connection");
            }
            finally
            {
                if (listener != null)
                {
                    listener.Stop();
                }
            }
            //listen for new connection
            //listen for new clients
            //listen for clients leaving
            // while that is going on....
            //write "waiting for new connection
            //if new connection, accept the connection
            //create new thread
            //if no connections, wait 
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
}
