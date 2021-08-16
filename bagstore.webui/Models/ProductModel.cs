using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using bagstore.entity;

namespace bagstore.webui.Models
{
    public class ProductModel //createproduct.cshtml label isimlerini tag helperla yollayan model
    {
        //asp-for="name" denilince id ve name'i otomatik olarak alır
        public int ProductId { get; set; }
        
        [Required(ErrorMessage="Name zorunlu bir alan.")]
        [Display(Name="Ürün Adı")]
        public string Name { get; set; }
        
        [Required(ErrorMessage="Url zorunlu bir alan.")]  
        public string Url { get; set; }
        
        [Required(ErrorMessage="Price zorunlu bir alan.")]  
        [Range(1,10000,ErrorMessage="Price için 1-10000 arasında değer girmelisiniz.")]
        [Display(Name="Fiyat")]
        public double? Price { get; set; }

         [Required(ErrorMessage="Description zorunlu bir alan.")]
        [Display(Name="Açıklama")]
        public string Description { get; set; }

        [Required(ErrorMessage="ImageUrl zorunlu bir alan.")]  
        [Display(Name="Resim")]
        public string ImageUrl { get; set; }

        public bool IsApproved { get; set; }
        public bool IsHome{ get; set; } //ana sayfada görüntülenme durumu
        public List<Category> SelectedCategories { get; set; }
    }
}