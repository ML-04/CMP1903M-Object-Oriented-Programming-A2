using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Game
    {
        /// <summary>
        /// This allows the user to select 5 different options that run different things.
        /// </summary>
        public void GameSelect()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Options: (1)Play SevensOut  (2)Play ThreeOrMore  (3)View Statisitics  (4)Open Testing  (5)Close Program");
                Console.WriteLine("Please pick an option by entering 1, 2, 3, 4 or 5.");

                string ChosenOption = Console.ReadKey().KeyChar.ToString();

                int.TryParse(ChosenOption, out int Chosen);
                switch (Chosen)
                {
                    case 1: Console.Clear(); Sevens_Out seven = new Sevens_Out(); seven.SevensOutGame(); continue;
                    case 2: Console.Clear(); ThreeOrMore three = new ThreeOrMore(); three.Game(); continue;
                    case 3: Console.Clear(); Statistics stats = new Statistics(); stats.ShowStatistics(); continue;
                    case 4: Console.Clear(); Testing testing = new Testing(); testing.OpenTesting(); continue;
                    case 5: Console.Clear(); break;
                    default: Console.Clear(); Console.WriteLine("Please select 1, 2, 3, 4 or 5."); Console.WriteLine("--------------------------------"); continue;
                }
                break;
            }
        }

    }
}