using PillowFight.Repositories.DataServices;
using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PillowFight.BusinessServices
{
    public class PlayerBL : IPlayerBL
    {
        private readonly int? starterWeaponId = 1;
        private readonly int? starterArmorId = 3;
        private readonly IDatastore _datastore;

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

        public async Task<PlayerCharacter> CreatePlayerCharacterAsync(int userId, string name, CharacterClassEnum characterClass)
        {
            return await _datastore.CreatePlayerCharacterAsync(userId, name, characterClass, starterWeaponId, starterArmorId);
        }

        public async Task<bool> DeletePlayerCharacterAsync(int userId, int characterId)
        {
            return await _datastore.DeletePlayerCharacterAsync(userId, characterId);
        }

        public async Task<bool> EquipCharacterAsync(int userId, int characterId, int itemId)
        {
            return await _datastore.EquipCharacterAsync(userId, characterId, itemId);
        }

        public async Task<Player> GetPlayerAsync(string p_username, string p_password)
        {
            return await _datastore.GetPlayerAsync(p_username, p_password);
        }

        public async Task<PlayerCharacter> GetPlayerCharacterAsync(int userId, int characterId)
        {
            return await _datastore.GetPlayerCharacterAsync(userId, characterId);
        }

        public async Task<IEnumerable<PlayerCharacter>> GetPlayerCharactersAsync(int userId)
        {
            return await _datastore.GetPlayerCharactersAsync(userId);
        }

        public async Task<IEnumerable<InventoryItem>> GetPlayerInventoryAsync(int userId)
        {
            return await _datastore.GetPlayerInventoryAsync(userId);
        }

        public async Task<bool> UnequipCharacterAsync(int userId, int characterId, int itemId)
        {
            return await _datastore.UnequipCharacterAsync(userId, characterId, itemId);
        }

        public async Task UnequipCharacterAsync(int userId, int characterId, ItemSlotEnum slot)
        {
            await _datastore.UnequipCharacterAsync(userId, characterId, slot);
        }
    }
}
