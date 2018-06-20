using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Trap {
        public string MyTrap { get; set; }
        public int Damage { get; private set; }

        public bool FallenInto { get; set; }

        public Trap(string myTrap, int damage) {
            MyTrap = myTrap;
            Damage = damage;
        }

        public override string ToString() {
            return "Trap (" + MyTrap.ToString() + ")";
        }
    }
}
