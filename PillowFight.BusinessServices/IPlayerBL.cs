using PillowFight.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillowFight.BusinessServices
{
    public interface IPlayerBL
    {
        public void CreatePlayer(Player p_player);

        public Player GetPlayer(string p_username, string p_password);
    }
}
