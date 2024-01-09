using RecipeApi.Entities;

namespace RecipeApi.DTO.Recipe
{
    public class UpdateRecipeDTO
    {
        public string Title { get; set; }

        public int Time { get; set; }

        public Difficulty Difficulty { get; set; }

        public int CategoryId { get; set; }
    }
}
