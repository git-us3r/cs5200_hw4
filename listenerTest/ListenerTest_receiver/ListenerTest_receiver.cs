using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunicationSubsystem;
using Messages;
 
namespace ListenerTest_receiver
{
    /// <summary>
    /// This is meant to test the listener class.
    /// The test consists on waiting until a message comes in,
    /// when (if) it does, information about that message is sent to
    /// standard output.
    /// 
    /// Note: since this test intends to change the default behavior of listener,
    /// it will extend it. Thus, the functions thread name and work need to be overriden.
    /// </summary>
    public class ListenerTest_receiver : Listener
    {

        public ListenerTest_receiver() :  base()
        {
            // EMPTY
        }

        public ListenerTest_receiver(int _port) :  base(_port)
        {
           // EMPTY
        }

        private void work()
        {
            // TODO

            // query communicator for incoming envelop
            // if an evelop is received with key "FUCK YOU",
                // send acknak
                // display message info            
                // keepGoing not
            // peace
            //----------------------------------------------

            // assume port is known from command line
            Envelop incoming =  communicator.receive();    // returns null on timeout

            if (incoming != null)
            {
                Messages.AckNak acknak = new Messages.AckNak(Reply.PossibleStatus.Success, 0, "FUCK YOU TOO");

                System.Net.IPEndPoint tempIPEndPoint = incoming.endPoint;
                tempIPEndPoint.Port = 4321;

                Envelop acknak_env = new Envelop(acknak, tempIPEndPoint);


                communicator.send(acknak_env);
         

                Messages.AckNak incoming_msg = incoming.msg as Messages.AckNak;

                Console.WriteLine(incoming_msg.Message);

                keepGoing = false;
            }
        }


        public override string ThreadName()
        {
            return "ListenerTest_receiver";
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
            Console.WriteLine("Receiver");

            int port = 1234;

            ListenerTest_receiver ltr = new ListenerTest_receiver(port);

            Console.WriteLine("Listening on address: " + ltr.communicator.socket.LocalEndPoint);
            Console.Read();

            ltr.Start();


            while (ltr.Status == "Running")
            {
                // wait
            }

            // hopefully a message has been printed out by now
            Console.WriteLine("DONE");
            Console.Read();

            return;
        }
    }
}
