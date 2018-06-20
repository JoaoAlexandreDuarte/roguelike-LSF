using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Generator {
        Random rnd;

        // Generator Objects
        private World myWorld;
        public Map myMap;

        // Current Level
        private int level;

        public Generator(int level, World myWorld, Random rnd) {
            this.rnd = rnd;
            this.level = level;
            this.myWorld = myWorld;
            myMap = new Map();
            PlaceTheMap();
        }

        public void PlaceTheMap() {
            int spawnRow = (int)(rnd.NextDouble() * myWorld.Rows);
            int spawnCol = (int)(rnd.NextDouble() * myWorld.Columns);
            myWorld.myTiles[spawnRow, spawnCol].Insert(0, myMap);
        }
    }
}
