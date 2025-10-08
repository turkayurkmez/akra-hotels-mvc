

using miniEShop.Application.Contracts;
using miniEShop.Entities;

namespace miniEShop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        //private List<Category> categories = new List<Category>
        //{
        //    new Category{ Id =1, Name ="Kırtasiye"},
        //    new Category{ Id =2, Name ="Elektronik"},
        //    new Category{ Id =3, Name ="Mobilya"},


        //};
        public IEnumerable<Category> GetCategories()
        {
            return categoryRepository.GetAll();
        }
    }
}
