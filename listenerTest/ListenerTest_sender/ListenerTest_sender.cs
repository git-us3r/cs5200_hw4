using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunicationSubsystem;

namespace ListenerTest_sender
{
    /// <summary>
    /// This is meant to test the listener class.
    /// The test consists on sending a message and waiting for acknack.
    /// Then, output confirmation.
    /// 
    /// Note: since this test intends to change the default behavior of listener,
    /// it will extend it. Thus, the functions thread name and work need to be overriden.
    /// </summary>
    public class ListenerTest_sender : Listener
    {
        public System.Net.IPEndPoint destinationEndPoint { get; set; }

        public ListenerTest_sender(int _port, System.Net.IPEndPoint _endPoint)
            : base(_port)
        {
            destinationEndPoint = _endPoint;
        }

        private void work()
        {
            // TODO
            // send acknak and wait for acknak
            Messages.AckNak outgoing = new Messages.AckNak(Messages.Reply.PossibleStatus.Success, 0, "FUCK YOU");
            Envelop outgoing_env = new Envelop(outgoing, destinationEndPoint);
            communicator.send(outgoing_env);

            Envelop incoming = communicator.receive();

            if (incoming != null)
            {
                Console.WriteLine(incoming.msg.ToString());
                keepGoing = false;
            }
        }


        public override string ThreadName()
        {
            return "ListenerTest_sender";
        }


        /// <summary>
        /// Main process method for background thread
        /// 
        /// This method should stop whatever it is doing and terminate whenever keepGoing becomes false. 
        /// Also, it should not actually do any process anything but stay alive, if suspend becomes true.
        /// </summary>
        protected override void Process()
        {
            // Try to empty the input queue
            while (keepGoing)
            {
                work();
            }
            this.Stop();
        }

        static void Main(string[] args)
        {

            // get local host IP addres
            // routine obtained from stackoverflow:
            // https://stackoverflow.com/questions/1069103/how-to-get-my-own-ip-address-in-c
            ////

            System.Net.IPHostEntry potentialLocalHosts;
            string str_localhost = "";
            potentialLocalHosts = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());

            foreach (System.Net.IPAddress ip in potentialLocalHosts.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    str_localhost = ip.ToString();
                    break;
                }
            }
            
            // IP address of localhost
            System.Net.IPAddress localhost_ip = System.Net.IPAddress.Parse(str_localhost);

            // localhost endpoint. 1234 is the port to which this one sends
            System.Net.IPEndPoint localhost_ep = new System.Net.IPEndPoint(localhost_ip, 1234);

            // 4321 is the port to which this one listens.
            ListenerTest_sender lts = new ListenerTest_sender(4321, localhost_ep);
            lts.Start();

            while (lts.Status == "Running")
            {
                // Wait
            }

            // done!
            Console.ReadKey();

            
        }

       
    }
}
