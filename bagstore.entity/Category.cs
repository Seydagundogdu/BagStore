using System.Collections.Generic;

namespace bagstore.entity
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<ProductCategory> ProductCategories { get; set; } //birden fazla ürüne sahip 
    }
}