using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PillowFight.BusinessServices
{
    public interface IPlayerBL
    {
        public Task CreatePlayerAsync(string p_username, string p_password, string p_email);

        Task<PlayerCharacter> CreatePlayerCharacterAsync(int userId, string name, CharacterClassEnum characterClass);

        public Task<bool> DeletePlayerCharacterAsync(int userId, int characterId);

        public Task<Player> GetPlayerAsync(string p_username, string p_password);

        public Task<PlayerCharacter> GetPlayerCharacterAsync(int userId, int characterId);

        public Task<IEnumerable<PlayerCharacter>> GetPlayerCharactersAsync(int userId);
    }
}
