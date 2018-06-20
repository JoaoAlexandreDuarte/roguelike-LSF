using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class World {
        Random rnd;

        /// <summary>
        /// The number of rows and Columns in the grid.
        /// </summary>
        public int Rows { get; } = 8;
        public int Columns { get; } = 8;

        // Array of Tiles
        public Tile[,] myTiles;

        /// <summary>
        /// Construct a new World
        /// </summary>
        /// <param name="myPlayer">My Player</param>
        /// <param name="rnd">Preveously random generated seed</param>
        public World(Player myPlayer, Random rnd) {
            this.rnd = rnd;
            myTiles = new Tile[Rows, Columns];
            PopulateEmptyTiles();
            SpawnPlayer(myPlayer);
            GenerateExit();
        }

        /// <summary>
        /// Pupulates the empty tiles with 10 nulls
        /// </summary>
        private void PopulateEmptyTiles() {
            // Runs the array filling each 'cell' with a 'PiceType.Bar'
            for (int row = 0; row < Rows; row++) {
                for (int column = 0; column < Columns; column++) {
                    myTiles[row, column] = new Tile();
                }
            }
        }

        /// <summary>
        /// Spaawns the player on a random Row of the first Column
        /// </summary>
        /// <param name="myPlayer">My Player</param>
        private void SpawnPlayer(Player myPlayer) {
            // Generate a new random to place the player in a certain Row
            int spawnRow = (int)(rnd.NextDouble() * Rows);

            // Insert the player in the first position of the selected Tile List
            myTiles[spawnRow, 0].Insert(0, myPlayer);

            // Give player X and Y their default values
            myPlayer.x = 0;
            myPlayer.y = spawnRow;
        }

        /// <summary>
        /// Generates an Exit
        /// </summary>
        private void GenerateExit() {
            // Generade a new random to set a determined Row as an exit
            int spawnRow = (int)(rnd.NextDouble() * Rows);

            // Set a Tile as being an exit
            myTiles[spawnRow, Columns - 1].Exit = true;
        }
    }
}
