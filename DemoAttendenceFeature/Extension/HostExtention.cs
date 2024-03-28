using DemoAttendenceFeature.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoAttendenceFeature.Extension
{
    public static class HostExtention
    {
        public static IHost MigrateDatabase<TContext>(this IHost host) where TContext:AppDbContext
        {
            using (var scope=host.Services.CreateScope())
            {
                var context=scope.ServiceProvider.GetService<TContext>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<TContext>>();
                try
                {
                    logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);
                    context.Database.Migrate();
                    logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(TContext).Name);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);
                }
                return host;
            }
        }
    }
}
