using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Testing
    {
        private static Die Die = new Die();
        public void OpenTesting()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Options: (1)Test Sum [Sevens Out]  (2)Test 7 Detected [Sevens Out]  (3)Test If Winner Is Detected [Three or More]  (4)Close Testing");
                Console.WriteLine("Please pick an option by entering 1, 2, 3 or 4.");

                string ChosenOption = Console.ReadKey().KeyChar.ToString();
                int.TryParse(ChosenOption, out int Chosen);

                switch (Chosen)
                {
                    case 1: Console.Clear(); TestSum(); continue;
                    case 2: Console.Clear(); TestSeven(); continue;
                    case 3: Console.Clear(); TestWinner(); continue;
                    case 4: Console.Clear(); break;
                    default: Console.Clear(); Console.WriteLine("Please select 1, 2 or 3."); Console.WriteLine("--------------------------------"); continue;
                }
                break;
            }
        }

        private void TestWinner()
        {
            Random random = new Random();
            int RandomNumber = random.Next(20, 100);

            ThreeOrMore threeormore = new ThreeOrMore();
            Debug.Assert(threeormore.CheckIfWinner(RandomNumber) == true, "The score of 20 or higher wasn't detected.");
            Console.WriteLine("Score: " + RandomNumber);
            Console.WriteLine("Was the win detected? " + threeormore.CheckIfWinner(RandomNumber));
            Console.WriteLine("[Press ANY KEY to Continue]");
            Console.ReadKey();
        }

        private void TestSum()
        {
            Console.Clear();
            int die1 = Die.Roll();
            int die2 = Die.Roll();
            int sum = die1 + die2;

            Sevens_Out seven = new Sevens_Out();
            Debug.Assert(seven.GetSum(die1, die2) == sum, "The sum wasn't correct or a double was rolled.");
            Console.WriteLine("Was the sum correct? " + seven.GetSum(die1, die2));
            Console.WriteLine("[Press ANY KEY to Continue]");
            Console.ReadKey();
        }

        private void TestSeven()
        {
            Console.Clear();
            int NumberSeven;
            NumberSeven = 7;

            Sevens_Out seven = new Sevens_Out();
            Debug.Assert(seven.CheckIfSeven(NumberSeven) == true, "The 7 wasn't detected.");
            Console.WriteLine("Was 7 detected? " + seven.CheckIfSeven(NumberSeven));
            Console.WriteLine("[Press ANY KEY to Continue]");
            Console.ReadKey();
        }

    }
}