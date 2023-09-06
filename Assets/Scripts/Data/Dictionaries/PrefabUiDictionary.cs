using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Assets.Scripts.Battlefield.Data.Dictionaries
{
    public class PrefabUictionary
    {
        private static ReadOnlyDictionary<int, string> _prefabs;

        public static PrefabUictionary Prefabs => _lazy.Value;

        private static readonly Lazy<PrefabUictionary> _lazy =
            new Lazy<PrefabUictionary>(() => new PrefabUictionary(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

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
        /// Prevents a default instance of the <see cref="PrefabDictionary"/> class from being created.
        /// </summary>
        private PrefabUictionary()
        {
            LoadDictionary();
        }

        /// <summary>
        /// Loads the dictionary.
        /// </summary>
        private static void LoadDictionary()
        {
            IDictionary<int, string> dict = new Dictionary<int, string>() 
            {
                { 1, "UnitListCell" },
                { 2, "UnitListTable" },
                { 3, "BattlefieldUi" },
                { 4, "1.3" }
             };

            _prefabs = new ReadOnlyDictionary<int, string>(dict);
        }
    }
}
