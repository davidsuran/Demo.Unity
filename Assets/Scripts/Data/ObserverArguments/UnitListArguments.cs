using Demo.Data.Units;
using System.Collections.Generic;

namespace Demo.Data.ObserverArguments
{
    public class UnitListArguments : IObserverArguments
    {
        /// <summary>
        /// The drones
        /// </summary>
        public List<Drone> Drones;

        /// <summary>
        /// The soldiers
        /// </summary>
        public List<Soldier> Soldiers;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitListArguments" /> class.
        /// </summary>
        /// <param name="units">The units.</param>
        public UnitListArguments(List<Soldier> soldiers)
        {
            Soldiers = soldiers;
            Drones = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitListArguments"/> class.
        /// </summary>
        /// <param name="soldiers">The soldiers.</param>
        /// <param name="drones">The drones.</param>
        public UnitListArguments(List<Soldier> soldiers, List<Drone> drones)
        {
            Soldiers = soldiers;
            Drones = drones;
        }
    }
}
