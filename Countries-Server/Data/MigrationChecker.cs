using Microsoft.EntityFrameworkCore;

namespace Countries_Server.Data
{
    public class MigrationChecker
    {
     
            public static void EnsureDatabaseUpdated(IServiceProvider serviceProvider)
            {
                try
                {
                    using (var scope = serviceProvider.CreateScope())
                    {
                        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                        var pendingMigrations = context.Database.GetPendingMigrations();
                        if (pendingMigrations.Any())
                        {
                            Console.WriteLine("Applying pending migrations...");
                            context.Database.Migrate();
                        }
                        else
                        {
                            Console.WriteLine("Database is up-to-date.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (use a logging framework or system here)
                    Console.WriteLine($"An error occurred while applying migrations: {ex.Message}");
                }
            }
        }
    
}
