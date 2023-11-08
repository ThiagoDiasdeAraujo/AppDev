using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SportStore.Models.ManageProducts
{
	public class ProductDetailsViewModel
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

		public string CategoryName { get; set; }

		public string ImageUrl { set; get; }
	}
}
