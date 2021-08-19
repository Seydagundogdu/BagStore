using bagstore.entity;

namespace bagstore.business.Abstract
{
    public interface ICartService
    {
         void InitializeCart(string userId);
         Cart GetCartByUserId(string userId);
         void AddToCart(string userId, int product, int quantity);
          void DeleteFromCart(string userId, int productId);
    }

}