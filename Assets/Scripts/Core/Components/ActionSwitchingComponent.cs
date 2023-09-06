using Demo.Data.ObserverArguments;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Components
{
    public class ActionSwitchingComponent : MonoBehaviour, IObservable<ActionSelectionArguments>
    {

        public Action OnRightPerformed;
        
        public Action OnLeftPerformed;

        /// <summary>
        /// The observers
        /// </summary>
        private List<IObserver<ActionSelectionArguments>> _observers;

        private void Start()
        {
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
            _observers.Clear();
        }

        public void RotateRight()
        {
            OnRightPerformed?.Invoke();
            NotifyObservers(ActionSelectionDirection.Right);
        }

        public void RotateLeft()
        {
            OnLeftPerformed?.Invoke();
            NotifyObservers(ActionSelectionDirection.Left);
        }

        /// <summary>
        /// Subscribes the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IDisposable Subscribe(IObserver<ActionSelectionArguments> observer)
        {
            //Debug.Log(observer);

            if (_observers == null)
            {
                _observers = new List<IObserver<ActionSelectionArguments>>();
            }

            // Check whether observer is already registered. If not, add it
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                // Provide observer with existing data.
                observer.OnNext(new ActionSelectionArguments(ActionSelectionDirection.None));
            }

            return new Unsubscriber<ActionSelectionArguments>(_observers, observer);
        }

        /// <summary>
        /// Uns the subscribe.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void UnSubscribe(IObserver<ActionSelectionArguments> observer)
        {
            if (_observers.Contains(observer))
            {
                observer.OnCompleted();
                _observers.Remove(observer);
            }
        }

        /// <summary>
        /// Notifies the observers.
        /// </summary>
        private void NotifyObservers(ActionSelectionDirection direction)
        {
            foreach (IObserver<ActionSelectionArguments> observer in _observers)
            {
                observer.OnNext(new ActionSelectionArguments(direction));
            }
        }
    }
}
