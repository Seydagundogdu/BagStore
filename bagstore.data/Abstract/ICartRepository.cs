using bagstore.entity;

namespace bagstore.data.Abstract
{
    public interface ICartRepository: IRepository<Cart>
    {
         Cart GetByUserId(string userId);
         void DeleteFromCart(int cartId, int productId);
    }
}