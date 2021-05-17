using RPGCharacters.Games;
using System;

namespace RPGCharacters
{
    class Program
    {
        /// <summary>
        /// Starts a new instance of the game.
        /// </summary>
        /// <param name="args">Not used</param>
        static void Main(string[] args)
        {
            Game game = new();
            game.Play();
        }

        
    }
}
