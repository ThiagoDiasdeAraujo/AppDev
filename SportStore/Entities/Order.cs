namespace SportStore.Entities
{
    public class Order : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int Zip { get; set; }
        public string City { get; set; }
        public DateTime OrderDate { get; set; }
        public string  CustomerID { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
