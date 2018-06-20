using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Menu {
        private Game myGame;
        private HighScore myScores;


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

        private void Choice(string option) {
            switch (option) {
                case "1":
                    myGame = new Game();
                    myGame.GenerateWorld();
                    break;
                case "2":
                    myScores.DisplayHighScores();
                    break;
                case "3":
                    DisplayCredits();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
            }
            DrawMenu();
        }

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
