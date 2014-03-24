using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agents
{
    
    public abstract class Agent : IObserver<object>
    {
        // TODO

        // implement IObserver
        public abstract void OnCompleted();
        public abstract void OnError(Exception e);
        public abstract void OnNext(object data);
    }
}
