using GymHubAPI.Entities;
using GymHubAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymHubAPI.Controllers
{
    [Route("api/ingredients")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ingredient>> GetAllIngredients()
        {
            var ingredients = _ingredientService.GetAllIngredients();

            return Ok(ingredients);
        }

        [HttpGet("{id}")]
        public ActionResult<Ingredient> GetIngredientById([FromRoute] int id)
        {
            object ingredient = _ingredientService.GetIngredientById(id);
            return Ok(ingredient);
        }

        [HttpPost]
        public ActionResult CreateIngredient([FromBody] Ingredient dto)
        {
            _ingredientService.Create(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _ingredientService.Delete(id);
            return Ok("Ingredient removed");
        }

        //[HttpPut("{id}")]
        //public IActionResult UpdateWorkout([FromRoute] int id, [FromBody] WorkoutDto dto)
        //{
        //    _ingredientService.Update(id, dto);

        //    return Ok();
        //}
    }
}
