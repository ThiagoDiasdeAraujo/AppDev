using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;
using RecipeApi.Entities;
using RecipeApi.Repositories.Base;

namespace RecipeApi.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }

        public Category GetCategoryDetails(int id)
        {
            return _context.Categories.Include(x => x.Recipes).SingleOrDefault(x => x.Id == id);
        }
    }
}
