//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using CommunicationSubsystem;

//namespace ListenerTest_sender
//{
//    /// <summary>
//    /// This is meant to test the listener class.
//    /// The test consists on sending a message and waiting for acknack.
//    /// Then, output confirmation.
//    /// 
//    /// Note: since this test intends to change the default behavior of listener,
//    /// it will extend it. Thus, the functions thread name and work need to be overriden.
//    /// </summary>
//    public class ListenerTest_sender : Listener
//    {
//        public int localPort { get; set; }
//        public int remotePort { get; set; }
        

//        public ListenerTest_sender(int _localPort, int _remotePort)
//            : base(_localPort)
//        {
//            localPort = _localPort;
//            remotePort = _remotePort;
//        }



//        private void work()
//        {
//            // TODO
//            // send acknak and wait for acknak
//            Messages.AckNak outgoing = new Messages.AckNak(Messages.Reply.PossibleStatus.Success, 0, "FUCK YOU");

//            // Create an endpoint with the same ip but different port to send the message.

//            System.Net.IPEndPoint remoteEndPoint = communicator.socket.LocalEndPoint as System.Net.IPEndPoint;
//            remoteEndPoint.Port = remotePort;
//            Envelop outgoing_env = new Envelop(outgoing, remoteEndPoint);

//            Console.WriteLine("inside work: \n\n" + remoteEndPoint + "\n\n");

//            communicator.send(outgoing_env);

//            Envelop incoming = communicator.receive();

//            if (incoming != null)
//            {
//                Messages.AckNak incoming_msg = incoming.msg as Messages.AckNak;
//                Console.WriteLine(incoming_msg.Message);
//                keepGoing = false;
//            }

//            Console.WriteLine("heding out");
//            return;
//        }


//        public override string ThreadName()
//        {
//            return "ListenerTest_sender";
//        }


//        /// <summary>
//        /// Main process method for background thread
//        /// 
//        /// This method should stop whatever it is doing and terminate whenever keepGoing becomes false. 
//        /// Also, it should not actually do any process anything but stay alive, if suspend becomes true.
//        /// </summary>
//        protected override void Process()
//        {
//            // Try to empty the input queue
//            while (keepGoing)
//            {
//                work();
//            }
//            this.Stop();
//        }

//        static void Main(string[] args)
//        {

//            Console.WriteLine("Sender");

//            // 4321 is the port to which this one listens.
//            ListenerTest_sender lts = new ListenerTest_sender(4321, 1234);
//            lts.Start();

//            while (lts.Status == "Running")
//            {
//                // Wait
//            }

//            // done!
//            Console.WriteLine("DONE");
//            Console.Read();

            
//        }


//        static private System.Net.IPAddress GetHostAddress(string hostName)
//        {
//            System.Net.IPAddress result = null;
//            System.Net.IPAddress[] addresses = System.Net.Dns.GetHostAddresses(hostName);
//            if (addresses.Length > 0 && addresses[0] != null)
//                result = addresses[0];
//            return result;
//        }

       
//    }
//}
