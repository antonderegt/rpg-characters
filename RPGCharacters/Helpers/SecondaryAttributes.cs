using System;

namespace RPGCharacters.Helpers
{
    public class SecondaryAttributes
    {
        public int Health { get; set; }
        public int ArmorRating { get; set; }
        public int ElementalResistence { get; set; }

        /// <summary>
        /// Checks if two SecondaryAttributes objects are equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            return obj is SecondaryAttributes attributes &&
                   Health == attributes.Health &&
                   ArmorRating == attributes.ArmorRating &&
                   ElementalResistence == attributes.ElementalResistence;
        }
    }
}
