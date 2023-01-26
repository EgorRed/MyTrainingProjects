using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientUDP
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8082;

            //create endpoint
            var udpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            //create socket
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //bind to endpoint
            udpSocket.Bind(udpEndPoint);

            while (true)
            {

                Console.Write("Client: ");
                string message = Console.ReadLine();

                EndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);

                //send data to server 
                udpSocket.SendTo(Encoding.UTF8.GetBytes(message), serverEndPoint);

                var buffer = new byte[256]; //buffer for data
                int size = 0; //size bubber
                var answer = new StringBuilder(); //data builder

                //create sender end point
                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);

                //waiting for a response from the server
                do
                {
                    size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);
                    answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (udpSocket.Available > 0);

                Console.WriteLine(answer);
            }
        }
    }
}
