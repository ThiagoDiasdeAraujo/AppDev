namespace RecipeApi.Models
{
    public class RecipeSearchOptions
    {
        public string? SearchTerm { get; set; }  //recipe name
        public List<int>? Categories { get; set; }
        public int? Difficulty { get; set; }
        public int? Time { get; set; }
    }
}
