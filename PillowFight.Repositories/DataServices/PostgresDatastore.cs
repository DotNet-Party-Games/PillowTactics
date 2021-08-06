using Microsoft.EntityFrameworkCore;
using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Interfaces;
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

        public async Task<IPlayerCharacter> CreatePlayerCharacterAsync(int userId, string name, CharacterClassEnum characterClass)
        {
            _context.PlayerCharacters.Add(new PlayerCharacter()
            {
                PlayerId = userId,
                Name = name,
                Class = characterClass,
                MainHandSlotItemId = 2,
                TorsoSlotItemId = 4
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

        public async Task<IPlayer> GetPlayerAsync(string p_username, string p_password)
        {
            return await _context.Players.Where(p => p.UserName == p_username).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ICharacter>> GetPlayerCharactersAsync(int userId)
        {
            return await _context.PlayerCharacters
                .Where(p_pc => p_pc.PlayerId == userId)
                .Include(p_pc => p_pc.TorsoSlotItem)
                .Include(p_pc => p_pc.MainHandSlotItem)
                .ToListAsync();
        }
    }
}
