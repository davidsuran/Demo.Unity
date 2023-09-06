using Scripts.Common.EventArguments;
using System;
using UnityEngine;

namespace Assets.Scripts.Core.Components
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class HitableComponent : MonoBehaviour
    {
        public event EventHandler<OnHitArgs> OnFireHitReceivedEvent;

        private void OnTriggerEnter(Collider collider)
        {
            SafeInvokeOnFireHitReceivedEvent(5f);
            //if (collider.gameObject.tag == "Bullet")
            //{
            //    OnCriticalHitReceivedPerformed?.Invoke();

            //}
        }

        protected void SafeInvokeOnFireHitReceivedEvent(float damage)
        {
            OnFireHitReceivedEvent?.Invoke(null, new OnHitArgs(damage));
        }
    }
}
