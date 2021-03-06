using RPGCharacters.Helpers;
using RPGCharacters.Heroes;
using RPGCharacters.Items;
using System;

namespace RPGCharacters.Game_Logic
{
    /// <summary>
    /// Game logic for the RPG game.
    /// </summary>
    public class Game
    {
        public Hero PlayerHero { get; set; }
        private const int MaxLengthOfName = 30;

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Play()
        {
            GameWriter.WelcomeMessage();

            int heroType = GameReader.GetHeroType();
            string name = GameReader.GetHeroName(MaxLengthOfName);
            PlayerHero = CreateHero(heroType, name);

            int action;
            do
            {
                action = GameReader.GetGameAction();
            } while (PlayGameAction(action));
        }

        /// <summary>
        /// Calls the actions the player specified.
        /// </summary>
        /// <param name="action">Action entered by player</param>
        /// <returns>True if game continues, false if game ended</returns>
        private bool PlayGameAction(int action)
        {
            switch (action)
            {
                case 1:
                    Hero opponent = CreateRandomOpponent(PlayerHero.Level);

                    // Characters get a luck bonus on their DPS between 0 and 20%
                    var rand = new Random();
                    double herosLuck = rand.NextDouble() * (1.2 - 1.0) + 1.0;
                    double opponentsLuck = rand.NextDouble() * (1.2 - 1.0) + 1.0;

                    Fight(PlayerHero, opponent, herosLuck, opponentsLuck);
                    break;
                case 2:
                    PlayerHero.DisplayStats();
                    break;
                default:
                case 3:
                    GameWriter.EndGameMessage(PlayerHero.Name);
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Creates the players hero.
        /// </summary>
        /// <param name="heroType">Type of hero</param>
        /// <param name="name">Hero name</param>
        /// <returns>The created hero</returns>
        private static Hero CreateHero(int heroType = 1, string name = "John Doe")
        {
            switch (heroType)
            {
                default:
                case 1:
                    return new Mage(name);
                case 2:
                    return new Ranger(name);
                case 3:
                    return new Rogue(name);
                case 4:
                    return new Warrior(name);
            }
        }

        /// <summary>
        /// Handles a fight between two Heroes. When the fight is lost, the game ends. When the fight is won, the player gets a random item and levels up.
        /// </summary>
        /// <param name="hero">The opponent</param>
        private static void Fight(Hero hero, Hero opponent, double herosLuck, double opponentsLuck)
        {
            GameWriter.OpponentDescriptionMessage(opponent.GetType().Name, opponent.DPS);

            GameWriter.PressKeyToContinue();

            if (hero.DPS * herosLuck < opponent.DPS * opponentsLuck)
            {
                GameWriter.GameLostMessage();
                GameWriter.EndGameMessage(hero.Name);
                Environment.Exit(0);
                return;
            }

            GameWriter.GameWonMessage();

            GameWriter.PressKeyToContinue();

            hero.LevelUp(1);
            GameWriter.LevelUpMessage(hero.Level);

            GameWriter.PressKeyToContinue();

            HandleFoundItem(hero);
        }

        /// <summary>
        /// Creates a new random item and asks the player what they want to do with it.
        /// </summary>
        /// <param name="hero">The players hero</param>
        private static void HandleFoundItem(Hero hero)
        {
            Item item = CreateRandomItem();
            string typeOfItem = item.GetType().Name;
            GameWriter.ItemFoundMessage(item.ItemDescription());

            switch (GameReader.GetFoundItemAction())
            {
                case 1:
                    try
                    {
                        string typeOfWeapon = new Weapon().GetType().Name;

                        if (typeOfItem.Equals(typeOfWeapon))
                        {
                            hero.Equip((Weapon)item);
                        }
                        else
                        {
                            hero.Equip((Armor)item);
                        }

                        GameWriter.ItemEquippedMessage(typeOfItem);
                        GameWriter.PressKeyToContinue();
                    }
                    catch (Exception e)
                    {
                        GameWriter.ItemEquippedErrorMessage(e.Message);
                        GameWriter.PressKeyToContinue();
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Creates a Hero of a random type with a random weapon.
        /// </summary>
        /// <param name="level">Level of the hero</param>
        /// <returns>Random Hero</returns>
        private static Hero CreateRandomOpponent(int level)
        {
            var rand = new Random();
            int type = rand.Next(1, 5);
            int damage = rand.Next(1, level);
            double attackSpeed = rand.NextDouble() * (level - 0.1) + 0.1;

            Weapon weapon = new()
            {
                ItemName = "Weapon",
                ItemLevel = level,
                ItemSlot = Slot.SLOT_WEAPON,
                WeaponAttributes = new WeaponAttributes() { Damage = damage, AttackSpeed = attackSpeed }
            };

            Hero opponent;
            string name = "Opponent";

            switch (type)
            {
                default:
                case 1:
                    opponent = new Mage(name);
                    weapon.WeaponType = WeaponType.WEAPON_WAND;
                    break;
                case 2:
                    opponent = new Ranger(name);
                    weapon.WeaponType = WeaponType.WEAPON_BOW;
                    break;
                case 3:
                    opponent = new Rogue(name);
                    weapon.WeaponType = WeaponType.WEAPON_DAGGER;
                    break;
                case 4:
                    opponent = new Warrior(name);
                    weapon.WeaponType = WeaponType.WEAPON_SWORD;
                    break;
            }

            if (level > 1)
            {
                opponent.LevelUp(level - 1);
            }

            try
            {
                opponent.Equip(weapon);
            }
            catch (Exception e)
            {
                GameWriter.ItemEquippedErrorMessage(e.Message);
            }

            opponent.CalculateTotalStats();

            return opponent;
        }

        /// <summary>
        /// Creates a random item of type Armor or Weapon with random attribute values.
        /// </summary>
        /// <returns>Random Item of type Armor or Weapon</returns>
        private static Item CreateRandomItem()
        {
            var rand = new Random();
            int type = rand.Next(0, 2);

            Item item;

            switch (type)
            {

                case 0:
                    int weaponType = rand.Next(7);
                    int damage = rand.Next(1, 11);
                    double attackSpeed = rand.NextDouble() * (2.0 - 0.1) + 0.1;

                    item = new Weapon()
                    {
                        ItemName = "Weapon",
                        ItemLevel = 1,
                        ItemSlot = Slot.SLOT_WEAPON,
                        WeaponType = (WeaponType)weaponType,
                        WeaponAttributes = new WeaponAttributes() { Damage = damage, AttackSpeed = attackSpeed }
                    };
                    break;
                default:
                    int slot = rand.Next(3);
                    int armorType = rand.Next(4);
                    int vitality = rand.Next(3);
                    int strength = rand.Next(3);
                    int dexterity = rand.Next(3);
                    int intelligence = rand.Next(3);

                    item = new Armor()
                    {
                        ItemName = "Armor",
                        ItemLevel = 1,
                        ItemSlot = (Slot)slot,
                        ArmorType = (ArmorType)armorType,
                        Attributes = new PrimaryAttributes() { Vitality = vitality, Strength = strength, Dexterity = dexterity, Intelligence = intelligence }
                    };
                    break;
            }

            return item;
        }
    }
}
