using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperheroUniverse.Models;


namespace SuperheroUniverse.Data
{
    public class SuperheroUniverseContext : DbContext
    {
        public SuperheroUniverseContext (DbContextOptions<SuperheroUniverseContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");
            optionsBuilder
                .UseMySql("server=127.0.0.1;port=3306;user=root ;password=;database=superverse", new MySqlServerVersion(new Version(10, 4, 17)), null)
                .UseLoggerFactory(LoggerFactory.Create(b => b
                    .AddConsole()
                    .AddFilter(level => level >= LogLevel.Information)))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
        public DbSet<SuperheroUniverse.Models.SaveWorld>? SaveWorld { get; set; }
    }
}
