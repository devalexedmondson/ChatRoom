﻿using System;
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
        TcpListener listener;
        
        public Server()
        {
            room = new List<Room>();
        }

        public void StartServer()
        {
             listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);

                byte[] bytes = new byte[256];
                string data = null;
                listener.Start();
                Console.WriteLine("MultiThread Started");

          //}
       //public void RecieveClients()
           //{

                while (true)
                {//thread for each client
                    Console.WriteLine("Waiting for client connections.");
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Accepted new client connection.");
                    NetworkStream stream = client.GetStream();
                    int i;

                    i = stream.Read(bytes, 0, bytes.Length);

                    while (i != 0)
                    {
                        data = Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("From User: {0}", data);
                      // if i want to alter data--> data = data;
                        byte[] msg = Encoding.ASCII.GetBytes(data);


                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);

                        i = stream.Read(bytes, 0, bytes.Length);
                    }
                    //client.Close();
                    Console.WriteLine("Closing connection with client");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
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
}
