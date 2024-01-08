using RecipeApi.Entities;
using RecipeApi.Models;
using RecipeApi.Repositories.Base;

namespace RecipeApi.Repositories
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<IEnumerable<Recipe>> GetRecipes();

        Task<Recipe> GetRecipeDetails(int id);

        Task<Recipe> GetRecipeById(int id);

        Task<Recipe> AddRecipe(Recipe recipe);

        Task<bool> SaveRecipeChanges();

        Task<bool> DeleteRecipe(int id);

        Task<IEnumerable<Recipe>> GetRecipeSearch(RecipeSearchOptions options);
    }
}
