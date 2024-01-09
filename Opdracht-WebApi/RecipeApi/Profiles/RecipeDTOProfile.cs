using AutoMapper;
using RecipeApi.DTO.Recipe;
using RecipeApi.Entities;

namespace RecipeApi.Profiles
{
    public class RecipeDTOProfile : Profile
    {
        public RecipeDTOProfile()
        {
            CreateMap<Recipe, RecipeDTO>()
               .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Recipe, ReadRecipeDTO>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateRecipeDTO, Recipe>();

            CreateMap<UpdateRecipeDTO, Recipe>();
        }
    }
}

