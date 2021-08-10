//Adapted from https://www.c-sharpcorner.com/article/unit-testing-with-inmemory-provider-and-sqlite-in-memory-database-in-efcore/

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using PillowFight.Repositories;

namespace PillowFight.Test
{
    public class ConnectionFactory : IDisposable
    {

        #region IDisposable Support  
        private bool disposedValue = false; // To detect redundant calls  

        public PillowContext CreateContextForSQLite()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var option = new DbContextOptionsBuilder<PillowContext>().UseSqlite(connection).Options;

            var context = new PillowContext(option);

            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
