using bagstore.entity;
using bagstore.data.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace bagstore.data.Concrete.EfCore
{
    public class EfCoreCartRepository: EfCoreGenericRepository<Cart,StoreContext>, ICartRepository
    {
        public void DeleteFromCart(int cartId, int productId)
        {
            using(var context = new StoreContext())
            {
                var cmd = @"delete from CartItems where CartId=@p0 and ProductId=@p1";
                context.Database.ExecuteSqlRaw(cmd,cartId,productId); //database'e sorguyu ve id bilgilerini yollar
            }
        }

        public Cart  GetByUserId(string userId)
        {
            using (var context = new StoreContext())
            {
                return context.Carts
                            .Include(i=>i.CartItems)
                            .ThenInclude(i=>i.Product)
                            .FirstOrDefault(i=>i.UserId == userId);
                            
            }
        }

        public override void Update(Cart entity) //update override : cart update
        //cartla ilişkili olan kayıtları da güncellemesi için update i override ettim
        {
            using (var context = new StoreContext())
            {
                context.Carts.Update(entity);
                context.SaveChanges();

            }
        }
    }
}