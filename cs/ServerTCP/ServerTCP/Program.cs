using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerTCP
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

            //bind to endpoint
            tcpSocket.Bind(localEP: tcpEndPoint);

            //set max number connection
            tcpSocket.Listen(5);

            //listening mode
            while (true)
            {
                
                var listener = tcpSocket.Accept(); //create listener
                var buffer = new byte[256]; //buffer for data
                int size = 0; //size bubber
                var data = new StringBuilder(); //data builder

                do
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                } 
                while (listener.Available > 0);

                Console.WriteLine(data);

                //send data to client
                listener.Send(Encoding.UTF8.GetBytes("Server: message received"));

                //socket close
                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }            
        }
    }
}
