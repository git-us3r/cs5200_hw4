using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{

    public abstract class ConversationExecutionStrategy : IObservable<object>
    {
        // Default CTOR

        public abstract void process(object data);

        // Common methods for all agents
        public abstract void startNewGame(object data);
        public abstract void newGameRequest(object data);
        public abstract void dataRequest(object data);
        public abstract void changeRequest(object data);
        public abstract void statusRequest(object data);        // noun ... ehh?

        public abstract void joinGame(object data);
        public abstract void requestData(object data);        // verb
        public abstract void receiveTick(object data);
        public abstract void getEaten(object data);
        public abstract void getDestroyed(object data);
        public abstract void heal(object data);
        public abstract void sendData(object data);
        public abstract void phoneHome(object data);            // ask for help from any student

        // From IObservable
        public abstract IDisposable Subscribe(IObserver<object> observer);
        public abstract void Unsubscribe(IObserver<object> observer);

    }


   
   }
