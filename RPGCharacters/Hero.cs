using System;
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

        public Hero(string name, int strength, int dexterity, int intelligence, int vitality)
        {
            Name = name;
            Level = 1;
            BasePrimaryAttributes = new PrimaryAttributes(strength, dexterity, intelligence, vitality);
            TotalPrimaryAttributes = new PrimaryAttributes(strength, dexterity, intelligence, vitality);
            BaseSecondaryAttributes = new SecondaryAttributes(vitality * 10, strength + vitality, intelligence); 
        }

        public abstract void LevelUp(int levels);

        public void displayStats()
        {
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
            stats.AppendFormat("DPS: {0}\n", 10);

            Console.WriteLine(stats.ToString());
        }
    }
}
