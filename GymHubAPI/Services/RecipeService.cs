using GymHubAPI.Entities;
using GymHubAPI.Models;
using AutoMapper;
using GymHubAPI.Exceptions;

namespace GymHubAPI.Services
{
    public interface IRecipeService
    {
        IEnumerable<Recipe> GetAllRecipes();
        public void Create(RecipeDto dto);
        public void Delete(int id);
        RecipeDto GetById(int id);
    }
        
    public class RecipeService : IRecipeService
    {
        private readonly GymHubDbContext _dbContext;
        private readonly IMapper _mapper;

        public RecipeService(GymHubDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
             return _dbContext.Recipes.ToList();
        }

        public void Create(RecipeDto dto)
        {
            var recipe = _mapper.Map<Recipe>(dto);
            _dbContext.Recipes.Add(recipe);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(r => r.Id == id);

            if (recipe is null) throw new NotFoundException("Movie not found");

            _dbContext.Recipes.Remove(recipe);
            _dbContext.SaveChanges();
        }

        public RecipeDto GetById(int id)
        {
            var recipe = _dbContext
              .Recipes
              .FirstOrDefault(r => r.Id == id);

            if (recipe is null) throw new NotFoundException("Recipe not found");

            var result = _mapper.Map<RecipeDto>(recipe);

            return result;
        }
    }
}
