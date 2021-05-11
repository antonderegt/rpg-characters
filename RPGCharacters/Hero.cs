using System;
using System.Collections.Generic;
using System.Text;

namespace RPGCharacters
{
    /// <summary>
    /// The parent class of all the characters.
    /// </summary>
    abstract class Hero
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
            BaseSecondaryAttributes = new SecondaryAttributes()
            {
                Health = TotalPrimaryAttributes.Vitality * 10,
                ArmorRating = TotalPrimaryAttributes.Strength + vitality,
                ElementalResistence = TotalPrimaryAttributes.Intelligence
            };
        }

        /// <summary>
        /// Each character type has it's own way of leveling up
        /// </summary>
        /// <param name="levels"></param>
        public abstract void LevelUp(int levels);

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

            stats.AppendFormat("Name: {0}\n", Name);
            stats.AppendFormat("Level: {0}\n", Level);
            stats.AppendFormat("Strength: {0}\n", TotalPrimaryAttributes.Strength);
            stats.AppendFormat("Dexterity: {0}\n", TotalPrimaryAttributes.Dexterity);
            stats.AppendFormat("Vitality: {0}\n", TotalPrimaryAttributes.Vitality);
            stats.AppendFormat("Intelligence: {0}\n", TotalPrimaryAttributes.Intelligence);
            stats.AppendFormat("Health: {0}\n", BaseSecondaryAttributes.Health);
            stats.AppendFormat("Armor Rating: {0}\n", BaseSecondaryAttributes.ArmorRating);
            stats.AppendFormat("Elemental Resistance: {0}\n", BaseSecondaryAttributes.ElementalResistence);
            stats.AppendFormat("DPS: {0}\n", DPS.ToString("0.##"));

            Console.WriteLine(stats.ToString());
        }

        /// <summary>
        /// Calculates total stats based on base stats and equipped items.
        /// </summary>
        private void CalculateTotalStats()
        {
            int totalVitality = BasePrimaryAttributes.Vitality;
            int totalStrength = BasePrimaryAttributes.Strength;
            int totalDexterity = BasePrimaryAttributes.Dexterity;
            int totalIntelligence = BasePrimaryAttributes.Intelligence;

            TotalPrimaryAttributes = new PrimaryAttributes() { Strength = totalStrength, Dexterity = totalDexterity, Intelligence = totalIntelligence, Vitality = totalVitality };

            DPS = CalculateDPS();
        }

        /// <summary>
        /// Calculates a characters damage per seconde.
        /// </summary>
        /// <returns></returns>
        public virtual double CalculateDPS()
        {
            double weaponDPS = CalculateWeaponDPS();
            if (weaponDPS == 1)
            {
                return 1;
            }

            double multiplier = 1 + TotalPrimaryAttributes.Strength / 100.0;

            return weaponDPS * multiplier;
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
