namespace SportStore.Models
{
    public class CartDetailsModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int? Quantity { get; set; }

        public decimal SubTotal { get; set; }
    }
}
