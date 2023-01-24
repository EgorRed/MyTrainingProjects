using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8080;

            //create endpoint
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            //create socket
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.Write("Client: ");
            string message = Console.ReadLine();

            //encoding data
            var data = Encoding.UTF8.GetBytes(message);
            //connect to end point
            tcpSocket.Connect(tcpEndPoint);
            //send data to server 
            tcpSocket.Send(data);

            var buffer = new byte[256]; //buffer for data
            int size = 0; //size bubber
            var answer = new StringBuilder(); //data builder

            //waiting for a response from the server
            do
            {
                size = tcpSocket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (tcpSocket.Available > 0);

            Console.WriteLine(answer);

            //socket close
            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();

            Console.ReadLine();
        }
    }
}
