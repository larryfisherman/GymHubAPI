using GymHubAPI.Entities;
using System.Text.Json.Serialization;

namespace GymHubAPI.Models
{
    public class RecipeIngredientsDto
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public int Carbs { get; set; }
        public int Kcal { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
        public Ingredient? Ingredient { get; set; }
    }
}
