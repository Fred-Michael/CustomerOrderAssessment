using CustomerOrder.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrder.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; } 
    }
}
