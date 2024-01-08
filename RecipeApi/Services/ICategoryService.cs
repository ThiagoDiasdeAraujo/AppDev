using RecipeApi.DTO.Category;
using RecipeApi.DTO.Recipe;

namespace RecipeApi.Services
{
    public interface ICategoryService
    {
       ReadCategoryDTO Read(int id);

        CategoryDTO Create(CreateCategoryDTO dto);

        IEnumerable<CategoryDTO> GetAll();
    }
}
