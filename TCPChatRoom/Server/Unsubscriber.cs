using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;

namespace Server
{
    public class Unsubscriber : IDisposable
    {
        private List<IObserver<TcpClient>> _observers;
        private IObserver<TcpClient> _observer;

        public Unsubscriber(List<IObserver<TcpClient>> observers, IObserver<TcpClient> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }
        public void Dispose()
        {
            if (!(_observer == null)) _observers.Remove(_observer);
        }
    }
}
