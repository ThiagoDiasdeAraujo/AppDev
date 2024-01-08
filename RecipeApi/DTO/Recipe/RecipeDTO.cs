using RecipeApi.Entities;

namespace RecipeApi.DTO.Recipe
{
    public class RecipeDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Time { get; set; }

        public string Category { get; set; } //category name

        public Difficulty Difficulty { get; set; }

    }
}
