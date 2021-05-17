using RPGCharacters.Helpers;

namespace RPGCharacters.Items
{
    /// <summary>
    /// Lists all available armor types.
    /// </summary>
    public enum ArmorType { 
        ARMOR_CLOTH,
        ARMOR_LEATHER,
        ARMOR_MAIL,
        ARMOR_PLATE
    }

    /// <summary>
    /// Defines structure of an item of type armor.
    /// </summary>
    public class Armor : Item
    {
        public ArmorType ArmorType { get; set; }
        public PrimaryAttributes Attributes { get; set; }

        /// <inheritdoc/>
        public override string ItemDescription()
        {
            return $"Armor of type {ArmorType}";
        }
    }
}
