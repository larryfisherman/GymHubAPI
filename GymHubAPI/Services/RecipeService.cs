using GymHubAPI.Entities;

namespace GymHubAPI.Services
{
    public interface IRecipeService
    {
        IEnumerable<Recipe> GetAllRecipes();
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
