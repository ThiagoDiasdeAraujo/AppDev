using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportStore.Entities;
using System.ComponentModel.DataAnnotations;

namespace SportStore.ViewModels.Product
{
	public class ProductDetailViewModel
	{
        public int ProductID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Precision(14, 2)]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string  CategoryName { get; set; }

        public int Quantity { get; set; }
	}
}
