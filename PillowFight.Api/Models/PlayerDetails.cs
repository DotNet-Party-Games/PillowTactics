using PillowFight.Repositories.Models;

namespace PillowFight.Api.Models
{
    public class PlayerDetails
    {
        public PlayerDetails()
        {

        }

        public PlayerDetails(Player player)
        {
            UserId = player.Id;
            UserName = player.UserName;
            Email = player.Email;
            Wins = player.Wins;
            Losses = player.Losses;
        }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }
    }
}
