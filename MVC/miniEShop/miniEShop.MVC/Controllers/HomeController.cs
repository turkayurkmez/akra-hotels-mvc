using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using miniEShop.Application.Services;
using miniEShop.MVC.Models;
using miniEShop.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace miniEShop.MVC.Controllers
{
    [ResponseCache(Duration = 300)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IMemoryCache cache)
        {
            _logger = logger;
            this.productService = productService;
            _cache = cache;
        }

        public IActionResult Index(int page=1, int? category=null)
        {



            //toplam sayfa: ürün toplamý / bir sayfada gösterilecek ürün sayýsý..

            //   var productService = new ProductService();// Yüksek baðýmlýlýk oluþur.

            /* Cache için geçerli yaklaþým lazy initialization yani cache'de varsa kullan yoksa db'den çek ve cache'e at tekniðidir */
            if (!_cache.TryGetValue("products",out IEnumerable<Product> products))
            {
                products = productService.GetProducts(category);

                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    Priority = CacheItemPriority.Normal
                };

                _cache.Set("products", products, cacheOptions);
            }

           
            //var products = productService.GetProducts(category);

            var totalProducts = products.Count();
            var pageSize = 4;

            //var products = productService.GetProductsWithPagination(page, pageSize);
            //var totalPage = (int)Math.Ceiling((decimal)totalProducts / pageSize);

            var pagingInfo = new PagingInfo { CurrentPage=page, PageSize = pageSize, TotalProducts=products.Count() };

            //ViewBag.TotalPages = totalPage;         
            //ViewBag.CurrentPage = page;


            var startIndex = (page -1 ) * pageSize;
            var endIndex = startIndex + pageSize;
            var paginatedProducts = products.Take(startIndex..endIndex);

            var viewModel = new HomeIndexViewModel { PagingInfo = pagingInfo, Products = paginatedProducts };

            return View(viewModel);
        }

        [ResponseCache(CacheProfileName ="Default45")]
        public IActionResult Privacy(string il_plaka_kodu)
        {
            ViewBag.Now = DateTime.Now.ToString();
            return View();
        }
        //Asla Error http isteðinin yanýtýný cache'e alma:
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
