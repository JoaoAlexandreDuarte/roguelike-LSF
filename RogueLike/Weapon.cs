using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    /// <summary>
    /// Creates a new Weapon
    /// </summary>
    class Weapon : IStuff {
        // Weapon Weight
        public float Weight { get; }
        // Weapon max damage
        public float AttackPower { get; }
        // Weapon Durability
        public float Durability { get; }
        // Name of the weapon
        public string Type { get; }

        /// <summary>
        /// Construct a new Weapon
        /// </summary>
        /// <param name="type">Name of the weapon</param>
        /// <param name="attack">Weapon max damage</param>
        /// <param name="weight">Weapon Weight</param>
        /// <param name="durability">Weapon Durability</param>
        public Weapon(string type, float attack, float weight, float durability) : base() {
            Type = type;
            Weight = weight;
            AttackPower = attack;
            Durability = durability;
        }

        /// <summary>
        /// Override ToString
        /// </summary>
        /// <returns>Information about the weapon</returns>
        public override string ToString() {
            return "Weapon (" + Type.ToString() + ")";
        }
    }
}
