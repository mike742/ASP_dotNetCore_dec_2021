using API_demo_Jan_2022_ver2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_demo_Jan_2022_ver2.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                    new Product { Id = 1, Name = "Pasta", Price = 14.99}
                );
            modelBuilder.Entity<Order>().HasData(
                    new Order { Id = 1, Name = "Bob's order", Date = DateTime.Now }
                );
            modelBuilder.Entity<OrderProducts>().HasData(
                    new OrderProducts { Id = 1, OrderId = 1, ProductId = 1}
                );
        }
    }
}
