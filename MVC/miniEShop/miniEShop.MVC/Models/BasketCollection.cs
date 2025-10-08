using miniEShop.Entities;

namespace miniEShop.MVC.Models
{
    public class BasketItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
    public class BasketCollection
    {
        //private field'lar maalesef serialize edilemez.
       // private List<BasketItem> basketItems = new List<BasketItem>();

        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
        public void AddToBasket(BasketItem item)
        {
            var existingItem = BasketItems.Find(bi => bi.Product.Id == item.Product.Id);
            if (existingItem != null) 
            {
                existingItem.Quantity += item.Quantity;            
            }
            else
            {
                BasketItems.Add(item);

            }
        }


        public void Clear()=> BasketItems.Clear();
        public decimal TotalPrice() => BasketItems.Sum(bi => bi.Quantity * bi.Product.Price);



    }
}
