using AutoMapper;
using RecipeApi.DTO.Category;
using RecipeApi.DTO.Recipe;
using RecipeApi.Entities;

namespace RecipeApi.Profiles
{
    public class CategoryDTOProfile : Profile
    {
        public CategoryDTOProfile()
        {
            CreateMap<Category, CategoryDTO>();

            CreateMap<Category, ReadCategoryDTO>();

            CreateMap<CreateCategoryDTO, Category>();
        }
    }
}
