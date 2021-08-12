using shoestore.entity;
using shoestore.data.Abstract;
using System.Collections.Generic;

namespace shoestore.data.Concrete.EfCore
{
    public class EfCoreCategoryRepository: EfCoreGenericRepository<Category, StoreContext>, ICategoryRepository
    {
        public List<Category> GetPopularCategories()
        {
            throw new System.NotImplementedException();
        }
    }
}