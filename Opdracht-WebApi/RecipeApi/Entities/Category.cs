using RecipeApi.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApi.Entities
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Recipe>? Recipes { get; set; }
    }
}
