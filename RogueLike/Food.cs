using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Food : IStuff {
        public string Type { get; }

        public float Weight { get; }

        public float Heal { get; }

        public Food(string type, float heal, float weight) : base() {
            Type = type;
            Weight = weight;
            Heal = heal;
        }

        public override string ToString() {
            return "Food (" + Type.ToString() + ")";
        }
    }
}
