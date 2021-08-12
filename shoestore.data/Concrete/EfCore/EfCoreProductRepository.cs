using System.Collections.Generic;
using System.Linq;
using shoestore.data.Abstract;
using shoestore.entity;
using Microsoft.EntityFrameworkCore;

namespace shoestore.data.Concrete.EfCore
{
    public class EfCoreProductRepository :
        EfCoreGenericRepository<Product, StoreContext>, IProductRepository //TEntity, TContext
                                                                           //Diğer görevler EfCoreGenericRepository içerinde halledilecek
    {
        public int GetCountByCategory(string category)
        {
            using (var context = new StoreContext())
            {
                //filtreleme
                var products = context
                                .Products
                                .Where(i=>i.IsApproved == true)
                                .AsQueryable(); //sorgulama yapılmadan önce üzerine aşağıdaki şartların eklenebilmesi için

                if (!string.IsNullOrEmpty(category)) //şartlar
                {
                    products = products
                                    .Include(i => i.ProductCategories)
                                    .ThenInclude(i => i.Category)
                                    .Where(i => i.ProductCategories.Any(a =>a.Category.Url == category));
                }
                return products.Count();
            }
        }

        public List<Product> GetHomePageProducts()
        {
            using (var context = new StoreContext())
            {
                return context.Products
                                    .Where(i=>i.IsApproved && i.IsHome == true)
                                    .ToList();
            }
        }

  

        public Product GetProductDetails(string url)
        {
            using (var context = new StoreContext())
            {
                return context.Products //leftjoin işlemi
                                .Where(i => i.Url == url)
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .FirstOrDefault(); //bulduğun ilk kaydı getir
            }
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            using (var context = new StoreContext())
            {
                //filtreleme
                var products = context
                                    .Products
                                    .Where(i=>i.IsApproved == true)
                                    .AsQueryable(); //sorgulama yapılmadan önce üzerine aşağıdaki şartların eklenebilmesi için

                if (!string.IsNullOrEmpty(name)) //şartlar
                {
                    products = products
                                    .Include(i => i.ProductCategories)
                                    .ThenInclude(i => i.Category)
                                    .Where(i => i.ProductCategories.Any(a =>a.Category.Url == name));
                }
                return products.Skip((page-1)*pageSize).Take(pageSize).ToList();
            }
        }

        public List<Product> GetSearchResult(string searchString)
        {
            using (var context = new StoreContext())
            {
                //filtreleme
                var products = context
                                    .Products
                                    .Where(i=>i.IsApproved == true && (i.Name.ToLower().Contains(searchString.ToLower()) || i.Description.ToLower().Contains(searchString.ToLower())))
                                    .AsQueryable(); //sorgulama yapılmadan önce üzerine aşağıdaki şartların eklenebilmesi için

                return products.ToList();
            }
        }

    }
}