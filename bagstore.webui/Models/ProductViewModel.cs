using System;
using System.Collections.Generic;
using bagstore.entity;

namespace bagstore.webui.Models
{
    public class PageInfo
    {
        public int TotalItems { get; set; } //tüm ürünlerin sayısı
        public int ItemsPerPage { get; set; } //sayfa başı ürün sayısı
        public int CurrentPage { get; set; } //o anki sayfa sayısı
        public string CurrentCategory { get; set; }

        public int TotalPages() //ürün sayısına göre kaç sayfa gösterileceğini hesaplar
        {
            return (int)Math.Ceiling((decimal)TotalItems/ItemsPerPage);
        }
    }
    public class ProductListViewModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Product> Products { get; set; }
    }
}
