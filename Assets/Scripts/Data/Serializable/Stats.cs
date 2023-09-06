using System;
using UnityEngine;

namespace Assets.Scripts.Battlefield.Data.Serializable
{
    [Serializable]
    public class Stats
    {
        [SerializeField]
        private float healthPoints;
        public float HealthPoints => healthPoints;
        
        [SerializeField]
        private float actionPoints;
        public float ActionPoints => actionPoints;
        
        [SerializeField]
        private float attack;
        public float Attack => attack;
        
        [SerializeField]
        private float defense;
        public float Defense => defense;

        [SerializeField]
        private int speed;
        public int Speed => speed;
        
        [SerializeField]
        private int cost;
        public int Cost => cost;

    }
}
