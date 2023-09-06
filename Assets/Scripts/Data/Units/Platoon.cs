using Assets.Scripts.Battlefield.Data;
using System.Collections.Generic;

namespace Demo.Data.Units
{
    public class Platoon
    {
        public List<Squad> Squads { get; private set; }

        public Commander Commander { get; private set; }

        public int MaxSquadNumber { get; private set; }

        private const int PLAYER_PREFAB_ID = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Platoon"/> class.
        /// </summary>
        /// <param name="commander">The commander.</param>
        public Platoon(Commander commander)
        {
            Commander = commander;
            MaxSquadNumber = 4;
            LoadSquads();
        }

        /// <summary>
        /// Loads the squads.
        /// </summary>
        private void LoadSquads()
        {
            Squads = new List<Squad>(MaxSquadNumber);

            for (int i = 0; i < MaxSquadNumber; i++)
            {
                // TODO: id of squad commander (TODO: unique unit id)
                int squadId = i + 1;
                int[] unitIds = new int[]
                {
                    (int)PlayerType.MachineGunner,
                    (int)PlayerType.Heavy,
                    (int)PlayerType.Artillery,
                    (int)PlayerType.Sniper
                };
                Squads.Add(new Squad(squadId, unitIds, Commander));
            }
        }
    }
}
