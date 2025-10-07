using miniEShop.Entities;

namespace miniEShop.Application.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}