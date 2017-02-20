using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;

namespace ServerSide
{
    public class Server
    {
        List<Room> room;
        TcpListener listener;
        TcpClient client;
        private string data;
        private byte[] bytes;
        Queue myQ;
        
        public Server()
        {
            room = new List<Room>();
            myQ = new Queue();
        }
        public void StartServer()
        {
            listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
                listener.Start();
                Console.WriteLine("MultiThread Started");

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            Thread newThread = new Thread(RecieveClientsAsync);
            newThread.Start();
            //RecieveClients();
        }
       public async void RecieveClientsAsync()
       {
            bytes = new byte[256];
            data = null;
            while (true)
                {//thread for each client
                    Console.WriteLine("Waiting for client connections.");
                    client = listener.AcceptTcpClient();
                    Console.WriteLine("Accepted new client connection.");
                Thread newThread = new Thread(ProcessClientRequest);
                newThread.Start();
                }
            }
        public void ProcessClientRequest()
        {
            NetworkStream stream = client.GetStream();
            int i;

            i = stream.Read(bytes, 0, bytes.Length);

            while (i != 0)
            {
                data = Encoding.ASCII.GetString(bytes, 0, i);
                myQ.Enqueue(data);
                Console.WriteLine("From User: {0}", data);
                //if i want to alter data--> data = data.toUpper();
                byte[] msg = Encoding.ASCII.GetBytes(data);

                stream.Write(msg, 0, msg.Length);
                Console.WriteLine("Sent: {0}", data);

                myQ.Dequeue();
                i = stream.Read(bytes, 0, bytes.Length);
            }
            client.Close();
            Console.WriteLine("Closing connection with client");
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
