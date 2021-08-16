using System.Collections.Generic;
using System.Linq;
using bagstore.data.Abstract;
using bagstore.entity;
using Microsoft.EntityFrameworkCore;

namespace bagstore.data.Concrete.EfCore
{
    public class EfCoreProductRepository :
        EfCoreGenericRepository<Product, StoreContext>, IProductRepository //TEntity, TContext
                                                                           //Diğer görevler EfCoreGenericRepository içerinde halledilecek
    {
        public Product GetByIdWithCategories(int id)
        {
            using (var context = new StoreContext())
            {
                return context.Products
                                .Where(i => i.ProductId == id)
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .FirstOrDefault();
            }
        }

        public int GetCountByCategory(string category) //kategoriye göre ürün sayısı
        {
            using (var context = new StoreContext())
            {
                //filtreleme
                var products = context
                                .Products
                                .Where(i => i.IsApproved == true)
                                .AsQueryable(); //sorgulama yapılmadan önce üzerine aşağıdaki şartların eklenebilmesi için

                if (!string.IsNullOrEmpty(category)) //şartlar
                {
                    products = products
                                    .Include(i => i.ProductCategories)
                                    .ThenInclude(i => i.Category)
                                    .Where(i => i.ProductCategories.Any(a => a.Category.Url == category));
                }
                return products.Count();
            }
        }

        public List<Product> GetHomePageProducts()
        {
            using (var context = new StoreContext())
            {
                return context.Products
                                    .Where(i => i.IsApproved && i.IsHome == true)
                                    .ToList();
            }
        }



        public Product GetProductDetails(string url)
        {
            using (var context = new StoreContext())
            {
                return context.Products //leftjoin işlemi : ürün detay sayfasından ürünün kategori bilgisini de getirir.
                                .Where(i => i.Url == url)
                                .Include(i => i.ProductCategories) //product tablosundan productCategoriese geçiş
                                .ThenInclude(i => i.Category)//productCategories'ten category'e geçiş
                                .FirstOrDefault(); //bulduğun ilk kaydı getir
            }
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize) //kategoriye göte filtreleme
        {
            using (var context = new StoreContext())
            {
                //filtreleme
                var products = context
                                    .Products
                                    .Where(i => i.IsApproved == true)
                                    .AsQueryable(); //sorgulama yapılmadan önce üzerine aşağıdaki şartların eklenebilmesi için

                if (!string.IsNullOrEmpty(name)) //şartlar
                {
                    products = products
                                    .Include(i => i.ProductCategories)
                                    .ThenInclude(i => i.Category)
                                    .Where(i => i.ProductCategories.Any(a => a.Category.Url == name)); //herhangi bi kayıt var mı yok mu
                }
                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Product> GetSearchResult(string searchString)
        {
            using (var context = new StoreContext())
            {
                //filtreleme
                var products = context
                                    .Products
                                    .Where(i => i.IsApproved == true && (i.Name.ToLower().Contains(searchString.ToLower()) || i.Description.ToLower().Contains(searchString.ToLower())))
                                    .AsQueryable(); //sorgulama yapılmadan önce üzerine aşağıdaki şartların eklenebilmesi için

                return products.ToList();
            }
        }

        public void Update(Product entity, int[] categoryId)
        {
            using (var context = new StoreContext())
            {
                var product = context.Products
                                    .Include(i => i.ProductCategories)
                                    .FirstOrDefault(i => i.ProductId == entity.ProductId);

                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Price = entity.Price;
                    product.Description = entity.Description;
                    product.Url = entity.Url;
                    product.ImageUrl = entity.ImageUrl;
                    product.IsApproved = entity.IsApproved;
                    product.IsHome = entity.IsHome;

                    product.ProductCategories = categoryId.Select(catId => new ProductCategory()
                    {
                        ProductId = entity.ProductId,
                        CategoryId = catId
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }
       
        

    }
}