using bagstore.entity;
using System.Collections.Generic;

namespace bagstore.webui.Models
{
    //hem ürün hem de kategori bilgisini talıyan model
    public class ProductDetail
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}