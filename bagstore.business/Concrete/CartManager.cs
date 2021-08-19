using bagstore.business.Abstract;
using bagstore.data.Abstract;
using bagstore.entity;

namespace bagstore.business.Concrete
{
    public class CartManager: ICartService
    {
        private ICartRepository _cartRepository;
        public CartManager(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void AddToCart(string userId, int productId, int quantity)
        {
            var cart = GetCartByUserId(userId);

            if(cart!=null)// kullanıcının cartı var mı
            {
                
                var index = cart.CartItems.FindIndex(i=>i.ProductId==productId);
                if(index < 0)//eklenmek istenen ürün sepette yok ise yani kayıt oluştur
                {
                    cart.CartItems.Add(new CartItem(){
                        ProductId = productId,
                        Quantity = quantity,
                        CartId = cart.Id
                    });
                }
                else//eklenmek istenen ürün sepette var mı (güncelleme)
                {
                    cart.CartItems[index].Quantity +=quantity;
                }
            }

            _cartRepository.Update(cart);
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);
            if(cart!=null)
            {
                _cartRepository.DeleteFromCart(cart.Id,productId);
            }
        }

        public void InitializeCart(string userId)
        {
            _cartRepository.Create(new Cart(){UserId = userId});//kartı oluşturup userId bilgisini gönderir
        }
        
        public Cart GetCartByUserId(string userId)
        {
            return _cartRepository.GetByUserId(userId);
        }
    }
}