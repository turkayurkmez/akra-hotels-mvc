using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using miniEShop.Application.DataTransferObjects;
using miniEShop.Application.Services;
using miniEShop.Entities;

namespace miniEShop.MVC.Controllers
{
    [Authorize(Roles ="Admin,Editor")]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var products = productService.GetProducts(null);

            return View(products);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> categories = getCategories();
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateNewProductRequest product)
        {
            if (ModelState.IsValid)
            {
                productService.CreateProduct(product);
                return RedirectToAction("Index");

            }

            ViewBag.Categories = getCategories();
            return View();  

        }

        public IActionResult Edit(int id)
        {
            var product = productService.GetProduct(id);
            ViewBag.Categories = getCategories();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = getCategories();
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = productService.GetProduct(id);
            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            if (id > 0)
            {
                productService.DeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("deleteFail", "id değeri pozitif olmalı");
            return View();
        }

        private IEnumerable<SelectListItem> getCategories()
        {
            var categories = categoryService.GetCategories();
            return categories.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
        }
    }
}
