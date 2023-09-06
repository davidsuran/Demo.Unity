using Assets.Scripts.Battlefield.Data.Dictionaries;
using Assets.Scripts.Battlefield.Data.Serializable;
using System;
using UnityEngine;
using Animation = Assets.Scripts.Battlefield.Data.Serializable.Animation;

namespace Demo.Data
{
    public static class ResourceLoader
    {
        /// <summary>
        /// Loads the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="System.ArgumentNullException">prefab</exception>
        public static GameObject LoadPrefab(int id)
        {
            GameObject prefab = Resources.Load(PrefabDictionary.Prefabs.GetPrefab(id)) as GameObject;
            if (prefab == null)
            {
                throw new ArgumentNullException(nameof(prefab), FormattableString.Invariant($"Failed to load prefab {id}."));
            }

            return prefab;
        }

        /// <summary>
        /// Loads the stats.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">stats</exception>
        public static Stats LoadStats(int id)
        {
            Stats stats = PlayerDataDictionary.PlayerData.GetStats(id);
            if (stats == null)
            {
                throw new ArgumentNullException(nameof(stats), FormattableString.Invariant($"Failed to load stats {id}."));
            }

            return stats;
        }

        /// <summary>
        /// Loads the animation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">animation</exception>
        public static Animation LoadAnimation(int id)
        {
            Animation animation = PlayerDataDictionary.PlayerData.GetAnimation(id);
            if (animation == null)
            {
                throw new ArgumentNullException(nameof(animation), FormattableString.Invariant($"Failed to load animation {id}."));
            }

            return animation;
        }

        /// <summary>
        /// Loads the UI.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="System.ArgumentNullException">prefab</exception>
        public static GameObject LoadUi(int id)
        {
            GameObject prefab = Resources.Load(PrefabUictionary.Prefabs.GetPrefab(id)) as GameObject;
            if (prefab == null)
            {
                throw new ArgumentNullException(nameof(prefab), FormattableString.Invariant($"Failed to load Ui prefab {id}."));
            }

            return prefab;
        }
    }
}
