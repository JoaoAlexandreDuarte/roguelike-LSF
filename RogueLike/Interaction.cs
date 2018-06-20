using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Interaction {
        // Pre Generated Random seed
        Random rnd;

        /// <summary>
        /// Interaction Objects
        /// </summary>
        private World myWorld;
        private Player myPlayer;
        private Draw myDrawing;
        private Generator myGenerator;

        /// <summary>
        /// Constructor for Interaction takes in 3 arguments
        /// </summary>
        /// <param name="player">My Player</param>
        /// <param name="world">My World</param>
        /// <param name="draw">My Drawing</param>
        public Interaction(Player player, World world, Draw draw, Generator generator, Random rnd) {
            this.rnd = rnd;
            myWorld = world;
            myPlayer = player;
            myDrawing = draw;
            myGenerator = generator;
        }

        /// <summary>
        /// Pick up items from the ground
        /// </summary>
        public void PickItems() {
            foreach (Object obj in myWorld.myTiles[myPlayer.y, myPlayer.x].GetList().ToList()) {
                if (obj is Map) {
                    myGenerator.myMap.UseMap(myWorld);
                    myWorld.myTiles[myPlayer.y, myPlayer.x].Remove(obj);
                    return;
                }
            }
        }
    }
}
