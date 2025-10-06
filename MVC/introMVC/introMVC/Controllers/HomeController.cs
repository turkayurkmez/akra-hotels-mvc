using introMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace introMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //HTML - CSS - JS
            //JSON
            //File
            //404

            ViewBag.Isim = "Türkay";
            ViewBag.ZiyaretTarihi = DateTime.Now.ToString();
            ViewBag.Saat = DateTime.Now.Hour;


            var products = new List<Product>
            {
                new Product{ Id=1, Name="Asus Zenbook"},
                new Product{ Id=2, Name="Lenovo"},
                new Product{ Id=1, Name="Monster"}
            };


            return View(products);
        }
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateContact(Contact contact)
        {

            // var name = formCollection["Name"];
            // var email = formCollection["Email"];

            // var contact = new Contact { Email = email, Name = name };
            if (ModelState.IsValid)
            {
                return View("Thanks", contact);
            }
            return View();
           

        }
    }
}
