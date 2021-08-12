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
                    context.AddRange(Products); //ürün ekler
                    context.AddRange(ProductCategories);
                }
            }
            context.SaveChanges();
            
        }

        private static Category[] Categories= {
            new Category(){Name="Flat Ayakkabı",Url="flat-ayakkabi"},
            new Category(){Name="Topuklu Ayakkabı", Url="topuklu-ayakkabi"},
            new Category(){Name="Bot",Url="bot"}
        };

        private static Product[] Products= {
            new Product(){Name="Hello Lover",Url="hello-lover",Price=395,ImageUrl="1.jpg",Description="Rahat ve şık bir stiletto.", IsApproved=true},
            new Product(){Name="Carrie",Url="carrie",Price=355,ImageUrl="2.jpg",Description="Carrie Bradshaw tarzından ilham alarak tasarlanmış bir ayakkabı.",IsApproved=true},
            new Product(){Name="Rampling",Url="rampling",Price=355,ImageUrl="3.jpg",Description="Carrie Bradshaw tarzından ilham alarak tasarlanmış bir ayakkabı.",IsApproved=false},
            new Product(){Name="Nirvana",Url="nirvana",Price=365,ImageUrl="4.jpg",Description="Carrie Bradshaw tarzından ilham alarak tasarlanmış bir ayakkabı.",IsApproved=true},
            new Product(){Name="Femme",Url="femme",Price=269,ImageUrl="5.jpg",Description="Carrie Bradshaw tarzından ilham alarak tasarlanmış bir ayakkabı.",IsApproved=false},
            new Product(){Name="Meteor",Url="meteor",Price=269,ImageUrl="7.jpg",Description="Carrie Bradshaw tarzından ilham alarak tasarlanmış bir ayakkabı.",IsApproved=false},
            new Product(){Name="Story",Url="story",Price=269,ImageUrl="8.jpg",Description="Carrie Bradshaw tarzından ilham alarak tasarlanmış bir ayakkabı.",IsApproved=true},
            new Product(){Name="Minnie",Url="minne",Price=269,ImageUrl="13.jpg",Description="Carrie Bradshaw tarzından ilham alarak tasarlanmış bir ayakkabı.",IsApproved=true}
        };

        private static ProductCategory[] ProductCategories={ //ürün-kategori eşleştirmeleri
            new ProductCategory(){Product=Products[0], Category=Categories[1]},
            new ProductCategory(){Product=Products[1], Category=Categories[1]},
            new ProductCategory(){Product=Products[2], Category=Categories[1]},
            new ProductCategory(){Product=Products[3], Category=Categories[1]},
            new ProductCategory(){Product=Products[4], Category=Categories[1]},
            new ProductCategory(){Product=Products[5], Category=Categories[0]},
            new ProductCategory(){Product=Products[6], Category=Categories[0]},
            new ProductCategory(){Product=Products[7], Category=Categories[2]}
        };
    }
}