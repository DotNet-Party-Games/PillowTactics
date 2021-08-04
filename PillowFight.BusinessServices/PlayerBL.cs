using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillowFight.Repositories.DataServices;
using PillowFight.Repositories.Enumerations;
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

        public void CreatePlayer(string p_username, string p_realname, string p_email)
        {
            _datastore.CreatePlayer(new Player
            {
                Name = p_username,
                RealName = p_realname,
                Email = p_email,
                Wins = 0,
                Losses = 0
            });
        }

        public Player GetPlayer(string p_username, string p_password)
        {
            return _datastore.GetPlayer(p_username, p_password);
        }
    }
}
