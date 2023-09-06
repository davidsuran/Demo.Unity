using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Assets.Scripts.Battlefield.Data.Dictionaries
{
    public class PrefabDictionary
    {
        private static ReadOnlyDictionary<int, string> _prefabs;

        public static PrefabDictionary Prefabs => _lazy.Value;

        private static readonly Lazy<PrefabDictionary> _lazy =
            new Lazy<PrefabDictionary>(() => new PrefabDictionary(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>
        /// Prevents a default instance of the <see cref="PrefabDictionary"/> class from being created.
        /// </summary>
        private PrefabDictionary()
        {
            LoadDictionary();
        }

        /// <summary>
        /// Gets the prefab.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public string GetPrefab(int key)
        {
            if (_prefabs.TryGetValue(key, out string prefab))
            { 
                return prefab;
            }

            throw new ArgumentException(FormattableString.Invariant($"Prefab {key} doesn't exist."));
        }

        /// <summary>
        /// Loads the dictionary.
        /// </summary>
        private static void LoadDictionary()
        {
            IDictionary<int, string> dict = new Dictionary<int, string>() 
            {
                { (int)PlayerType.Artillery, PlayerType.Artillery.ToString() },
                { (int)PlayerType.Heavy, PlayerType.Heavy.ToString() },
                { (int)PlayerType.MachineGunner, PlayerType.MachineGunner.ToString() },
                { (int)PlayerType.Sniper, PlayerType.Sniper.ToString() },
                {5, "Arc" },
                {6, "Point" },

             };

            _prefabs = new ReadOnlyDictionary<int, string>(dict);
        }

        internal IEnumerable<int> GetAllPlayerIds()
        {
            return _prefabs.Where(_ => _.Key <= 4).Select(_ => _.Key);
        }
    }
}
