using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Models;
using System.Collections.Generic;

namespace PillowTactics.Game.Models
{
    public class InGamePlayerCharacter
    {
        public InGamePlayerCharacter(PlayerCharacter playerCharacter)
        {
            Id = playerCharacter.Id;
            Name = playerCharacter.Name;
            CharacterClass = playerCharacter.Class.ToString();
            MaxHp = Constitution * 20;
            CurrentHp = MaxHp;
            Strength = playerCharacter.Strength;
            Dexterity = playerCharacter.Dexterity;
            Constitution = playerCharacter.Constitution;
            Intelligence = playerCharacter.Intelligence;
            Wisdom = playerCharacter.Wisdom;
            MainHandSlotItem = playerCharacter.MainHandSlotItem;
            TorsoSlotItem = playerCharacter.TorsoSlotItem;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string CharacterClass { get; set; }

        public int MaxHp { get; set; }

        public int CurrentHp { get; set; }

        public int MaxSp { get; set; }

        public int CurrentSp { get; set; }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Constitution { get; set; }

        public int Intelligence { get; set; }

        public int Wisdom { get; set; }

        public ArmorItem TorsoSlotItem { get; set; }

        public WeaponItem MainHandSlotItem { get; set; }

        public MapPosition Position { get; set; }

        /// <summary>
        /// The action's owned by the character.
        /// </summary>
        public List<ActionTypeEnum> Actions { get; } = new() { ActionTypeEnum.Move, ActionTypeEnum.Attack, ActionTypeEnum.EndTurn };

        /// <summary>
        /// The action's currently availalble to the character.
        /// </summary>
        public List<ActionTypeEnum> AvailableActions { get; set; }
    }
}
