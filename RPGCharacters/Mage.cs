using System;

namespace RPGCharacters
{
    class Mage : Hero
    {
        public Mage(string name) : base(name, 5, 1, 8, 1)
        {
            Console.WriteLine("Created mage");
        }

        public override void LevelUp(int levels)
        {
            int newVitality = BasePrimaryAttributes.Vitality + (3 * levels);
            int newStrength = BasePrimaryAttributes.Strength + (1 * levels);
            int newDexterity = BasePrimaryAttributes.Dexterity + (1 * levels);
            int newIntelligence = BasePrimaryAttributes.Intelligence + (5 * levels);

            this.BasePrimaryAttributes = new PrimaryAttributes() { Strength = newStrength, Dexterity = newDexterity, Intelligence = newIntelligence, Vitality = newVitality };

            Level += 1 * levels;
        }

        public override double CalculateDPS()
        {
            double weaponDPS = CalculateWeaponDPS();
            if (weaponDPS == 1)
            {
                return 1;
            }

            double multiplier = 1 + TotalPrimaryAttributes.Intelligence / 100.0;

            return weaponDPS * multiplier;
        }
    }
}
