using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Game {
        // Random seed
        Random rnd;

        // Starting level
        private int level = 1;

        // Saves the player's key press
        private ConsoleKeyInfo key;

        // MyPlayer
        private Player myPlayer;
        // MyWorld
        private World myWorld;
        // MyGenerator
        private Generator myGenerator;
        // MyDrawing Draws the world
        private Draw myDrawing;
        // MyInteractions
        private Interaction myInteractions;
        // MyScores
        private HighScore myScore;

        /// <summary>
        /// Game Constructor 
        /// </summary>
        public Game() {
            // Generate a new Random seed
            rnd = new Random();
            // Create a new Player
            myPlayer = new Player(65);
            // Create a new World
            myWorld = new World(myPlayer, rnd);
            // Create a new Generator
            myGenerator = new Generator(level, myWorld, rnd);
            // Create a new Draw
            myDrawing = new Draw();
            // Start HiScores
            myScore = new HighScore();
            // Create a new Interaction
            myInteractions = new Interaction(myPlayer, myWorld, myDrawing, myGenerator, rnd);
        }

        /// <summary>
        /// Runs the Game on a do-while loop
        /// </summary>
        public void GenerateWorld() {
            // Start a new do-while loop to play the game
            do {
                // Update all explored tiles
                UpdateTiles();

                // Draw the world and the stats/legend side bar
                myDrawing.DrawWorld(myPlayer, myWorld, level);
                myDrawing.DrawStats(myPlayer, myWorld);
                myDrawing.DrawMessages(myPlayer, myWorld, myGenerator);

                // Read Key input and update player
                key = Console.ReadKey();

                // Updates the player
                UpdatePlayer();

                // Checks if the player is standing in an Exit tile to switch levels
                if (myWorld.myTiles[myPlayer.y, myPlayer.x].Exit) {
                    level++;
                    myWorld = new World(myPlayer, rnd);
                    myGenerator = new Generator(level, myWorld, rnd);
                    myInteractions = new Interaction(myPlayer, myWorld, myDrawing, myGenerator, rnd);
                }

                // Loops the game while the player is alive
            } while (myPlayer.Hp > 0);

            // Ask the player for his name
            myScore.NewScore(level);
        }

        /// <summary>
        /// Updates every information about the player
        /// </summary>
        private void UpdatePlayer() {
            Player passPlayer;
            passPlayer = myPlayer;
            // Remove the player from the current Tile
            myWorld.myTiles[myPlayer.y, myPlayer.x].RemoveAt(0);

            // Check witch key was pressed to update the player X or Y
            if (key.Key == ConsoleKey.W) {
                // Moves the Player North losing 1 hp
                if (myPlayer.y != 0) {
                    myPlayer.y--;
                    myPlayer.Hp--;
                    myPlayer.LastMove = "You Moved NORTH!";
                    myInteractions.TrapChecker();
                    myInteractions.NpcChecker();
                }
            } else if (key.Key == ConsoleKey.A) {
                // Moves the Player West losing 1 hp
                if (myPlayer.x != 0) {
                    myPlayer.x--;
                    myPlayer.Hp--;
                    myPlayer.LastMove = "You Moved WEST!";
                    myInteractions.TrapChecker();
                    myInteractions.NpcChecker();
                }
            } else if (key.Key == ConsoleKey.S) {
                // Moves the Player South losing 1 hp
                if (myPlayer.y != 7) {
                    myPlayer.y++;
                    myPlayer.Hp--;
                    myPlayer.LastMove = "You Moved SOUTH!";
                    myInteractions.TrapChecker();
                    myInteractions.NpcChecker();
                }
            } else if (key.Key == ConsoleKey.D) {
                // Moves the Player East losing 1 hp
                if (myPlayer.x != 7) {
                    myPlayer.x++;
                    myPlayer.Hp--;
                    myPlayer.LastMove = "You Moved EAST!";
                    myInteractions.TrapChecker();
                    myInteractions.NpcChecker();
                }
            } else if (key.Key == ConsoleKey.E) {
                // Choses an item to pickup 
                myInteractions.PickItems();
            } else if (key.Key == ConsoleKey.I) {
                // Draw Informations
                myDrawing.DrawInformations();
                // Check for enemy NPCs
                myInteractions.NpcChecker();
            } else if (key.Key == ConsoleKey.Q) {
                // Quit the game
                myInteractions.Quit();
            } else if (key.Key == ConsoleKey.V) {
                // Choses an item to drop
                myInteractions.DropItems();
            } else if (key.Key == ConsoleKey.U) {
                // Choses an item to use
                myInteractions.UseItems();
            } else if (key.Key == ConsoleKey.F) {
                // Start a fight interaction
                myInteractions.Fight();
            }

            // Insert the player into the first position on the Tile list
            myWorld.myTiles[myPlayer.y, myPlayer.x].Insert(0, passPlayer);
        }

        /// <summary>
        /// Updates the tiles arround the player, setting them as explored
        /// </summary>
        private void UpdateTiles() {
            // Update explored tiles keeping in mind the limits of the grid
            //
            if (myPlayer.y > 0) {
                myWorld.myTiles[myPlayer.y - 1, myPlayer.x].Explored = true;
            }
            if (myPlayer.y < myWorld.Rows - 1) {
                myWorld.myTiles[myPlayer.y + 1, myPlayer.x].Explored = true;
            }
            if (myPlayer.x > 0) {
                myWorld.myTiles[myPlayer.y, myPlayer.x - 1].Explored = true;
            }
            if (myPlayer.x < myWorld.Columns - 1) {
                myWorld.myTiles[myPlayer.y, myPlayer.x + 1].Explored = true;
            }
            //
        }
    }
}
