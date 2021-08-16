using System.Collections.Generic;
using bagstore.entity;
using System.ComponentModel.DataAnnotations;

namespace bagstore.webui.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage="The 'category name' field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage="The 'url' field is required.")]
        public string Url { get; set; }
        public List<Product> Products { get; set; } //categori bilgisinin yanında gelecek olan liste
    }
}