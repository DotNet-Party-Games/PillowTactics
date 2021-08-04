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
        public void CreatePlayer(string p_username, string p_realname, string p_email);

        public Player GetPlayer(string p_username, string p_password);
    }
}
