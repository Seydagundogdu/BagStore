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
using bagstore.data.Concrete.EfCore;
using bagstore.data.Abstract;
using bagstore.business.Abstract;
using bagstore.business.Concrete;

namespace bagstore.webui
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //farklı bir servis kullanıldığında (mysql,adonet vb) yapılması gereken tek şey efCoreProductRepository yerine o servisin sınıfını eklemek
            //dependency injection
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<IProductRepository, EfCoreProductRepository>(); //IProductRepository çağırılınca EfCoreProductRepository'den nesne üretip gönder
            
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
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
        }
    }
}
