using Demo.Data.ObserverArguments;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Components
{
    public class ActionPointsComponent : MonoBehaviour, IObservable<ActionPointsArguments>
    {
        /// <summary>
        /// Gets the action points.
        /// </summary>
        /// <value>
        /// The action points.
        /// </value>
        [SerializeField]
        public float CurrentActionPoints => _currentActionPoints;
        [SerializeField]
        private float _currentActionPoints = 100.00f;
        private float _previousActionPoints = 100.00f;

        [SerializeField]
        public float MaxActionPoints => _maxActionPoints;
        [SerializeField]
        private float _maxActionPoints = 100.00f;

        /// <summary>
        /// The distance traveled multiplier
        /// </summary>
        [SerializeField]
        private float distanceTraveledMultiplier = 10.00f;

        /// <summary>
        /// The on zero action points performed
        /// </summary>
        public Action OnZeroActionPointsPerformed;

        /// <summary>
        /// The observers
        /// </summary>
        private List<IObserver<ActionPointsArguments>> _observers;

        /// <summary>
        /// Called when [disable].
        /// </summary>
        private void OnDisable()
        {
            _observers.Clear();
        }

        /// <summary>
        /// Distances the traveled.
        /// </summary>
        /// <param name="distance">The distance.</param>
        public void DistanceTraveled(float distance)
        {
            _currentActionPoints = _currentActionPoints - (distance * distanceTraveledMultiplier);

            if (Mathf.Abs(_previousActionPoints - _currentActionPoints) > float.Epsilon)
            {
                NotifyObservers();
                _previousActionPoints = _currentActionPoints;
            }

            if (_currentActionPoints < 0.0001f)
            {
                OnZeroActionPointsPerformed?.Invoke();
            }

        }

        /// <summary>
        /// Subscribes the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <returns></returns>
        public IDisposable Subscribe(IObserver<ActionPointsArguments> observer)
        {
            if (_observers == null)
            {
                _observers = new List<IObserver<ActionPointsArguments>>();
            }

            // Check whether observer is already registered. If not, add it
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                // Provide observer with existing data.
                observer.OnNext(new ActionPointsArguments(_currentActionPoints, _maxActionPoints));
            }

            return new Unsubscriber<ActionPointsArguments>(_observers, observer);
        }

        /// <summary>
        /// Uns the subscribe.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void UnSubscribe(IObserver<ActionPointsArguments> observer)
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
        private void NotifyObservers()
        {
            if (_observers == null)
            {
                return;
            }

            foreach (IObserver<ActionPointsArguments> observer in _observers)
            {
                observer.OnNext(new ActionPointsArguments(_currentActionPoints, _maxActionPoints));
            }
        }

        /// <summary>
        /// Sets up.
        /// </summary>
        /// <param name="max">The maximum.</param>
        public void SetUp(float max)
        {
            _currentActionPoints = max;
            _previousActionPoints = max;
            _maxActionPoints = max;

            NotifyObservers();
        }
    }
}
