using GymHubAPI.Entities;
using System.Text.Json.Serialization;

namespace GymHubAPI.Models
{
    public class RecipeIngredientsDto
    {
        [JsonPropertyName("id")]
        public int RecipeId { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
    }
}
