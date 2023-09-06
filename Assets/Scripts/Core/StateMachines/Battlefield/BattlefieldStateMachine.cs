using Assets.Scripts.Battlefield.Data;
using Assets.Scripts.Battlefield.Data.StateMachine;
using Assets.Scripts.Core.Providers;
using Assets.Scripts.Core.StateMachines.Battlefield.States;
using Assets.Scripts.Core.StateMachines.Player;
using Assets.Scripts.StateMachines.Battlefield.States;
using Demo.Data.ObserverArguments;
using Demo.Data.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Core.StateMachines.Battlefield
{
    public class BattlefieldStateMachine : StateMachine
    {
        private BaseCamp[] BaseCamps;

        private Platoon _playerPlatoon;

        private Platoon _enemyPlatoon;

        private IEnumerator<Squad> _currentSquad;

        private List<IObserver<UnitListArguments>> _observers;

        public Squad CurrentSquad => _currentSquad.Current;

        public BattlefieldUiViewController BattlefieldUiViewController;

        private void Awake()
        {
            LoadPlatoons();
            LoadBaseCamps();

            BattlefieldUiViewController = new BattlefieldUiViewController();

            BattlefieldProvider.Instance.LoadBattlefield(this);
            BattlefieldUiViewController.ShowUnitListDialog();
        }

        private void Start()
        {
            SwitchState(new BattlefieldPlayerSelectUnitState(this));
        }

        private void LoadPlatoons()
        {
            _playerPlatoon = new Platoon(Commander.Player);
            _enemyPlatoon = new Platoon(Commander.Enemy);

            Squad[] orderedSquads = GetSquadTurnOrder();

            var x = ((IEnumerable<Squad>)orderedSquads);

            _currentSquad = x.GetEnumerator();
            if (!_currentSquad.MoveNext())
            {
                throw new InvalidOperationException("Can't move to next squad");
            }
            //foreach (Squad os in orderedSquads)
            //{
            //    Debug.Log(FormattableString.Invariant($"Id:{os.Id}, Speed:{os.SquadSpeed}, Commander:{os.Commander}"));
            //}
        }

        private void LoadBaseCamps()
        {
            BaseCamps = GameObject.FindGameObjectsWithTag("BaseCamp").Select(g => new BaseCamp(g)).ToArray();
        }

        private Squad[] GetSquadTurnOrder()
        {
            Squad[] allSquads = _playerPlatoon.Squads.Concat(_enemyPlatoon.Squads).ToArray();
            bool finished;

            for (int ii = 0; ii < allSquads.Length - 1; ii++)
            {
                finished = true;
                for (int i = 0; i < allSquads.Length - ii - 1; i++)
                {
                    void Swap()
                    {
                        Squad tmp = allSquads[i];
                        allSquads[i] = allSquads[i + 1];
                        allSquads[i + 1] = tmp;
                        finished = false;
                    }

                    if (allSquads[i].SquadSpeed > allSquads[i + 1].SquadSpeed)
                    {
                        Swap();
                    }
                    else if (allSquads[i].SquadSpeed == allSquads[i + 1].SquadSpeed)
                    {
                        if (allSquads[i].Commander > allSquads[i + 1].Commander)
                        {
                            Swap();
                        }
                    }                  
                }

                if (finished)
                {
                    break;
                }
            }

            return allSquads;
        }

        /// <summary>
        /// Subscribes the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <returns></returns>
        public IDisposable Subscribe(IObserver<UnitListArguments> observer)
        {
            //Debug.Log(observer);

            if (_observers == null)
            {
                _observers = new List<IObserver<UnitListArguments>>();
            }

            // Check whether observer is already registered. If not, add it
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                // Provide observer with existing data.
                observer.OnNext(
                    new UnitListArguments(CurrentSquad.Soldiers, CurrentSquad.Drones));
            }

            return new Unsubscriber<UnitListArguments>(_observers, observer);
        }

        /// <summary>
        /// Uns the subscribe.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void UnSubscribe(IObserver<UnitListArguments> observer)
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
        public void NotifyObservers()
        {
            foreach (IObserver<UnitListArguments> observer in _observers)
            {
                observer.OnNext(new UnitListArguments(CurrentSquad.Soldiers, CurrentSquad.Drones));
            }
        }

        /// <summary>
        /// Units the selected.
        /// </summary>
        /// <param name="unit">The unit.</param>
        internal void UnitSelected(string name)
        {
            Soldier soldier = CurrentSquad.Soldiers.Single(_ => _.Name == name);

            if (soldier != null)
            {
                SwitchState(new BattlefieldPlayerTurnState(this));

                PlayerStateMachine playerStateMachine = null;

                if (soldier.GameObject == null)
                {
                    soldier.Instatiate(BaseCamps.First().GameObject.transform.position);

                    playerStateMachine = soldier.GameObject.GetComponent<PlayerStateMachine>();
                    playerStateMachine.SetUnit(soldier);
                }

                playerStateMachine = playerStateMachine ?? soldier.GameObject.GetComponent<PlayerStateMachine>();
                ActiveUnitProvider.Instance.SwitchActivePlayer(playerStateMachine);
                
                soldier.TakeTurn();
            }
        }

        internal void ShowUnitHealthPointsBar()
        {
            BattlefieldUiViewController.ShowUnitHealthPointsBar();
        }
        internal void HideUnitHealthPointsBar()
        {
            BattlefieldUiViewController.HideUnitHealthPointsBar();
        }

        internal void ShowUnitActionPointsBar()
        {
            BattlefieldUiViewController.ShowUnitActionPointsBar();
        }

        internal void HideUnitActionPointsBar()
        {
            BattlefieldUiViewController.HideUnitActionPointsBar();
        }

        internal void ShowEndTurnDialog()
        {
            BattlefieldUiViewController.ShowEndTurnDialog();
        }

        internal void HideEndTurnDialog()
        {
            BattlefieldUiViewController.HideEndTurnDialog();
        }

        internal void ShowCrosshair()
        {
            BattlefieldUiViewController.ShowCrosshair();
        }

        internal void HideCrosshair()
        {
            BattlefieldUiViewController.HideCrosshair();
        }

        internal void EndActivePlayerTurn()
        {
            SwitchState(new BattlefieldEndOfTurnState(this));

        }
    }
}
