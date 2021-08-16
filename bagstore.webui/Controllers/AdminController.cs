using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using bagstore.business.Abstract;
using bagstore.entity;
using bagstore.webui.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace bagstore.webui.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService; //servislere ait metotları kullanabilmek için injection işlemleri
        private ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult ProductList()
        {
            return View(new ProductListViewModel()
            {
                Products = _productService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult ProductCreate() //ürün ekle butonuna basınca
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model, IFormFile file) //submit butonuna basınca
        {
            if(ModelState.IsValid)
            {
                var entity = new Product()
                {
                    Name = model.Name,
                    Url = model.Url,
                    Price = model.Price,
                    Description = model.Description
                };

                if(file!=null)//form içerisinden bir dosya yollandıysa
                {
                    var extention = Path.GetExtension(file.FileName);//resmin uzantısı
                    var randName = string.Format($"{Guid.NewGuid()}{extention}");//random gelen eşsiz isim
                    entity.ImageUrl = randName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\img",randName);//GetCurrentDirectory: uygulamanın çalıştığı ana dizini getirir


                    using(var stream = new FileStream(path, FileMode.Create))//resmi kayıt etme
                    {
                        await file.CopyToAsync(stream); //await: asenkron metot kullandığın için işlem sona erene kadar uygulama durudurulur
                    }
                }

                _productService.Create(entity);
                
                CreateMessage("The product has been added.","success");
                return RedirectToAction("ProductList");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ProductEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _productService.GetByIdWithCategories((int)id);

            if (entity == null)
            {
                return NotFound();
            }
            var model = new ProductModel() //bilgileri edit formuna getirir
            {
                ProductId = entity.ProductId,
                Name = entity.Name,
                Url = entity.Url,
                Price = entity.Price,
                ImageUrl = entity.ImageUrl,
                Description = entity.Description,
                IsApproved = entity.IsApproved,
                IsHome = entity.IsHome,
                SelectedCategories =entity.ProductCategories.Select(i=>i.Category).ToList() //ürünle ilişkili olan categorileri selectedcategoriese attım
            };
            ViewBag.Categories = _categoryService.GetAll();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductModel model, int[] categoryId, IFormFile file)
        {
            if(ModelState.IsValid)
            {

                var entity = _productService.GetById(model.ProductId);

                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
                entity.Price = model.Price;
                entity.Url = model.Url;
                entity.Description = model.Description;
                entity.IsApproved = model.IsApproved;
                entity.IsHome = model.IsHome;

                if(file!=null)//form içerisinden bir dosya yollandıysa
                {
                    var extention = Path.GetExtension(file.FileName);//resmin uzantısı
                    var randName = string.Format($"{Guid.NewGuid()}{extention}");//random gelen eşsiz isim
                    entity.ImageUrl = randName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\img",randName);//GetCurrentDirectory: uygulamanın çalıştığı ana dizini getirir


                    using(var stream = new FileStream(path, FileMode.Create))//resmi kayıt etme
                    {
                        await file.CopyToAsync(stream); //await: asenkron metot kullandığın için işlem sona erene kadar uygulama durudurulur
                    }
                }

                if(_productService.Update(entity, categoryId))
                {
                    CreateMessage("The product has been updated.","success");
                    return RedirectToAction("ProductList");
                }
                CreateMessage(_productService.ErrorMessage,"danger");
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }

        public IActionResult ProductDelete(int productId)
        {
            var entity = _productService.GetById(productId);

            if (entity != null)
            {
                _productService.Delete(entity);
            }

            //redirectToAction kullanılarak farklı bir actiona yönlendirme yapıldığı iin mesajlar viewdata ile değil tempdata ile alınır

            CreateMessage("The product has been deleted.","danger");
            return RedirectToAction("ProductList");
        }

        public IActionResult CategoryList()
        {
            return View(new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult CategoryCreate() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel model) 
        {
            if(ModelState.IsValid)
            {
                var entity = new Category()
                {
                    Name = model.Name,
                    Url = model.Url
                };

                _categoryService.Create(entity);

               CreateMessage("The product has been added.","success");
                return RedirectToAction("CategoryList");
            }
            return View(model);
            
        }

        [HttpGet]
        public IActionResult CategoryEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _categoryService.GetByIdWithProducts((int)id);

            if (entity == null)
            {
                return NotFound();
            }
            var model = new CategoryModel() //bilgileri edit formuna getirir
            {
                CategoryId = entity.CategoryId,
                Name = entity.Name,
                Url = entity.Url,
                Products = entity.ProductCategories.Select(p=>p.Product).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CategoryEdit(CategoryModel model)
        {
            if(ModelState.IsValid)
            {
                var entity = _categoryService.GetById(model.CategoryId);

                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
                entity.Url = model.Url;

                _categoryService.Update(entity);

                //redirectToAction kullanılarak farklı bir actiona yönlendirme yapıldığı iin mesajlar viewdata ile değil tempdata ile alınır

                CreateMessage("The category has been updated.","success");
                return RedirectToAction("CategoryList");
            }
            return  View(model);
            
        }

        public IActionResult CategoryDelete(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);

            if (entity != null)
            {
                _categoryService.Delete(entity);
            }

            //redirectToAction kullanılarak farklı bir actiona yönlendirme yapıldığı iin mesajlar viewdata ile değil tempdata ile alınır

            CreateMessage("The category has been deleted.","danger");
            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult DeleteFromCategory(int productId, int categoryId) //parametre olarak tablonun iki primary keyini de alır 
        {
           _categoryService.DeleteFromCategory(productId, categoryId);
           return Redirect("/admin/categories/"+categoryId);
        }

        private void CreateMessage(string message, string alerttype)
        {
            var msg = new AlertMessage()
                {
                    Message = message,
                    AlertType = alerttype

                };
                 //redirectToAction kullanılarak farklı bir actiona yönlendirme yapıldığı iin mesajlar viewdata ile değil tempdata ile alınır
                TempData["message"] = JsonConvert.SerializeObject(msg); //obje serialize edilmiyor hatasından sonra objeyi json formatına dönüştürerek serialize ettim
        }
    }
}