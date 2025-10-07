using Microsoft.AspNetCore.Mvc;
using miniEShop.MVC.Models;
using miniEShop.MVC.Services;

namespace miniEShop.MVC.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {

        private readonly ICategoryService categoryService;

        public MenuViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = categoryService.GetCategories();
            return View(categories);
        }
    }
}
