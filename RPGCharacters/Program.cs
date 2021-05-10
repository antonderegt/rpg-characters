using System;

namespace RPGCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            Mage mage = new Mage("Anton");

            mage.displayStats();

            mage.LevelUp(1);

            mage.displayStats();
        }
    }
}
