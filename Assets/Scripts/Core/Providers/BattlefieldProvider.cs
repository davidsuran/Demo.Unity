using Assets.Scripts.Core.StateMachines.Battlefield;
using Demo.Data.ObserverArguments;
using System;

namespace Assets.Scripts.Core.Providers
{
    public class BattlefieldProvider
    {
        private BattlefieldStateMachine _battlefieldStateMachine;

        public static BattlefieldProvider Instance => _lazy.Value;

        private static readonly Lazy<BattlefieldProvider> _lazy =
            new Lazy<BattlefieldProvider>(() => new BattlefieldProvider(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        //public HealthPointsComponent HealthPointsComponent => _playerStateMachine?.HealthPointsComponent;

        private BattlefieldProvider()
        {
        }

        public void LoadBattlefield(BattlefieldStateMachine playerStateMachine)
        {
            _battlefieldStateMachine = playerStateMachine;
        }

        public void UnLoadBattlefield()
        {
            _battlefieldStateMachine = null;
        }

        public IDisposable SubscribeToBattlefield(IObserver<UnitListArguments> observer)
        {
            return _battlefieldStateMachine.Subscribe(observer);
        }

        public void UnSubscribeToBattlefield(IObserver<UnitListArguments> observer)
        {
            _battlefieldStateMachine.UnSubscribe(observer);
        }

        public void UnitSelected(string name)
        {
            _battlefieldStateMachine.UnitSelected(name);
        }

        public void ShowUnitsHealthBar()
        {
            _battlefieldStateMachine.ShowUnitHealthPointsBar();
        }

        public void HideUnitsHealthBar()
        {
            _battlefieldStateMachine.HideUnitHealthPointsBar();
        }

        public void ShowUnitsActionBar()
        {
            _battlefieldStateMachine.ShowUnitActionPointsBar();
        }

        public void HideUnitsActionBar()
        {
            _battlefieldStateMachine.HideUnitActionPointsBar();
        }

        public void ShowEndTurnDialog()
        {
            _battlefieldStateMachine.ShowEndTurnDialog();
        }

        public void HideEndTurnDialog()
        {
            _battlefieldStateMachine.HideEndTurnDialog();
        }

        public void EndActivePlayerTurn()
        {
            _battlefieldStateMachine.EndActivePlayerTurn();
        }

        public void ShowCrosshair()
        {
            _battlefieldStateMachine.ShowCrosshair();
        }

        public void HideCrosshair()
        {
            _battlefieldStateMachine.HideCrosshair();
        }
    }
}
