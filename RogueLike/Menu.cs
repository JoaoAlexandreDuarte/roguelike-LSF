using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Menu {
        private Game myGame;

        public Menu(Game myGame) {
            this.myGame = myGame;
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
                    myGame.GenerateWorld();
                    DrawMenu();
                    break;
                case "2":
                    DrawMenu();
                    break;
                case "3":
                    DisplayCredits();
                    DrawMenu();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    DrawMenu();
                    break;
            }
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
