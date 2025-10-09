using miniEShop.Application.DataTransferObjects;
using miniEShop.Entities;

namespace miniEShop.Application.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(int? category);
        IEnumerable<Product> GetProductsWithPagination(int page,  int pageSize);

        Product GetProduct(int productId);
        void CreateProduct(CreateNewProductRequest product);

        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}