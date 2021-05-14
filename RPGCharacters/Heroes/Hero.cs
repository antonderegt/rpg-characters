using RPGCharacters.Custom_Exceptions;
using RPGCharacters.Helpers;
using RPGCharacters.Items;
using System;
using System.Collections.Generic;

namespace RPGCharacters.Heroes
{
    /// <summary>
    /// Abstract parent class of all the hero characters.
    /// </summary>
    public abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public PrimaryAttributes BasePrimaryAttributes { get; set; }
        public PrimaryAttributes TotalPrimaryAttributes { get; set; }
        public SecondaryAttributes BaseSecondaryAttributes { get; set; }
        public Dictionary<Slot, Item> Equipment { get; set; }
        public double DPS { get; set; }

        /// <summary>
        /// Initializes a hero.
        /// </summary>
        /// <param name="name">Name of hero</param>
        /// <param name="strength">Strength of hero</param>
        /// <param name="dexterity">Dexterity of hero</param>
        /// <param name="intelligence">Intelligence of hero</param>
        /// <param name="vitality">Vitality of hero</param>
        public Hero(string name, int strength, int dexterity, int intelligence, int vitality)
        {
            Name = name;
            Level = 1;
            Equipment = new Dictionary<Slot, Item>();
            BasePrimaryAttributes = new PrimaryAttributes() { Strength = strength, Dexterity = dexterity, Intelligence = intelligence, Vitality = vitality };
            CalculateTotalStats();
        }

        /// <summary>
        /// Levels up a hero and recalculates total stats.
        /// </summary>
        /// <param name="levels">Number of levels to level up</param>
        /// <exception cref="ArgumentException">Levels is lower than 1</exception>
        public abstract void LevelUp(int levels);

        /// <summary>
        /// Calculates a heros damage per seconde.
        /// </summary>
        /// <returns>Damage per second</returns>
        public abstract double CalculateDPS();

        /// <summary>
        /// Equips a weapon.
        /// </summary>
        /// <param name="weapon">Weapon object</param>
        /// <exception cref="InvalidWeaponException">Thrown when weapon level is higher than character level or when weapon is not of type WEAPON_STAFF or WEAPON_WAND</exception>
        /// <returns>Success message</returns>
        public abstract string Equip(Weapon weapon);

        /// <summary>
        /// Equips armor.
        /// </summary>
        /// <param name="armor">Armor object</param>
        /// <exception cref="InvalidArmorException">Thrown when armor level is higher than character level or when armor is not of type ARMOR_CLOTH</exception>
        /// <returns>Success message</returns>
        public abstract string Equip(Armor armor);

        /// <summary>
        /// Calculates and outputs hero stats.
        /// </summary>
        public void DisplayStats()
        {
            CalculateTotalStats();

            HeroWriter writer = new();
            writer.WriteStatsToConsole(Name, Level, TotalPrimaryAttributes, BaseSecondaryAttributes, DPS);
        }

        /// <summary>
        /// Calculates total stats based on base stats and equipped items.
        /// </summary>
        public void CalculateTotalStats()
        {
            TotalPrimaryAttributes = CalculateArmorBonus();
            BaseSecondaryAttributes = CalculateSecondaryStats();
            DPS = CalculateDPS();
        }

        /// <summary>
        /// Calculates armor bonus
        /// </summary>
        /// <returns>New PrimaryAttributes</returns>
        public PrimaryAttributes CalculateArmorBonus()
        {
            PrimaryAttributes armorBonusValues = new() { Strength = 0, Dexterity = 0, Intelligence = 0, Vitality = 0 };

            bool hasHeadArmor = Equipment.TryGetValue(Slot.SLOT_HEADER, out Item headArmor);
            bool hasBodyArmor = Equipment.TryGetValue(Slot.SLOT_BODY, out Item bodyArmor);
            bool hasLegsArmor = Equipment.TryGetValue(Slot.SLOT_LEGS, out Item legsArmor);

            if (hasHeadArmor)
            {
                Armor a = (Armor)headArmor;
                armorBonusValues += new PrimaryAttributes() { Strength = a.Attributes.Strength, Dexterity = a.Attributes.Dexterity, Intelligence = a.Attributes.Intelligence, Vitality = a.Attributes.Vitality };
            }

            if (hasBodyArmor)
            {
                Armor a = (Armor)bodyArmor;
                armorBonusValues += new PrimaryAttributes() { Strength = a.Attributes.Strength, Dexterity = a.Attributes.Dexterity, Intelligence = a.Attributes.Intelligence, Vitality = a.Attributes.Vitality };
            }

            if (hasLegsArmor)
            {
                Armor a = (Armor)legsArmor;
                armorBonusValues += new PrimaryAttributes() { Strength = a.Attributes.Strength, Dexterity = a.Attributes.Dexterity, Intelligence = a.Attributes.Intelligence, Vitality = a.Attributes.Vitality };
            }

            return BasePrimaryAttributes + armorBonusValues;
        }

        public SecondaryAttributes CalculateSecondaryStats()
        {
            return new SecondaryAttributes()
            {
                Health = TotalPrimaryAttributes.Vitality * 10,
                ArmorRating = TotalPrimaryAttributes.Strength + TotalPrimaryAttributes.Dexterity,
                ElementalResistence = TotalPrimaryAttributes.Intelligence
            };
        }

        /// <summary>
        /// Calculates a weapons damage per seconde.
        /// </summary>
        /// <returns></returns>
        public double CalculateWeaponDPS()
        {
            Item equippedWeapon;
            bool hasWeapon = Equipment.TryGetValue(Slot.SLOT_WEAPON, out equippedWeapon);
            if (hasWeapon)
            {
                Weapon w = (Weapon)equippedWeapon;
                return w.WeaponAttributes.AttackSpeed * w.WeaponAttributes.Damage;
            }
            else
            {
                return 1;
            }
        }
    }
}
