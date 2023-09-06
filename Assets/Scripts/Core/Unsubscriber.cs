using System;
using System.Collections.Generic;

namespace Assets.Scripts.Core
{
    public class Unsubscriber<T> : IDisposable
    {
        private List<IObserver<T>> _observers;

        private IObserver<T> _observer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Unsubscriber{T}"/> class.
        /// </summary>
        /// <param name="observers">The observers.</param>
        /// <param name="observer">The observer.</param>
        public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            if (_observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}
