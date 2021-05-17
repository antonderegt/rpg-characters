using RPGCharacters.Helpers;
using RPGCharacters.Heroes;
using RPGCharacters.Items;
using System;

namespace RPGCharacters
{
    class Program
    {
        /// <summary>
        /// Handles the game loop to make the game playable.
        /// </summary>
        /// <param name="args">Not used</param>
        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to the RPG Games");

            int heroType = GetHeroType();

            string name = GetHeroName();

            Hero hero = CreateHero(heroType, name);

            int action;
            do
            {
                action = GetGameAction();
            } while (PlayGameAction(action, hero));
        }

        private static bool PlayGameAction(int action, Hero hero)
        {
            switch (action)
            {
                case 1:
                    Fight(hero);
                    break;
                case 2:
                    hero.DisplayStats();
                    break;
                default:
                case 3:
                    Console.WriteLine($"\nThanks for playing {hero.Name}!");
                    return false;
            }

            return true;
        }

        private static Hero CreateHero(int heroType, string name)
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

        private static int GetGameAction()
        {
            DisplayGameOptions();

            var actionInput = Console.ReadLine();
            int action;
            while (!int.TryParse(actionInput, out action) || action < 1 || action > 4)
            {
                Console.Clear();

                Console.WriteLine("\nPlease enter a number between 1 and 3");

                DisplayGameOptions();

                actionInput = Console.ReadLine();
            }

            Console.Clear();
            return action;
        }

        private static void DisplayGameOptions()
        {
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Show my stats");
            Console.WriteLine("3. Leave the game\n");
        }

        private static string GetHeroName()
        {
            Console.WriteLine("\nEnter your hero name: ");
            string name = Console.ReadLine();

            Console.Clear();
            return name;
        }

        private static int GetHeroType()
        {
            DisplayHeroOptions();

            var typeInput = Console.ReadLine();
            int heroType;
            while (!int.TryParse(typeInput, out heroType) || heroType < 1 || heroType > 4)
            {
                Console.Clear();

                Console.WriteLine("\nPlease enter a number between 1 and 4");

                DisplayHeroOptions();

                typeInput = Console.ReadLine();
            }

            Console.Clear();
            return heroType;
        }

        private static void DisplayHeroOptions()
        {
            Console.WriteLine("\nChoose the type of your character");
            Console.WriteLine("1. Mage");
            Console.WriteLine("2. Ranger");
            Console.WriteLine("3. Rogue");
            Console.WriteLine("4. Warrior\n");
        }

        /// <summary>
        /// Handles a fight between two Heroes. When the fight is lost, the game ends. When the fight is won, the player gets a random item and levels up.
        /// </summary>
        /// <param name="hero">The opponent</param>
        public static void Fight(Hero hero)
        {
            Hero opponent = CreateRandomOpponent(hero.Level);

            Console.WriteLine($"\nYour opponent is a {opponent.GetType().Name}, with a DPS of {opponent.DPS:0.##}");

            PressKeyToContinue();

            // Characters luck is between 0 and 20%
            var rand = new Random();
            double herosLuck = rand.NextDouble() * (1.2 - 1.0) + 1.0;
            double opponentsLuck = rand.NextDouble() * (1.2 - 1.0) + 1.0;

            if (hero.DPS * herosLuck < opponent.DPS * opponentsLuck)
            {
                Console.WriteLine("\nYou lost, the game is over...");
                Console.WriteLine($"\nThanks for playing {hero.Name}!");
                Environment.Exit(0);
                return;
            }

            Console.WriteLine("\nYou won!");

            PressKeyToContinue();

            hero.LevelUp(1);
            Console.WriteLine($"\nYou leveled up! Your current level is {hero.Level}.");

            PressKeyToContinue();

            Item item = CreateRandomItem();
            string typeOfItem = item.GetType().Name;
            Console.WriteLine($"\nYou found: {item.ItemDescription()}");

            switch (GetFoundItemAction())
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

                        Console.WriteLine($"\n{typeOfItem} equipped!");
                        PressKeyToContinue();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"\nYou can't equip this item: {e.Message}");
                        PressKeyToContinue();
                    }
                    break;
                default:
                    break;
            }

            
        }

        private static int GetFoundItemAction()
        {
            DisplayItemOptions();
            var actionInput = Console.ReadLine();
            int action;
            while (!int.TryParse(actionInput, out action) || action < 1 || action > 4)
            {
                Console.Clear();
                Console.WriteLine("\nPlease enter a number between 1 and 2");

                DisplayItemOptions();

                actionInput = Console.ReadLine();
            }

            Console.Clear();
            return action;
        }

        private static void DisplayItemOptions()
        {
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Try to equip");
            Console.WriteLine("2. Leave behind\n");
        }

        private static void PressKeyToContinue()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Creates a Hero of a random type with a random weapon.
        /// </summary>
        /// <param name="level">Level of the hero</param>
        /// <returns>Random Hero</returns>
        public static Hero CreateRandomOpponent(int level)
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
                Console.WriteLine($"Opponent failed to equip it's weapon. {e.Message}");
            }

            opponent.CalculateTotalStats();

            return opponent;
        }

        /// <summary>
        /// Creates a random item of type Armor or Weapon with random attribute values.
        /// </summary>
        /// <returns>Random Item of type Armor or Weapon</returns>
        public static Item CreateRandomItem()
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
