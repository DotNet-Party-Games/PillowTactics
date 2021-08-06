using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Interfaces;
using PillowFight.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PillowFight.Repositories.DataServices
{
    public interface IDatastore
    {
        public Task CreatePlayerAsync(Player p_player);

        public Task<IPlayerCharacter> CreatePlayerCharacterAsync(int userId, string name, CharacterClassEnum characterClass);

        public Task<bool> DeletePlayerCharacterAsync(int userId, int characterId);

        public Task<IPlayer> GetPlayerAsync(string p_username, string p_password);

        public Task<IEnumerable<ICharacter>> GetPlayerCharactersAsync(int userId);
    }
}