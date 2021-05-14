using System;

namespace RPGCharacters.Helpers
{
    /// <summary>
    /// Helper class to group primary attributes of a hero.
    /// </summary>
    public class PrimaryAttributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Vitality { get; set; }

        /// <summary>
        /// Checks if two PrimaryAttributes objects are equal.
        /// </summary>
        /// <param name="obj">Object to compare to</param>
        /// <returns>Whether the objects are equal</returns>
        public override bool Equals(object obj)
        {
            return obj is PrimaryAttributes attributes &&
                   Strength == attributes.Strength &&
                   Dexterity == attributes.Dexterity &&
                   Intelligence == attributes.Intelligence &&
                   Vitality == attributes.Vitality;
        }

        /// <summary>
        /// Adds two PrimaryAttributes together.
        /// </summary>
        /// <param name="a">Object one</param>
        /// <param name="b">Object two</param>
        /// <returns>New PrimaryAttributes object of sum of the inputs</returns>
        public static PrimaryAttributes operator +(PrimaryAttributes a, PrimaryAttributes b) => new()
        {
            Strength = a.Strength + b.Strength,
            Dexterity = a.Dexterity + b.Dexterity,
            Intelligence = a.Intelligence + b.Intelligence,
            Vitality = a.Vitality + b.Vitality
        };
    }
}
