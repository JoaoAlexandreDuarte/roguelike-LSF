using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Player {
        // Player baseWeight
        private float baseWeight;
        // Player x and y position
        public int x, y;

        // Player Hp
        public float Hp { get; set; } = 100;

        // Player's last move
        public string LastMove { get; set; }
        // Player's last interaction
        public string LastInteraction { get; set; }

        // Player Inventory and equiped weapon
        public Inventory myInventory;
        public Weapon equiptSlot;

        /// <summary>
        /// Get Player's Weight
        /// </summary>
        public float Weight {
            get {
                return baseWeight + myInventory.Weight +
                    (equiptSlot != default(Weapon) ? equiptSlot.Weight : 0);
            }
        }

        /// <summary>
        /// Construct a new Player
        /// </summary>
        /// <param name="baseWeight">Player base Weight</param>
        public Player(float baseWeight) {
            this.baseWeight = baseWeight;
            myInventory = new Inventory();
        }

        /// <summary>
        /// Returns the what % the Inventory is at
        /// </summary>
        /// <returns>Inventory filled percentage</returns>
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
