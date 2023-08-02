using GymHubAPI.Entities;
using System.Text.Json.Serialization;

namespace GymHubAPI.Models
{
    public class RecipeIngredientsDto
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
    }
}
