using RecipeApi.DTO.Category;
using RecipeApi.DTO.Ingredient;
using RecipeApi.Entities;

namespace RecipeApi.DTO.Recipe
{
    public class CreateRecipeDTO
    {
        public string Title { get; set; }

        public int Time { get; set; }

        public Difficulty Difficulty { get; set; }

        public int CategoryId { get; set; }
    }
}
