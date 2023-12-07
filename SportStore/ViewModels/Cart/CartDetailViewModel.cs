using SportStore.Models;

namespace SportStore.ViewModels.Cart
{
    public class CartDetailViewModel
    {
        public IEnumerable<CartDetailsModel> CartItems { get; set; }

        public decimal Total { get; set; }    
    }
}
