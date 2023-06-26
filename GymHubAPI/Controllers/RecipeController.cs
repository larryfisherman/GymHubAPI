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

            public RecipeController(IRecipeService recipeService)
            {
                _recipeService = recipeService;
            }

            [HttpGet]
            public ActionResult<IEnumerable<RecipeDto>> GetAllRecipes()
            {
                var recipes = _recipeService.GetAllRecipes();

                return Ok(recipes);
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
        }
}
