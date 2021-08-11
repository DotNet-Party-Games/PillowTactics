using PillowFight.BusinessServices;
using PillowFight.Repositories;
using PillowFight.Repositories.DataServices;
using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Models;
using System;
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
        [InlineData("foo@bar.baz", "Joe_Blow", "xyz")]
        public void CreateOnePlayer(string p_email, string p_userName, string p_password)
        {
            PillowContext context = _factory.CreateContextForSQLite();
            PostgresDatastore datastore = new(context);
            PlayerBL bl = new(datastore);
            bl.CreatePlayerAsync(p_userName, p_password, p_email).Wait();
            Player newPlayer = context.Players.FirstOrDefault();
            Assert.Equal(1, context.Players.Count()); // There is one row in the table
            Assert.Equal(p_email, newPlayer.Email); //The fields match
            Assert.Equal(p_userName, newPlayer.UserName);
            Assert.Equal(p_password, newPlayer.Password);
        }

    }
}
