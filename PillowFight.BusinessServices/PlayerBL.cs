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

        public void CreatePlayer (string p_username, string p_realname, UserRoleEnum p_role, string p_email, int p_wins, int p_losses)
        {
            _datastore.CreatePlayer(new Player
            {
                Name = p_username,
                RealName = p_realname,
                Role = p_role,
                Email = p_email,
                Wins = p_wins,
                Losses = p_losses
            });
        }

        public Player GetPlayer(string p_username, string p_password)
        {
            return _datastore.GetPlayer(p_username, p_password);
        }
    }
}
