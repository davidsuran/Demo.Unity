using UnityEngine;

namespace Assets.Scripts.Core.StateMachines.Battlefield
{
    public class BaseCamp
    {
        public GameObject GameObject { get; private set; }

        public string State { get; set; }

        public BaseCamp(GameObject gameObject)
        {
            GameObject = gameObject;
            State = "PlayerOwned";
        }
    }
}
