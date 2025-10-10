using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using miniEShop.Application.Services;
using System.Threading.Tasks;



namespace miniEShop.MVC.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {

        private readonly ICategoryService categoryService;
        private readonly IMemoryCache _cache;
        private readonly ILogger<MenuViewComponent> _logger;

        public MenuViewComponent(ICategoryService categoryService, IMemoryCache cache, ILogger<MenuViewComponent> logger)
        {
            this.categoryService = categoryService;
            _cache = cache;
            _logger = logger;
        }

        public  async Task<IViewComponentResult> InvokeAsync()
        {
            string cacheKey = "categories";
            var categories = await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(10);
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20);
                entry.Priority = CacheItemPriority.Low;
                entry.RegisterPostEvictionCallback((key, value, reason, state) =>
                {
                    _logger.LogInformation($"Cache silindi. {key}- sebebi: {reason}");
                });

                return categoryService.GetCategories();
            });

            return View(categories);
        }
    }
}
