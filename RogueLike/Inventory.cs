using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Inventory : List<IStuff>, IStuff {
        public float Weight {
            get {
                float totalWeight = 0;
                foreach (IStuff stuff in this) {
                    if (stuff != null) {
                        totalWeight += stuff.Weight;
                    }
                }
                return totalWeight;
            }
        }

        public Inventory() { }
    }
}
