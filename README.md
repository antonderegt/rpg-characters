# RPG Characters Generator
A console game written in C#. 

## How to Play
When you start the game you are greeted and asked what type of hero you want to play with. You can choose between a mage, ranger, rogue and warrior.
The next step is to give your hero a name. Now it's time to start playing! You'll be asked if you want fight, see you stats or leave the game.
If you choose to fight, a random opponent will be generated and you will fight that opponent. If you win, you'll be awarded a new weapon of a new piece of armor. If you loose, the game ends.

## Components
Custom exceptions.
Helper classes to group atributes.
A Hero class that gets extended by four types of hero's.
Various items a hero can equip.
Full test coverage.
Summary tags for all classes and methods.

## Heroes
In the game there are currently four types of characters:
- Mage
- Ranger
- Rogue
- Warrior

Characters in the game have several types of attributes, which represent different aspects of the character. They are divided into two groups:
- Primary attributes
- Secondary attributes

Primary attributes are what determine the characters power, as the character levels up their primary attributes
increase. Items they equip also can increase these primary attributes (this is detailed in Appendix B). Secondary
attributes affect the characters’ ability to survive, they are calculated from primary attributes. Certain character classes
are more durable against certain types of damage.

### Primary Attributes
- Strength
- Dexterity
- Intelligence
- Vitality

### Secondary Attributes
- Health
- Armor Rating
- Elemental Resistence

## Damage
A character can deal damage based on it's type, primary attributes and equipped weapon and armor.

## Leveling
### Mage
A mage starts with these stats:
Vitality: 5, Strength: 1, Dexterity: 1, Intelligence: 8

Every time a mage levels up, they gain:
Vitality: 3, Strength: 1, Dexterity: 1, Intelligence: 5

### Ranger
A ranger starts with these stats:
Vitality: 8, Strength: 1, Dexterity: 7, Intelligence: 1

Every time a ranger levels up, they gain:
Vitality: 2, Strength: 1, Dexterity: 5, Intelligence: 1

### Rogue
A rogue starts with these stats:
Vitality: 8, Strength: 2, Dexterity: 6, Intelligence: 1

Every time a rogue levels up, they gain:
Vitality: 3, Strength: 1, Dexterity: 4, Intelligence: 1

### Warrior
A warrior starts with these stats:
Vitality: 10, Strength: 5, Dexterity: 2, Intelligence: 1

Every time a warrior levels up, they gain:
Vitality: 5, Strength: 3, Dexterity: 2, Intelligence: 1

## Items
Characters can equip weapons, based on their type and armor, also based on their type.
These items give bonus to the characters attributes.