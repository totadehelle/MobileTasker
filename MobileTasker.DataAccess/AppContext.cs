using Microsoft.EntityFrameworkCore;
using MobileTasker.Entities;

namespace MobileTasker.DataAccess
{
    public class AppContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>().HasKey(t => t.Id);
            modelBuilder.Entity<TaskItem>().Property(t => t.Id).ValueGeneratedOnAdd();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=TasksDB.db;");
        }
    }
}