using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stopreceived = false;
            Console.WriteLine("Looking for connection");
            TcpClient client = new TcpClient("", 5252);
            Console.WriteLine("Type (stop) to stop connection");
            while (!stopreceived)
            {
                Console.Write("Send something to the server: ");
                string clientmes = Console.ReadLine();

                WriteTextMessage(client, clientmes);

                string response = ReadTextMessage(client);
                Console.WriteLine("Response: " + response);
                stopreceived = response.Equals("stop");
            }
        }

        public static void WriteTextMessage(TcpClient client, string message)
        {
            var stream = new StreamWriter(client.GetStream(), Encoding.ASCII);
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

