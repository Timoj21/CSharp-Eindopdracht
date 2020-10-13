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
            bool TryIp;
            IPAddress localhost = IPAddress.TryParse("", out TryIp );
            TcpListener tcplistener = new TcpListener(localhost, 5252);

            tcplistener.Start();

            while(true)
            {

            }

        }

        public static Encoding encoding = Encoding.UTF8;

        public static string ReadTextMessage(NetworkStream networkStream)
        {
            StreamReader stream = new StreamReader(networkStream, encoding);
            return stream.ReadLine();
            var stream = new StreamReader(networkStream, encoding);
            {
                return stream.ReadLine();
            }
        }

        public static void WriteTextMessage(NetworkStream networkStream, string message)
        {
            StreamWriter stream = new StreamWriter(networkStream, encoding);
            stream.WriteLine(message);
            stream.Flush();
            using (var stream = new StreamWriter(networkStream, encoding, -1, true))
            {
                stream.WriteLine(message);
                stream.Flush();
            }
        }
    }
}
