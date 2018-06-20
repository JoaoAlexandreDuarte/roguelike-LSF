using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Food : IStuff {
        // Name of the Food
        public string Type { get; }

        // Weight of the Food
        public float Weight { get; }

        // Level of healing of the Food
        public float Heal { get; }

        /// <summary>
        /// Food Constructor
        /// </summary>
        /// <param name="type">Name of the food</param>
        /// <param name="heal">Level of healing of the Food</param>
        /// <param name="weight">Weight of the Food</param>
        public Food(string type, float heal, float weight) : base() {
            Type = type;
            Weight = weight;
            Heal = heal;
        }

        // Override ToString, to display information about the food
        public override string ToString() {
            return "Food (" + Type.ToString() + ")";
        }
    }
}
