using System.IO;
using Microsoft.Data.Entity;
using Microsoft.Extensions.PlatformAbstractions;



namespace nwfw.Models
{
    public class NwfwContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Wood> Woods { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbName = Startup.Configuration["Data:Database"];          
            // var dbConnection = Startup.Configuration["Data:SqlServerConnection"];          
            var path = PlatformServices.Default.Application.ApplicationBasePath;
            optionsBuilder.UseSqlite("Filename=" + Path.Combine(path, dbName));
            // optionsBuilder.UseSqlServer(dbConnection);
            
        }
    }
}
