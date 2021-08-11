using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using shoestore.data.Abstract;
using shoestore.business.Abstract;

namespace shoestore.webui.Controllers
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

            var productViewModel = new ProductViewModel()
            {
                Products = _productService.GetAll()
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