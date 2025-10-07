namespace miniEShop.MVC.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }


}
