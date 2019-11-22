using Microsoft.EntityFrameworkCore;
using MobileTasker.Entities;

namespace MobileTasker.DataAccess
{
    public class AppContext : DbContext
    {
        private string _databasePath;
        public DbSet<TaskItem> Tasks { get; set; }    

        public AppContext(string databasePath)
        {
            _databasePath = databasePath;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>().HasKey(t => t.Id);
            modelBuilder.Entity<TaskItem>().Property(t => t.Id).ValueGeneratedOnAdd();
        }       
    }
}