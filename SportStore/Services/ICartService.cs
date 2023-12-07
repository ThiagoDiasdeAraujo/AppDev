using SportStore.Entities;
using SportStore.Models;
using SportStore.ViewModels.Cart;

namespace SportStore.Services
{
    public interface ICartService
    {
        void AddCartLineToCart(int productID, int quantity);
        CartDetailViewModel GetCartDetails();
    }
}
