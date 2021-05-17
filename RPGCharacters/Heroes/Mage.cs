using System;
using RPGCharacters.Custom_Exceptions;
using RPGCharacters.Helpers;
using RPGCharacters.Items;

namespace RPGCharacters.Heroes
{
    /// <summary>
    /// Hero of type mage.
    /// </summary>
    public class Mage : Hero
    {
        /// <summary>
        /// Initialize a mage.
        /// </summary>
        /// <param name="name">Hero's name</param>
        public Mage(string name) : base(name, 1, 1, 8, 5)
        {
        }

        /// <inheritdoc/>
        public override void LevelUp(int levels)
        {
            if (levels < 1) throw new ArgumentException();

            PrimaryAttributes levelUpValues = new() { Vitality = 3 * levels, Strength = 1 * levels, Dexterity = 1 * levels, Intelligence = 5 * levels };

            BasePrimaryAttributes += levelUpValues;

            Level += 1 * levels;

            CalculateTotalStats();
        }

        /// <inheritdoc/>
        public override double CalculateDPS()
        {
            TotalPrimaryAttributes = CalculateArmorBonus();
            double weaponDPS = CalculateWeaponDPS();
            if (weaponDPS == 1)
            {
                return 1;
            }

            double multiplier = 1 + TotalPrimaryAttributes.Intelligence / 100.0;

            return weaponDPS * multiplier;
        }

        /// <inheritdoc/>
        public override string Equip(Weapon weapon)
        {
            if (weapon.ItemLevel > Level)
            {
                throw new InvalidWeaponException($"Character needs to be level {weapon.ItemLevel} to equip this item");
            }

            if (weapon.WeaponType != WeaponType.WEAPON_STAFF && weapon.WeaponType != WeaponType.WEAPON_WAND)
            {
                throw new InvalidWeaponException($"Character can't equip a {weapon.WeaponType}");
            }

            Equipment[weapon.ItemSlot] = weapon;

            return "New weapon equipped!";
        }

        /// <inheritdoc/>
        public override string Equip(Armor armor)
        {
            if (armor.ItemLevel > Level)
            {
                throw new InvalidArmorException($"Character needs to be level {armor.ItemLevel} to equip this item");
            }

            if (armor.ArmorType != ArmorType.ARMOR_CLOTH)
            {
                throw new InvalidArmorException($"Character can't equip a {armor.ArmorType}");
            }

            Equipment[armor.ItemSlot] = armor;

            return "New armor equipped!";
        }
    }
}
