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

            Console.WriteLine("\nChoose the type of your character");
            Console.WriteLine("1. Mage");
            Console.WriteLine("2. Ranger");
            Console.WriteLine("3. Rogue");
            Console.WriteLine("4. Warrior");
            int type = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("\nEnter a name for your character");
            string name = Console.ReadLine();
            Console.Clear();

            Hero hero;

            switch (type)
            {
                default:
                case 1:
                    hero = new Mage(name);
                    break;
                case 2:
                    hero = new Ranger(name);
                    break;
                case 3:
                    hero = new Rogue(name);
                    break;
                case 4:
                    hero = new Warrior(name);
                    break;
            }

            bool playing = true;
            while (playing)
            {
                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Show my stats");
                Console.WriteLine("3. Leave the game");

                int action = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
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
                        playing = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Handles a fight between two Heroes. When the fight is lost, the game ends. When the fight is won, the player gets a random item and levels up.
        /// </summary>
        /// <param name="hero">The opponent</param>
        public static void Fight(Hero hero)
        {
            Hero opponent = CreateRandomOpponent(hero.Level);

            Console.WriteLine($"\nYour opponent is a {opponent.GetType().Name}, with a DPS of {opponent.DPS:0.##}");

            if (hero.DPS < opponent.DPS)
            {
                Console.WriteLine("\nYou lost, the game is over...");
                Environment.Exit(0);
                return;
            }

            Console.WriteLine("\nYou won!");

            Item item = CreateRandomItem();
            string typeOfItem = item.GetType().Name;
            Console.WriteLine($"\nYou found: {item.ItemDescription()}");

            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Try to equip");
            Console.WriteLine("2. Leave behind");
            int action = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (action)
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
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"\nYou can't equip this item: {e.Message}");
                    }
                    break;
                default:
                    break;
            }

            hero.LevelUp(1);
            Console.WriteLine("\nYou leveled up!");
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
            string name = "Opponent";
            int damage = rand.Next(1, level);
            double attackSpeed = rand.NextDouble() * (level - 0.1) + 0.1;

            Hero opponent;
            Weapon weapon = new Weapon()
            {
                ItemName = "Weapon",
                ItemLevel = level,
                ItemSlot = Slot.SLOT_WEAPON,
                WeaponAttributes = new WeaponAttributes() { Damage = damage, AttackSpeed = attackSpeed }
            };

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
