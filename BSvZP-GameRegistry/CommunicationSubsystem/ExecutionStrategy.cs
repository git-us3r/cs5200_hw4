using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationSubsystem
{
    public abstract class ExecutionStrategy
    {

        // Private members
        protected string excID;


        // Default CTOR
        public ExecutionStrategy()
        {
            // EMPTY
        }

        

        // Public Methods
        public abstract void newGame(object data);
        
        public abstract void dataRequest(object data);
        
        public abstract void changeRequest(object data);
        
        public abstract void statusRequest(object data);
        
        public abstract void moveRequest(object data);
        
        public abstract void joinGameRequest(object data);
        

        public abstract void ThrowBombRequest(object data);
        


    }
}
