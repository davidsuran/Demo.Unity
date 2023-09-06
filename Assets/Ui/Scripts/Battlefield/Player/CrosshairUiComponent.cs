using Demo.Data.ObserverArguments;
using System;
using UnityEngine;

namespace Assets.Ui.Scripts.Battlefield.Player
{
    public class CrosshairUiComponent : MonoBehaviour, IObserver<CrosshairArguments>
    {
        private void OnEnable()
        {
            //_context = ActiveUnitProvider.Instance.SubscribeToHealthPointsComponent(this);
        }

        private void OnDisable()
        {
            //ActiveUnitProvider.Instance.UnSubscribeToHealthPointsComponent(this);
            //_context.Dispose();
        }

        private void Update()
        {
            transform.position = Input.mousePosition;
        }

        void IObserver<CrosshairArguments>.OnCompleted()
        {
            throw new NotImplementedException();
        }

        void IObserver<CrosshairArguments>.OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        void IObserver<CrosshairArguments>.OnNext(CrosshairArguments value)
        {
            throw new NotImplementedException();
        }
    }
}
