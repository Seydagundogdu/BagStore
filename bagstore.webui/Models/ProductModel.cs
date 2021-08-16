using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using bagstore.entity;

namespace bagstore.webui.Models
{
    public class ProductModel //createproduct.cshtml label isimlerini tag helperla yollayan model
    {
        //asp-for="name" denilince id ve name'i otomatik olarak alır
        public int ProductId { get; set; }
        
        [Required(ErrorMessage="The 'product name' field is required")]
        [Display(Name="Product Name")]
        public string Name { get; set; }
        
        [Display(Name="Product Url")]
        [Required(ErrorMessage="The 'url' field is required")]  
        public string Url { get; set; }
        
        [Required(ErrorMessage="The 'price' field is required")]  
        [Range(1,10000,ErrorMessage="A value between 1-10000 should be entered for the 'price' field.")]
        [Display(Name="Price")]
        public double? Price { get; set; }

        [Required(ErrorMessage="The 'description' field is required")]
        [Display(Name="Description")]
        public string Description { get; set; }

        [Display(Name="Product Image")]
        public string ImageUrl { get; set; }

        [Display(Name="In Stock")]
        public bool IsApproved { get; set; }

        [Display(Name="Home Product")]
        public bool IsHome{ get; set; } //ana sayfada görüntülenme durumu
        public List<Category> SelectedCategories { get; set; }
    }
}