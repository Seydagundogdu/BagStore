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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using bagstore.webui.Identity;
using System.Collections.Generic;

namespace bagstore.webui.Controllers
{
    [Authorize(Roles="admin")]
    public class AdminController : Controller
    {
        private IProductService _productService; //servislere ait metotları kullanabilmek için injection işlemleri
        private ICategoryService _categoryService;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;

        public AdminController(IProductService productService, 
                               ICategoryService categoryService,
                               RoleManager<IdentityRole> roleManager,
                               UserManager<User> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user!=null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);//seçili olan rolleri getirir
                var roles = _roleManager.Roles.Select(i=>i.Name); //tüm rolleri getirir
                
                ViewBag.Roles = roles;
                return View(new UserDetailModel(){
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    SelectedRoles = selectedRoles
                });
            }
            return Redirect("~/admin/user/list");
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserDetailModel model, string[] selectedRoles)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if(user!=null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName;
                    user.Email = model.Email;

                    var result = await _userManager.UpdateAsync(user);

                    if(result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        selectedRoles = selectedRoles?? new string[]{}; //kullanıcı sayfadan bir rol seçmezse boş dizi döndür (null refernces hatası almamak için)
                        //birden fazla kaydı aynı anda eklemek
                        await _userManager.AddToRolesAsync(user,selectedRoles.Except(userRoles).ToArray<string>()); //seçilen roller arasından daha önceden veritabanında seçili olan(USERROLES) varsa onları except ile hariç tutar ve diğer rolleri ekler
                        //birden fazla kaydı aynı anda silmek
                        await _userManager.RemoveFromRolesAsync(user,userRoles.Except(selectedRoles).ToArray<string>()); //userrolleri arasından rol silme işlemi yaparken seçilen rolleri hariç tutar geri kalanı siler
                   
                        return Redirect("/admin/user/list");
                    }
                }
                return Redirect("/admin/user/list");
            }
            return View(model);
        }

        public IActionResult UserList()
        {
            return View(_userManager.Users);
        }

        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }

        [HttpGet]
        public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var members = new List<User>();
            var nonmembers = new List<User>();

            foreach (var user in _userManager.Users.ToList())
            {
                var list = await _userManager.IsInRoleAsync(user,role.Name)
                                                ?members:nonmembers; //değer true ise listi members yapar
                //değer false ise listi nonmembers yapar
                list.Add(user);//list'e kullanıcıyı ekler
            }
           
            var model = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
            if(ModelState.IsValid)
            {
                foreach(var userId in model.IdsToAdd ?? new string[]{})//eğer null ise boş bir dizi tanımla
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user!=null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);//ilgili rolename'e ilgili kullanıcıyı atadım
                        if(!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("",error.Description);
                            }
                        }
                    }
                }
                foreach(var userId in model.IdsToDelete ?? new string[]{})
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user!=null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);//ilgili rolename'e ilgili kullanıcıyı atadım
                        if(!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("",error.Description);
                            }
                        }
                    }
                }
            }
            return Redirect("/admin/role/"+model.RoleId);
        }

        [HttpGet]
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if(result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                }
            }
            return View(model);
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