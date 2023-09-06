using System;
using UnityEngine;

namespace Assets.Scripts.Battlefield.Data.Serializable
{
    [Serializable]
    public class Actions
    {
        [SerializeField]
        private string[] weapons;
        public string[] Weapons => weapons;

        [SerializeField]
        private string heal;
        public string Heal => heal;

        [SerializeField]
        private string[] grenade;
        public string[] Grenade => grenade;
    }
}
