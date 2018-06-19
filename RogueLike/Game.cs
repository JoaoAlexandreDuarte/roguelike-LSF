using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Game {
        Random rnd;

        private int level = 1;
        private ConsoleKeyInfo key;

        // MyPlayer
        private Player myPlayer;
        // MyWorld
        private World myWorld;
        // MyGenerator
        private Generator myGenerator;
        // MyDrawing Draws the world
        private Draw myDrawing;

        public Game() {
            rnd = new Random();
            myPlayer = new Player(65);
            myWorld = new World(myPlayer, rnd);
            myGenerator = new Generator(level, myWorld, rnd);
            myDrawing = new Draw();
        }

        public void GenerateWorld() {
            do {
                // Draw the world and the stats/legend side bar
                myDrawing.DrawWorld(myPlayer, myWorld, level);
                myDrawing.DrawStats(myPlayer, myWorld);
                myDrawing.DrawMessages(myPlayer, myWorld, myGenerator);

                // Read Key input and update player
                key = Console.ReadKey();

                UpdatePlayer();

                if (myWorld.myTiles[myPlayer.y, myPlayer.x].Exit) {
                    level++;
                    myWorld = new World(myPlayer, rnd);
                    myGenerator = new Generator(level, myWorld, rnd);
                }

            } while (myPlayer.Hp > 0);
        }

        private void UpdatePlayer() {
            Player passPlayer;
            passPlayer = myPlayer;
            // Remove the player from the current Tile
            myWorld.myTiles[myPlayer.y, myPlayer.x].RemoveAt(0);

            // Check witch key was pressed to update the player X or Y
            if (key.Key == ConsoleKey.W) {
                if (myPlayer.y != 0) {
                    myPlayer.y--;
                    myPlayer.Hp--;
                    myPlayer.LastMove = "You Moved NORTH!";
                }
            } else if (key.Key == ConsoleKey.A) {
                if (myPlayer.x != 0) {
                    myPlayer.x--;
                    myPlayer.Hp--;
                    myPlayer.LastMove = "You Moved WEST!";
                }
            } else if (key.Key == ConsoleKey.S) {
                if (myPlayer.y != 7) {
                    myPlayer.y++;
                    myPlayer.Hp--;
                    myPlayer.LastMove = "You Moved SOUTH!";
                }
            } else if (key.Key == ConsoleKey.D) {
                if (myPlayer.x != 7) {
                    myPlayer.x++;
                    myPlayer.Hp--;
                    myPlayer.LastMove = "You Moved EAST!";
                }
            }

            // Insert the player into the first position on the Tile list
            myWorld.myTiles[myPlayer.y, myPlayer.x].Insert(0, passPlayer);
        }
    }
}
