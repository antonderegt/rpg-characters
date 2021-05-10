namespace RPGCharacters
{
    public enum ArmorType { 
        ARMOR_CLOTH,
        ARMOR_LEATHER,
        ARMOR_MAIL,
        ARMOR_PLATE
    }
    class Armor : Item
    {
        public ArmorType ArmorType { get; set; }
        public PrimaryAttributes Attributes { get; set; }
    }
}
