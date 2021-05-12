using System;
using Xunit;
using RPGCharacters;

namespace RPGCharactersTests
{
    public class RPGCharacterCreationTests
    {
        [Fact]
        public void Init_InitOfCharacter_SetsCorrectLevel()
        {
            // Arrange
            Mage mage = new("Mage");
            int expected = 1;
            // Act
            int actual = mage.Level;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_CharacterLevelsUp_SetsLevel()
        {
            // Arrange
            Warrior warrior = new("Warrior");
            int expected = 2;
            // Act
            warrior.LevelUp(1);
            int actual = warrior.Level;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void LevelUp_GainWrongNumberOfLevels_ThrowsArgumentException(int levels)
        {
            // Arrange
            Rogue rogue = new("Rogue");
            // Act and Assert
            Assert.Throws<ArgumentException>(() => rogue.LevelUp(levels));
        }

        [Fact]
        public void Init_InitOfMage_SetsCorrectPrimaryAttributes()
        {
            // Arrange
            Mage mage = new("Mage");
            PrimaryAttributes expected = new() { Vitality = 5, Strength = 1, Dexterity = 1, Intelligence = 8 };
            // Act
            PrimaryAttributes actual = mage.BasePrimaryAttributes;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Init_InitOfRanger_SetsCorrectPrimaryAttributes()
        {
            // Arrange
            Ranger ranger = new("Ranger");
            PrimaryAttributes expected = new() { Vitality = 8, Strength = 1, Dexterity = 7, Intelligence = 1 };
            // Act
            PrimaryAttributes actual = ranger.BasePrimaryAttributes;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Init_InitOfRogue_SetsCorrectPrimaryAttributes()
        {
            // Arrange
            Rogue rogue = new("Rogue");
            PrimaryAttributes expected = new() { Vitality = 8, Strength = 2, Dexterity = 6, Intelligence = 1 };
            // Act
            PrimaryAttributes actual = rogue.BasePrimaryAttributes;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Init_InitOfWarrior_SetsCorrectPrimaryAttributes()
        {
            // Arrange
            Warrior warrior = new("Warrior");
            PrimaryAttributes expected = new() { Vitality = 10, Strength = 5, Dexterity = 2, Intelligence = 1 };
            // Act
            PrimaryAttributes actual = warrior.BasePrimaryAttributes;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevelUpOfMage_SetsCorrectPrimaryAttributes()
        {
            // Arrange
            Mage mage = new("Mage");
            PrimaryAttributes expected = new() { Vitality = 8, Strength = 2, Dexterity = 2, Intelligence = 13 };
            // Act
            mage.LevelUp(1);
            PrimaryAttributes actual = mage.BasePrimaryAttributes;
            //Assert
            Assert.Equal(expected, actual);
        }

        

        [Fact]
        public void LevelUp_LevelUpOfRanger_SetsCorrectPrimaryAttributes()
        {
            // Arrange
            Ranger ranger = new("Ranger");
            PrimaryAttributes expected = new() { Vitality = 10, Strength = 2, Dexterity = 12, Intelligence = 2 };
            // Act
            ranger.LevelUp(1);
            PrimaryAttributes actual = ranger.BasePrimaryAttributes;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevelUpOfRogue_SetsCorrectPrimaryAttributes()
        {
            // Arrange
            Rogue rogue = new("Rogue");
            PrimaryAttributes expected = new() { Vitality = 11, Strength = 3, Dexterity = 10, Intelligence = 2 };
            // Act
            rogue.LevelUp(1);
            PrimaryAttributes actual = rogue.BasePrimaryAttributes;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevelUpOfWarrior_SetsCorrectPrimaryAttributes()
        {
            // Arrange
            Warrior warrior = new("Warrior");
            PrimaryAttributes expected = new() { Vitality = 15, Strength = 8, Dexterity = 4, Intelligence = 2 };
            // Act
            warrior.LevelUp(1);
            PrimaryAttributes actual = warrior.BasePrimaryAttributes;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_LevelUpOfWarrior_SetsCorrectSecondaryAttributes()
        {
            // Arrange
            Warrior warrior = new("Warrior");
            SecondaryAttributes expected = new() { Health = 150, ArmorRating = 12, ElementalResistence = 2 };
            // Act
            warrior.LevelUp(1);
            SecondaryAttributes actual = warrior.BaseSecondaryAttributes;
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
