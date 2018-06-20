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

        /// <summary>
        /// Checks the tile list for traps that damage the player
        /// </summary>
        public void TrapChecker() {
            foreach (Object obj in myWorld.myTiles[myPlayer.y, myPlayer.x].GetList().ToList()) {
                if (obj is Trap) {
                    if (!(obj as Trap).FallenInto) {
                        // Get Random Damage
                        float myDamage = (float)(rnd.NextDouble() *
                            myWorld.myTiles[myPlayer.y, myPlayer.x].GetObjects<Trap>().Damage);

                        (obj as Trap).FallenInto = true;
                        // Take random damage from the trap
                        myPlayer.Hp -= myDamage;

                        // Update Last Interaction
                        myPlayer.LastInteraction = string.Format("You fell in a trap and lost " +
                            "{0:f2} Hp.", myDamage);
                    }
                }
            }
        }
    }
}
