using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Interfaces;

namespace PillowFight.Repositories.Models
{
    public class Player : IPlayer
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string RealName { get; set; }

        public string Email { get; set; }

        public int Losses { get; set; }

        public int Wins { get; set; }

        public UserRoleEnum Role { get; set; }
    }
}
