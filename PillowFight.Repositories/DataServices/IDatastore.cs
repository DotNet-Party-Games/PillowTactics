using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PillowFight.Repositories.DataServices
{
    public interface IDatastore
    {
        public Task CreatePlayerAsync(Player p_player);

        public Task<PlayerCharacter> CreatePlayerCharacterAsync(int userId, string name, CharacterClassEnum characterClass, int? mainHandSlotItemId, int? torsoSlotItemId);

        public Task<bool> DeletePlayerCharacterAsync(int userId, int characterId);

        public Task<Player> GetPlayerAsync(string p_username, string p_password);

        public Task<PlayerCharacter> GetPlayerCharacterAsync(int userId, int characterId);

        public Task<IEnumerable<PlayerCharacter>> GetPlayerCharactersAsync(int userId);
    }
}