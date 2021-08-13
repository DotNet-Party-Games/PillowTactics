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
        private readonly PillowContext _context;

        public PostgresDatastore(PillowContext p_context)
        {
            _context = p_context;
        }

        public async Task CreatePlayerAsync(Player player)
        {
            _context.Players.Add(player);
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

        public async Task<bool> EquipCharacterAsync(int userId, int characterId, int itemId)
        {
            var inventoryTask = GetPlayerInventoryAsync(userId);
            var characterTask = GetPlayerCharacterAsync(userId, characterId);

            // Verify that the item exists.
            var item = await GetItemAsync(itemId);
            if (item == null)
                return false;

            // Verify that the item exists in the player's inventory.
            var inventoryItem = inventoryTask.Result
                .Where(l_inventoryItem => l_inventoryItem.ItemId == itemId)
                .FirstOrDefault();
            if (inventoryItem == null)
                return false;

            // Equipping an item decreases it's quantity and possibly removes it from inventory.
            inventoryItem.Quantity--;
            if (inventoryItem.Quantity == 0)
            {
                _context.Inventory.Remove(inventoryItem);
            }

            // Set proper equipment slot to the item's id.
            var character = await characterTask;
            switch (item.Type.GetSlotLocation())
            {
                case ItemSlotEnum.MainHand:
                    if (character.MainHandSlotItemId != null)
                        await UnequipCharacterAsync(userId, characterId, ItemSlotEnum.MainHand);
                    character.MainHandSlotItemId = item.Id;
                    break;
                case ItemSlotEnum.Torso:
                    if (character.TorsoSlotItemId != null)
                        await UnequipCharacterAsync(userId, characterId, ItemSlotEnum.Torso);
                    character.TorsoSlotItemId = item.Id;
                    break;
            }

            await _context.SaveChangesAsync();
            return true;
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

        public async Task<IEnumerable<Player>> GetTopPlayersAsync(int? n)
        {
            return await _context.Players
                .OrderByDescending(a_player => a_player.Wins)
                .ThenBy(a_player => a_player.UserName)
                .Take(n == null || n.Value < 1 ? int.MaxValue : n.Value)
                .ToListAsync();
        }

        public async Task<bool> UnequipCharacterAsync(int userId, int characterId, int itemId)
        {
            var characterTask = GetPlayerCharacterAsync(userId, characterId);
            var inventoryTask = GetPlayerInventoryAsync(userId);
            var item = await GetItemAsync(itemId);

            if (item == null)
                return false;

            // Set item's equipment slot to null.
            var character = await characterTask;
            switch (item.Type.GetSlotLocation())
            {
                case ItemSlotEnum.MainHand:
                    if (character.MainHandSlotItemId == item.Id)
                    {
                        character.MainHandSlotItemId = null;
                        break;
                    }
                    else
                        return false;
                case ItemSlotEnum.Torso:
                    if (character.TorsoSlotItemId == item.Id)
                    {
                        character.TorsoSlotItemId = null;
                        break;
                    }
                    else
                        return false;
            }

            // Return item to inventory.
            var inventoryItem = inventoryTask.Result
                .Where(l_inventoryItem => l_inventoryItem.ItemId == itemId)
                .FirstOrDefault();
            if (inventoryItem == null)
                _context.Inventory.Add(new()
                {
                    PlayerId = userId,
                    ItemId = itemId,
                    Quantity = 1
                });
            else
                inventoryItem.Quantity++;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UnequipCharacterAsync(int userId, int characterId, ItemSlotEnum slot)
        {
            var inventoryTask = GetPlayerInventoryAsync(userId);

            // Set item's equipment slot to null.
            int? itemId = null;
            var character = await GetPlayerCharacterAsync(userId, characterId);
            switch (slot)
            {
                case ItemSlotEnum.MainHand:
                    if (character.MainHandSlotItemId != null)
                    {
                        itemId = character.MainHandSlotItemId;
                        character.MainHandSlotItemId = null;
                    }
                    break;
                case ItemSlotEnum.Torso:
                    if (character.TorsoSlotItemId != null)
                    {
                        itemId = character.TorsoSlotItemId;
                        character.TorsoSlotItemId = null;
                    }
                    break;
            }

            // Return item to inventory.
            if (itemId != null)
            {
                var inventoryItem = inventoryTask.Result
                    .Where(l_inventoryItem => l_inventoryItem.ItemId == itemId)
                    .FirstOrDefault();
                if (inventoryItem == null)
                    _context.Inventory.Add(new()
                    {
                        PlayerId = userId,
                        ItemId = itemId.Value,
                        Quantity = 1
                    });
                else
                    inventoryItem.Quantity++;

                await _context.SaveChangesAsync();
            }
        }
    }
}
