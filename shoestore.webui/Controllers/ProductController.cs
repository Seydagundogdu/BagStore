using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using shoestore.entity;

namespace shoestore.webui.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var p = new Product { Name = "Kot Ceket", Price = 180, Description = "%100 pamuk içerikli jean ceket ile hem spor hem şık görünüm." };

            // ViewData["Category"] = "Ceketler";
            // ViewData["Product"] = p;

            ViewBag.Category = "Ceketler";
            ViewBag.Product = p;

            return View(p);
        }
        public IActionResult List(int? id, string q)
        {

            // var products = ProductRepository.Products;

            // if(id!=null)
            // {
            //     products = products.Where(p=>p.CategoryId==id).ToList();
            // }

            // if (!string.IsNullOrEmpty(q))
            // {
            //     products = products.Where(i=>i.Name.ToLower().Contains(q.ToLower()) || i.Description.ToLower().Contains(q.ToLower())).ToList();
            // }

            // var productViewModel = new ProductViewModel()
            // {
            //     Products = products
            // };

            // return View(productViewModel);
            return View();
        }
        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpGet] //serverdan bilgi alınırken
        public IActionResult Create() //ürün ekle sekmesine basılınca açılan form sayfası
        {
            //ViewBag.Categories = new SelectList(CategoryRepository.Categories,"CategoryId","Name");
            return View(new Product());
        }

        [HttpPost] //servera bilgi verilirken
        public IActionResult Create(Product p) //ürün ekleme işlemi biterken ekle butonuna bastıktan sonra
        {
            //      if(ModelState.IsValid) //ürün modeli bizim tanımladığımız kurallara göre oluşturulduysa
            //      {
            //         ProductRepository.AddProduct(p);
            //         return RedirectToAction("List");
            //      }
            //      ViewBag.Categories = new SelectList(CategoryRepository.Categories,"CategoryId","Name");

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id) // list sayfasında ürün düzenle diyince
        {
           // ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "Name"); //kategorileri dinamik olarak asp-items ile selectbox'a aktarabilmek için
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Product p)// ürün düzenleme işlemi bittikten sonra düzenle butonuna basınca
        {
            //ProductRepository.EditProduct(p);
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Delete(int ProductId)
        {
            //ProductRepository.DeleteProduct(ProductId);
            return RedirectToAction("List");
        }
    }
}