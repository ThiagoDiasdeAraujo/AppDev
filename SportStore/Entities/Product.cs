using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SportStore.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        [Precision(14, 2)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
