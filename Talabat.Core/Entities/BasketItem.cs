namespace Talabat.Core.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public  decimal Price { get; set; } // Not the price of product but this price in basket [after Quantity or discount]
        public string Category { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
    }
}