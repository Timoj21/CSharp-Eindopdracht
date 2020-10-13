using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server started!");
            IPAddress localhost = IPAddress.Parse("");
            TcpListener listener1 = new TcpListener(localhost, 5252);
            listener1.Start();

            while (true)
            {
                Console.WriteLine("Waiting for connection");
                TcpClient client = listener1.AcceptTcpClient();
                Thread thread = new Thread(HandleClientThread);
                thread.Start(client);
            }

        }

        static void HandleClientThread(object obj)
        {
            TcpClient client = obj as TcpClient;

            bool ready = false;
            while (!ready)
            {
                string received = ReadTextMessage(client);
                Console.WriteLine("Received: {0}", received);

                ready = received.Equals("stop");
                if (ready) WriteTextMessage(client, "stop");
                else WriteTextMessage(client, "Accepted");
            }
            client.Close();
            Console.WriteLine("Connection stopped");
        }


        public static void WriteTextMessage(TcpClient client, string message)
        {
            var stream = new StreamWriter(client.GetStream(), Encoding.ASCII, -1, true);
            {
                stream.WriteLine(message);
                stream.Flush();
            }
        }

        public static string ReadTextMessage(TcpClient client)
        {
            var stream = new StreamReader(client.GetStream(), Encoding.ASCII);
            {
                return stream.ReadLine();
            }
        }

    }
}