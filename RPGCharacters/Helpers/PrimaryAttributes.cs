using System;

namespace RPGCharacters.Helpers
{
    public class PrimaryAttributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Vitality { get; set; }

        /// <summary>
        /// Checks if two PrimaryAttributes objects are equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if equal, otherwise false</returns>
        public override bool Equals(object obj)
        {
            return obj is PrimaryAttributes attributes &&
                   Strength == attributes.Strength &&
                   Dexterity == attributes.Dexterity &&
                   Intelligence == attributes.Intelligence &&
                   Vitality == attributes.Vitality;
        }

        /// <summary>
        /// Adds to Primary Attributes together
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>New PrimaryAttributes object of sum of inputs</returns>
        public static PrimaryAttributes operator +(PrimaryAttributes a, PrimaryAttributes b) => new()
        {
            Strength = a.Strength + b.Strength,
            Dexterity = a.Dexterity + b.Dexterity,
            Intelligence = a.Intelligence + b.Intelligence,
            Vitality = a.Vitality + b.Vitality
        };
    }
}
