using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Menu {
        private Game myGame;
        private HighScore myScores;

        /// <summary>
        /// Constructs a new Menu
        /// </summary>
        public Menu() {
            myScores = new HighScore();
        }

        public void DrawMenu() {

            // Clears the console to write a simple menu.
            Console.Clear();
            Console.WriteLine("╔═══════════════════════╗");
            Console.WriteLine("║\tRandom Name\t║");
            Console.WriteLine("╠═══════════════════════╣");
            Console.WriteLine("║\t1 - New Game\t║");
            Console.WriteLine("║\t2 - High Scores\t║");
            Console.WriteLine("║\t3 - Credits\t║");
            Console.WriteLine("║\t4 - Quit\t║");
            Console.WriteLine("╚═══════════════════════╝");

            // Calls the 'Choice()' Method.
            Choice(Console.ReadLine());
        }

        /// <summary>
        /// Check what the player chose
        /// </summary>
        /// <param name="option">Player input</param>
        private void Choice(string option) {
            switch (option) {
                case "1": // Starts the Game
                    myGame = new Game();
                    myGame.GenerateWorld();
                    break;
                case "2": // Displays the HighScores
                    myScores.DisplayHighScores();
                    break;
                case "3": // Displays the Credits
                    DisplayCredits();
                    break;
                case "4": // Exits the game
                    Environment.Exit(0);
                    break;
            }
            DrawMenu();
        }

        /// <summary>
        /// Displays the credits
        /// </summary>
        private void DisplayCredits() {
            Console.Clear();
            Console.WriteLine("Developers:");
            Console.WriteLine("\t* Leandro Bras  a21701284");
            Console.WriteLine("\t* Flavio Santos a21702334");
            Console.WriteLine("\t* Sara Gama     a21705494");
            Console.ReadKey();
        }
    }
}
