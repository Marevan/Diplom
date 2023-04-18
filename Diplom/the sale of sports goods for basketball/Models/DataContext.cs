using Microsoft.EntityFrameworkCore;

namespace the_sale_of_sports_goods_for_basketball.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Basket> Baskets => Set<Basket>();
        
    }
}