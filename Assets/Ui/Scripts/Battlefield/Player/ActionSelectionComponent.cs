using System;
using UnityEngine;
using Demo.Data.ObserverArguments;

namespace Assets.Ui.Scripts.Battlefield.Player
{
    public class ActionSelectionComponent : MonoBehaviour, IObserver<ActionSelectionArguments>
    {
        private void OnEnable()
        {
            //_mask = _mask ?? transform.GetChild(0).GetComponent<RectMask2D>();
            //_image = _image ?? transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();

            //_context = ActiveUnitProvider.Instance.SubscribeToActionPointsComponent(this);
        }
        private void OnDisable()
        {
            //ActiveUnitProvider.Instance.UnSubscribeToActionPointsComponent(this);
            //_context.Dispose();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(ActionSelectionArguments value)
        {
            throw new NotImplementedException();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}