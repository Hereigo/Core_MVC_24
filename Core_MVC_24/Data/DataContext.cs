using APP_4_TESTS;
using Core_MVC_24.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_MVC_24.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        // { ... }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().ToTable("Profiles");

            modelBuilder.Entity<CsvProfile>().ToTable("CsvProfile");
        }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<CsvProfile> CsvProfiles { get; set; }
    }
}
