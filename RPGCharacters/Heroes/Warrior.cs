﻿using System;
using RPGCharacters.Custom_Exceptions;
using RPGCharacters.Helpers;
using RPGCharacters.Items;

namespace RPGCharacters.Heroes
{
    public class Warrior : Hero
    {
        /// <summary>
        /// Initialize character
        /// </summary>
        /// <param name="name"></param>
        public Warrior(string name) : base(name, 5, 2, 1, 10)
        {
            Console.WriteLine("Created a warrior");
        }

        /// <summary>
        /// Levels up a character.
        /// Each character levels up differently
        /// </summary>
        /// <param name="levels"></param>
        public override void LevelUp(int levels)
        {
            if (levels < 1) throw new ArgumentException();

            PrimaryAttributes levelUpValues = new() { Vitality = 5 * levels, Strength = 3 * levels, Dexterity = 2 * levels, Intelligence = 1 * levels };

            BasePrimaryAttributes += levelUpValues;

            Level += 1 * levels;

            CalculateTotalStats();
        }

        /// <summary>
        /// Calculates damage per second
        /// </summary>
        /// <returns>Character damage per second</returns>
        public override double CalculateDPS()
        {
            TotalPrimaryAttributes = CalculateArmorBonus();
            double weaponDPS = CalculateWeaponDPS();
            if (weaponDPS == 1)
            {
                return 1;
            }

            double multiplier = 1 + TotalPrimaryAttributes.Strength / 100.0;

            return weaponDPS * multiplier;
        }

        /// <summary>
        /// Equips a weapon.
        /// </summary>
        /// <exception cref="InvalidWeaponException">Thrown when weapon level is higher than character level or when weapon is not of type WEAPON_STAFF or WEAPON_WAND</exception>
        /// <param name="weapon"></param>
        public override string Equip(Weapon weapon)
        {
            if (weapon.ItemLevel > Level)
            {
                throw new InvalidWeaponException($"Character needs to be level {weapon.ItemLevel} to equip this item");
            }

            if (weapon.WeaponType != WeaponType.WEAPON_AXE && weapon.WeaponType != WeaponType.WEAPON_HAMMER && weapon.WeaponType != WeaponType.WEAPON_SWORD)
            {
                throw new InvalidWeaponException($"Character can't equip a {weapon.WeaponType}");
            }

            Equipment.Add(weapon.ItemSlot, weapon);

            return "New weapon equipped!";
        }

        /// <summary>
        /// Equips armor.
        /// </summary>
        /// <exception cref="InvalidWeaponException">Thrown when armor level is higher than character level or when armor is not of type ARMOR_CLOTH</exception>
        /// <param name="weapon"></param>
        public override string Equip(Armor armor)
        {
            if (armor.ItemLevel > Level)
            {
                throw new InvalidArmorException($"Character needs to be level {armor.ItemLevel} to equip this item");
            }

            if (armor.ArmorType != ArmorType.ARMOR_PLATE && armor.ArmorType != ArmorType.ARMOR_MAIL)
            {
                throw new InvalidArmorException($"Character can't equip a {armor.ArmorType}");
            }

            Equipment.Add(armor.ItemSlot, armor);

            return "New armor equipped!";
        }
    }
}