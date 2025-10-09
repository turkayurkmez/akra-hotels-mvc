using Mapster;
using miniEShop.Application.Contracts;
using miniEShop.Application.DataTransferObjects;
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

        public void CreateProduct(CreateNewProductRequest request)
        {
            var product = new Product
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Price = request.Price
            };

            var product2 = request.Adapt<Product>();
            productRepository.Create(product);
        }

        public void DeleteProduct(int productId)
        {
            productRepository.Delete(productId);
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

        public void UpdateProduct(Product product)
        {
            //
            productRepository.Update(product); 
        }

    }
}
