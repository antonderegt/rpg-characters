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

            BasePrimaryAttributes = new PrimaryAttributes() { Strength = newStrength, Dexterity = newDexterity, Intelligence = newIntelligence, Vitality = newVitality };

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

        /// <summary>
        /// Equips a weapon.
        /// </summary>
        /// <exception cref="InvalidWeaponException">Thrown when weapon level is higher than character level or when weapon is not of type WEAPON_STAFF or WEAPON_WAND</exception>
        /// <param name="weapon"></param>
        public override void Equip(Weapon weapon)
        {
            if (weapon.ItemLevel > Level)
            {
                throw new InvalidWeaponException("Player needs to be level " + weapon.ItemLevel + " to equip this item");
            }

            if (weapon.WeaponType.Equals(WeaponType.WEAPON_STAFF) || weapon.WeaponType.Equals(WeaponType.WEAPON_WAND))
            {
                Equipment.Add(weapon.ItemSlot, weapon);
            }

            throw new InvalidWeaponException("A mage can't equip a " + weapon.WeaponType);
        }

        /// <summary>
        /// Equips armor.
        /// </summary>
        /// <exception cref="InvalidWeaponException">Thrown when armor level is higher than character level or when armor is not of type ARMOR_CLOTH</exception>
        /// <param name="weapon"></param>
        public override void Equip(Armor armor)
        {
            if (armor.ItemLevel > Level)
            {
                throw new InvalidArmorException("Player needs to be level " + armor.ItemLevel + " to equip this item");
            }

            if(armor.ArmorType.Equals(ArmorType.ARMOR_CLOTH))
            {
                Equipment.Add(armor.ItemSlot, armor);
            }

            throw new InvalidArmorException("A mage can't equip a " + armor.ArmorType);
        }
    }
}
