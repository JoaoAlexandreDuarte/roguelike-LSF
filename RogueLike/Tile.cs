using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Tile : List<Object> {
        // Unicode for all Objects
        public string Player { get; } = "\u2A00";
        public string Enemy { get; } = "\u263F";
        public string Neutral { get; } = "\u00B6";
        public string Food { get; } = "\u271A";
        public string Weapon { get; } = "\u2020";
        public string Maps { get; } = "\u2360";
        public string Trap { get; } = "\u2622";


        /// <summary>
        /// Max houses that are shown per tile
        /// </summary>
        private readonly int maxTiles = 10;

        /// <summary>
        /// Offset for the current column and row when using "SetCursorPosition"
        /// </summary>
        private readonly int cOffset = 7;
        private readonly int rOffset = 3;

        // Mark a tile as being an Exit
        public bool Exit { get; set; }

        /// <summary>Construtor que cria uma nova instância de mochila</summary>
        public Tile() {
            for (int i = 0; i < 10; i++) {
                Add(null);
            }
        }

        public IEnumerable<Object> GetList() {
            foreach (Object obj in this) {
                yield return obj;
            }
        }

        public override string ToString() {
            string myObjects = "";
            foreach (Object obj in this) {
                if (obj != null) {
                    myObjects += obj.ToString() + ", ";
                }
            }
            return myObjects;
        }

        /// <summary>
        /// Draws the World
        /// </summary>
        /// <param name="cRow">Current Row</param>
        /// <param name="cColumn">Current Column</param>
        public void DrawMe(int cRow, int cColumn) {
            cRow += 1;

            for (int i = 0; i < maxTiles; i++) {
                if (i == 0) {
                    Console.SetCursorPosition(cColumn * cOffset, cRow * rOffset);
                    Console.Write("  ");
                } else if (i == maxTiles / 2) {
                    Console.SetCursorPosition(cColumn * cOffset, cRow * rOffset + 1);
                    Console.Write("  ");
                }

                if (Exit) {
                    if (i == 0 || i == 5) {
                        Console.Write("EXIT!");
                    }
                } else if (this[i] is Player) {
                    Console.Write(Player);
                } else if (this[i] is Player) {
                    Console.Write(Player);
                } else if (this[i] is Player) {
                    Console.Write(Player);
                } else if (this[i] is Player) {
                    Console.Write(Player);
                } else if (this[i] is Player) {
                    Console.Write(Player);
                } else {
                    Console.Write(".");
                }
            }
        }
    }
}
