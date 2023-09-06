using Assets.Scripts.Battlefield.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Demo.Data.Units
{
    public class Squad
    {
        //private int _squadSize;

        //[SerializeField]
        //public Transform BaseCamp;

        public int Id { get; }

        public GameObject ActiveUnit { get; private set; }

        public List<Soldier> Soldiers { get; private set; }

        public List<Drone> Drones { get; private set; }

        public Soldier Leader { get; private set; }

        public int Token { get; private set; }

        public int SquadSpeed { get; private set; }

        public Commander Commander { get; private set; }

        public int CurrentTokens { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Squad"/> class.
        /// </summary>
        public Squad(int squadId, int[] unitIds, Commander commander)
        {
            Id = squadId;
            Commander = commander;

            if (unitIds == null || unitIds.Length < 1)
            {
                throw new ArgumentException(nameof(unitIds));
            }

            CurrentTokens = 3;

            //_squadSize = unitIds.Length;
            LoadUnits(unitIds);
        }

        /// <summary>
        /// Loads the units.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">playerPrefab</exception>
        private void LoadUnits(int[] unitIds) 
        {
            Soldiers = new List<Soldier>();

            for (int i = 0; i < unitIds.Length; i++)
            {
                if (i >= 4)
                {
                    throw new ArgumentException($"Theres only 4 units i is {i}");
                }

                Soldier soldier = new Soldier(unitIds[i], this);

                SquadSpeed = SquadSpeed + soldier.Stats.Speed;

                Soldiers.Add(soldier);
            }

            Leader = Soldiers.First();

            Drones = new List<Drone>();
        }

        /// <summary>
        /// Instantiates the specified unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        public GameObject Instantiate(Unit unit, Vector3 position)
        {
            return unit.Instatiate(position);
        }

        /// <summary>
        /// Updates the current tokens.
        /// </summary>
        /// <param name="substract">The substract.</param>
        public void UpdateCurrentTokens(int substract)
        {
            CurrentTokens -= substract;
        }
    }
}
