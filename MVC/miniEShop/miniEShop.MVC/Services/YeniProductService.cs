using miniEShop.MVC.Models;

namespace miniEShop.MVC.Services
{
    public class YeniProductService : IProductService
    {
        private List<Product> products = new List<Product>()
            {
                new Product { Id = 21, Name = "Ürün Z", Description = "Açıklama A", Price = 1 },
                new Product { Id = 22, Name = "Ürün X", Description = "Açıklama B", Price = 1 },
                new Product { Id = 23, Name = "Ürün Y", Description = "Açıklama C", Price = 1 },
                new Product { Id = 24, Name = "Ürün W", Description = "Açıklama D", Price = 1 },
             

            };
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
    }
}
