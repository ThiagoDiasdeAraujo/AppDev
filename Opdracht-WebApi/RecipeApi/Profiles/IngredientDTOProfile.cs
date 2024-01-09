using AutoMapper;
using RecipeApi.DTO.Ingredient;
using RecipeApi.Entities;

namespace RecipeApi.Profiles
{
    public class IngredientDTOProfile : Profile
    {
        public IngredientDTOProfile()
        {
            CreateMap<Ingredient, IngredientDTO>();
        }
    }
}
