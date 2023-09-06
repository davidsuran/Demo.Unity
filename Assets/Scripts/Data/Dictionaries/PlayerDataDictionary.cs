using Assets.Scripts.Battlefield.Data.Serializable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;
using Animation = Assets.Scripts.Battlefield.Data.Serializable.Animation;

namespace Assets.Scripts.Battlefield.Data.Dictionaries
{
    public class PlayerDataDictionary
    {
        private const string STATS_FILE_SUFFIX = "_stats";
        private const string ANIMATION_FILE_SUFFIX = "_animation";

        private static ReadOnlyDictionary<int, string> _stats;
        private static ReadOnlyDictionary<int, string> _animation;

        public static PlayerDataDictionary PlayerData => _lazy.Value;

        private static readonly Lazy<PlayerDataDictionary> _lazy =
            new Lazy<PlayerDataDictionary>(() => new PlayerDataDictionary(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>
        /// Prevents a default instance of the <see cref="PrefabDictionary"/> class from being created.
        /// </summary>
        private PlayerDataDictionary()
        {
            LoadStatsDictionary();
            LoadAnimationDictionary();
        }

        /// <summary>
        /// Gets the stats.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public Stats GetStats(int key)
        {
            if (_stats.TryGetValue(key, out string value))
            {
                Stats stats = JsonUtility.FromJson<Stats>(value);
                if (stats == new Stats())
                {
                    throw new ArgumentException(FormattableString.Invariant($"Stats were loaded with default values for key: {key}"));
                }

                return stats;
            }

            throw new ArgumentException(FormattableString.Invariant($"Prefab {key} doesn't exist."));
        }

        /// <summary>
        /// Gets the animation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public Animation GetAnimation(int key)
        {
            if (_animation.TryGetValue(key, out string animation))
            {
                return JsonUtility.FromJson<Animation>(animation);
            }

            throw new ArgumentException(FormattableString.Invariant($"Prefab {key} doesn't exist."));
        }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public Actions GetAction(int key)
        {
            if (_animation.TryGetValue(key, out string action))
            {
                return JsonUtility.FromJson<Actions>(action);
            }

            throw new ArgumentException(FormattableString.Invariant($"Prefab {key} doesn't exist."));
        }

        /// <summary>
        /// Loads the dictionary.
        /// </summary>
        private static void LoadStatsDictionary()
        {
            _stats = LoadDictionary(STATS_FILE_SUFFIX);
        }

        /// <summary>
        /// Loads the animation dictionary.
        /// </summary>
        private static void LoadAnimationDictionary()
        {
            _animation = LoadDictionary(ANIMATION_FILE_SUFFIX);
        }

        /// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <param name="suffix">The suffix.</param>
        /// <returns></returns>
        private static ReadOnlyDictionary<int, string> LoadDictionary(string suffix)
        {
            int[] playerIds = Battlefield.Data.Dictionaries.PrefabDictionary.Prefabs.GetAllPlayerIds().ToArray();
            IDictionary<int, string> dict = new Dictionary<int, string>(playerIds.Length);
            TextAsset file;

            foreach (int id in playerIds)
            {
                file = Resources.Load(FormattableString.Invariant($"{id}{suffix}")) as TextAsset;
                dict.Add(id, file.ToString());
            }

            return new ReadOnlyDictionary<int, string>(dict);
        }
    }
}
