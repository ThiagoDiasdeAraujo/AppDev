using RecipeApi.DTO.Recipe;
using RecipeApi.Models;

namespace RecipeApi.Services
{
    public interface IRecipeService
    {
        Task<ReadRecipeDTO> GetById(int id);

        Task<RecipeDTO> Create(CreateRecipeDTO dto);

        Task<IEnumerable<RecipeDTO>> GetAll();

        Task<RecipeDTO> Update(int id, UpdateRecipeDTO dto);

        Task<bool> Delete(int id);

        Task<IEnumerable<RecipeDTO>> GetSearchResults(RecipeSearchOptions options);
    }
}
