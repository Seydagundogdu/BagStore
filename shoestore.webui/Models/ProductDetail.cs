using shoestore.entity;
using System.Collections.Generic;

namespace shoestore.webui.Models
{
    //hem ürün hem de kategori bilgisini talıyan model
    public class ProductDetail
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}