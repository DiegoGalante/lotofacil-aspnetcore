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

        
        public DbSet<Person> Persons { get; set; } // novo #Person
        public DbSet<Configuration> Configuration { get; set; } //novo #Configuration
        public DbSet<Type_Lottery> Type_Lottery { get; set; } //novo #Type_Lottery

        //public DbSet<Lottery> Lottery { get; set; } //novo #Lottery
        //public DbSet<Person_Lottery> Person_Lottery { get; set; } //novo #Person_Lottery

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMap()); //novo - #Person

            modelBuilder.ApplyConfiguration(new ConfigurationMap()); //novo - #Configuration

            modelBuilder.ApplyConfiguration(new Type_LotteryMap()); //novo - #Type_Lottery

            //modelBuilder.ApplyConfiguration(new LotteryMap()); //novo - #Lottery

           // modelBuilder.ApplyConfiguration(new Person_LotteryMap()); //novo - #Person_Lottery

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
