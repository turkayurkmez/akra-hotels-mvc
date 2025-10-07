namespace miniEShop.MVC.Models
{
    public class PagingInfo
    {
        public int TotalPages { get => (int)Math.Ceiling((decimal)TotalProducts / PageSize); }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalProducts { get; set; }
    }
}
