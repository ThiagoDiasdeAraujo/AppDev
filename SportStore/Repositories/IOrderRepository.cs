using SportStore.Entities;

namespace SportStore.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<OrderItem> GetOrderItemWithOrder(string customerId);
    }
}
