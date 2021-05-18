using System;
using System.Linq;

namespace RPGCharacters.Game_Logic
{
    public class GameReader
    {
        /// <summary>
        /// Reads player input.
        /// </summary>
        /// <returns>Player input string</returns>
        public static string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Asks player for their hero name.
        /// </summary>
        /// <returns>Name of hero string</returns>
        public static string GetHeroName(int maxLengthOfName)
        {
            GameWriter.AskForHeroNameMessage();
            string name = ReadLine();

            while (!NameInputIsValid(name, maxLengthOfName))
            {
                GameWriter.ClearScreen();
                GameWriter.AskForHeroNameErrorMessage(maxLengthOfName);
                GameWriter.AskForHeroNameMessage();
                name = ReadLine();
            }

            GameWriter.ClearScreen();
            return name;
        }

        /// <summary>
        /// Checks if name is valid.
        /// </summary>
        /// <param name="name">Input name</param>
        /// <returns>True if name is not empty, is made up of letters and digits and is smaller than 30 characters. Otherwise false</returns>
        private static bool NameInputIsValid(string name, int maxLengthOfName)
        {
            bool nameIsNotEmpty = name != "";
            bool nameIsValid = name.Any(c => char.IsLetterOrDigit(c));
            bool lengthIsValid = name.Length < maxLengthOfName;

            return nameIsNotEmpty && nameIsValid && lengthIsValid;
        }

        /// <summary>
        /// Asks the player which type of hero they want to play with.
        /// </summary>
        /// <returns>Hero type number</returns>
        public static int GetHeroType()
        {
            GameWriter.DisplayHeroOptions();
            var typeInput = ReadLine();
            int heroType;

            while (!int.TryParse(typeInput, out heroType) || heroType < 1 || heroType > 4)
            {
                GameWriter.ClearScreen();
                GameWriter.AskForNumberMessage(1, 4);
                GameWriter.DisplayHeroOptions();
                typeInput = ReadLine();
            }

            GameWriter.ClearScreen();
            return heroType;
        }

        /// <summary>
        /// Asks the player which action they want to perform.
        /// </summary>
        /// <returns>Action number</returns>
        public static int GetGameAction()
        {
            GameWriter.DisplayGameOptions();
            var actionInput = ReadLine();
            int action;

            while (!int.TryParse(actionInput, out action) || action < 1 || action > 4)
            {
                GameWriter.ClearScreen();
                GameWriter.AskForNumberMessage(1, 3);
                GameWriter.DisplayGameOptions();
                actionInput = ReadLine();
            }

            GameWriter.ClearScreen();
            return action;
        }

        /// <summary>
        /// Asks the player which item action they want to take.
        /// </summary>
        /// <returns>Action number</returns>
        public static int GetFoundItemAction()
        {
            GameWriter.DisplayItemOptions();
            var actionInput = ReadLine();
            int action;
            while (!int.TryParse(actionInput, out action) || action < 1 || action > 4)
            {
                GameWriter.ClearScreen();
                GameWriter.AskForNumberMessage(1, 2);

                GameWriter.DisplayItemOptions();

                actionInput = ReadLine();
            }

            GameWriter.ClearScreen();
            return action;
        }
    }
}
