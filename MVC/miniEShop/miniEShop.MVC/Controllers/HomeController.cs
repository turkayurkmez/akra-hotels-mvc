using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using miniEShop.Application.Services;
using miniEShop.MVC.Models;
using miniEShop.Entities;

namespace miniEShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        public IActionResult Index(int page=1, int? category=null)
        {



            //toplam sayfa: ürün toplamý / bir sayfada gösterilecek ürün sayýsý..

           //   var productService = new ProductService();// Yüksek baðýmlýlýk oluþur.
            var products = productService.GetProducts(category);

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
