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

            Weapon axe = new Weapon()
            {
                ItemName = "Common axe",
                ItemLevel = 1,
                ItemSlot = Slot.SLOT_WEAPON,
                WeaponType = WeaponType.WEAPON_AXE,
                WeaponAttributes = new WeaponAttributes() { Damage = 7, AttackSpeed = 1.1 }
            };

            mage.Equip(axe);

            mage.DisplayStats();
        }
    }
}
