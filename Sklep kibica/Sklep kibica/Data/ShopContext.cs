using Microsoft.EntityFrameworkCore;
using Sklep_kibica.Models;
using System.IO;

namespace Sklep_kibica.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<CartItem> CartItems => Set<CartItem>();

        public static void SeedData(ShopContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Koszulka meczowa", Price = 199.99m, Quantity = 100 },
                    new Product { Name = "Spodenki", Price = 99.99m, Quantity = 100 },
                    new Product { Name = "Szalik", Price = 69.99m, Quantity = 100 },
                    new Product { Name = "Czapka z daszkiem", Price = 39.99m, Quantity = 100 },
                    new Product { Name = "Kubek", Price = 29.99m, Quantity = 100 },
                    new Product { Name = "Brelok", Price = 9.99m, Quantity = 100 },
                    new Product { Name = "Bransoletka", Price = 14.99m, Quantity = 100 },
                    new Product { Name = "Piłka meczowa", Price = 149.99m, Quantity = 100 }
                );
                context.SaveChanges();
            }
        }
    }
}
