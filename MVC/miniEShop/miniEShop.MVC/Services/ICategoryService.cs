using miniEShop.MVC.Models;

namespace miniEShop.MVC.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
    }
}
