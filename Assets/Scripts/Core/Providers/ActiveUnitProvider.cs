using Assets.Scripts.Core.StateMachines.Player;
using Demo.Data.ObserverArguments;
using System;
using UnityEngine;

namespace Assets.Scripts.Core.Providers
{
    public class ActiveUnitProvider
    {
        private PlayerStateMachine _playerStateMachine;

        public static ActiveUnitProvider Instance => _lazy.Value;

        private static readonly Lazy<ActiveUnitProvider> _lazy =
            new Lazy<ActiveUnitProvider>(() => new ActiveUnitProvider(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        private ActiveUnitProvider()
        {
        }

        public void UnLoadUnit()
        {
            _playerStateMachine = null;
        }

        public IDisposable SubscribeToHealthPointsComponent(IObserver<HealthPointsArguments> observer)
        {
            return _playerStateMachine.HealthPointsComponent.Subscribe(observer);
        }

        public void UnSubscribeToHealthPointsComponent(IObserver<HealthPointsArguments> observer)
        {
            _playerStateMachine.HealthPointsComponent?.UnSubscribe(observer);
        }

        public IDisposable SubscribeToActionPointsComponent(IObserver<ActionPointsArguments> observer)
        {
            return _playerStateMachine.ActionPointsComponent.Subscribe(observer);
        }

        public void UnSubscribeToActionPointsComponent(IObserver<ActionPointsArguments> observer)
        {
            _playerStateMachine.ActionPointsComponent?.UnSubscribe(observer);
        }

        public IDisposable SubscribeToActionSelection(IObserver<ActionSelectionArguments> observer)
        {
            return _playerStateMachine.ActionSwitchingComponent.Subscribe(observer);
        }

        public void UnSubscribeTActionSelection(IObserver<ActionSelectionArguments> observer)
        {
            _playerStateMachine.ActionSwitchingComponent.UnSubscribe(observer);
        }

        public void SwitchActivePlayer(PlayerStateMachine playerStateMachine)
        {
            CameraController.SetTurn();

            playerStateMachine.FreeLook.SetActive(true);
            if (playerStateMachine.Unit.Name != _playerStateMachine?.Unit?.Name)
            {
                _playerStateMachine?.FreeLook.SetActive(false);
            }

            _playerStateMachine = playerStateMachine;

            if (_playerStateMachine == null)
            {
                UnityEngine.Debug.LogError(nameof(_playerStateMachine));
            }

            _playerStateMachine.StartOfTurn();
        }

        public void CancelEndTurn()
        {
            _playerStateMachine.SwitchToActiveState();
        }

        internal void EndActivePlayerTurn()
        {
            CameraController.SetToEndOfTurn(_playerStateMachine.CameraLookAt);
            _playerStateMachine?.FreeLook.SetActive(false);

            _playerStateMachine.SwitchToNotMyTurnState();
        }

        public Vector3 WorldPosition()
        {
            return _playerStateMachine?.transform.position ?? Vector3.zero;
        }
    }
}
