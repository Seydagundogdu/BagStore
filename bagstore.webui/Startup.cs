using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using bagstore.data.Concrete.EfCore;
using bagstore.data.Abstract;
using bagstore.business.Abstract;
using bagstore.business.Concrete;
using bagstore.webui.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace bagstore.webui
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options=>options.UseSqlServer("Server=SEYDA;Database=StoreDb;User Id=sa;Password=password1;"));
            services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();//tanımladığım identityi ekledim. AddDefaultTokenProviders(): parola resetlemede benzersiz bir sayı üretecek olan yapı (doğrulama işlemleri için token oluşturur)

            services.Configure<IdentityOptions>(options=>{
                //for password
                options.Password.RequireDigit = true; //parolada sayısal değer bulunmalı
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;

                options.User.RequireUniqueEmail = true; // her kullanıcının farklı mail adresi olmalı
                options.SignIn.RequireConfirmedEmail = false ;//mail onayı

            });

            services.ConfigureApplicationCookie(options=> {
                options.LoginPath = "/account/login"; //herhangi bir nedenden dolayı cookie ile session birbirini tanımıyorsa logine yönlendirir
                options.LogoutPath = "/account/logout"; //çıkış işlemi yapılınca sessionla cookienin bir bağlantısı kalmadığın logout sayfasına yönlendirir
                options.AccessDeniedPath = "/account/accessdenied"; //yetkisi olmayan sayfaya erişim durumunda
                options.SlidingExpiration = true; //uygulamya her istek yapılışında kullanıcıya default olarak 20 dk daha süre verir
                options.ExpireTimeSpan = TimeSpan.FromDays(365); //default olarak 20 dk olan süreyi 365 gün yapar
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true, //cookie sadece http talebiyle elde edilsin
                    Name = ".BagStore.Security.Cookie", //tarayıcıda oluşturulan cookienin ismi
                    SameSite = SameSiteMode.Strict //B kullanıcısı a kullanıcısının cookiesine sahip olsa dahi adres farklılığından dolayı hesabına erişim gerçekleştiremez
              };
            });

            //farklı bir servis kullanıldığında (mysql,adonet vb) yapılması gereken tek şey efCoreProductRepository yerine o servisin sınıfını eklemek
            //dependency injection
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<IProductRepository, EfCoreProductRepository>(); //IProductRepository çağırılınca EfCoreProductRepository'den nesne üretip gönder
            services.AddScoped<ICartRepository, EfCoreCartRepository>(); //IProductRepository çağırılınca EfCoreProductRepository'den nesne üretip gönder


            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICartService, CartManager>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {

            app.UseStaticFiles();

             app.UseStaticFiles(new StaticFileOptions
             {
                 FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                 RequestPath = "/modules"
            });
            if (env.IsDevelopment()) //uygulama geliştiriken çalışacak olan kısımlar
            //yayınlanana kadar true değer döndürür
            //yayınlanırken launch.json içerinden "ASPPNETCORE_ENVİRONMENT" değeri "production" yapılırsa false döndürür
            {
                SeedDatabase.Seed(); //test verilerini veri tabanına ekler
                app.UseDeveloperExceptionPage(); //hata mesajı verir
            }

            
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(//ürünler linkine tıklandığında storecontroller altındaki list metoduna gitmesi için
                    name: "cart",
                    pattern: "cart",
                    defaults: new {controller="Cart", action="Index"}
                );

                endpoints.MapControllerRoute(//ürünler linkine tıklandığında storecontroller altındaki list metoduna gitmesi için
                    name: "adminusers",
                    pattern: "admin/user/list",
                    defaults: new {controller="Admin", action="UserList"}
                );

                endpoints.MapControllerRoute(
                    name: "adminuseredit",
                    pattern: "admin/user/{id?}",
                    defaults: new {controller="Admin", action="UserEdit"}
                );

                endpoints.MapControllerRoute(//ürünler linkine tıklandığında storecontroller altındaki list metoduna gitmesi için
                    name: "adminrolecreate",
                    pattern: "admin/role/create",
                    defaults: new {controller="Admin", action="RoleCreate"}
                );

                endpoints.MapControllerRoute(//ürünler linkine tıklandığında storecontroller altındaki list metoduna gitmesi için
                    name: "adminroles",
                    pattern: "admin/role/list",
                    defaults: new {controller="Admin", action="RoleList"}
                );

                endpoints.MapControllerRoute(
                    name: "adminroleedit",
                    pattern: "admin/role/{id?}",
                    defaults: new {controller="Admin", action="RoleEdit"}
                );

                endpoints.MapControllerRoute(//ürünler linkine tıklandığında storecontroller altındaki list metoduna gitmesi için
                    name: "adminproducts",
                    pattern: "admin/products",
                    defaults: new {controller="Admin", action="ProductList"}
                );

                endpoints.MapControllerRoute(
                    name: "adminproductcreate",
                    pattern: "admin/products/create",
                    defaults: new {controller="Admin", action="ProductCreate"}
                );

                endpoints.MapControllerRoute(
                    name: "adminproductedit",
                    pattern: "admin/products/{id?}",
                    defaults: new {controller="Admin", action="ProductEdit"}
                );

                endpoints.MapControllerRoute(
                    name: "admincategories",
                    pattern: "admin/categories",
                    defaults: new {controller="Admin", action="CategoryList"}
                );

                endpoints.MapControllerRoute(
                    name: "admincategorycreate",
                    pattern: "admin/categories/create",
                    defaults: new {controller="Admin", action="CategoryCreate"}
                );

                endpoints.MapControllerRoute(
                    name: "admincategoryedit",
                    pattern: "admin/categories/{id?}",
                    defaults: new {controller="Admin", action="CategoryEdit"}
                );

                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "search",
                    defaults: new {controller="Store", action="search"}
                );

                endpoints.MapControllerRoute(//ürünler linkine tıklandığında storecontroller altındaki list metoduna gitmesi için
                    name: "productdetails",
                    pattern: "{url}",
                    defaults: new {controller="Store", action="details"}
                );

                endpoints.MapControllerRoute(//ürünler linkine tıklandığında storecontroller altındaki list metoduna gitmesi için
                    name: "products",
                    pattern: "products/{category?}",
                    defaults: new {controller="Store", action="list"}
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            });

            SeedIdentity.Seed(userManager, roleManager, configuration).Wait();
        }
    }
}
