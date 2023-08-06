using System.Text.Json.Serialization;

namespace GymHubAPI.Entities
{
    public class RecipeCategories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int RecipeId { get; set; }

        [JsonIgnore]
        public Recipe? Recipe { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
    }
}
