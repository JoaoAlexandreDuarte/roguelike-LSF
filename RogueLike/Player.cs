using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Player {
        private float baseWeight;
        public int x, y;

        public float Hp { get; set; } = 100;

        public string LastMove { get; set; }
        public string LastInteraction { get; set; }

        public Inventory myInventory;
        public Weapon equiptSlot;

        public float Weight {
            get {
                return baseWeight + myInventory.Weight +
                    (equiptSlot != default(Weapon) ? equiptSlot.Weight : 0);
            }
        }

        public Player(float baseWeight) {
            this.baseWeight = baseWeight;
            myInventory = new Inventory();
        }

        public string InventoryPercentage() {
            string percent;
            if (equiptSlot != default(Weapon)) {
                percent = string.Format("{0:p2}",
                    (myInventory.Weight + equiptSlot.Weight) / Weight);
            } else {
                percent = string.Format("{0:p2}", myInventory.Weight / Weight);
            }

            return percent;
        }
    }
}
