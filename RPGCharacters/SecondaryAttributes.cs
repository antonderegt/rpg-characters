using System;

namespace RPGCharacters
{
    public class SecondaryAttributes : IEquatable<SecondaryAttributes>
    {
        public int Health { get; set; }
        public int ArmorRating { get; set; }
        public int ElementalResistence { get; set; }

        public bool Equals(SecondaryAttributes other)
        {
            if (Health != other.Health)
                return false;
            if (ArmorRating != other.ArmorRating)
                return false;
            if (ElementalResistence != other.ElementalResistence)
                return false;

            return true;
        }
    }
}
