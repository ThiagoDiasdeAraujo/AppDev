using Microsoft.EntityFrameworkCore;

namespace SportStore.Entities
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }
        [Precision(14, 2)]
        public Decimal UnitPrice { get; set; }
        public int ProductID;
        public int OrderID;
        public Order Order { get; set; }
    }
}
