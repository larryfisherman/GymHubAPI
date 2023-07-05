using GymHubAPI.Entities;
using GymHubAPI.Models;
using AutoMapper;
using GymHubAPI.Exceptions;
using Microsoft.EntityFrameworkCore;


namespace GymHubAPI.Services
{
    public interface IRecipeService
    {
        IEnumerable<Recipe> GetAllRecipes();
        public void Create(RecipeDto dto);
        public void Delete(int id);
        public RecipeDto GetRecipeById(int id);
        public void Update(int id, RecipeDto dto);
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
             return _dbContext.Recipes.Include(s => s.Steps).Include(i => i.Ingrediens).ToList();
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

            if (recipe is null) throw new NotFoundException("Recipe not found");

            _dbContext.Recipes.Remove(recipe);
            _dbContext.SaveChanges();
        }

        public RecipeDto GetRecipeById(int id)
        {
            var recipe = _dbContext
              .Recipes.Include(s => s.Steps).Include(i => i.Ingrediens)
              .FirstOrDefault(r => r.Id == id);

            if (recipe is null) throw new NotFoundException("Recipe not found");

            var result = _mapper.Map<RecipeDto>(recipe);

            return result;
        }

        public void Update(int id, RecipeDto dto)
        {
            var recipe = _dbContext
                .Recipes
                .FirstOrDefault(r => r.Id == id);

            if (recipe is null) throw new NotFoundException("Recipe not found");

            recipe.Title = dto.Title;
            recipe.Description = dto.Description;
            recipe.Protein = dto.Protein;
            recipe.Fat = dto.Fat;
            recipe.Carbo = dto.Carbo;
            recipe.Kcal = dto.Kcal;
            recipe.TimeToBeDone = dto.TimeToBeDone;
            recipe.Category = dto.Category;
            recipe.Ingrediens = dto.Ingrediens;
            recipe.Steps = dto.Steps;


            _dbContext.SaveChanges();
        }

    }
}
