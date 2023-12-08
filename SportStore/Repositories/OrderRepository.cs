using Microsoft.EntityFrameworkCore;
using SportStore.Data;
using SportStore.Entities;

namespace SportStore.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<OrderItem> GetOrderItemWithOrder(string customerId)
        {
            return _context.OrderItems
                              .Include(x => x.Order)
                              .Where(x => x.Order.CustomerID == customerId)
                              .ToList();
        }
    }
}
