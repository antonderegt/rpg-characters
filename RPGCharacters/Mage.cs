using System;

namespace RPGCharacters
{
    class Mage : Hero
    {
        public Mage(string name) : base(name, 5, 1, 1, 8)
        {
            Console.WriteLine("Created mage");
        }

        public override void LevelUp(int levels)
        {
            int newVitality = BasePrimaryAttributes.Vitality + (3 * levels);
            int newStrength = BasePrimaryAttributes.Strength + (1 * levels);
            int newDexterity = BasePrimaryAttributes.Dexterity + (1 * levels);
            int newIntelligence = BasePrimaryAttributes.Intelligence + (8 * levels);

            this.BasePrimaryAttributes = new PrimaryAttributes(newStrength, newDexterity, newIntelligence, newVitality);

            Level += 1 * levels;
        }
    }
}
