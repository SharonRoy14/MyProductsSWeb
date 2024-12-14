using Microsoft.EntityFrameworkCore;
using MyProductsS.Models;

namespace MyProductsS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
    
}
