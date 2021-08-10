using PillowFight.Repositories;
using PillowFight.Repositories.DataServices;
using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Models;
using System.Linq;
using Xunit;

namespace PillowFight.Test
{
    public class UnitTests
    {
        private ConnectionFactory _factory;


        public UnitTests()
        {
            _factory = new ConnectionFactory();
        }

        [Theory]
        [InlineData("foo@bar.baz", "Joeseph Blowtarski", "Joe_Blow", "xyz", UserRoleEnum.User, 3, 4)]
        public void CreateOnePlayer(string p_email, string p_realName, string p_userName, string p_password, UserRoleEnum p_role,
            int p_wins, int p_losses)
        {
            PillowContext context = _factory.CreateContextForSQLite();
            PostgresDatastore datastore = new(context);
            Player player = new Player
            {
                Email = p_email,
                RealName = p_realName,
                UserName = p_userName,
            };
            datastore.CreatePlayerAsync(player).Wait();
            Player newPlayer = context.Players.FirstOrDefault();
            Assert.Equal(1, context.Players.Count()); // There is one row in the table
            Assert.Equal(player.Email, newPlayer.Email); //The fields match
            Assert.Equal(player.RealName, newPlayer.RealName);
            Assert.Equal(player.UserName, newPlayer.UserName);
            Assert.Equal(player.Password, newPlayer.Password);
            Assert.Equal(player.Role, newPlayer.Role);
            Assert.Equal(player.Wins, newPlayer.Wins);
            Assert.Equal(player.Losses, newPlayer.Losses);
        }
    }
}
