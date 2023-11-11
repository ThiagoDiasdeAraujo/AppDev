using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportStore.Data.Entities;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SportStore.Models
{
    public class _000Model
    {
        //Dropdown
        [Required]
        [Display(Name = "Sport Categories")]
        public int CategoryId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> AllCategories { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
