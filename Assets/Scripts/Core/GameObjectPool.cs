using System;
using UnityEngine;

namespace Assets.Scripts.Core
{
    [Serializable]
    public class GameObjectPool
    {
        public string tag;

        public GameObject prefab;

        public Quaternion prefabRotation;

        public int size;
    }
}
