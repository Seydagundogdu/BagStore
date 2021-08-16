using bagstore.entity;
using bagstore.data.Abstract;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace bagstore.data.Concrete.EfCore
{
    public class EfCoreCategoryRepository: EfCoreGenericRepository<Category, StoreContext>, ICategoryRepository
    {
        public Category GetByIdWithProducts(int categoryId)
        {
            using(var context = new StoreContext())
            {
                return context.Categories
                                .Where(i=>i.CategoryId==categoryId)
                                .Include(i=>i.ProductCategories)
                                .ThenInclude(i=>i.Product)
                                .FirstOrDefault();
            }
        }

        public void DeleteFromCategory(int productId, int categoryId)
        {
            using(var context = new StoreContext())
            {
                var cmd = "delete from productcategory where ProductId=@p0 and CategoryId=@p1";
                context.Database.ExecuteSqlRaw(cmd,productId,categoryId);
            }
        }
    }

}