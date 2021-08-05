using Microsoft.EntityFrameworkCore;
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

        public async Task<IPlayer> GetPlayerAsync(string p_username, string p_password)
        {
            return await _context.Players.Where(p => p.UserName == p_username).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ICharacter>> GetPlayerCharactersAsync(int userId)
        {
            return await _context.PlayerCharacters
                .Include(p_pc => p_pc.TorsoSlotItem)
                .Include(p_pc => p_pc.MainHandSlotItem)
                .Where(p_pc => p_pc.PlayerId == userId)
                .ToListAsync();
        }
    }
}
