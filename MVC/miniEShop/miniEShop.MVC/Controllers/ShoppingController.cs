using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using miniEShop.Application.Services;
using miniEShop.MVC.Extensions;
using miniEShop.MVC.Models;
using System.Text.Json;

namespace miniEShop.MVC.Controllers
{
    [Authorize(Policy = "Client")]
    public class ShoppingController : Controller
    {

        private readonly IProductService productService;

        public ShoppingController(IProductService productService)
        {
            this.productService = productService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var collection = getCollectionFromSession();
            return View(collection);
        }

        public IActionResult AddToCard(int id)
        {
            var product = productService.GetProduct(id);

            BasketCollection basketCollection = getCollectionFromSession();
            basketCollection.AddToBasket(new BasketItem { Product = product, Quantity = 1 });
            saveToSession(basketCollection);


            return Json(new { message = $"{id} id'li ürün bilgisi sunucuya ulaştı" });
        }

  
        private BasketCollection getCollectionFromSession()
        {
            /*
             * Eğer daha önce koleksion oluşturulmuş ve session'a aktarılmış ise oradan okuyup döndür.
             * İlk kez sepete ürün ekleniyorsa yeni instance al.
             */
            //var basketJSON = HttpContext.Session.GetString("basket");
            //if (!string.IsNullOrEmpty(basketJSON))
            //{
            //    return JsonSerializer.Deserialize<BasketCollection>(basketJSON);
            //}

            //return new BasketCollection();


            //daha TEMİZ bir biçimde Session ile çalışabilmek için iki adet extension metod yazdık.
            return HttpContext.Session.GetJson<BasketCollection>("basket") ?? new BasketCollection();

        }

        private void saveToSession(BasketCollection basketCollection)
        {
            //var serilizedBasket = JsonSerializer.Serialize(basketCollection);
            // HttpContext.Session.SetString("basket", serilizedBasket);

            HttpContext.Session.SetJson("basket", basketCollection);
            
        }

    }
}
