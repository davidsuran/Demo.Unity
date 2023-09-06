using Assets.Scripts.Battlefield.Data.Serializable;
using Assets.Scripts.Battlefield.Data;
using UnityEngine;
using Animation = Assets.Scripts.Battlefield.Data.Serializable.Animation;
using Random = System.Random;

namespace Demo.Data.Units
{
    public abstract class Unit
    {
        public GameObject GameObject { get; private set; }

        public readonly string Name;

        public readonly int PrefabId;

        private GameObject _prefab;

        public readonly int Cost;

        public readonly Squad Squad;

        public Stats Stats { get; private set; }
        public Animation Animation { get; private set; }

        public Unit(int prefabId, Squad squad)
        {
            PrefabId = prefabId;
            Squad = squad;

            Stats = ResourceLoader.LoadStats(prefabId);
            Animation = ResourceLoader.LoadAnimation(prefabId);

            Name = ((PlayerType)prefabId).ToString();
        }

        public virtual GameObject Instatiate(Vector3 position)
        {
            if (_prefab == null)
            {
                _prefab = ResourceLoader.LoadPrefab(PrefabId);
            }

            GameObject = GameObject.Instantiate(_prefab, position, Quaternion.identity);
            return GameObject;
        }

        public void TakeTurn()
        {
            Squad.UpdateCurrentTokens(Cost);
        }
    }
}
