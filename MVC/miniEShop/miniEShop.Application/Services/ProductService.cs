using miniEShop.Application.Contracts;
using miniEShop.Entities;


namespace miniEShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product GetProduct(int productId)
        {
           return productRepository.GetById(productId);
        }

        public IEnumerable<Product> GetProducts(int? category)
        {
            return category == null ? productRepository.GetAll() : 
                                      productRepository.GetProductsByCategory(category.Value);
        }

        public IEnumerable<Product> GetProductsWithPagination(int page, int pageSize)
        {
            return productRepository.GetWithPagination(page, pageSize);
        }
    }
}
