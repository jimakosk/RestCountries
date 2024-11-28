using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Countries_Server.Data
{
    public class AppDbContextFactory
    {
        public AppDbContextFactory()
        {
        }

        public AppDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            return new AppDbContext(optionsBuilder.UseSqlServer(connectionString).Options);

        }
    }
}
