using System.Collections.Generic;
using bagstore.entity;
using System.ComponentModel.DataAnnotations;

namespace bagstore.webui.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage="Kategori alanı zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage="Url alanı zorunludur.")]
        public string Url { get; set; }
        public List<Product> Products { get; set; } //categori bilgisinin yanında gelecek olan liste
    }
}