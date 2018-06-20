using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class HighScore {
        private readonly int maxSize = 10;

        private string filename = "scores.txt";
        public List<string> ScoreList { get; set; }
        private string name = "";

        public HighScore() {
            if (File.Exists(filename)) {
                ScoreList = File.ReadAllLines(filename).ToList();
            } else {
                ScoreList = new List<string>();
            }
        }

        /// <summary>
        /// Adds final score to the "ScoreList", then sorts the list adn remove any extra info.
        /// </summary>
        /// <param name="level">level the player was at when the game ended</param>
        public void NewScore(int level) {
            Console.Clear();
            Console.WriteLine("You Died! What's your name? ");
            // Ask for the player's name
            do {
                name = Console.ReadLine();
            } while (name == "");
            
            // Add name and score to the list
            ScoreList.Add(name + " " + level);
            // Sort the list in a descending order
            IOrderedEnumerable<string> sortedScoreList = ScoreList.OrderByDescending(
                ss => int.Parse(ss.Substring(ss.LastIndexOf(" ") + 1))
                );
            // Remove any extra scores from the list
            if (ScoreList.Count() > maxSize) {
                ScoreList = sortedScoreList.ToList();
                ScoreList.RemoveAt(maxSize);
            }
            // Add all scores to the "scores.txt" file
            File.WriteAllLines(filename, ScoreList.ToArray());
            // Update ScoreList
            ScoreList = File.ReadAllLines(filename).ToList();
        }

        /// <summary>
        /// Displays the scores
        /// </summary>
        public void DisplayHighScores() {
            int offsetx = 10;
            int i = 0;
            Console.Clear();
            Console.Write("HighScores:");
            foreach (string score in ScoreList) {
                i++;
                Console.SetCursorPosition(offsetx, i);
                Console.Write(i + ". " + score);
            }
            Console.ReadKey();
        }
    }
}
