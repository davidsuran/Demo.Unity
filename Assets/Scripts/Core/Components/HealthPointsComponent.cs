using Demo.Data.ObserverArguments;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Components
{
    public class HealthPointsComponent : MonoBehaviour, IObservable<HealthPointsArguments>
    {
        /// <summary>
        /// Gets the health points.
        /// </summary>
        /// <value>
        /// The health points.
        /// </value>
        [SerializeField]
        public float CurrentHealthPoints => _currentHealthPoints;
        [SerializeField]
        private float _currentHealthPoints = 100.00f;

        /// <summary>
        /// Gets the maximum health points.
        /// </summary>
        /// <value>
        /// The maximum health points.
        /// </value>
        [SerializeField]
        public float MaxHealthPoints => _maxHealthPoints;
        [SerializeField]
        private float _maxHealthPoints = 100.00f;

        /// <summary>
        /// The on zero health performed
        /// </summary>
        public Action OnZeroHealthPerformed;

        /// <summary>
        /// The observers
        /// </summary>
        private List<IObserver<HealthPointsArguments>> _observers;


        /// <summary>
        /// Starts this instance.
        /// </summary>
        private void Start()
        {
        }

        private void OnEnable()
        {
            //_observers = new List<IObserver<HealthPointsArguments>>();

        }

        private void OnDisable()
        {
            _observers.Clear();
        }

        /// <summary>
        /// Takes the damage.
        /// </summary>
        /// <param name="damage">The damage.</param>
        public void TakeDamage(float damage)
        {
            _currentHealthPoints = _currentHealthPoints - damage;
            
            NotifyObservers();
            
            if (_currentHealthPoints < 0.0001f)
            {
                OnZeroHealthPerformed?.Invoke();
            }
        }

        /// <summary>
        /// Sets up.
        /// </summary>
        /// <param name="current">The current.</param>
        /// <param name="max">The maximum.</param>
        public void SetUp(float max)
        {
            _currentHealthPoints = max;
            _maxHealthPoints = max;
        }

        #region Observable

        /// <summary>
        /// Subscribes the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <returns></returns>
        public IDisposable Subscribe(IObserver<HealthPointsArguments> observer)
        {
            //Debug.Log(observer);

            if (_observers == null)
            {
                _observers = new List<IObserver<HealthPointsArguments>>();
            }

            // Check whether observer is already registered. If not, add it
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                // Provide observer with existing data.
                observer.OnNext(new HealthPointsArguments(_currentHealthPoints, _maxHealthPoints));
            }

            return new Unsubscriber<HealthPointsArguments>(_observers, observer);
        }

        /// <summary>
        /// Unsubscribes the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void UnSubscribe(IObserver<HealthPointsArguments> observer)
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
            foreach (IObserver<HealthPointsArguments> observer in _observers)
            {
                observer.OnNext(new HealthPointsArguments(_currentHealthPoints, _maxHealthPoints));
            }
        }

        #endregion Observable
    }
}
