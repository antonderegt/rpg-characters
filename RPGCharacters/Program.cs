using RPGCharacters.Heroes;
using RPGCharacters.Games;
using System;

namespace RPGCharacters
{
    class Program
    {
        /// <summary>
        /// Handles the game loop to make the game playable.
        /// </summary>
        /// <param name="args">Not used</param>
        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to the RPG Games");

            Game game = new();

            int heroType = game.GetHeroType();

            string name = game.GetHeroName();

            Hero hero = game.CreateHero(heroType, name);

            int action;
            do
            {
                action = game.GetGameAction();
            } while (game.PlayGameAction(action, hero));
        }

        
    }
}
