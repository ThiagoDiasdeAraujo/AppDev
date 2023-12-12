using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportStore.Entities;
using System.ComponentModel.DataAnnotations;

namespace SportStore.ViewModels.Order
{
    public class AddOrderFormViewModel
    {
        public string? CustomerID { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required(ErrorMessage = "Number is required")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Zip is required")]
        public int Zip { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [ValidateNever]
        public IEnumerable<OrderItem> OrderItems { get; set; }       
    }
}
