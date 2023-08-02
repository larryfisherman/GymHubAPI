using AutoMapper;
using GymHubAPI.Entities;
using GymHubAPI.Exceptions;
using GymHubAPI.Models;

namespace GymHubAPI.Services
{

    public interface IIngredientService
    {
        public IEnumerable<Ingredient> GetAllIngredients();
        public void Create(Ingredient dto);
        public void Delete(int id);
        public Ingredient GetIngredientById(int id);

    }
        public class IngredientService : IIngredientService
        {
            private readonly GymHubDbContext _dbContext;
            private readonly IMapper _mapper;

            public IngredientService(GymHubDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public IEnumerable<Ingredient> GetAllIngredients()
            {
                return _dbContext.Ingredients.ToList();
            }

            public void Create(Ingredient dto)
            {
                _dbContext.Ingredients.Add(dto);
                _dbContext.SaveChanges();
            }

            public void Delete(int id)
            {
                var ingredient = _dbContext.Ingredients.FirstOrDefault(i => i.IngredientId == id);

                if (ingredient is null) throw new NotFoundException("Ingredient not found");

                _dbContext.Ingredients.Remove(ingredient);
                _dbContext.SaveChanges();
            }

            public Ingredient GetIngredientById(int id)
            {
                var ingredient = _dbContext
                  .Ingredients
                  .FirstOrDefault(i => i.IngredientId == id);


                if (ingredient is null) throw new NotFoundException("Ingredient not found");

                return ingredient;
            }

    }
}
