using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;
using RecipeApi.DTO.Recipe;
using RecipeApi.Entities;
using RecipeApi.Models;
using RecipeApi.Repositories.Base;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RecipeApi.Repositories
{
    public class RecipeRepository : IRecipeRepository /*Repository<Recipe>,*/
    {
        private readonly ApplicationDbContext context;

        public RecipeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Recipe> GetRecipeDetails(int id)
        {
            try
            {
                return await context.Recipes
                  .Include(x => x.Ingredients)
                  .Include(x => x.Category)
                  .SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting recipe details. ", ex);
            }
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            try
            {
                return await context.Recipes
               .Include(x => x.Category)
               .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting recipes. ", ex);
            }
        }

        public async Task<Recipe> GetRecipeById(int id)
        {
            try
            {
                return await context.Recipes
                    .FirstOrDefaultAsync(r => r.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting recipe by id. ", ex);
            }
        }

        public async Task<Recipe> AddRecipe(Recipe recipe)
        {
            var result = await context.Recipes.AddAsync(recipe);

            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> SaveRecipeChanges()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRecipe(int id)
        {
            var result = await context.Recipes
                .FirstOrDefaultAsync(r => r.Id == id);

            if (result != null)
            {
                context.Recipes.Remove(result);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipeSearch(RecipeSearchOptions options)
        {
            try
            {
                IQueryable<Recipe> query = context.Recipes;

                if (!string.IsNullOrWhiteSpace(options.SearchTerm))
                {
                    query = query.Where(x => x.Title.ToLower().Contains(options.SearchTerm.Trim().ToLower()));
                }

                if (options?.Categories?.Any() == true)
                {
                    query = query.Where(x => options.Categories.Contains(x.CategoryId));
                }

                if (options?.Difficulty.HasValue == true)
                {
                    query = query.Where(x => (int)x.Difficulty <= options.Difficulty);
                }

                if (options?.Time.HasValue == true)
                {
                    query = query.Where(x => x.Time <= options.Time);
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching for recipe. ", ex);
            }
        }
    }
}
