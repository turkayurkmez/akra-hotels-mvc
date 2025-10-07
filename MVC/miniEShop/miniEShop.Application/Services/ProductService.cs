using miniEShop.Entities;


namespace miniEShop.Application.Services
{
    public class ProductService : IProductService
    {
        private List<Product> products = new List<Product>()
            {
                new Product { Id = 1, Name = "Ürün A", Description = "Açıklama A", Price = 1 },
                new Product { Id = 2, Name = "Ürün B", Description = "Açıklama B", Price = 1 },
                new Product { Id = 3, Name = "Ürün C", Description = "Açıklama C", Price = 1 },
                new Product { Id = 4, Name = "Ürün D", Description = "Açıklama D", Price = 1 },
                new Product { Id = 5, Name = "Ürün E", Description = "Açıklama E", Price = 1 },
                new Product { Id = 6, Name = "Ürün A1", Description = "Açıklama A", Price = 1 },
                new Product { Id = 7, Name = "Ürün B1", Description = "Açıklama B", Price = 1 },
                new Product { Id = 8, Name = "Ürün C1", Description = "Açıklama C", Price = 1 },
                new Product { Id = 9, Name = "Ürün D1", Description = "Açıklama D", Price = 1 },
                new Product { Id = 10, Name = "Ürün A2", Description = "Açıklama A", Price = 1 },
                new Product { Id = 11, Name = "Ürün B2", Description = "Açıklama B", Price = 1 },
                new Product { Id = 12, Name = "Ürün C2", Description = "Açıklama C", Price = 1 },
                new Product { Id = 13, Name = "Ürün D2", Description = "Açıklama D", Price = 1 },

            };
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
    }
}
