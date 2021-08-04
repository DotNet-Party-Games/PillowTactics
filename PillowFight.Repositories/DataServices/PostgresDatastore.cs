using PillowFight.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillowFight.Repositories.DataServices
{
    class PostgresDatastore : IDatastore
    {
        private PillowContext _context;

        public PostgresDatastore(PillowContext p_context)
        {
            _context = p_context;
        }

        public void CreatePlayer(Player p_player)
        {
            _context.Players.Add(p_player);
        }

        public Player GetPlayer(string p_username, string p_password)
        {
            return _context.Players.Where(p => p.Name == p_username).FirstOrDefault();
        }
    }
}
