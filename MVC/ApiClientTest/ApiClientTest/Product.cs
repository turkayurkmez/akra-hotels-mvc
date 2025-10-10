using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientTest
{
    internal class Product_test
    {
    }



    public class ProductResult
    {
        public IEnumerable<Product> Products { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string imageUrl { get; set; }
        public int categoryId { get; set; }
        public object category { get; set; }
    }



}
