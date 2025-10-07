using miniEShop.MVC.Models;

namespace miniEShop.MVC.Services
{
    public class CategoryService : ICategoryService
    {
        private List<Category> categories = new List<Category>
        {
            new Category{ Id =1, Name ="Kırtasiye"},
            new Category{ Id =2, Name ="Elektronik"},
            new Category{ Id =3, Name ="Mobilya"},


        };
        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }
    }
}
