using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using miniEShop.Application.DataTransferObjects;
using miniEShop.Application.Services;

namespace miniEShop.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        //REST: REpresentational State Transfer
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetProducts() 
        {
            var products = productService.GetProductsWithPagination(1, 5);

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetProduct(int id)
        {
            var product = productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("[action]/{name}")]
        public IActionResult Search(string name)
        {

            //HttpClient client = new HttpClient();
            //client.GetAsync()
            return Ok(name);
            
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateNewProductRequest request)
        {
            if (ModelState.IsValid)
            {
                productService.CreateProduct(request);
                return CreatedAtAction(nameof(GetProduct), routeValues: new { id = 25 }, request);
            }
            
            return BadRequest(ModelState);

            //HTTPPUT - HttpDelete - HttpPatch 

        }
    }
}
