using Microsoft.EntityFrameworkCore;
using ProductManagement.Models;

namespace ProductManagement.Context
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
