using System;

namespace Scripts.Common.EventArguments
{
    public class OnHitArgs : EventArgs
    {
        public float Damage { get; private set; }

        public OnHitArgs(float damage)
        {
            Damage = damage;
        }
    }
}
