using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using miniEShop.MVC.Models;

namespace miniEShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int page=1)
        {

            var products = new List<Product>()
            {
                new Product { Id = 1, Name = "�r�n A", Description = "A��klama A", Price = 1 },
                new Product { Id = 2, Name = "�r�n B", Description = "A��klama B", Price = 1 },
                new Product { Id = 3, Name = "�r�n C", Description = "A��klama C", Price = 1 },
                new Product { Id = 4, Name = "�r�n D", Description = "A��klama D", Price = 1 },
                new Product { Id = 5, Name = "�r�n E", Description = "A��klama E", Price = 1 }

            };
            ViewBag.Id = page;
            return View(products);
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
