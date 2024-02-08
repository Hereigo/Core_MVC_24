using Core_MVC_24.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_MVC_24.Data
{
    public class AppDataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        // {
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}
