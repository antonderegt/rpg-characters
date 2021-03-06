using Xunit;
using RPGCharacters.Custom_Exceptions;
using RPGCharacters.Helpers;
using RPGCharacters.Items;
using RPGCharacters.Heroes;

namespace RPGCharactersTests
{
    /// <summary>
    /// Test RPG Character items, equipping and DPS calculations.
    /// </summary>
    public class RPGCharacterEquipmentTests
    {
        #region TestItems
        Weapon testAxe = new Weapon()
        {
            ItemName = "Common axe",
            ItemLevel = 1,
            ItemSlot = Slot.SLOT_WEAPON,
            WeaponType = WeaponType.WEAPON_AXE,
            WeaponAttributes = new WeaponAttributes() { Damage = 7, AttackSpeed = 1.1 }
        };

        Armor testPlateBody = new Armor()
        {
            ItemName = "Common plate body armor",
            ItemLevel = 1,
            ItemSlot = Slot.SLOT_BODY,
            ArmorType = ArmorType.ARMOR_PLATE,
            Attributes = new PrimaryAttributes() { Vitality = 2, Strength = 1 }
        };

        Weapon testBow = new Weapon()
        {
            ItemName = "Common bow",
            ItemLevel = 1,
            ItemSlot = Slot.SLOT_WEAPON,
            WeaponType = WeaponType.WEAPON_BOW,
            WeaponAttributes = new WeaponAttributes() { Damage = 12, AttackSpeed = 0.8 }
        };

        Armor testClothHead = new Armor()
        {
            ItemName = "Common cloth head armor",
            ItemLevel = 1,
            ItemSlot = Slot.SLOT_HEADER,
            ArmorType = ArmorType.ARMOR_CLOTH,
            Attributes = new PrimaryAttributes() { Vitality = 1, Intelligence = 5 }
        };

        #endregion

        #region Equip

        [Fact]
        public void Equip_CharacterTriesToEquipHighLevelWeapon_ThrowsInvalidWeaponException()
        {
            //Arrange
            Warrior warrior = new("Warrior");
            testAxe.ItemLevel = 2;
            // Act and Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.Equip(testAxe));
        }

        [Fact]
        public void Equip_CharacterTriesToEquipHighLevelArmor_ThrowsInvalidArmorException()
        {
            //Arrange
            Warrior warrior = new("Warrior");
            testPlateBody.ItemLevel = 2;
            // Act and Assert
            Assert.Throws<InvalidArmorException>(() => warrior.Equip(testPlateBody));
        }

        [Fact]
        public void Equip_CharacterTriesToEquipWrongWeaponType_ThrowsInvalidWeaponException()
        {
            //Arrange
            Warrior warrior = new("Warrior");
            // Act and Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.Equip(testBow));
        }

        [Fact]
        public void Equip_CharacterTriesToEquipWrongArmorType_ThrowsInvalidArmorException()
        {
            //Arrange
            Warrior warrior = new("Warrior");
            // Act and Assert
            Assert.Throws<InvalidArmorException>(() => warrior.Equip(testClothHead));
        }

        [Fact]
        public void Equip_CharacterTriesToEquipValidWeaponType_ReturnsSuccessMessage()
        {
            //Arrange
            Warrior warrior = new("Warrior");
            string expected = "New weapon equipped!";
            // Act
            string actual = warrior.Equip(testAxe);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Equip_CharacterTriesToEquipValidArmorType_ReturnsSuccessMessage()
        {
            //Arrange
            Warrior warrior = new("Warrior");
            string expected = "New armor equipped!";
            // Act
            string actual = warrior.Equip(testPlateBody);
            // Assert
            Assert.Equal(expected, actual);
        }

        #endregion

        #region PrimaryAttributes

        [Fact]
        public void OperatorAddition_AddTwoPrimaryAttributes_ShouldReturnSumOfAttributes()
        {
            // Arrange
            PrimaryAttributes lhs = new() { Vitality = 3, Strength = 1, Dexterity = 1, Intelligence = 5 };
            PrimaryAttributes rhs = new() { Vitality = 7, Strength = 9, Dexterity = 9, Intelligence = 5 };
            PrimaryAttributes expected = new() { Vitality = 10, Strength = 10, Dexterity = 10, Intelligence = 10 };
            // Act
            PrimaryAttributes actual = lhs + rhs;
            // Assert
            Assert.Equal(expected, actual);
        }

        #endregion

        #region CalculateDPS

        [Fact]
        public void CalculateDPS_CalculateDPSOfWarriorOfLevelOne_ReturnsDPS()
        {
            //Arrange
            Warrior warrior = new("Warrior");
            double expected = 1 * (1 + (5 / 100));
            // Act
            double actual = warrior.CalculateDPS();
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateDPS_CalculateDPSOfWarriorOfLevelOneAndEquippedWeapon_ReturnsDPS()
        {
            //Arrange
            Warrior warrior = new("Warrior");
            double expected = (7 * 1.1) * (1 + (5 / 100.0));
            // Act
            warrior.Equip(testAxe);
            double actual = warrior.CalculateDPS();
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateDPS_CalculateDPSOfhWarriorOfLevelOneAndEquippedWeaponAndArmor_ReturnsDPS()
        {
            //Arrange
            Warrior warrior = new("Warrior");
            double expected = (7 * 1.1) * (1 + ((5 + 1) / 100.0));
            // Act
            warrior.Equip(testAxe);
            warrior.Equip(testPlateBody);
            double actual = warrior.CalculateDPS();
            // Assert
            Assert.Equal(expected, actual);
        }

        #endregion
    }
}
