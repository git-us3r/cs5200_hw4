using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunicationSubsystem;

namespace CommunicationSubsystem
{
    public class Listener : BackgroundThread
    {
        // *** This is likely to change .. when we figure how to discover queues.
        public Conversations conversations { get; set; }
        public MessageQ requests { get; set; }
        public Communicator communicator { get; set; }
        public int port { get; set; }

        // Since we don't know yet how to handle the queues, It will have its own for now.
        public Listener()
        {
            communicator = new Communicator();
            conversations = new Conversations();
            requests = new MessageQ("RQ");
        }


        public Listener(int _port)
        {
            port = _port;
            communicator = new Communicator(port);
            conversations = new Conversations();
            requests = new MessageQ("RQ");
        }


        private void fileMsg(Envelop _env)
        {
            // check conversation id and msgId
            if (_env.msg.ConversationId == _env.msg.MessageNr)
            {
                // if match place in requests
                requests.addMessage(_env);
            }
            else if (conversations.hasMessageQ(_env.msg.ConversationId))
            {

                // else if a conversation exists with mathching key (conversationID) insert there
                conversations.addMessageInConversation(_env.msg.ConversationId, _env);
            }
            // else dismiss as erroneous ( do nothing )
        }




        private void work()
        {
            Envelop tempMsg = communicator.receive();
            if (tempMsg != null)
            {
                fileMsg(tempMsg);
            }
        }


        public override string ThreadName()
        {
            return "Listener";
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
        }
    }
}
