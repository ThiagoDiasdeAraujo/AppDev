using RecipeApi.DTO.Ingredient;
using RecipeApi.Entities;

namespace RecipeApi.DTO.Recipe
{
    public class ReadRecipeDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Difficulty Difficulty { get; set; }

        public int Time { get; set; }

        public string Category { get; set; } //category name

        public List<IngredientDTO> Ingredients { get; set; }
    }
}
