using SportStore.Entities;
using SportStore.ViewModels.Order;
using SportStore.ViewModels.Product;

namespace SportStore.Services
{
    public interface IOrderService
    {
        int AddOrder(AddOrderFormViewModel model);
        List<OrderItem> GetOrderItems(string customerId);
    }
}
