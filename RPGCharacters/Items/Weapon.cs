using RPGCharacters.Helpers;

namespace RPGCharacters.Items
{
    /// <summary>
    /// Lists all available weapons.
    /// </summary>
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

    /// <summary>
    /// Defines structure of an item of type weapon.
    /// </summary>
    public class Weapon : Item
    {
        public WeaponType WeaponType { get; set; }
        public WeaponAttributes WeaponAttributes { get; set; }

        public override string ItemDescription()
        {
            return $"Weapon of type {WeaponType}";
        }
    }
}
