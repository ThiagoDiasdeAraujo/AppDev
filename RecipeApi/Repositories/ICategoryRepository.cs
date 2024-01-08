using RecipeApi.Entities;
using RecipeApi.Repositories.Base;

namespace RecipeApi.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryDetails(int id);
    }
}
