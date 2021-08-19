using Microsoft.EntityFrameworkCore;
using bagstore.entity;

namespace bagstore.data.Concrete.EfCore
{
    public class StoreContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SEYDA;Database=StoreDb;Integrated Security=True;MultipleActiveResultSets=true;User Id=sa;Password=password1;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(c=>new {c.CategoryId,c.ProductId}); //tablonun birincil anahtarları
        }
    }
}