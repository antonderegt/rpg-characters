using RPGCharacters.Helpers;
using System;

namespace RPGCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            Mage mage = new Mage("Anton");

            mage.LevelUp(5);

            mage.DisplayStats();

            Weapon wand = new Weapon()
            {
                ItemName = "Common wand",
                ItemLevel = 2,
                ItemSlot = Slot.SLOT_WEAPON,
                WeaponType = WeaponType.WEAPON_WAND,
                WeaponAttributes = new WeaponAttributes() { Damage = 17, AttackSpeed = 0.7 }
            };

            Armor cloth = new Armor()
            {
                ItemName = "Common cloth body armor",
                ItemLevel = 1,
                ItemSlot = Slot.SLOT_BODY,
                ArmorType = ArmorType.ARMOR_CLOTH,
                Attributes = new PrimaryAttributes() { Vitality = 10, Strength = 20 }
            };

            mage.Equip(wand);
            mage.Equip(cloth);

            mage.DisplayStats();
        }
    }
}
