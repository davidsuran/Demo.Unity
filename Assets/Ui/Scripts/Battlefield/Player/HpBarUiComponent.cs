using Assets.Scripts.Core.Providers;
using Assets.Ui.Scripts.Core;
using Demo.Data.ObserverArguments;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Ui.Scripts.Battlefield.Player
{
    public class HpBarUiComponent : MonoBehaviour, IObserver<HealthPointsArguments>
    {
        private RectMask2D _mask;
        private RectTransform _image;
        private IDisposable _context;

        private const float BASE_WIDTH = 512f;
        private const float OFFSET = 25f;
        private const float SCALE = 1f;

        private void OnEnable()
        {
            _mask = _mask ?? transform.GetChild(0).GetComponent<RectMask2D>();
            _image = _image ?? transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();

            _context = ActiveUnitProvider.Instance.SubscribeToHealthPointsComponent(this);
        }

        private void OnDisable()
        {
            ActiveUnitProvider.Instance.UnSubscribeToHealthPointsComponent(this);
            _context.Dispose();
        }

        private void UpdateMask(float currentHealthPoints, float maxHealthPoints)
        {
            BarHelper.UpdateMask(currentHealthPoints, maxHealthPoints,
                BASE_WIDTH, OFFSET, SCALE,
                _mask, _image);
        }

        public void OnCompleted()
        {
            //ActiveUnitProvider.Instance.UnSubscribeToHealthPointsComponent(this);
            //_context.Dispose();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(HealthPointsArguments value)
        {
            UpdateMask(value.CurrentHealthPoints, value.MaximumHealthPoints);
        }
    }
}
