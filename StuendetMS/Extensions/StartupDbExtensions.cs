using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using StuendetMS.Data;

namespace StuendetMS.Extensions
{
    public static class StartupDbExtensions
    {

        public static async void CreateDbIfNotExists(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var studentContext = services.GetRequiredService<StudentDbContext>();

            var logger = services.GetRequiredService<ILogger<Program>>();

            try
            {
                var databsecrate = studentContext.Database.GetService<IDatabaseCreator>()
                    as RelationalDatabaseCreator;
                if (databsecrate != null)
                {
                    if (!databsecrate.CanConnect())
                    {

                        databsecrate.Create();
                        logger.LogInformation("enter databsecrate Create");
                    }
                    if (!databsecrate.HasTables())
                    {
                        databsecrate.CreateTables();
                        logger.LogInformation("enter databsecrate CreateTables");
                    }

                    DBInitializerSeedData.InitializeDatabase(studentContext);
                    logger.LogInformation("enter databsecrate InitializeDatabase");
                }

            }
            catch (Exception ex)
            {

                logger.LogError($"migration issue {ex.Message}");

            }
        }
    }
}
