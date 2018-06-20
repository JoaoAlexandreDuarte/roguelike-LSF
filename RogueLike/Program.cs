using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    /// <summary>
    /// Starts the program
    /// </summary>
    class Program {
        static void Main(string[] args) {
            // Changes the Console encoding to be 'UTF8'.
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(120, 50);

            // Createa new menu
            Menu myMenu = new Menu();

            // Call the DrawMenu method
            myMenu.DrawMenu();
        }
    }
}
