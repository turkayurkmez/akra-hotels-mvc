using System.Diagnostics;
using IoCLifeCyclePOC.Models;
using IoCLifeCyclePOC.Services;
using Microsoft.AspNetCore.Mvc;

namespace IoCLifeCyclePOC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ISingleton singleton;
        private readonly IScoped scoped;
        private readonly ITransient transient;
        private readonly AllInOne allInOne;

        public HomeController(ILogger<HomeController> logger, IScoped scoped, ITransient transient, ISingleton singleton, AllInOne allInOne)
        {
            _logger = logger;
            this.scoped = scoped;
            this.transient = transient;
            this.singleton = singleton;
            this.allInOne = allInOne;
        }

        public IActionResult Index()
        {
            ViewBag.Singleton = singleton.Id.ToString();
            ViewBag.Scoped = scoped.Id.ToString();
            ViewBag.Transient = transient.Id.ToString();

            ViewBag.SingletonScope = allInOne.Singleton.Id.ToString();
            ViewBag.ScopedScope = allInOne.Scoped.Id.ToString();
            ViewBag.TransientScope = allInOne.Transient.Id.ToString();
            return View();
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
