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

            //[HttpPost]
            //public ActionResult CreateRecipe([FromBody] RecipeDto dto)
            //{
            //    var id = recipeController.Create(dto);
            //    return Created($"/api/recipe/{id}", null);
            //}

            //[HttpDelete("{id}")]
            //public ActionResult Delete([FromRoute] int id)
            //{
            //    _recipeController.Delete(id);
            //    return Ok("Recipe removed");
            //}
    }
}
