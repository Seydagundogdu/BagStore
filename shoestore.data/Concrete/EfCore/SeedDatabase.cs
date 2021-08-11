using Microsoft.EntityFrameworkCore;
using System.Linq;
using shoestore.entity;

namespace shoestore.data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new StoreContext();

            if(context.Database.GetPendingMigrations().Count() == 0) //bekleyen bir migration yoksa
            {
                if(context.Categories.Count() == 0) // veritabanında kategori bulunmuyorsa
                {
                    context.Categories.AddRange(Categories); //kategori ekler
                }

                if(context.Products.Count() == 0) //veritabanında ürün bulunmuyorusa
                {
                    context.Products.AddRange(Products); //ürün ekler
                }
            }
            context.SaveChanges();
            
        }

        private static Category[] Categories= {
            new Category(){Name="Flat"},
            new Category(){Name="Pump"},
            new Category(){Name="Bot"}
        };

        private static Product[] Products= {
            new Product(){Name="Hello Lover",Price=395,ImageUrl="1.jpg",Description="Rahat ve şık bir stiletto.", IsApproved=true},
            new Product(){Name="Carrie",Price=355,ImageUrl="2.jpg",Description="Carrie Bradshaw tarzından ilham alarak tasarlanmış bir ayakkabı.",IsApproved=true},
            new Product(){Name="Rampling",Price=355,ImageUrl="3.jpg",Description="Carrie Bradshaw tarzından ilham alarak tasarlanmış bir ayakkabı.",IsApproved=false},
            new Product(){Name="Nirvana",Price=365,ImageUrl="4.jpg",Description="Carrie Bradshaw tarzından ilham alarak tasarlanmış bir ayakkabı.",IsApproved=true},
            new Product(){Name="Femme",Price=269,ImageUrl="5.jpg",Description="Carrie Bradshaw tarzından ilham alarak tasarlanmış bir ayakkabı.",IsApproved=false}
        };
    }
}