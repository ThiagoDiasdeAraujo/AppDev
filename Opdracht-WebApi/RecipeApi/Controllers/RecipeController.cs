﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.DTO.Recipe;
using RecipeApi.Entities;
using RecipeApi.Models;
using RecipeApi.Services;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminOnly")]
    public class RecipeController : ControllerBase
    {
        private IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet("")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await recipeService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting all recipes");
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var result = await recipeService.GetById(id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting recipe details");
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateRecipeDTO recipe)
        {
            try
            {
                if (recipe == null) return BadRequest();
      
                RecipeDTO created = await recipeService.Create(recipe);

                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating recipe");
            }
        }

        [HttpDelete("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                bool success = await recipeService.Delete(id);

                if (success)
                {
                    return Ok(new { Message = "Deleted successfully" });
                }
                else
                {
                    return NotFound(new { Message = "No item found to delete" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting recipe");
            }
        }

        [HttpPut("{id:int}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, UpdateRecipeDTO recipe)
        {
            try
            {
                var updatedRecipe = await recipeService.Update(id, recipe);

                if (updatedRecipe != null)
                {
                    return Ok(updatedRecipe);
                }
                else
                {
                    return NotFound(new { Message = "No item found to update" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    
        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<RecipeDTO>>> Search([FromQuery] RecipeSearchOptions options)
        {
            try
            {
                var result = await recipeService.GetSearchResults(options);

                if (result.Any()) return Ok(result);

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error searching");
            }
        }
    }
}
