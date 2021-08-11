using shoestore.entity;
using System.Collections.Generic;

namespace shoestore.business.Abstract
{
    public interface IProductService
    {
         Product GetById(int id);
         List<Product> GetAll();
         void Create(Product entity);
         void Update(Product entity);
         void Delete(Product entity);
    }
}