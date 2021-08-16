using bagstore.entity;
using System.Collections.Generic;

namespace bagstore.data.Abstract
{
    public interface IProductRepository : IRepository<Product> //IRepositoryden gelen bütün metotlara sahip bir repository
    {
        Product GetByIdWithCategories(int id);
        Product GetProductDetails(string url);
        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchString);
        int GetCountByCategory(string category);
        void Update(Product entity, int[] categoryId);
    }
}