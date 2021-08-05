using PillowFight.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PillowFight.BusinessServices
{
    public interface IPlayerBL
    {
        public Task CreatePlayerAsync(string p_username, string p_password, string p_email);

        public Task<IPlayer> GetPlayerAsync(string p_username, string p_password);

        public Task<IEnumerable<ICharacter>> GetPlayerCharactersAsync(int userId);
    }
}
