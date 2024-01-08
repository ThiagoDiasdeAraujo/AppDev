using RecipeApi.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApi.Entities
{
    [Table("Recipes")]
    public class Recipe : BaseEntity
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        public int Time { get; set; }

        [Required]
        public Difficulty Difficulty { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
    }

    public enum Difficulty
    {
        Easy, Intermediate, Advanced
    }
}
