using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ThreeOrMore
    {
        private static Random Rand = new Random();
        Die Die = new Die();
        int Player1Score;
        int Player2Score;

        public void Game()
        {
            Console.WriteLine("ThreeOrMore Game Mode Instantiated");
            System.Threading.Thread.Sleep(800);

            Console.Clear();
            bool PlrOrPC = PlayerOrComputer();

            while (true)
            {
                if (PlrOrPC) // Play with friend
                {
                    Console.Clear();
                    Console.WriteLine("Player 1's Go");
                    Console.WriteLine("--------------------------------");

                    var tuple = RollDice(0, 0);
                    int MostCommonNumber = tuple.Item1;
                    int HowManyOfKind = tuple.Item2;
                    Player1GetScore(MostCommonNumber, HowManyOfKind);

                    Console.WriteLine($"Player 1's Score: {Player1Score}   [Press ANY KEY to Continue]");
                    Console.ReadKey();

                    if (CheckIfWinner(Player1Score) == true)
                    {
                        ShowWinner(1);
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine("Player 2's Go");
                    Console.WriteLine("--------------------------------");
                    var tuple2 = RollDice(0, 0);
                    int MostCommonNumber2 = tuple2.Item1;
                    int HowManyOfKind2 = tuple2.Item2;
                    Player2GetScore(MostCommonNumber2, HowManyOfKind2);
                    Console.WriteLine($"Player 2's Score: {Player2Score}   [Press ANY KEY to Continue]");
                    Console.ReadKey();

                    if (CheckIfWinner(Player2Score) == true)
                    {
                        ShowWinner(2);
                        break;
                    }
                }
                else // Play with Computer
                {
                    Console.Clear();
                    Console.WriteLine("Player 1's Go");
                    Console.WriteLine("--------------------------------");
                    var tuple3 = RollDice(0, 0);
                    int MostCommonNumber3 = tuple3.Item1;
                    int HowManyOfKind3 = tuple3.Item2;
                    Player1GetScore(MostCommonNumber3, HowManyOfKind3);
                    Console.WriteLine($"Player 1's Score: {Player1Score}   [Press ANY KEY to Continue]");
                    Console.ReadKey();

                    if (CheckIfWinner(Player1Score) == true)
                    {
                        ShowWinner(1);
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine("Player 2's Go");
                    Console.WriteLine("--------------------------------");

                    var tuple4 = RollDice(0, 0);
                    int MostCommonNumber4 = tuple4.Item1;
                    int HowManyOfKind4 = tuple4.Item2;
                    Player2ComputerGetScore(MostCommonNumber4, HowManyOfKind4);

                    Console.WriteLine($"Player 2's Score: {Player2Score}   [Press ANY KEY to Continue]");
                    Console.ReadKey();

                    if (CheckIfWinner(Player2Score) == true)
                    {
                        ShowWinner(2);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// This determines who the winner is and prints out the information in the console.
        /// This also updates the relevant statistics.
        /// </summary>
        /// <param name="Winner"></param>
        private void ShowWinner(int Winner)
        {
            Console.Clear();
            if (Winner == 1)
            {
                Console.WriteLine("Winner: Player 1");
            }
            else
            {
                Console.WriteLine("Winner: Player 2");
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Player 1's Score: {Player1Score}");
            Console.WriteLine($"Player 2's Score: {Player2Score}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("[Press ANY KEY to Continue]");
            Statistics.ThreeOrMoreMatches += 1;

            if (Player1Score > Statistics.ThreeOrMoreHighScore)
            {
                Statistics.ThreeOrMoreHighScore = Player1Score;
            }
            if (Player2Score > Statistics.ThreeOrMoreHighScore)
            {
                Statistics.ThreeOrMoreHighScore = Player2Score;
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This checks if the integer being passed through is greater than or equal to 20.
        /// This function is public to allow the testing class to use it.
        /// </summary>
        /// <param name="Score"></param>
        /// <returns></returns>
        public bool CheckIfWinner(int Score)
        {
            if (Score >= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This uses the results from the roll in order to determine how many points player 1 should be awarded. 
        /// If the roll results are 2 then they will re-roll until they get a higher result or 0.
        /// If the roll results are 0 then 0 points are awarded.
        /// </summary>
        /// <param name="MostCommonNumber"></param>
        /// <param name="HowManyOfKind"></param>
        private void Player1GetScore(int MostCommonNumber, int HowManyOfKind)
        {
            while (true)
            {
                if (HowManyOfKind == 2)
                {
                    Console.WriteLine("2 Numbers matched, you can re-roll the other 3 die or all 5.");
                    int Choice = DiceToRoll();

                    if (Choice == 3)
                    {
                        var tuple = RollDiceAgainThree(MostCommonNumber, HowManyOfKind);
                        Player1GetScore(tuple.Item1, tuple.Item2);
                    }
                    else
                    {
                        var tuple = RollDice(0, 0);
                        Player1GetScore(tuple.Item1, tuple.Item2);
                    }
                    break;
                }
                else if (HowManyOfKind == 3)
                {
                    Console.WriteLine("3 Numbers matched, you received 3 points.");
                    Player1Score += 3;
                    break;
                }
                else if (HowManyOfKind == 4)
                {
                    Console.WriteLine("4 Numbers matched, you received 6 points.");
                    Player1Score += 6;
                    break;
                }
                else if (HowManyOfKind == 5)
                {
                    Console.WriteLine("5 Numbers matched, you received 12 points.");
                    Player1Score += 12;
                    break;
                }
                else
                {
                    Console.WriteLine("0 Numbers matched, you received 0 points.");
                    break;
                }
            }
        }

        /// <summary>
        /// This uses the results from the roll in order to determine how many points player 2 should be awarded. 
        /// If the roll results are 2 then they will re-roll until they get a higher result or 0.
        /// If the roll results are 0 then 0 points are awarded.
        /// </summary>
        /// <param name="MostCommonNumber"></param>
        /// <param name="HowManyOfKind"></param>
        private void Player2GetScore(int MostCommonNumber, int HowManyOfKind)
        {
            while (true)
            {
                if (HowManyOfKind == 2)
                {
                    Console.WriteLine("2 Numbers matched, you can re-roll the other 3 die or all 5.");
                    int Choice = DiceToRoll();

                    if (Choice == 3)
                    {
                        var tuple = RollDiceAgainThree(MostCommonNumber, HowManyOfKind);
                        Player2GetScore(tuple.Item1, tuple.Item2);
                    }
                    else
                    {
                        var tuple = RollDice(0, 0);
                        Player2GetScore(tuple.Item1, tuple.Item2);
                    }
                    break;
                }
                else if (HowManyOfKind == 3)
                {
                    Console.WriteLine("3 Numbers matched, you received 3 points.");
                    Player2Score += 3;
                    break;
                }
                else if (HowManyOfKind == 4)
                {
                    Console.WriteLine("4 Numbers matched, you received 6 points.");
                    Player2Score += 6;
                    break;
                }
                else if (HowManyOfKind == 5)
                {
                    Console.WriteLine("5 Numbers matched, you received 12 points.");
                    Player2Score += 12;
                    break;
                }
                else
                {
                    Console.WriteLine("0 Numbers matched, you received 0 points.");
                    break;
                }
            }
        }

        /// <summary>
        /// This uses the results from the roll in order to determine how many points the computer should be awarded. 
        /// If roll results are 2 then they will re-roll until they get a higher result or 0.
        /// If the roll results are 0 then 0 points are awarded.
        /// </summary>
        /// <param name="MostCommonNumber"></param>
        /// <param name="HowManyOfKind"></param>
        private void Player2ComputerGetScore(int MostCommonNumber, int HowManyOfKind)
        {
            while (true)
            {
                if (HowManyOfKind == 2)
                {
                    Console.WriteLine("2 Numbers matched, you can re-roll the other 3 die or all 5.");
                    int Choice = Rand.Next(1, 3);

                    if (Choice == 1)
                    {
                        Console.WriteLine("Computer chose to re-roll 3 die.");
                        var tuple = RollDiceAgainThree(MostCommonNumber, HowManyOfKind);
                        Player2ComputerGetScore(tuple.Item1, tuple.Item2);
                    }
                    else
                    {
                        Console.WriteLine("Computer chose to re-roll 5 die.");
                        var tuple = RollDice(0, 0);
                        Player2ComputerGetScore(tuple.Item1, tuple.Item2);
                    }
                    break;
                }
                else if (HowManyOfKind == 3)
                {
                    Console.WriteLine("3 Numbers matched, you received 3 points.");
                    Player2Score += 3;
                    break;
                }
                else if (HowManyOfKind == 4)
                {
                    Console.WriteLine("4 Numbers matched, you received 6 points.");
                    Player2Score += 6;
                    break;
                }
                else if (HowManyOfKind == 5)
                {
                    Console.WriteLine("5 Numbers matched, you received 12 points.");
                    Player2Score += 12;
                    break;
                }
                else
                {
                    Console.WriteLine("0 Numbers matched, you received 0 points.");
                    break;
                }
            }
        }

        /// <summary>
        /// This creates a tuple that allows me to return multiple integer values, the most common number found and how many were found.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private Tuple<int, int> RollDice(int a, int b)
        {
            List<int> ints = new List<int>();

            int DiceAmount = 5;

            while (DiceAmount > 0)
            {
                int rolledNumber = Die.Roll();
                ints.Add(rolledNumber);
                DiceAmount--;
            }

            List<int> counts = new List<int>(6);
            for (int number = 1; number <= 6; number++)
            {
                counts.Add(0);
            }

            foreach (int rolledNumber in ints)
            {
                counts[rolledNumber - 1]++;
            }

            int HowManyOfKind = counts.Max();
            int MostCommonNumber = counts.IndexOf(HowManyOfKind) + 1;

            return Tuple.Create(MostCommonNumber, HowManyOfKind);
        }

        /// <summary>
        /// This does a similar thing to the "RollDice" function however it increases the "HowManyOfKind" only if the die roll result is the same as the MostCommonNumber.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private Tuple<int, int> RollDiceAgainThree(int a, int b)
        {
            int MostCommonNumber = a;
            int HowManyOfKind = b;

            int i = 3;
            while (i > 0)
            {
                int d = Die.Roll();
                if (d == MostCommonNumber)
                {
                    HowManyOfKind++;
                }
                i--;
            }
            return Tuple.Create(MostCommonNumber, HowManyOfKind);
        }

        /// <summary>
        /// This prompts the user to select how many die they want to roll.
        /// </summary>
        /// <returns></returns>
        private int DiceToRoll()
        {
            while (true)
            {
                Console.WriteLine("Dice amount options: (3)3 Dice  (5)5 Dice");
                Console.WriteLine("Please pick your dice amount by entering 3 or 5.");
                string ChosenOption = Console.ReadKey().KeyChar.ToString();

                int.TryParse(ChosenOption, out int Chosen);
                switch (Chosen)
                {
                    case 3: Console.Clear(); return 3;
                    case 5: Console.Clear(); return 5;
                    default: Console.Clear(); Console.WriteLine("Please select 3 or 5."); Console.WriteLine("--------------------------------"); continue;
                }
            }
        }

        /// <summary>
        /// This prompts the user to select if they want to play against another player or a computer.
        /// </summary>
        /// <returns></returns>
        private bool PlayerOrComputer()
        {
            while (true)
            {
                Console.WriteLine("Opponent options: (1)Friend  (2)Computer");
                Console.WriteLine("Please pick your opponent by entering 1 or 2.");
                string ChosenOption = Console.ReadKey().KeyChar.ToString();


                int.TryParse(ChosenOption, out int Chosen);
                switch (Chosen)
                {
                    case 1: Console.Clear(); return true;
                    case 2: Console.Clear(); return false;
                    default: Console.Clear(); Console.WriteLine("Please select 1 or 2."); Console.WriteLine("--------------------------------"); continue;
                }
            }
        }


    }
}