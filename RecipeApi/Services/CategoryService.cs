using AutoMapper;
using RecipeApi.DTO.Category;
using RecipeApi.Entities;
using RecipeApi.Repositories.Base;

namespace RecipeApi.Services
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> _categoryRepo;
        private IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepo, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;

        }

        public ReadCategoryDTO Read(int id)
        {
            Category category = _categoryRepo.GetById(id);

            if (category == null)
            {
                return null;
            }
            return _mapper.Map<ReadCategoryDTO>(category);
        }

        public CategoryDTO Create(CreateCategoryDTO dto)
        {
            Category category = _mapper.Map<Category>(dto);

            _categoryRepo.Add(category);
            _categoryRepo.SaveChanges();

            return _mapper.Map<CategoryDTO>(category);
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return _categoryRepo.GetAll().Select(_mapper.Map<CategoryDTO>);
        }
    }
}
