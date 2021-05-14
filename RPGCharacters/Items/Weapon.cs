using RPGCharacters.Helpers;

namespace RPGCharacters.Items
{
    public enum WeaponType
    {
        WEAPON_AXE,
        WEAPON_BOW,
        WEAPON_DAGGER,
        WEAPON_HAMMER,
        WEAPON_STAFF,
        WEAPON_SWORD,
        WEAPON_WAND
    }
    public class Weapon : Item
    {
        public WeaponType WeaponType { get; set; }
        public WeaponAttributes WeaponAttributes { get; set; }
    }
}
