using PillowFight.Repositories.Enumerations;

namespace PillowFight.Repositories.Interfaces
{
    public interface IPlayer
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
