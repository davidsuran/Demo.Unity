using System;
using UnityEngine;

namespace Assets.Scripts.Battlefield.Data.Serializable
{
    [Serializable]
    public class Animation
    {
        [SerializeField]
        private string idle;
        public int Idle => Animator.StringToHash(idle);

        [SerializeField]
        private string walk;
        public int Walk => Animator.StringToHash(walk);

        [SerializeField]
        private string prepareAttack;
        public int PrepareAttack => Animator.StringToHash(prepareAttack);

        [SerializeField]
        private string attack;
        public int Attack => Animator.StringToHash(attack);

        [SerializeField]
        private string death;
        public int Death => Animator.StringToHash(death);
    }
}
