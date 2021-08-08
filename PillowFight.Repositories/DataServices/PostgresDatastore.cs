using Microsoft.EntityFrameworkCore;
using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillowFight.Repositories.DataServices
{
    public class PostgresDatastore : IDatastore
    {
        private PillowContext _context;

        public PostgresDatastore(PillowContext p_context)
        {
            _context = p_context;
        }

        public async Task CreatePlayerAsync(Player p_player)
        {
            _context.Players.Add(p_player);
            await _context.SaveChangesAsync();
        }

        public async Task<PlayerCharacter> CreatePlayerCharacterAsync(int userId, string name, CharacterClassEnum characterClass, int? mainHandSlotItemId, int? torsoSlotItemId)
        {
            _context.PlayerCharacters.Add(new PlayerCharacter()
            {
                PlayerId = userId,
                Name = name,
                Class = characterClass,
                MainHandSlotItemId = mainHandSlotItemId,
                TorsoSlotItemId = torsoSlotItemId
            });
            await _context.SaveChangesAsync();
            return await _context.PlayerCharacters
                .Include(p_character => p_character.MainHandSlotItem)
                .Include(p_character => p_character.TorsoSlotItem)
                .FirstOrDefaultAsync(p_character => p_character.Name == name);
        }

        public async Task<bool> DeletePlayerCharacterAsync(int userId, int characterId)
        {
            try
            {
                _context.PlayerCharacters
                    .Remove(await _context.PlayerCharacters
                    .Where(p_character => p_character.PlayerId == userId && p_character.Id == characterId)
                    .FirstOrDefaultAsync());
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task EquipCharacterAsync(int userId, int characterId, int itemId)
        {
            var inventoryTask = GetPlayerInventoryAsync(userId);
            var characterTask = GetPlayerCharactersAsync(userId);
            var itemTask = GetItemAsync(itemId);
            await Task.WhenAll(inventoryTask, characterTask, itemTask);
        }

        public async Task<Item> GetItemAsync(int itemId)
        {
            return await _context.Items.FindAsync(itemId);
        }

        public async Task<Player> GetPlayerAsync(string p_username, string p_password)
        {
            return await _context.Players.Where(p => p.UserName == p_username).FirstOrDefaultAsync();
        }

        public async Task<PlayerCharacter> GetPlayerCharacterAsync(int userId, int characterId)
        {
            return await _context.PlayerCharacters
                .Where(p_playerCharacter => p_playerCharacter.PlayerId == userId && p_playerCharacter.Id == characterId)
                .Include(p_playerCharacter => p_playerCharacter.TorsoSlotItem)
                .Include(p_playerCharacter => p_playerCharacter.MainHandSlotItem)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PlayerCharacter>> GetPlayerCharactersAsync(int userId)
        {
            return await _context.PlayerCharacters
                .Where(p_playerCharacter => p_playerCharacter.PlayerId == userId)
                .Include(p_playerCharacter => p_playerCharacter.TorsoSlotItem)
                .Include(p_playerCharacter => p_playerCharacter.MainHandSlotItem)
                .ToListAsync();
        }

        public async Task<IEnumerable<InventoryItem>> GetPlayerInventoryAsync(int userId)
        {
            return await _context.Inventory
                .Where(l_inventoryItem => l_inventoryItem.PlayerId == userId)
                .ToListAsync();
        }
    }
}
