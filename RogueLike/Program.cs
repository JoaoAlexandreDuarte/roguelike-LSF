using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Program {
        static void Main(string[] args) {
            // Changes the Console encoding to be 'UTF8'.
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(120, 50);
            // Create a new Game
            Game myGame = new Game();
            // Create a new Menu Object
            Menu myMenu = new Menu(myGame);
            // Call the DrawMenu method
            myMenu.DrawMenu();
        }
    }
}
