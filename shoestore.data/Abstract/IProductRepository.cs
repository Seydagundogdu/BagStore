using shoestore.entity;
using System.Collections.Generic;

namespace shoestore.data.Abstract
{
    public interface IProductRepository:IRepository<Product> //IRepositoryden gelen bütün metotlara sahip bir repository
    {
         List<Product> GetPopularProducts();
         List<Product> GetTop5Products();
    }
}