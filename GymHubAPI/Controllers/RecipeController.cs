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
        private readonly IWebHostEnvironment _hostEnvironment;

        public RecipeController(IRecipeService recipeService, GymHubDbContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            _recipeService = recipeService;
            _dbContext = dbContext;
            _hostEnvironment = hostEnvironment;
        }
        //[HttpGet("categories")]
        //public ActionResult<IEnumerable<RecipeCategories>> GetAllCategories()
        //{
        //    var categories = _recipeService.GetAllCategories();
        //    return Ok(categories);
        //}

        [HttpGet]
        public ActionResult<IEnumerable<RecipeDto>> GetAllRecipes()
        {
            var recipes = _recipeService.GetAllRecipes();

            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public ActionResult<RecipeDto> GetRecipeById([FromRoute] int id)
        {
            object recipe = _recipeService.GetRecipeById(id);
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult<RecipeDto>> CreateRecipe([FromBody] RecipeDto dto)
        {
            //dto.ImageName = await SaveImage(dto.ImageFile);
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

        //[NonAction]
        //public async Task<string> SaveImage(IFormFile imageFile)
        //{
        //    string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');

        //    imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);

        //    var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);

        //    using (var fileStream = new FileStream(imagePath, FileMode.Create))
        //    {
        //        await imageFile.CopyToAsync(fileStream);
        //    }

        //    return imageName;
        //}

        [HttpPost("upload")]
        public IActionResult Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Process the uploaded file
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                // Save the file or perform any additional processing

                return Ok(new { message = "File uploaded successfully." });
            }
        }

    }
}
