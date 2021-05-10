namespace RPGCharacters
{
    class SecondaryAttributes
    {
        public int Health { get; set; }
        public int ArmorRating { get; set; }
        public int ElementalResistence { get; set; }

        public SecondaryAttributes(int health, int armorRating, int elementalResistence)
        {
            Health = health;
            ArmorRating = armorRating;
            ElementalResistence = elementalResistence;
        }
    }
}
