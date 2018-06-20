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
        private Food myFood;
        private Weapon myWeapon;
        private NPC myNPC;

        // Current Level
        private int level;

        // Number of NPC
        private readonly int maxNPCs = 20;
        private readonly int baseNPCs = 5;
        // Multiplier
        private readonly float multiplier = 0.5f;
        // Number of traps
        private int baseTraps = 5;
        // Max Food
        private int food = 10;
        // Max Food
        private int weapon = 5;

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
            PlaceTheFood();
            PlaceTheWeapons();
            PlaceNPCs(level);
        }

        public void PlaceTheMap() {
            do {
                spawnRow = (int)(rnd.NextDouble() * myWorld.Rows);
                spawnCol = (int)(rnd.NextDouble() * myWorld.Columns);
            } while (myWorld.myTiles[spawnRow, spawnCol].Exit ||
                myWorld.myTiles[spawnRow, spawnCol].AsPlayer);

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

        private void PlaceTheFood() {
            List<string> FoodList = File.ReadAllLines(localFood).ToList();

            // Determine the number of food for this level
            int levelFood = rnd.Next(food);

            for (int i = 0; i < levelFood; i++) {
                int randomFood = rnd.Next(FoodList.Count());
                string[] foods = FoodList[randomFood].Split(' ');

                myFood = new Food(foods[0], Convert.ToSingle(foods[1]), Convert.ToSingle(foods[2]));

                do {
                    spawnRow = (int)(rnd.NextDouble() * myWorld.Rows);
                    spawnCol = (int)(rnd.NextDouble() * myWorld.Columns);
                } while (myWorld.myTiles[spawnRow, spawnCol].Exit);

                myWorld.myTiles[spawnRow, spawnCol].Insert(0, myFood);
            }
        }

        private void PlaceTheWeapons() {
            List<string> WeaponList = File.ReadAllLines(localWeapon).ToList();

            // Determine the number of food for this level
            int levelWeapon = rnd.Next(weapon);

            for (int i = 0; i < levelWeapon; i++) {
                int randomWeapon = rnd.Next(WeaponList.Count());
                string[] weapons = WeaponList[randomWeapon].Split(' ');

                myWeapon = new Weapon(weapons[0], Convert.ToSingle(weapons[1]),
                    Convert.ToSingle(weapons[2]), Convert.ToSingle(weapons[3]));

                do {
                    spawnRow = (int)(rnd.NextDouble() * myWorld.Rows);
                    spawnCol = (int)(rnd.NextDouble() * myWorld.Columns);
                } while (myWorld.myTiles[spawnRow, spawnCol].Exit);

                myWorld.myTiles[spawnRow, spawnCol].Insert(0, myWeapon);
            }
        }

        private void PlaceNPCs(int level) {
            myNPC = new NPC(level, rnd);
            int NPCftl;
            if (level < baseNPCs) {
                NPCftl = baseNPCs + level;
            } else {
                NPCftl = baseNPCs + (int)(level * multiplier);
            }

            NPCftl = rnd.Next(NPCftl);
            if (NPCftl > maxNPCs) NPCftl = maxNPCs;

            for (int i = 0; i < NPCftl; i++) {
                do {
                    spawnRow = (int)(rnd.NextDouble() * myWorld.Rows);
                    spawnCol = (int)(rnd.NextDouble() * myWorld.Columns);
                } while (myWorld.myTiles[spawnRow, spawnCol].Exit);

                myWorld.myTiles[spawnRow, spawnCol].Insert(0, myNPC);
            }
        }
    }
}
