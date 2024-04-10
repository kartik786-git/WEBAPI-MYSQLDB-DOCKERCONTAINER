using EFCore.AutomaticMigrations;
using Microsoft.EntityFrameworkCore;
using WebApiefcoremigrationautomatic.Data;

namespace WebApiefcoremigrationautomatic.Extensions
{
    public static class StartupDbExtensions
    {
        public static async void CreateDbIfNotExists(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var blogContext = services.GetRequiredService<BLobDbContext>();

            try
            {
                blogContext.Database.EnsureCreated();
                blogContext.Database.Migrate();
                DBInitializerSeedData.InitializeDatabase(blogContext);
            }
            catch (Exception ex)
            {

                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError($"migration issue {ex.Message}");
            }
           

            // MigrateDatabaseToLatestVersion.Execute(blogContext);


            //MigrateDatabaseToLatestVersion.Execute(blogContext, 
            //   new DbMigrationsOptions { ResetDatabaseSchema = true,  });

            //blogContext.MigrateToLatestVersion();
           
        }
    }
}
