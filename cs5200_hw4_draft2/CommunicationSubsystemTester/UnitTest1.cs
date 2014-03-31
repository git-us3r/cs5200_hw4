using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Net;
using System.Net.Sockets;
using CommunicationSubsystem;
using Messages;

namespace CommunicationSubsystemTester
{
    [TestClass]
    public class CommunicationSubsystemTester

    {
        [TestMethod]
        public void testListener()
        {
            // This should be like a a strategy
            //
            // set up two sockets with different ports
            // setup two communicators
            // setup a listener for one of the communicators
            // send a message from the other.

            Socket ss = new Socket(SocketType.Dgram, ProtocolType.Udp);
            Socket sr = new Socket(SocketType.Dgram, ProtocolType.Udp);

            int portS = 1234;
            int portR = 4321;

            Communicator cs = new Communicator(portS, ss);
            Communicator cr = new Communicator(portR, sr);

            IPAddress localhost = Communicator.getLocalHost();


            MessageQ msgQ = new MessageQ("testQ");
            Conversations cnv = new Conversations();

            Listener lstnr = new Listener(ref cr, ref msgQ, ref cnv);
            lstnr.Start();

            for (int i = 0; i < 10; i++)
            { 
                // Send messgages.
                GetStatus msg = new GetStatus();

                IPEndPoint ep = new IPEndPoint(localhost, portR);
                Envelop env = new Envelop(msg, ep);
                cs.send(env);
            }

            // check msgQ for incoming
            int test = 0;


        }
    }
}
