using shoestore.entity;
using System.Collections.Generic;

namespace shoestore.data.Abstract
{
    public interface IProductRepository : IRepository<Product> //IRepositoryden gelen bütün metotlara sahip bir repository
    {
        Product GetProductDetails(string url);
        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchString);
        int GetCountByCategory(string category);
    }
}