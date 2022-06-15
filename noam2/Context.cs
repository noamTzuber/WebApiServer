using Microsoft.EntityFrameworkCore;
using noam2.Model;


namespace WebShop
{
    public class ItemsContext : DbContext
    {
        private const string connectionString = "server=localhost;port=3306;database=Users;user=root;password=12345678";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, MariaDbServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the Name property as the primary
            // key of the Items table
            modelBuilder.Entity<User>().HasKey(e => e.Id);
        }

        public DbSet<User> Users { get; set; }
    }
}
