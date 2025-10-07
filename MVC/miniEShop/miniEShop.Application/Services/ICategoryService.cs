using miniEShop.Entities;

namespace miniEShop.Application.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
    }
}
