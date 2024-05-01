using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        /// <summary>
        /// This runs the game selection.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Game Game = new Game();
            Game.GameSelect();
        }


    }

}