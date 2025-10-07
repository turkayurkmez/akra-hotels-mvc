using miniEShop.MVC.Models;

namespace miniEShop.MVC.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}