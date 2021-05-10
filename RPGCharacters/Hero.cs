using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters
{
    abstract class Hero
    {
        private string Name { get; set; }
        protected int Level { get; set; }

        // Base primary attributes
        protected int BaseStrength { get; set; }
        protected int BaseDexterity { get; set; }
        protected int BaseIntelligence { get; set; }
        protected int BaseVitality { get; set; }


        // Total primary attributes
        private int TotalStrength { get; set; }
        private int TotalDexterity { get; set; }
        private int TotalIntelligence { get; set; }
        private int TotalVitality { get; set; }

        // Secondary attributes
        private int Health { get; set; }
        private int ArmorRating { get; set; }
        private int ElementalResistance { get; set; }


        public Hero(string name, int strength, int dexterity, int intelligence, int vitality)
        {
            Name = name;
            Level = 1;
            BaseStrength = strength;
            BaseDexterity = dexterity;
            BaseIntelligence = intelligence;
            BaseVitality = vitality;
            Health = BaseVitality * 10;
            ArmorRating = BaseStrength + BaseDexterity;
            ElementalResistance = BaseIntelligence;
        }

        public abstract void LevelUp();
    }
}
