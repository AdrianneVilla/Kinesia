using KinesiaAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace KinesiaAPI.Tests.DataTest
{
    public static class TestDbContextFactory
    {
        public static ApplicationDbContext CreateDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
