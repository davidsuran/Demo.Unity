using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Components
{
    public class CritableComponent : HitableComponent
    {
        // TODO: critting critable should cause large AoE

        public float Multiplier = 1.5f;

        private void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            //if (collider.gameObject.tag == "Bullet")
            //{
            //    OnCriticalHitReceivedPerformed?.Invoke();
            //}
        }

        private void OnTriggerEnter(Collider collider)
        {
            Debug.Log("crittable");
            base.SafeInvokeOnFireHitReceivedEvent(5f * Multiplier);
            //if (collider.gameObject.tag == "Bullet")
            //{
            //    OnCriticalHitReceivedPerformed?.Invoke();
            //}
        }
    }
}

