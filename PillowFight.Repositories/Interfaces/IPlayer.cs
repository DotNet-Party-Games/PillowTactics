using PillowFight.Repositories.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillowFight.Repositories.Interfaces
{
    public interface IPlayer
    {
        public int Losses { get; set; }

        public int Wins { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public string RealName { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}
