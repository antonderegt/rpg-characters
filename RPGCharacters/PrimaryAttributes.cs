namespace RPGCharacters
{
    class PrimaryAttributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Vitality { get; set; }

        public PrimaryAttributes(int strength, int dexterity, int intelligence, int vitality)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Vitality = vitality;
        }
    }
}
