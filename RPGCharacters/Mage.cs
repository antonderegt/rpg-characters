﻿using System;

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
            if (levels < 1) throw new ArgumentException();

            PrimaryAttributes levelValues = new() { Vitality = 3 * levels, Strength = 1 * levels, Dexterity = 1 * levels, Intelligence = 5 * levels };

            BasePrimaryAttributes += levelValues;

            Level += 1 * levels;

            CalculateTotalStats();
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
                throw new InvalidWeaponException($"Character needs to be level {weapon.ItemLevel} to equip this item");
            }

            if (weapon.WeaponType != WeaponType.WEAPON_STAFF && weapon.WeaponType != WeaponType.WEAPON_WAND)
            {
                throw new InvalidWeaponException($"A mage can't equip a {weapon.WeaponType}");
            }

            Equipment.Add(weapon.ItemSlot, weapon);

            Console.WriteLine("New weapon equipped!");
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
                throw new InvalidArmorException($"Character needs to be level {armor.ItemLevel} to equip this item");
            }

            if (armor.ArmorType != ArmorType.ARMOR_CLOTH)
            {
                throw new InvalidArmorException($"A mage can't equip a {armor.ArmorType}");
            }

            Equipment.Add(armor.ItemSlot, armor);

            Console.WriteLine("New armor equipped!");
        }
    }
}
