using Microsoft.EntityFrameworkCore;
using RecipeApi.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApi.Entities
{
    [Table("Ingredients")]
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public string? Unit { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
