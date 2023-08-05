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
        public object GetRecipeById(int id);
        public void Update(int id, RecipeDto dto);
        //public IEnumerable<RecipeCategories> GetAllCategories();

    }

    public class RecipeService : IRecipeService
    {
        private readonly GymHubDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;



        public RecipeService(GymHubDbContext dbContext, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        //public IEnumerable<RecipeCategories> GetAllCategories()
        //{
        //    return _dbContext.RecipeCategories.ToList();
        //}

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
            var recipe = _dbContext.Recipes.FirstOrDefault(r => r.RecipeId == id);

            if (recipe is null) throw new NotFoundException("Recipe not found");

            _dbContext.Recipes.Remove(recipe);
            _dbContext.SaveChanges();
        }

        public object GetRecipeById(int id)
        {
            var recipe = _dbContext
              .Recipes.Include(s => s.RecipeSteps).Include(i => i.RecipeIngredients)
              .FirstOrDefault(r => r.RecipeId == id);

            var recipeIngredients = GetIngredientsByRecipeId(id);

            if (recipe is null) throw new NotFoundException("Recipe not found");

            var result = _mapper.Map<RecipeDto>(recipe);

            return new {
                recipe = recipe,
                recipeIngredients = recipeIngredients
            };
        }

        public void Update(int id, RecipeDto dto)
        {
            var recipe = _dbContext
                .Recipes
                .FirstOrDefault(r => r.RecipeId == id);

            if (recipe is null) throw new NotFoundException("Recipe not found");

            recipe.Title = dto.Title;
            recipe.Description = dto.Description;
            recipe.Protein = dto.Protein;
            recipe.Fat = dto.Fat;
            recipe.Carbo = dto.Carbo;
            recipe.Kcal = dto.Kcal;
            recipe.TimeToBeDone = dto.TimeToBeDone;
            recipe.Category = dto.Category;
            recipe.RecipeSteps = dto.RecipeSteps;

            AddIngrediensToRecipe(id, dto.RecipeIngredients);

            _dbContext.SaveChanges();
        }

        private void AddIngrediensToRecipe(int recipeId, List<RecipeIngredientsDto> ingrediens)
        {
            var recipe = _dbContext.Recipes.Find(recipeId);

            if (recipe is null) throw new NotFoundException("Workout not found");

            var existingRecipes = _dbContext.RecipeIngredients
                .Where(re => re.RecipeId == recipeId)
                .ToList();

            if (existingRecipes.Count > 0) RemoveIngredientsConnectedToRecipe(recipeId, ingrediens);

            foreach (var ingredient in ingrediens)
            {
                var existingRecipe = existingRecipes.FirstOrDefault(ri => ri.Id == ingredient.Id);

                if (existingRecipe == null)
                {
                    var recipeIngredients = new RecipeIngredients
                    {
                        RecipeId = recipeId,
                        IngredientId = ingredient.IngredientId,
                        Amount = ingredient.Amount,
                        Name = ingredient.Name,
                    };

                    _dbContext.RecipeIngredients.Add(recipeIngredients);
                }
                else
                {
                    existingRecipe.Name = ingredient.Name;
                    existingRecipe.Amount = ingredient.Amount;
                }
            }

            _dbContext.SaveChanges();
        }

        private void RemoveIngredientsConnectedToRecipe(int recipeId, List<RecipeIngredientsDto> ingredients)
        {
            var receivedIngredientsIds = ingredients.Select(e => e.RecipeId).ToList();
            var recipe = _dbContext.Recipes.Find(recipeId);


            if (receivedIngredientsIds == null || receivedIngredientsIds.Count == 0)
            {
                var recipeIngredientsToRemove = _dbContext.RecipeIngredients
                    .Where(ri => ri.RecipeId == recipeId)
                    .ToList();

                _dbContext.RecipeIngredients.RemoveRange(recipeIngredientsToRemove);
            }
            else
            {
                var ingredientsToRemove = recipe.RecipeIngredients
                    .Where(ri => !receivedIngredientsIds.Contains(ri.RecipeId))
                    .ToList();

                _dbContext.RecipeIngredients.RemoveRange(ingredientsToRemove);
            }
        }

        private List<RecipeIngredientsDto> GetIngredientsByRecipeId(int recipeId)
        {
            var ingredientIds = _dbContext.RecipeIngredients
              .Where(ri => ri.RecipeId == recipeId)
              .Select(ri => ri.IngredientId) 
              .ToList();

            var ingredients = _dbContext.Ingredients
                .Where(i => ingredientIds.Contains(i.IngredientId))
                .ToList();

            var  ingredientsDto = _mapper.Map<List<RecipeIngredientsDto>>(ingredients);

            return ingredientsDto;
        }
    }
}
