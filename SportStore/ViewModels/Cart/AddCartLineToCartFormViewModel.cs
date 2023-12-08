using System.ComponentModel.DataAnnotations;

namespace SportStore.ViewModels.Cart
{
    public class AddCartLineToCartFormViewModel
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Quantity has to be greater dan 0")]
        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}
