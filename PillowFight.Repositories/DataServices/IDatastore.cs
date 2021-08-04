using PillowFight.Repositories.Models;

namespace PillowFight.Repositories.DataServices
{
    public interface IDatastore
    {
        public void CreatePlayer(Player p_player);
        public Player GetPlayer(string p_username, string p_password);
    }
}