using PillowFight.Repositories.DataServices;
using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Interfaces;
using PillowFight.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PillowFight.BusinessServices
{
    public class PlayerBL : IPlayerBL
    {
        private IDatastore _datastore;

        public PlayerBL(IDatastore p_datastore)
        {
            _datastore = p_datastore;
        }

        public async Task CreatePlayerAsync(string p_username, string p_password, string p_email)
        {
            await _datastore.CreatePlayerAsync(new Player
            {
                UserName = p_username,
                Password = p_password,
                Email = p_email,
            });
        }

        public async Task<IPlayerCharacter> CreatePlayerCharacterAsync(int userId, string name, CharacterClassEnum characterClass)
        {
            return await _datastore.CreatePlayerCharacterAsync(userId, name, characterClass);
        }

        public async Task<bool> DeletePlayerCharacterAsync(int userId, int characterId)
        {
            return await _datastore.DeletePlayerCharacterAsync(userId, characterId);
        }

        public async Task<IPlayer> GetPlayerAsync(string p_username, string p_password)
        {
            return await _datastore.GetPlayerAsync(p_username, p_password);
        }

        public async Task<IPlayerCharacter> GetPlayerCharacterAsync(int userId, int characterId)
        {
            return await _datastore.GetPlayerCharacterAsync(userId, characterId);
        }

        public async Task<IEnumerable<IPlayerCharacter>> GetPlayerCharactersAsync(int userId)
        {
            return await _datastore.GetPlayerCharactersAsync(userId);
        }
    }
}
