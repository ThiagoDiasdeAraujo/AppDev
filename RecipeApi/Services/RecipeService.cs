using AutoMapper;
using RecipeApi.DTO.Recipe;
using RecipeApi.Entities;
using RecipeApi.Models;
using RecipeApi.Repositories;

namespace RecipeApi.Services
{
    public class RecipeService : IRecipeService
    {
        private IRecipeRepository recipeRepo;
        private IMapper mapper;

        public RecipeService(IRecipeRepository recipeRepo, IMapper mapper)
        {
            this.mapper = mapper;
            this.recipeRepo = recipeRepo;
        }

        public async Task<IEnumerable<RecipeDTO>> GetAll()
        {
            try
            {
                var recipes = await recipeRepo.GetRecipes();

                return recipes.Select(mapper.Map<RecipeDTO>);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting recipes.", ex);
            }
        }

        public async Task<IEnumerable<RecipeDTO>> GetSearchResults(RecipeSearchOptions options)
        {
            try
            {
                var result = await recipeRepo.GetRecipeSearch(options);

                return result.Select(mapper.Map<RecipeDTO>);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting search results.", ex);
            }
        }

        public async Task<ReadRecipeDTO> GetById(int id)
        {
            try
            {
                Recipe recipe = await recipeRepo.GetRecipeDetails(id);

                if (recipe == null) return null;
                
                return mapper.Map<ReadRecipeDTO>(recipe);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting details.", ex);
            }
        }

        public async Task<RecipeDTO> Create(CreateRecipeDTO dto)
        {
            try
            {
                Recipe recipe = mapper.Map<Recipe>(dto);

                await recipeRepo.AddRecipe(recipe);

                RecipeDTO result = mapper.Map<RecipeDTO>(recipe);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating", ex);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var toDelete = await recipeRepo.GetRecipeById(id);

                if (toDelete != null)
                {
                    await recipeRepo.DeleteRecipe(toDelete.Id);
                    return await recipeRepo.SaveRecipeChanges();
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro deleting", ex);
            }
        }
    }
}
