namespace shoestore.entity
{
    //çoka çok ilişki için oluşturulan tablo
    public class ProductCategory //bir kategori birden fazla ürüne bir ürün birden fazla kategoriye ait olabilsin diye
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}