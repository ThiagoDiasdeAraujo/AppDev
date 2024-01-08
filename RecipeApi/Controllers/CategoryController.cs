using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.DTO.Category;
using RecipeApi.DTO.Recipe;
using RecipeApi.Services;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Policy = "AdminOnly")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        [HttpGet("")]
        public ActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            ReadCategoryDTO category = _categoryService.Read(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost("")]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(CreateCategoryDTO dto)
        {
            CategoryDTO created = _categoryService.Create(dto);

            return CreatedAtAction(nameof(GetById), 
                new { id = created.Id }, created);
        }
    }
}
