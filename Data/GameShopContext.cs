using Data.Models;
using System;
using System.Data.Entity;
using static NUnit.Framework.Internal.OSPlatform;

namespace Data
{
    public class GameShopContext : DbContext
    {
        public DbSet<TypeProduct> TypeProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public GameShopContext() : base("name=GameShopContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>().HasKey(x => new { x.OrderId, x.ProductId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
