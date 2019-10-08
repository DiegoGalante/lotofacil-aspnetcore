using System.IO;
using LoteriaFacil.Domain.Core.Events;
using LoteriaFacil.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


namespace LoteriaFacil.Infra.Data.Context
{
    public class EventStoreSQLContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }
        private readonly IHostingEnvironment _env;
        public IConfiguration Configuration { get; }

        public EventStoreSQLContext(IHostingEnvironment env, IConfiguration configuration)
        {
            _env = env;
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true)
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
        }
    }
}