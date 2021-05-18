using System;

namespace RPGCharacters.Game_Logic
{
    /// <summary>
    /// Handles all writing to console for the Game class.
    /// </summary>
    public class GameWriter
    {
        /// <summary>
        /// Prints the welcome message.
        /// </summary>
        public static void WelcomeMessage()
        {
            Console.WriteLine("\nWelcome to the RPG game Fake Diablo");
        }

        /// <summary>
        /// Prints the goodbye message.
        /// </summary>
        /// <param name="name">Name of the Hero</param>
        public static void EndGameMessage(string name)
        {
            Console.WriteLine($"\nThanks for playing {name}!");
        }

        /// <summary>
        /// Clears the screen.
        /// </summary>
        public static void ClearScreen()
        {
            Console.Clear();
        }

        /// <summary>
        /// Asks for a number in a range.
        /// </summary>
        /// <param name="from">From</param>
        /// <param name="to">To</param>
        public static void AskForNumberMessage(int from, int to)
        {
            Console.WriteLine($"\nPlease enter a number between {from} and {to}");
        }

        /// <summary>
        /// Outputs all game options.
        /// </summary>
        public static void DisplayGameOptions()
        {
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Show my stats");
            Console.WriteLine("3. Leave the game\n");
        }

        /// <summary>
        /// Outputs all available heroes.
        /// </summary>
        public static void DisplayHeroOptions()
        {
            Console.WriteLine("\nChoose the type of your character");
            Console.WriteLine("1. Mage");
            Console.WriteLine("2. Ranger");
            Console.WriteLine("3. Rogue");
            Console.WriteLine("4. Warrior\n");
        }

        /// <summary>
        /// Outputs all available item actions.
        /// </summary>
        public static void DisplayItemOptions()
        {
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Try to equip");
            Console.WriteLine("2. Leave behind\n");
        }

        /// <summary>
        /// Waits for user to press a key to continue the game.
        /// </summary>
        public static void PressKeyToContinue()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            ClearScreen();
        }

        public static void AskForHeroNameMessage()
        {
            Console.WriteLine("\nEnter your hero name: ");
        }

        public static void AskForHeroNameErrorMessage(int length)
        {
            Console.WriteLine($"\nPlease enter a max of {length} letters and digits");
        }

        public static void GameLostMessage()
        {
            Console.WriteLine("\nYou lost, the game is over...");
        }

        public static void GameWonMessage()
        {
            Console.WriteLine("\nYou won!");
        }

        public static void LevelUpMessage(int level)
        {
            Console.WriteLine($"\nYou leveled up! Your current level is {level}.");
        }

        public static void OpponentDescriptionMessage(string type, double dps)
        {
            Console.WriteLine($"\nYour opponent is a {type}, with a DPS of {dps:0.##}");
        }

        public static void ItemFoundMessage(string itemDescription)
        {
            Console.WriteLine($"\nYou found: {itemDescription}");
        }

        public static void ItemEquippedMessage(string itemDescription)
        {
            Console.WriteLine($"\n{itemDescription} equipped!");
        }

        public static void ItemEquippedErrorMessage(string message)
        {
            Console.WriteLine($"\nYou can't equip this item: {message}");
        }
    }
}
