using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Sevens_Out
    {

        private static Die Die = new Die();
        public void SevensOutGame()
        {

            Console.WriteLine("SevensOut Game Mode Instantiated");
            System.Threading.Thread.Sleep(800);
            int total = 0;
            int sum;

            Console.Clear();
            bool PlrOrPC = PlayerOrComputer();

            while (true)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Player 1's Go");
                int die1 = Die.Roll();
                int die2 = Die.Roll();
                sum = die1 + die2;
                if (CheckIfSeven(sum))
                {
                    Console.WriteLine("You got 7.");
                    break;
                }
                sum = GetSum(die1, die2);
                total += sum;
                Console.WriteLine("Total: " + total);
            }
            Console.WriteLine($"Player 1's Score: {total}   [Press ANY KEY to Continue]");
            Console.ReadKey();
            Console.Clear();
            int Player1Score = total;
            total = 0;

            int Player2Score = GetScore(PlrOrPC);

            Console.Clear();
            ShowWinner(Player1Score, Player2Score);
        }

        /// <summary>
        /// This checks if the integer that's being passed through is 7 or not.
        /// This function is public to allow the testing class to use it.
        /// </summary>
        /// <param name="sum"></param>
        /// <returns></returns>
        public bool CheckIfSeven(int sum)
        {
            if (sum == 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This checks if both integers being passed through are the same, which results in a double roll.
        /// </summary>
        /// <param name="die1"></param>
        /// <param name="die2"></param>
        /// <returns></returns>
        private bool CheckDouble(int die1, int die2)
        {
            if (die1 == die2)
            {
                return true;
            }
            else
            {
                return false;
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

        /// <summary>
        /// This determines the score depending on if a friend match should be played or if it should be a computer match.
        /// </summary>
        /// <param name="PlayerType"></param>
        /// <returns></returns>
        private int GetScore(bool PlayerType)
        {
            int Player2Score;

            if (PlayerType)
            {
                Console.Clear();
                Player2Score = FriendMatch();
            }
            else
            {
                Console.Clear();
                Player2Score = ComputerMatch();
            }
            return Player2Score;
        }

        /// <summary>
        /// This runs through a friend match.
        /// </summary>
        /// <returns></returns>
        private int FriendMatch()
        {
            int total = 0;
            int sum;

            while (true)
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Player 2's Go");
                int die1 = Die.Roll();
                int die2 = Die.Roll();
                sum = die1 + die2;
                if (CheckIfSeven(sum))
                {
                    Console.WriteLine("You got 7.");
                    break;
                }
                sum = GetSum(die1, die2);
                total += sum;
                Console.WriteLine("Total: " + total);
            }
            Console.WriteLine($"Player 2's Score: {total}   [Press ANY KEY to Continue]");
            Console.ReadKey();
            return total;
        }

        /// <summary>
        /// This determines who the winner is and prints out the information in the console.
        /// This also updates the relevant statistics.
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        private void ShowWinner(int player1, int player2)
        {
            if (player1 > player2)
            {
                Console.WriteLine("Winner: Player 1");
            }
            else
            {
                Console.WriteLine("Winner: Player 2");
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Player 1's Score: {player1}");
            Console.WriteLine($"Player 2's Score: {player2}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("[Press ANY KEY to Continue]");
            Statistics.SevensOutMatches += 1;

            if (player1 > Statistics.SevensOutHighScore)
            {
                Statistics.SevensOutHighScore = player1;

            }
            if (player2 > Statistics.SevensOutHighScore)
            {
                Statistics.SevensOutHighScore = player2;
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This runs through a computer match.
        /// </summary>
        /// <returns></returns>
        private int ComputerMatch()
        {
            int total = 0;
            int sum;

            while (true)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Player 2's Go (Computer)");
                int die1 = Die.Roll();
                int die2 = Die.Roll();
                sum = die1 + die2;
                if (CheckIfSeven(sum))
                {
                    Console.WriteLine("Computer got 7.");
                    break;
                }
                sum = GetSum(die1, die2);
                total += sum;
                Console.WriteLine("Total: " + total);
            }
            Console.WriteLine($"Player 2's Score: {total}   [Press ANY KEY to Continue]");
            Console.ReadKey();
            return total;
        }

        /// <summary>
        /// This determines what the sum is and also doubles each roll if a double is rolled.
        /// This function is public to allow the testing class to use it.
        /// </summary>
        /// <param name="die1"></param>
        /// <param name="die2"></param>
        /// <returns></returns>
        public int GetSum(int die1, int die2)
        {
            int sum = die1 + die2;
            if (CheckDouble(die1, die2))
            {
                Console.WriteLine("");
                sum = (die1 + die2) * 2;
            }
            Console.WriteLine($"Dice1: {die1}   Dice2: {die2}   Sum: {sum}");
            return sum;
        }

    }
}