using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillowFight.Repositories.DataServices;
using PillowFight.Repositories.Models;

namespace PillowFight.BusinessServices
{
    public class PlayerBL : IPlayerBL
    {
        private IDatastore _datastore;

        public PlayerBL (IDatastore p_datastore)
        {
            _datastore = p_datastore;
        }

        public void CreatePlayer (Player p_player)
        {
            _datastore.CreatePlayer(p_player);
        }

        public Player GetPlayer(string p_username, string p_password)
        {
            return _datastore.GetPlayer(p_username, p_password);
        }
    }
}
