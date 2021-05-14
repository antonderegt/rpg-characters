using RPGCharacters.Helpers;

namespace RPGCharacters
{
    public enum ArmorType { 
        ARMOR_CLOTH,
        ARMOR_LEATHER,
        ARMOR_MAIL,
        ARMOR_PLATE
    }
    public class Armor : Item
    {
        public ArmorType ArmorType { get; set; }
        public PrimaryAttributes Attributes { get; set; }
    }
}
