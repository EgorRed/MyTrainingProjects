using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerUDP
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8081;

            //create endpoint
            var udpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            //create socket
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //bind to endpoint
            udpSocket.Bind(udpEndPoint);

            while (true)
            {
                var buffer = new byte[256]; //buffer for data
                int size = 0; //size bubber
                var data = new StringBuilder(); //data builder
                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);

                do
                {
                    size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);
                    data.Append(Encoding.UTF8.GetString(buffer));
                } while (udpSocket.Available > 0);

                udpSocket.SendTo(Encoding.UTF8.GetBytes("server: message received"), senderEndPoint);

                Console.WriteLine(data);
            }
        }
    }
}
