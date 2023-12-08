using SportStore.ViewModels.Cart;

namespace SportStore.Services
{
    public interface ICartService
    {
        void AddCartLineToCart(int productID, int quantity);
        void RemoveCartLineFromCart(int productID);
        void ClearCart();
        CartDetailViewModel GetCartDetails();
    }
}
