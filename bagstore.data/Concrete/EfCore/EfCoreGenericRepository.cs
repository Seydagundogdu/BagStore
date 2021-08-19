using Microsoft.EntityFrameworkCore;
using bagstore.data.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace bagstore.data.Concrete.EfCore
{
    //IRepositorydeki metotların içeriği
    public class EfCoreGenericRepository<TEntity, TContext>:IRepository<TEntity> //farklı veritabanlarıyla çaışmadyı kolaylaştırmak için TContext dendi
        // kısıtlamalar
        where TEntity : class //tentity, bir class olmalı (product, category, order gibi)
        where TContext : DbContext, new() //tcontext, dbcontext'ten türetilmiş bir nesne olmalı
    {
        public void Create(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public virtual void Update(TEntity entity) //override edilebilir
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified; //entity'nin değiştirilen alanının ne olduğunu söyler
                context.SaveChanges();
            }
        }

    }
}