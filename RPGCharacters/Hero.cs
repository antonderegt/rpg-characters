using System;
using System.Collections.Generic;
using System.Text;

namespace RPGCharacters
{
    abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public PrimaryAttributes BasePrimaryAttributes { get; set; }
        public PrimaryAttributes TotalPrimaryAttributes { get; set; }
        public SecondaryAttributes BaseSecondaryAttributes { get; set; }
        public Dictionary<Slot, Item> Equipment { get; set; }
        public double DPS { get; set; }

        public Hero(string name, int strength, int dexterity, int intelligence, int vitality)
        {
            Name = name;
            Level = 1;
            Equipment = new Dictionary<Slot, Item>();
            BasePrimaryAttributes = new PrimaryAttributes() { Strength = strength, Dexterity = dexterity, Intelligence = intelligence, Vitality = vitality };
            //TotalPrimaryAttributes = new PrimaryAttributes() { Strength = strength, Dexterity = dexterity, Intelligence = intelligence, Vitality = vitality };
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
        /// Used to equip a weapon
        /// </summary>
        /// <param name="weapon"></param>
        public void Equip(Weapon weapon)
        {
            if (weapon.ItemLevel > Level)
            {
                throw new InvalidWeaponException("Player needs to be level " + weapon.ItemLevel + " to equip this item");
            }

            Equipment.Add(weapon.ItemSlot, weapon);
        }

        public void Equip(Armor armor)
        {
            if (armor.ItemLevel > Level)
            {
                throw new InvalidArmorException("Player needs to be level " + armor.ItemLevel + " to equip this item");
            }

            Equipment.Add(armor.ItemSlot, armor);
        }

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

        private void CalculateTotalStats()
        {
            int totalVitality = BasePrimaryAttributes.Vitality;
            int totalStrength = BasePrimaryAttributes.Strength;
            int totalDexterity = BasePrimaryAttributes.Dexterity;
            int totalIntelligence = BasePrimaryAttributes.Intelligence;

            TotalPrimaryAttributes = new PrimaryAttributes() { Strength = totalStrength, Dexterity = totalDexterity, Intelligence = totalIntelligence, Vitality = totalVitality };

            DPS = CalculateDPS();
        }

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
