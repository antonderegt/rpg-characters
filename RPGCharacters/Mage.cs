using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters
{
    class Mage : Hero
    {
        public Mage(string name) : base(name, 5, 1, 1, 1)
        {
            Console.WriteLine("Created mage");
        }

        public override void LevelUp()
        {
            Level++;
            //BaseVitality += 3;
            //BaseStrength += 1;
            //BaseDexterity += 1;
            //BaseIntelligence += 5;

            // Compute total attributes
        }
    }
}
