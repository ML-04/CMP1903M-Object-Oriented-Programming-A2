using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Statistics
    {
        // Need to also add a stat for highest score of each match

        public static int DiceRolled;
        public static int SevensOutMatches;
        public static int ThreeOrMoreMatches;
        public static int SevensOutHighScore;
        public static int ThreeOrMoreHighScore;

        public int TotalMatches = SevensOutMatches + ThreeOrMoreMatches;
        public void ShowStatistics()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Matches completed: {TotalMatches}");
            Console.WriteLine($"Three or More matches completed: {ThreeOrMoreMatches}");
            Console.WriteLine($"Sevens Out matches completed: {SevensOutMatches}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Three or More highest score: {ThreeOrMoreHighScore}");
            Console.WriteLine($"Sevens Out highest score: {SevensOutHighScore}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("[Press ANY KEY to Continue]");
            Console.ReadKey();
        }
    }
}