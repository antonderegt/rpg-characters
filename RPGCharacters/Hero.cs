using System;
using System.Collections.Generic;
using System.Text;

namespace RPGCharacters
{
    /// <summary>
    /// The parent class of all the characters.
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
        /// Initializes a characters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strength"></param>
        /// <param name="dexterity"></param>
        /// <param name="intelligence"></param>
        /// <param name="vitality"></param>
        public Hero(string name, int strength, int dexterity, int intelligence, int vitality)
        {
            Name = name;
            Level = 1;
            Equipment = new Dictionary<Slot, Item>();
            BasePrimaryAttributes = new PrimaryAttributes() { Strength = strength, Dexterity = dexterity, Intelligence = intelligence, Vitality = vitality };
            CalculateTotalStats();
        }

        /// <summary>
        /// Each character type has it's own way of leveling up
        /// </summary>
        /// <param name="levels"></param>
        public abstract void LevelUp(int levels);

        /// <summary>
        /// Calculates a characters damage per seconde.
        /// </summary>
        /// <returns></returns>
        public abstract double CalculateDPS();

        /// <summary>
        /// Is used to equip a weapon.
        /// </summary>
        /// <param name="weapon"></param>
        public abstract void Equip(Weapon weapon);

        /// <summary>
        /// Is used to equip a weapon.
        /// </summary>
        /// <param name="armor"></param>
        public abstract void Equip(Armor armor);

        /// <summary>
        /// Outputs all stats of a character to the console
        /// </summary>
        public void DisplayStats()
        {
            CalculateTotalStats();

            StringBuilder stats = new StringBuilder("\n-- Stats --\n");

            stats.AppendFormat($"Name: {Name}\n");
            stats.AppendFormat($"Level: {Level}\n");
            stats.AppendFormat($"Strength: {TotalPrimaryAttributes.Strength}\n");
            stats.AppendFormat($"Dexterity: {TotalPrimaryAttributes.Dexterity}\n");
            stats.AppendFormat($"Vitality: {TotalPrimaryAttributes.Vitality}\n");
            stats.AppendFormat($"Intelligence: {TotalPrimaryAttributes.Intelligence}\n");
            stats.AppendFormat($"Health: {BaseSecondaryAttributes.Health}\n");
            stats.AppendFormat($"Armor Rating: {BaseSecondaryAttributes.ArmorRating}\n");
            stats.AppendFormat($"Elemental Resistance: {BaseSecondaryAttributes.ElementalResistence}\n");
            stats.AppendFormat($"DPS: {DPS.ToString("0.##")}\n");

            Console.WriteLine(stats.ToString());
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
