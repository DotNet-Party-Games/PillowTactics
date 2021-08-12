using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
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

        private bool _VerifyTableEmpty(SqliteConnection p_connection, string p_tableName)
        {
            SqliteCommand command = new SqliteCommand($"SELECT * FROM \"{p_tableName}\";", p_connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                return(!reader.HasRows);
            }
        }

        [Theory]
        [InlineData("foo@bar.baz", "Joe_Blow", "xyz")]
        public void CreateOnePlayer(string p_email, string p_userName, string p_password)
        {
            PillowContext context = _factory.CreateContextForSQLite();
            SqliteConnection connection = (SqliteConnection)context.Database.GetDbConnection();
            Assert.True(_VerifyTableEmpty(connection, "Players"));
            PostgresDatastore datastore = new(context);
            PlayerBL bl = new(datastore);
            bl.CreatePlayerAsync(p_userName, p_password, p_email).Wait();
            SqliteCommand command = new SqliteCommand("SELECT \"Email\", \"Username\", \"Password\" FROM \"Players\" ", connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                Assert.True(reader.HasRows);
                Assert.True(reader.Read());
                Assert.Equal(p_email, reader[0]);
                Assert.Equal(p_userName, reader[1]);
                Assert.Equal(p_password, reader[2]);
                Assert.False(reader.Read());
            }
        }

        [Theory]
        [InlineData("Lothar", CharacterClassEnum.Fighter)]
        public void CreateAndDestroyCharacter(string p_name, CharacterClassEnum p_class)
        {
            PillowContext context = _factory.CreateContextForSQLite();
            SqliteConnection connection = (SqliteConnection)context.Database.GetDbConnection();
            Assert.True(_VerifyTableEmpty(connection, "Players"));
            PostgresDatastore datastore = new(context);
            PlayerBL bl = new(datastore);
            bl.CreatePlayerCharacterAsync(1, p_name, p_class).Wait();
            SqliteCommand command = new SqliteCommand("SELECT \"Name\", \"Class\", \"Id\" FROM \"Characters\" ", connection);
            int id;
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                Assert.True(reader.HasRows);
                Assert.True(reader.Read());
                Assert.Equal(p_name, reader[0]);
                Assert.Equal((int)p_class, reader.GetInt32(1));
                Assert.False(reader.Read());
                id = reader.GetInt32(2);
                Assert.True(id > 0);
            }
            bl.DeletePlayerCharacterAsync(1, id).Wait();
            Assert.True(_VerifyTableEmpty(connection, "Players"));
        }
    }
}
