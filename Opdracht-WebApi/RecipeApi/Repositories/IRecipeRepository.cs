using RecipeApi.Entities;
using RecipeApi.Models;
using RecipeApi.Repositories.Base;

namespace RecipeApi.Repositories
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetRecipes();

        Task<Recipe> GetRecipeDetails(int id);

        Task<Recipe> GetRecipeById(int id);

        Task<Recipe> AddRecipe(Recipe recipe);

        Task<bool> SaveRecipeChanges();

        Task<bool> DeleteRecipe(int id);

        Task UpdateRecipe(Recipe recipe);
       
        Task<IEnumerable<Recipe>> GetRecipeSearch(RecipeSearchOptions options);
    }
}
