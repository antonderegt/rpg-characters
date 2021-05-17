using RPGCharacters.Helpers;
using System;
using System.Text;

namespace RPGCharacters.Heroes
{
    /// <summary>
    /// This class handles writing to the console for the Hero class.
    /// </summary>
    class HeroWriter
    {
        /// <summary>
        /// Outputs stats to console.
        /// </summary>
        /// <param name="name">Name of hero</param>
        /// <param name="level">Level of hero</param>
        /// <param name="totalPrimaryAttributes">PrimaryAttributes of hero</param>
        /// <param name="baseSecondaryAttributes">SecondaryAttributes of hero</param>
        /// <param name="dps">Damage per second of hero</param>
        public void WriteStatsToConsole(string name, int level, PrimaryAttributes totalPrimaryAttributes, SecondaryAttributes baseSecondaryAttributes, double dps)
        {
            StringBuilder stats = new StringBuilder("\n-- Stats --\n");

            stats.AppendFormat($"Name: {name}\n");
            stats.AppendFormat($"Level: {level}\n");
            stats.AppendFormat($"Strength: {totalPrimaryAttributes.Strength}\n");
            stats.AppendFormat($"Dexterity: {totalPrimaryAttributes.Dexterity}\n");
            stats.AppendFormat($"Vitality: {totalPrimaryAttributes.Vitality}\n");
            stats.AppendFormat($"Intelligence: {totalPrimaryAttributes.Intelligence}\n");
            stats.AppendFormat($"Health: {baseSecondaryAttributes.Health}\n");
            stats.AppendFormat($"Armor Rating: {baseSecondaryAttributes.ArmorRating}\n");
            stats.AppendFormat($"Elemental Resistance: {baseSecondaryAttributes.ElementalResistence}\n");
            stats.AppendFormat($"DPS: {dps:0.##}");

            Console.WriteLine(stats.ToString());
        }
    }
}
