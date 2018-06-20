using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    /// <summary>
    /// Drawing Class
    /// </summary>
    class Draw {
        // Current Level
        private int level;

        // Info File
        private string info = "Info.txt";

        // Offsets
        private readonly int offsetX = 61;
        private readonly int offsetY = 3;
        private readonly int statOffset = 5;
        private readonly int messageOffset = 30;

        /// <summary>
        /// Empty Draw Constructor
        /// </summary>
        public Draw() { }

        /// <summary>
        /// Draws the World
        /// </summary>
        /// <param name="myPlayer">My Player</param>
        /// <param name="myWorld">The World</param>
        /// <param name="level">Current level</param>
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
            Console.Write("Weapon\t: " + myPlayer.equiptSlot);
            Console.SetCursorPosition(offsetX, offsetY + i);
            Console.Write("Inventory\t: " + myPlayer.InventoryPercentage() + " Full");
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
            Console.WriteLine("* " + myPlayer.LastMove);
            Console.WriteLine("* " + myPlayer.LastInteraction + "\n");
            Console.WriteLine("What do i see?");
            Console.WriteLine("---------------");

            // Check Player position to write what he can see on the tiles next to him
            //
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
            //

            Console.WriteLine("* HERE  : " + myWorld.myTiles[myPlayer.y, myPlayer.x]);
            Console.WriteLine();
            Console.WriteLine("Options");
            Console.WriteLine("--------");
            Console.WriteLine("(W) Move NORTH  (A) Move WEST    (S) Move SOUTH (D) Move EAST");
            Console.WriteLine("(F) Attack NPC  (E) Pick up item (U) Use item   (V) Drop item");
            Console.WriteLine("(I) Information (Q) Quit game");
        }

        /// <summary>
        /// Draws a small header for the item interactions
        /// </summary>
        /// <param name="type">Type of interaction</param>
        public void ItemInteraction(string type) {
            Console.Clear();
            Console.WriteLine("Select item to " + type);
            Console.WriteLine("--------------------\n");
            Console.WriteLine("0  Back");
        }

        /// <summary>
        /// Draws a small header for the commbat interactions
        /// </summary>
        public void FightInteraction() {
            Console.Clear();
            Console.WriteLine("Select NPC to Attack");
            Console.WriteLine("--------------------\n");
        }

        /// <summary>
        /// Draws the ful information window
        /// </summary>
        public void DrawInformations() {
            Console.Clear();
            List<string> infoList = File.ReadAllLines(info).ToList();
            foreach (string line in infoList) {
                Console.WriteLine(line);
            }
            Console.ReadKey();
        }
    }
}
