using LoteriaFacil.Domain.Models;
using LoteriaFacil.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace LoteriaFacil.Infra.Data.Context
{
    public class LoteriaFacilContext : DbContext
    {
        private readonly IHostingEnvironment _env;

        public LoteriaFacilContext(IHostingEnvironment env)
        {
            _env = env;
        }


        public DbSet<Person> Person { get; set; } // novo #Person
        public DbSet<Configuration> Configuration { get; set; } //novo #Configuration
        public DbSet<TypeLottery> TypeLottery { get; set; } //novo #TypeLottery
        public DbSet<Lottery> Lottery { get; set; } //novo #Lottery
        public DbSet<PersonLottery> PersonLottery { get; set; } //novo #PersonLottery


        public DbSet<JsonDashboard> JsonDashboard { get; set; } //novo #JsonDashboard

        public DbSet<PersonGame> PersonGame { get; set; } //novo #GamePerson

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMap()); //novo - #Person

            modelBuilder.ApplyConfiguration(new ConfigurationMap()); //novo - #Configuration

            modelBuilder.ApplyConfiguration(new TypeLotteryMap()); //novo - #TypeLottery

            modelBuilder.ApplyConfiguration(new LotteryMap()); //novo - #Lottery

            modelBuilder.ApplyConfiguration(new PersonLotteryMap()); //novo - #PersonLottery

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
