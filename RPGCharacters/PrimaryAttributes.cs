namespace RPGCharacters
{
    class PrimaryAttributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Vitality { get; set; }

        public static PrimaryAttributes operator+ (PrimaryAttributes a, PrimaryAttributes b)
        {
            PrimaryAttributes result = new PrimaryAttributes();
            result.Strength = a.Strength + b.Strength;
            result.Dexterity = a.Dexterity + b.Dexterity;
            result.Intelligence = a.Intelligence + b.Intelligence;
            result.Vitality = a.Vitality + b.Vitality;

            return result;
        }
    }
}
