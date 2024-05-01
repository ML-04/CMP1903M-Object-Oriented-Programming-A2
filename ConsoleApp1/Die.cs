using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Die
    {
        private int rollOutcome;
        public int RollOutcome // Usage of encapsulating values.
        {
            get { return rollOutcome; }
            set { rollOutcome = value; }
        }

        Random random = new Random();

        /// <summary>
        /// This creates a random number between 1 and 6 for each roll of the dice.
        /// </summary>
        /// <returns></returns>
        public int Roll()
        {
            int rollOutcome = random.Next(1, 7);
            return rollOutcome;
        }

    }
}