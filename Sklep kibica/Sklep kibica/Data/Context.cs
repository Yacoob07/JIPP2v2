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

        public DbSet<ShopModel> Shops { get; set; }
    }
}
