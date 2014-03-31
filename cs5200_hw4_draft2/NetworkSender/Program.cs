using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Net;
using System.Net.Sockets;
using CommunicationSubsystem;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter msg:");
            string msg = Console.ReadLine();

            // Uses a socket instead of udp client.... why?
            //Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
            //    ProtocolType.Udp);
            //UdpClient updc = new UdpClient();
            IPAddress broadcast = IPAddress.Parse("192.168.1.255");

            byte[] sendbuf = Encoding.ASCII.GetBytes(msg);
            IPEndPoint ep = new IPEndPoint(broadcast, 11000);

            //s.SendTo(sendbuf, ep);
            //updc.Send(sendbuf, sendbuf.Length, ep);
            UDPClient updc = new UDPClient();
            updc.Send(sendbuf, ep);





            Console.WriteLine("Message sent to the broadcast address");
        }
    }
}
