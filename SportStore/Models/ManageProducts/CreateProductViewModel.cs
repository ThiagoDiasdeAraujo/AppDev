using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportStore.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace SportStore.Models.ManageProducts
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(250)]
        public string Description { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        //Dropdown
        [Required]
        [Display(Name = "Sport Categories")]
        public int CategoryId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> AllCategories { get; set; }

        [Display(Name = "Image")]
        public IFormFile ProductImage { set; get; }
        //public string ImageUrl { get; set; }
    }
}
