﻿namespace PillowFight.Repositories.Interfaces
{
    public interface IPlayerCharacter : ICharacter
    {
        int PlayerId { get; set; }

        public IPlayer Player { get; set; }
    }
}
