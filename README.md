# Strong-Pi.html-P2
# **Pillow Tactics Project Proposal**

**Team Strong-Pi.html**

**Overview**

The Pillow Tactics will be a Web application that allows users to create, customize and fight with their characters. Players will be able to make characters from classes and customize them with attribute points. They can also add gear based on their attributes and change gear in between fights. Players will fight one another with teams of three. Each character will perform limited actions only during their turn. Players will be able to see their standing on the leaderboard and points will be awarded after the fight. Before fights a random event will happen to modify the fight to make each fight interesting and unique. The map will be a 2D grid style arena like final fantasy tactics-style gameplay.

**Tables**

- Equipment Table - Holds information of all equipment in the game
  - Int EquipmentID,
  - String Name
  - String Description,
  - Int Damage Value,
  - Int Armor Value,
  - Int Range
  - Enum equipment\_type
- EquipmentStatRequirements
  - Int Id
  - Enum stat //An enumerated type denoting one of Strength, Wisdom, etc
  - Int Min\_stat
  - Int Fk\_equipment
- Player Table - Contains login information for all users
  - Int UserId
  - String Username
  - String Email
  - String Password
  - Int Points
- Leaderboard Table - Contains relevant leaderboard records
  - Int Position
  - Int PlayerId
- Spells:
  - Int id
  - Int dmg
  - String desc
  - Int range
  - Int manacost
  - class
- Inventory Table - Holds inventory data for each character
  - Int Id,
  - Int Head,
  - Int Chest,
  - Int Arms,
  - Int Legs,
  - Int Weapon
- Attributes Table - Holds character attribute information
  - Int Id,
  - Int HP,
  - Int Sp,
  - int Strength,
  - int Dexterity,
  - int Constitution,
  - int Intellect,
  - int Wisdom,
- Character
  - Int ID
  - Fk\_attributes
  - Fk\_player
  - Fk\_inventory
  - Enum CharacterClass

**Completed Functionality**

- As a player, I will be able to save their character data through logins
- As a player I will have different names for characters to differentiate from one another (user input)
- As a player I will have an account where I can edit my information
- As a player I can see Leaderboards to compare Player ranks
- As a player I will be able to make characters from each of the three classes Wizard, Rogue, Knight
- As a player, I will be able to equip/unequip gear before and after fights
- As a Wizard, I will have low health but able to fight at range, low melee damage
- As a Rogue, I will have middle health and able to fight at close and long range
- As a Knight, I will have high health and fights melee

**Stretch Goals**

- Possible looting aspect to assist players during matches
- Possibility to include zone control to apply bonuses to players
- Tournament Mode for unique gear
- Multiple players can join in and control certain characters in a team
- Possibility for more than 3 characters per team
- Chatroom and live viewing platform
- As a player I will have multiple characters (3 characters) on screen at once and perform actions for each character during their turn.
- Status effect linked to map
- As a player I will have a timer on actions will limit the amount of time I have to make a move

**Tech Stack**

- Angular
- C#
- PostgreSQL Database
- DevOps
- Sonar Cloud
- Moq/XUnit
- Serilog
