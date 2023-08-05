using GymHubAPI.Entities;

namespace GymHubAPI.Services
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetAllCategories();
    }

    public class CategoryService : ICategoryService
    {
        private readonly GymHubDbContext _dbContext;

        public CategoryService(GymHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _dbContext.Categories.ToList();
        }
    }
}
