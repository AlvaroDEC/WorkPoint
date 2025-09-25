using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ClaseEntityFramework.Data
{
    public class AppContextsFactory : IDesignTimeDbContextFactory<AppContexts>
    {
        public AppContexts CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppContexts>();
            
            // Configuración para el tiempo de diseño
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("LocalhostConnection");
            optionsBuilder.UseNpgsql(connectionString);

            return new AppContexts(optionsBuilder.Options);
        }
    }
}
