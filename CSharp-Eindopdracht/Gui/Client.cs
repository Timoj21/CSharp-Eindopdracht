using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Gui
{

    public delegate void DataCallback(string data);
    class Client
    {
        private TcpClient client;
        private NetworkStream stream;
        private byte[] buffer = new byte[4];

        public event DataCallback OnDataReceived;

        public Client()
        {
            this.client = new TcpClient();
            this.client.BeginConnect("localhost", 5252, new AsyncCallback(Connect), null);
        }

        private void Connect(IAsyncResult ar)
        {
            this.client.EndConnect(ar);
            this.stream = client.GetStream();
            this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(ReceiveLengthInt), null);
        }

        private void ReceiveLengthInt(IAsyncResult ar)
        {
            int dataLength = BitConverter.ToInt32(this.buffer);

            this.buffer = new byte[dataLength];

            this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(ReceiveData), null);
        }

        private void ReceiveData(IAsyncResult ar)
        {
            string data = System.Text.Encoding.ASCII.GetString(this.buffer);

            handleData(data);

            this.buffer = new byte[4];
            this.stream.BeginRead(this.buffer, 0, this.buffer.Length, new AsyncCallback(ReceiveLengthInt), null);
        }

        private void handleData(string data)
        {
            switch (data)
            {
                case "HOSTSUCCEED":
                    {
                        OnDataReceived?.Invoke(data);
                        break;
                    }
                case "JOINSUCCEED":
                    {
                        OnDataReceived?.Invoke(data);
                        break;
                    }
                case "JOINFAILED":
                    {
                        OnDataReceived?.Invoke(data);
                        break;
                    }
            }
        }
        public void SendData(string message)
        {
          // create the sendBuffer based on the message
            List<byte> sendBuffer = new List<byte>(Encoding.ASCII.GetBytes(message));
            
            // append the message length (in bytes)
            sendBuffer.InsertRange(0, BitConverter.GetBytes(sendBuffer.Count));

            // send the message
            this.stream.Write(sendBuffer.ToArray(), 0, sendBuffer.Count);
        }
    }
}
