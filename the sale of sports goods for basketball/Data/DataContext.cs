using Microsoft.EntityFrameworkCore;
using the_sale_of_sports_goods_for_basketball.Models;

namespace the_sale_of_sports_goods_for_basketball.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Client>().ToTable("Clients");          
        }
    }
}