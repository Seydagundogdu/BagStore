using Microsoft.EntityFrameworkCore;
using System.Linq;
using bagstore.entity;

namespace bagstore.data.Concrete.EfCore
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
            new Category(){Name="Tote Bags",Url="tote-bags"},
            new Category(){Name="Mini Bags", Url="mini-bags"},
            new Category(){Name="Cross Body Bags",Url="cross-body-bags"}
        };

        private static Product[] Products= {
            new Product(){Name="Ava",Url="ava",Price=1095,ImageUrl="1.jpg",Description="Ava is an easy chic, large open tote for everyday use. From shopping to meetings, or a weekend away, Ava also works as a luxury gym bag, or a 'Mom' bag. Crafted with a large open pocket for a tablet, a pouch for a water bottle, card pocket and a zip pocket.  Its spacious body can accommodate a 16 inch laptop. Ava fits everything you KNEED and more. Light, effortless everyday elegance, featuring KNEED's signature leather braid in a resilient grain leather.", IsApproved=true},
            new Product(){Name="Elena",Url="elena",Price=1340,ImageUrl="2.jpg",Description="KNEED’s essential raffia summer tote, the Elena is hand-crocheted by our artisans in Italy, and is of exceptional quality. Elegant enough for a chic restaurant, and roomy enough to pack up and go to the beach. Trimmed in calfskin, lined in canvas and with a calfskin front flap pocket that is finished with KNEED’s signature braid.",IsApproved=true},
            new Product(){Name="Ava",Url="ava-black",Price=1095,ImageUrl="3.jpg",Description="Ava is an easy chic, large open tote for everyday use. From shopping to meetings, or a weekend away, Ava also works as a luxury gym bag, or a 'Mom' bag. Crafted with a large open pocket for a tablet, a pouch for a water bottle, card pocket and a zip pocket.  Its spacious body can accommodate a 16 inch laptop. Ava fits everything you KNEED and more. Light, effortless everyday elegance, featuring KNEED's signature leather braid in a resilient grain leather.",IsApproved=false},
            new Product(){Name="Coco",Url="coco-white",Price=1130,ImageUrl="4.jpg",Description="Structured to stand on a table, this glamorous clutch has a spacious interior to house all of your essentials, and with a myriad of pockets. This evening bag features a striking curved pleated flap draped with KNEED’s sumptuous braid, and a detachable chain. Designed to be worn with the braid draped over your hand or on the shoulder. Coco exudes refinement.",IsApproved=true},
            new Product(){Name="Liberty at Night",Url="libertyatnight-black",Price=1340,ImageUrl="5.jpg",Description="KNEED’s adaptable design gets an evening makeover. The optional chain or leather straps can be adjusted to give multiple wearing options. KNEED’s signature braid is perfectly worked into the flap, and the spacious interior has multiple pockets for cell phone and essentials. A stunning addition to an evening look.",IsApproved=false},
            new Product(){Name="Noa",Url="noa-black",Price=1395,ImageUrl="6.jpg",Description="Noa is the ultimate mini-bag - the youngest sibling of the Rona and Golché, this stunning bag can be worn cross-body, on the shoulder or as the chicest handle-top bag.  With enough room for your essentials and a little more, the Noa is sure to look chic in any setting or season. With a detachable strap, and KNEED's signature hand-woven braid polished elegance is second nature with this beautiful bag. ",IsApproved=false},
            new Product(){Name="Coco",Url="Coco-denim",Price=1130,ImageUrl="7.jpg",Description="Structured to stand on a table, this glamorous clutch has a spacious interior to house all of your essentials, and with a myriad of pockets. This evening bag features a striking curved pleated flap draped with KNEED’s sumptuous braid, and a detachable chain. Designed to be worn with the braid draped over your hand or on the shoulder. Coco exudes refinement.",IsApproved=true},
            new Product(){Name="Alexia",Url="alexia-slate",Price=1095,ImageUrl="8.jpg",Description="A compact top-handle shoulder bag with detatchable chain-and-leather shoulder strap, Alexia is the perfect desk-to-dinner handbag. The petite exterior harbors a deceptively generous interior with multiple pockets, and is lined in KNEED’s bougainvillea colored grosgrain. The architectural folio-flap front is embellished with KNEED’s woven leather braid. A classic shape with a modern spirit.",IsApproved=true}
        };

        private static ProductCategory[] ProductCategories={ //ürün-kategori eşleştirmeleri
            new ProductCategory(){Product=Products[0], Category=Categories[0]},
            new ProductCategory(){Product=Products[1], Category=Categories[0]},
            new ProductCategory(){Product=Products[2], Category=Categories[0]},
            new ProductCategory(){Product=Products[3], Category=Categories[1]},
            new ProductCategory(){Product=Products[4], Category=Categories[1]},
            new ProductCategory(){Product=Products[5], Category=Categories[1]},
            new ProductCategory(){Product=Products[6], Category=Categories[1]},
            new ProductCategory(){Product=Products[7], Category=Categories[1]}
        };
    }
}