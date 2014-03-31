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
    
    public class UDPClientTester_Receiver
    {

        public static void Main(string[] args)
        {
            UDPClient updc = new UDPClient();

            byte[] temp = updc.Receive() as byte[];
            

            Console.WriteLine(Encoding.Default.GetString(temp));
            Console.ReadKey();
        }

    }
}
