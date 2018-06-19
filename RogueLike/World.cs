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

        public World(Player myPlayer, Random rnd) {
            this.rnd = rnd;
            myTiles = new Tile[Rows, Columns];
            PopulateEmptyTiles();
            SpawnPlayer(myPlayer);
            GenerateExit();
        }

        private void PopulateEmptyTiles() {
            // Runs the array filling each 'cell' with a 'PiceType.Bar'
            for (int row = 0; row < Rows; row++) {
                for (int column = 0; column < Columns; column++) {
                    myTiles[row, column] = new Tile();
                }
            }
        }

        private void SpawnPlayer(Player myPlayer) {
            // Generate a new random to place the player in a certain Row
            int spawnRow = (int)(rnd.NextDouble() * Rows);

            // Insert the player in the first position of the selected Tile List
            myTiles[spawnRow, 0].Insert(0, myPlayer);

            // Give player X and Y their default values
            myPlayer.x = 0;
            myPlayer.y = spawnRow;
        }

        private void GenerateExit() {
            // Generade a new random to set a determined Row as an exit
            int spawnRow = (int)(rnd.NextDouble() * Rows);

            // Set a Tile as being an exit
            myTiles[spawnRow, Columns - 1].Exit = true;
        }

        private void GenerateNpc() {
            int numberOfNPCs = rnd.Next(20) + 10;

            for (int i = 0; i < numberOfNPCs; i++) {
                int rows = rnd.Next(8);
                int cols = rnd.Next(8);

                //myTiles[rows, cols].Add();
            }
        }
    }
}
