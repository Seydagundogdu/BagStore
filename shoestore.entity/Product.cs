using System.Collections.Generic;

namespace shoestore.entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome{ get; set; } //ana sayfada görüntülenme durumu
        public List<ProductCategory> ProductCategories { get; set; } //birden fazla categoriye sahip
    }
}