using Microsoft.EntityFrameworkCore;
using shoestore.entity;

namespace shoestore.data.Concrete.EfCore
{
    public class StoreContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SEYDA;Database=StoreDb;User Id=sa;Password=password1;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(c=>new {c.CategoryId,c.ProductId}); //tablonun birincil anahtarları
        }
    }
}