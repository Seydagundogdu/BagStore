using Microsoft.AspNetCore.Mvc;
using bagstore.business.Abstract;
using bagstore.entity;
using bagstore.webui.Models;
using System.Linq;

namespace bagstore.webui.Controllers
{
    public class StoreController: Controller
    {
        private IProductService _productService;

        public StoreController(IProductService productService)
        {
            this._productService = productService; //Injection işlemi
        }

        // localhost/products/bot?page=1
        public IActionResult List(string category,int page=1)
        {   
            const int pageSize=3;
            var productViewModel = new ProductListViewModel()
            {
                PageInfo = new PageInfo()
                {
                    TotalItems=_productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                Products = _productService.GetProductsByCategory(category, page, pageSize)
            };

            return View(productViewModel);
        }

        public IActionResult Details(string url)
        {
            if (url==null)
            {
                return NotFound();
            }

            Product product = _productService.GetProductDetails(url);

            if(product==null)
            {
                return NotFound();
            }
            return View(new ProductDetail{
                Product = product,
                Categories = product.ProductCategories.Select(i=>i.Category).ToList()
            });

        }

        public IActionResult Search(string q)
        {
            var productViewModel = new ProductListViewModel()
            {
                Products = _productService.GetSearchResult(q)
            };

            return View(productViewModel);
        }
    }
}