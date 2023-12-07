namespace SportStore.Entities
{
    public class Cart : BaseEntity
    {
        public ICollection<CartLine> CartLines { get; set; }
    }
}
