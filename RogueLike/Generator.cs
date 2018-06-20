using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Generator {
        Random rnd;

        // Generator Objects
        private World myWorld;
        public Map myMap;
        private Trap myTrap;

        // Current Level
        private int level;

        // Multiplier
        private readonly float multiplier = 0.5f;
        // Number of traps
        private int baseTraps = 5;

        // Get a random value for the Row and Column
        int spawnRow;
        int spawnCol;

        // Files location
        private readonly string localTrap = "Trap.txt";
        private readonly string localFood = "Food.txt";
        private readonly string localWeapon = "Weapon.txt";

        public Generator(int level, World myWorld, Random rnd) {
            this.rnd = rnd;
            this.level = level;
            this.myWorld = myWorld;
            myMap = new Map();
            PlaceTheMap();
            PlaceTraps();
        }

        public void PlaceTheMap() {
            int spawnRow = (int)(rnd.NextDouble() * myWorld.Rows);
            int spawnCol = (int)(rnd.NextDouble() * myWorld.Columns);
            myWorld.myTiles[spawnRow, spawnCol].Insert(0, myMap);
        }

        public void PlaceTraps() {
            List<string> TrapList = File.ReadAllLines(localTrap).ToList();

            // Determine the max number of traps for this level
            int maxTraps;
            if (level < baseTraps) {
                maxTraps = baseTraps + level;
            } else {
                maxTraps = baseTraps + (int)(level * multiplier);
            }

            baseTraps = rnd.Next(maxTraps);

            for (int i = 0; i < baseTraps; i++) {
                int randomTrap = rnd.Next(TrapList.Count());
                string[] trap = TrapList[randomTrap].Split(' ');

                myTrap = new Trap(trap[0], Convert.ToInt32(trap[1]));

                do {
                    spawnRow = (int)(rnd.NextDouble() * myWorld.Rows);
                    spawnCol = (int)(rnd.NextDouble() * myWorld.Columns);
                } while (myWorld.myTiles[spawnRow, spawnCol].Exit ||
                myWorld.myTiles[spawnRow, spawnCol].AsPlayer);

                myWorld.myTiles[spawnRow, spawnCol].Insert(0, myTrap);
            }
        }
    }
}
