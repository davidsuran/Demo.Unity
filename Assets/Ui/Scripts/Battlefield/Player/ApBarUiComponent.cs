using Assets.Scripts.Core.Providers;
using Assets.Ui.Scripts.Core;
using Demo.Data.ObserverArguments;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Ui.Scripts.Battlefield.Player
{
    public class ApBarUiComponent : MonoBehaviour, IObserver<ActionPointsArguments>
    {
        private RectMask2D _mask;

        private const float BASE_WIDTH = 512f;
        private const float OFFSET = 25f;
        private const float SCALE = 0.5f;

        private RectTransform _image;
        private IDisposable _context;

        private void OnEnable()
        {
            _mask = _mask ?? transform.GetChild(0).GetComponent<RectMask2D>();
            _image = _image ?? transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();

            _context = ActiveUnitProvider.Instance.SubscribeToActionPointsComponent(this);
        }
        private void OnDisable()
        {
            ActiveUnitProvider.Instance.UnSubscribeToActionPointsComponent(this);
            _context.Dispose();
        }

        private void UpdateMask(float currentActionPoints, float maxActionPoints)
        {
            BarHelper.UpdateMask(currentActionPoints, maxActionPoints,
                BASE_WIDTH, OFFSET, SCALE,
                _mask, _image);
        }

        public void OnCompleted()
        {
            //ActiveUnitProvider.Instance.UnSubscribeToActionPointsComponent(this);
            //_context.Dispose();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(ActionPointsArguments value)
        {
            UpdateMask(value.CurrentActionPoints, value.MaximumActionPoints);
        }
    }
}
