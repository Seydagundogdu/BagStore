
using System.Collections.Generic;

namespace shoestore.data.Abstract
{
    public interface IRepository<Type> //generic arayüzü
    {
         Type GetById(int id);
         List<Type> GetAll();
         void Create(Type entity);
         void Update(Type entity);
         void Delete(Type entity);
        
    }
}