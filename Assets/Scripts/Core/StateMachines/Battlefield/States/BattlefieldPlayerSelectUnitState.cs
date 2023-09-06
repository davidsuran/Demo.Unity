using Assets.Scripts.Core.StateMachines.Battlefield;
using Assets.Scripts.Core.StateMachines.Player.States;
using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StateMachines.Battlefield.States
{
    public class BattlefieldPlayerSelectUnitState : BattlefieldBaseState
    {
        //private List<IObserver<UnitListArguments>> _observers;

        public override string Name => nameof(BattlefieldPlayerSelectUnitState);

        public BattlefieldPlayerSelectUnitState(BattlefieldStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            // create ui here 

            StateMachine.NotifyObservers();
        }

        public override void Exit()
        {
            //StateMachine.UnSubscribe();
        }

        public override void Tick()
        {
        }

        ///// <summary>
        ///// Subscribes the specified observer.
        ///// </summary>
        ///// <param name="observer">The observer.</param>
        ///// <returns></returns>
        //public IDisposable Subscribe(IObserver<UnitListArguments> observer)
        //{
        //    //Debug.Log(observer);

        //    if (_observers == null)
        //    {
        //        _observers = new List<IObserver<UnitListArguments>>();
        //    }

        //    // Check whether observer is already registered. If not, add it
        //    if (!_observers.Contains(observer))
        //    {
        //        _observers.Add(observer);
        //        // Provide observer with existing data.
        //        observer.OnNext(
        //            new UnitListArguments(StateMachine.CurrentSquad.Soldiers, StateMachine.CurrentSquad.Drones));
        //    }

        //    return new Unsubscriber<UnitListArguments>(_observers, observer);
        //}

        ///// <summary>
        ///// Notifies the observers.
        ///// </summary>
        //private void NotifyObservers()
        //{
        //    foreach (IObserver<UnitListArguments> observer in _observers)
        //    {
        //        observer.OnNext(new UnitListArguments(StateMachine.CurrentSquad.Soldiers, StateMachine.CurrentSquad.Drones));
        //    }
        //}
    }
}
