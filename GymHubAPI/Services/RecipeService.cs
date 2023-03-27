using GymHubAPI.Entities;

namespace GymHubAPI.Services
{

    public interface IRecipeService
    {

    }

    public class RecipeService : IRecipeService
    {
        private readonly GymHubDbContext _dbContext;

        public RecipeService(GymHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
             return _dbContext.Recipes.ToList();
        }
    }
}
