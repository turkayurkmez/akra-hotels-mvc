using miniEShop.Entities;

namespace miniEShop.Application.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(int? category);
        IEnumerable<Product> GetProductsWithPagination(int page,  int pageSize);

        Product GetProduct(int productId);
    }
}