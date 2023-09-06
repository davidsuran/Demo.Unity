using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    [Serializable]

    public class GameObjectPooler
    {
        public List<GameObjectPool> pools;
        public Dictionary<string, (Queue<GameObject>, Quaternion)> poolDictionary;

        public GameObjectPooler()
        {
        }

        /// <summary>
        /// Loads the specified parent transform.
        /// </summary>
        /// <param name="parentTransform">The parent transform.</param>
        public void Load(Transform parentTransform = null)
        {
            poolDictionary = new Dictionary<string, (Queue<GameObject>, Quaternion)>();

            foreach (GameObjectPool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                GameObject obj = null;
                for (int i = 0; i < pool.size; i++)
                {
                    obj = UnityEngine.Object.Instantiate(pool.prefab);
                    obj.transform.parent = parentTransform;
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag, (objectPool, obj.transform.rotation));
            }
        }

        /// <summary>
        /// Spawns from pool.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public GameObject SpawnFromPool(string tag)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning($"Pool with tag {tag} doesnt exist.");

                return null;
            }

            if (poolDictionary[tag].Item1.Count == 0)
            {
                return null;
            }

            GameObject objectToSpawn = poolDictionary[tag].Item1.Dequeue();

            if (objectToSpawn == null)
            {
                Debug.LogWarning($"No more objects with tag {tag}.");

                return null;
            }

            objectToSpawn.transform.rotation = poolDictionary[tag].Item2;
            objectToSpawn.SetActive(true);

            return objectToSpawn;
        }

        /// <summary>
        /// Returns to pool.
        /// </summary>
        /// <param name="tag">The tag.</param>
        public void ReturnToPool(string tag)
        {
            if (poolDictionary.ContainsKey(tag))
            {
                foreach (GameObject gameObject in poolDictionary[tag].Item1)
                {
                    if (gameObject != null)
                    {
                        ReturnToPool(tag, gameObject);
                    }
                }
            }
        }

        /// <summary>
        /// Returns to pool.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="gameObject">The game object.</param>
        public void ReturnToPool(string tag, GameObject gameObject)
        {
            poolDictionary[tag].Item1.Enqueue(gameObject);
            gameObject.GetComponent<MeshRenderer>().enabled = true; //TODO
            gameObject.SetActive(false);
        }
    }
}
