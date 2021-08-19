using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using bagstore.business.Abstract;
using Microsoft.AspNetCore.Identity;
using bagstore.entity;
using System;
using System.Linq;
using bagstore.webui.Models;
using bagstore.webui.Identity;

namespace bagstore.webui.Controllers
{
    [Authorize] // ulaşmak için login olmalı
    public class CartController: Controller
    {
        private ICartService _cartService;
        private UserManager<User> _userManager;

        public CartController(ICartService cartService,UserManager<User> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            
            return View(new CartModel(){
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i=>new CartItemModel()
                {
                    CartItemId = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Price = (double)i.Product.Price, //fiyat bilgisi nullable olduğu için double'a cast ettim
                    ImageUrl = i.Product.ImageUrl,
                    Quantity = i.Quantity
                }).ToList()
            });
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var userId = _userManager.GetUserId(User);

            _cartService.AddToCart(userId,productId,quantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteFromCart(int productId)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.DeleteFromCart(userId, productId);
            return RedirectToAction("Index");
        }
    }
}