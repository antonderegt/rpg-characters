using System;

namespace RPGCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            Mage mage = new Mage("Anton");

            mage.DisplayStats();

            mage.LevelUp(1);

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
                Attributes = new PrimaryAttributes() { Vitality = 2, Strength = 1 }
            };

            mage.Equip(wand);
            mage.Equip(cloth);

            mage.DisplayStats();
        }
    }
}
