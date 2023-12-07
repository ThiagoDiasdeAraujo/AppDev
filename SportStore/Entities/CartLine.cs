namespace SportStore.Entities
{
    public class CartLine : BaseEntity
    {
        public int ProductID { get; set; } 
        public int Quantity { get; set; }
    }
}
