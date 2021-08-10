using System.Collections.Generic;
using System.Linq;
using shoestore.data.Abstract;
using shoestore.entity;

namespace shoestore.data.Concrete.EfCore
{
    public class EfCoreProductRepository:
        EfCoreGenericRepository<Product, StoreContext>, IProductRepository //TEntity, TContext
        //IProductRepository içerisinde ekstra bir görev varsa o görev burada icra edilecek
        //Diğer görevler EfCoreGenericRepository içerinde halledilecek
    {
        public List<Product> GetPopularProducts()
        {
            using(var context = new StoreContext())
            {
                return context.Products.ToList();
            }
        }
        public List<Product> GetTop5Products()
        {
            throw new System.NotImplementedException();
        }
    }
}