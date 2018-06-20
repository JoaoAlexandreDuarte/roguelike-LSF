using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Trap {
        // Trap name
        public string MyTrap { get; set; }
        // Trap Damage
        public int Damage { get; private set; }
        // Check if the player as already fallen into the trap before
        public bool FallenInto { get; set; }

        /// <summary>
        /// Construct a new Trap
        /// </summary>
        /// <param name="myTrap">Trap Name</param>
        /// <param name="damage">Trap Maximum Damage</param>
        public Trap(string myTrap, int damage) {
            MyTrap = myTrap;
            Damage = damage;
        }

        /// <summary>
        /// Override ToString
        /// </summary>
        /// <returns>Information about the trap</returns>
        public override string ToString() {
            return "Trap (" + MyTrap.ToString() + ")";
        }
    }
}
