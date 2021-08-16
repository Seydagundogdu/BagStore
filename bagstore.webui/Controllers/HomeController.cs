using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using bagstore.data.Abstract;
using bagstore.business.Abstract;
using bagstore.webui.Models;

namespace bagstore.webui.Controllers
{
    public class HomeController:Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            this._productService = productService; //Injection işlemi
        }
        public IActionResult Index()
        {   

            var productViewModel = new ProductListViewModel()
            {
                Products = _productService.GetHomePageProducts()
            };

            return View(productViewModel);
        }
         public IActionResult About()
         {
             return View();
         }
         public IActionResult Contact()
         {
             return View("MyView");
         }
    }
}