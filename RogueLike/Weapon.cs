using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Weapon : IStuff {
        public float Weight { get; }

        public float AttackPower { get; }

        public float Durability { get; }

        public string Type { get; }

        public Weapon(string type, float attack, float weight, float durability) : base() {
            Type = type;
            Weight = weight;
            AttackPower = attack;
            Durability = durability;
        }

        public override string ToString() {
            return "Weapon (" + Type.ToString() + ")";
        }
    }
}
