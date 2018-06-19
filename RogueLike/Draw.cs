using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Draw {
        // Current Level
        private int level;

        // Offsets
        private readonly int offsetX = 61;
        private readonly int offsetY = 3;
        private readonly int statOffset = 5;
        private readonly int messageOffset = 30;

        public Draw() { }

        public void DrawWorld(Player myPlayer, World myWorld, int level) {
            this.level = level;
            Console.Clear();
            Console.Write("+++++++++++++++++++++++++++ LP1 Rogue : Level {0:d3} +++++++++++++++++++++++++++", level);
            for (int row = 0; row < myWorld.Rows; row++) {
                for (int column = 0; column < myWorld.Columns; column++) {
                    myWorld.myTiles[row, column].DrawMe(row, column);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Draws all the stats on the side of the world
        /// </summary>
        /// <param name="myPlayer">Player Info</param>
        /// <param name="myWorld">World Info</param>
        public void DrawStats(Player myPlayer, World myWorld) {
            int i = 0;

            // Draw Player Stats
            Console.SetCursorPosition(offsetX, offsetY + i++);
            Console.Write("Player Stats");
            Console.SetCursorPosition(offsetX, offsetY + i++);
            Console.Write("------------");
            Console.SetCursorPosition(offsetX, offsetY + i++);
            Console.Write("Hp\t\t: " + myPlayer.Hp);
            Console.SetCursorPosition(offsetX, offsetY + i++);
            Console.Write("Weapon\t: " + "'WeponHere'");
            Console.SetCursorPosition(offsetX, offsetY + i);
            Console.Write("Inventory\t: " + "'inv%Here' Full");
            // Offset Stats from Legend
            i += statOffset;

            // Draw Legend
            Console.SetCursorPosition(offsetX, offsetY + i++);
            Console.Write("Legend");
            Console.SetCursorPosition(offsetX, offsetY + i++);
            Console.Write("-------");
            Console.SetCursorPosition(offsetX, offsetY + i++);
            Console.Write($"\t{myWorld.myTiles[0, 0].Player} : Player");
            Console.SetCursorPosition(offsetX, offsetY + i++);
            Console.Write("EXIT!: Exit");
            Console.SetCursorPosition(offsetX, offsetY + i++);
            Console.Write($"\t. : Empty");
            Console.SetCursorPosition(offsetX, offsetY + i++);
            Console.Write($"\t~ : Unexplored");
            Console.SetCursorPosition(offsetX, offsetY + i++);
            Console.Write($"\t{myWorld.myTiles[0, 0].Neutral} : Neutral NPC");
            Console.SetCursorPosition(offsetX, offsetY + i++);
            Console.Write($"\t{myWorld.myTiles[0, 0].Enemy} : Hostile NPC");
            Console.SetCursorPosition(offsetX, offsetY + i++);
            Console.Write($"\t{myWorld.myTiles[0, 0].Food} : Food");
            Console.SetCursorPosition(offsetX, offsetY + i++);
            Console.Write($"\t{myWorld.myTiles[0, 0].Weapon} : Weapon");
            Console.SetCursorPosition(offsetX, offsetY + i++);
            Console.Write($"\t{myWorld.myTiles[0, 0].Trap} : Trap");
            Console.SetCursorPosition(offsetX, offsetY + i++);
            Console.Write($"\t{myWorld.myTiles[0, 0].Maps} : Map");
        }

        /// <summary>
        /// Draws all the messages that appear bellow the world
        /// </summary>
        /// <param name="myPlayer">Player info</param>
        /// <param name="myWorld">World info</param>
        /// <param name="myGenerator">Generator info</param>
        public void DrawMessages(Player myPlayer, World myWorld, Generator myGenerator) {
            Console.SetCursorPosition(0, messageOffset);
            Console.WriteLine("Messages");
            Console.WriteLine("---------");
            Console.WriteLine(myPlayer.LastMove);
            Console.WriteLine("*\n");
            Console.WriteLine("What do i see?");
            Console.WriteLine("---------------");
            if (myPlayer.y > 0) {
                Console.WriteLine("* NORTH : " + myWorld.myTiles[myPlayer.y - 1, myPlayer.x]);
            }
            if (myPlayer.y < myWorld.Rows - 1) {
                Console.WriteLine("* SOUTH : " + myWorld.myTiles[myPlayer.y + 1, myPlayer.x]);
            }
            if (myPlayer.x > 0) {
                Console.WriteLine("* WEST  : " + myWorld.myTiles[myPlayer.y, myPlayer.x - 1]);
            }
            if (myPlayer.x < myWorld.Columns - 1) {
                Console.WriteLine("* EAST  : " + myWorld.myTiles[myPlayer.y, myPlayer.x + 1]);
            }
            Console.WriteLine("* HERE  : " + myWorld.myTiles[myPlayer.x, myPlayer.y]);
            Console.WriteLine();
            Console.WriteLine("Options");
            Console.WriteLine("--------");
            Console.WriteLine("(W) Move NORTH  (A) Move WEST    (S) Move SOUTH (D) Move EAST");
            Console.WriteLine("(F) Attack NPC  (E) Pick up item (U) Use item   (V) Drop item");
            Console.WriteLine("(I) Information (Q) Quit game");
        }
    }
}
