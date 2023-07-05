using GymHubAPI.Entities;
using GymHubAPI.Models;
using GymHubAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymHubAPI.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly GymHubDbContext _dbContext;

        public RecipeController(IRecipeService recipeService, GymHubDbContext dbContext)
        {
            _recipeService = recipeService;
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RecipeDto>> GetAllRecipes()
        {
            var recipes = _recipeService.GetAllRecipes();

            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public ActionResult<RecipeDto> GetRecipeById([FromRoute] int id)
        {
            RecipeDto recipe = _recipeService.GetRecipeById(id);
            return Ok(recipe);
        }

        [HttpPost]
        public ActionResult CreateRecipe([FromBody] RecipeDto dto)
        {
            _recipeService.Create(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _recipeService.Delete(id);
            return Ok("Recipe removed");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRecipe([FromRoute] int id, [FromBody] RecipeDto dto)
        {
             _recipeService.Update(id, dto);

             return Ok();
        }

    }
}
